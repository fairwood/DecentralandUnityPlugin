using System;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Dcl
{
    public enum EDclNodeType
    {
        _none,
        entity,
        box,
        sphere,
        plane,
        cylinder,
        cone,
        circle,
        text,
        gltf,
        ChildOfGLTF,
        CustomNode,
    }
    public static class SceneTraverser
    {

        const string indentUnit = "  ";

        private static List<Material> primitiveMaterialsToExport;
        public static List<Texture> primitiveTexturesToExport;

        private static DclSceneMeta _sceneMeta;

        public  static readonly  Dictionary<GameObject, EDclNodeType> GameObjectToNodeTypeDict = new Dictionary<GameObject, EDclNodeType>();

        public static void TraverseAllScene(List<GameObject>  gos,StringBuilder xmlBuilder, List<GameObject> meshesToExport, SceneStatistics statistics, SceneWarningRecorder warningRecorder){

            if (xmlBuilder != null)
            {
                xmlBuilder.AppendIndent(indentUnit, 3);
                xmlBuilder.AppendFormat("<scene position={{{0}}}>\n", Vector3ToJSONString(new Vector3(5, 0, 5)));
            }

            _sceneMeta = Object.FindObjectOfType<DclSceneMeta>();
            primitiveMaterialsToExport = new List<Material>();
            primitiveTexturesToExport = new List<Texture>();
            GameObjectToNodeTypeDict.Clear();

            //====== Start Traversing ======
            foreach (var rootGO in gos)
            {
                RecursivelyTraverseTransform(rootGO.transform, xmlBuilder, meshesToExport, 4, statistics, warningRecorder, GameObjectToNodeTypeDict);
            }
            foreach (var material in primitiveMaterialsToExport)
            {
                var materialXml = xmlBuilder != null ? new StringBuilder() : null;
                TraverseMaterial(material, materialXml, warningRecorder);

                //Append materials
                if (xmlBuilder != null)
                {
                    xmlBuilder.AppendIndent(indentUnit, 4);
                    xmlBuilder.Append(materialXml).Append("\n");
                }
            }

            //Check textures
            if (warningRecorder != null)
            {
                foreach (var texture in primitiveTexturesToExport)
                {
                    CheckTextureValidity(texture, warningRecorder);
                }
            }

            statistics.materialCount += primitiveMaterialsToExport.Count; //TODO: include glTF's materials
            statistics.textureCount += primitiveTexturesToExport.Count; //TODO: include glTF's textures

            if (xmlBuilder != null)
            {
                xmlBuilder.AppendIndent(indentUnit, 3);
                xmlBuilder.Append("</scene>");
            }

        }



        public static void TraverseAllScene(StringBuilder xmlBuilder, List<GameObject> meshesToExport, SceneStatistics statistics, SceneWarningRecorder warningRecorder)
        {
            var rootGameObjects = new List<GameObject>();
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var roots = SceneManager.GetSceneAt(i).GetRootGameObjects();
                rootGameObjects.AddRange(roots);
            }

            if (xmlBuilder != null)
            {
                xmlBuilder.AppendIndent(indentUnit, 3);
                xmlBuilder.AppendFormat("<scene position={{{0}}}>\n", Vector3ToJSONString(new Vector3(5, 0, 5)));
            }

            _sceneMeta = Object.FindObjectOfType<DclSceneMeta>();
            primitiveMaterialsToExport = new List<Material>();
            primitiveTexturesToExport = new List<Texture>();
            GameObjectToNodeTypeDict.Clear();

            //====== Start Traversing ======
            foreach (var rootGO in rootGameObjects)
            {
                RecursivelyTraverseTransform(rootGO.transform, xmlBuilder, meshesToExport, 4, statistics, warningRecorder, GameObjectToNodeTypeDict);
            }
            foreach (var material in primitiveMaterialsToExport)
            {
                var materialXml = xmlBuilder != null ? new StringBuilder() : null;
                TraverseMaterial(material, materialXml, warningRecorder);
                
                //Append materials
                if (xmlBuilder != null)
                {
                    xmlBuilder.AppendIndent(indentUnit, 4);
                    xmlBuilder.Append(materialXml).Append("\n");
                }
            }

            //Check textures
            if (warningRecorder != null)
            {
                foreach (var texture in primitiveTexturesToExport)
                {
                    CheckTextureValidity(texture, warningRecorder);
                }
            }

            statistics.materialCount += primitiveMaterialsToExport.Count; //TODO: include glTF's materials
            statistics.textureCount += primitiveTexturesToExport.Count; //TODO: include glTF's textures
            
            if (xmlBuilder != null)
            {
                xmlBuilder.AppendIndent(indentUnit, 3);
                xmlBuilder.Append("</scene>");
            }
        }

        public static void RecursivelyTraverseTransform(Transform tra, StringBuilder xmlBuilder, List<GameObject> meshesToExport, int indentLevel, SceneStatistics statistics, SceneWarningRecorder warningRecorder, Dictionary<GameObject, EDclNodeType> gameObjectToNodeTypeDict)
        {
            if (!tra.gameObject.activeInHierarchy) return;

            //TODO: Hide empty

            if (statistics != null)
            {
                statistics.entityCount += 1;
            }

            string nodeName = null;
            var nodeType = EDclNodeType._none;
            var position = tra.localPosition;
            var scale = tra.localScale;
            var eulerAngles = tra.localEulerAngles;
            string pColor = null; //<...  color="#4A4A4A" ...>
            string pMaterial = null; //<... material="#mat01" ...>
            var extraProperties = new StringBuilder(); //TODO: can be omitted if xmlBuilder == null

            var dclObject = tra.GetComponent<DclObject>();
            
            if (tra.GetComponent<DclCustomNode>())
            {
                var customNode = tra.GetComponent<DclCustomNode>();
                nodeName = customNode.nodeName;
                nodeType = EDclNodeType.CustomNode;
                if (customNode.position)
                {
                    extraProperties.AppendFormat(" position={{{0}}}", Vector3ToJSONString(tra.localPosition));
                }
                if (customNode.rotation)
                {
                    extraProperties.AppendFormat(" rotation={{{0}}}", Vector3ToJSONString(tra.eulerAngles));
                }
                if (customNode.scale)
                {
                    extraProperties.AppendFormat(" scale={{{0}}}", Vector3ToJSONString(tra.localScale));
                }
                foreach (var propertyPair in customNode.propertyPairs)
                {
                    extraProperties.AppendFormat(" {0}={1}", propertyPair.name, propertyPair.value);
                }
            }
            else
            {

                if (tra.GetComponent<MeshFilter>() && tra.GetComponent<MeshRenderer>()) //Primitives & glTF
                {
                    var meshFilter = tra.GetComponent<MeshFilter>();
                    if (meshFilter.sharedMesh == DclPrimitiveHelper.GetDclPrimitiveMesh(DclPrimitiveType.box))
                    {
                        nodeName = "box";
                        nodeType = EDclNodeType.box;
                    }
                    else if (meshFilter.sharedMesh == DclPrimitiveHelper.GetDclPrimitiveMesh(DclPrimitiveType.sphere))
                    {
                        nodeName = "sphere";
                        nodeType = EDclNodeType.sphere;
                    }
                    else if (meshFilter.sharedMesh == DclPrimitiveHelper.GetDclPrimitiveMesh(DclPrimitiveType.plane))
                    {
                        nodeName = "plane";
                        nodeType = EDclNodeType.plane;
                    }
                    else if (meshFilter.sharedMesh == DclPrimitiveHelper.GetDclPrimitiveMesh(DclPrimitiveType.cylinder))
                    {
                        nodeName = "cylinder";
                        nodeType = EDclNodeType.cylinder;
                    }
                    else if (meshFilter.sharedMesh == DclPrimitiveHelper.GetDclPrimitiveMesh(DclPrimitiveType.cone))
                    {
                        nodeName = "cone";
                        nodeType = EDclNodeType.cone;
                    }

                    if (nodeName != null)
                    {
                        //Primitive

                        //read color/mat
                        var rdrr = tra.GetComponent<MeshRenderer>();
                        if (rdrr && rdrr.sharedMaterial)
                        {
                            var material = rdrr.sharedMaterial;
                            if (material == PrimitiveHelper.GetDefaultMaterial())
                            {
                                //not use material
                                //                                var matColor = rdrr.sharedMaterial.color;
                                //                                pColor = ToHexString(matColor);
                            }
                            else
                            {
                                //need to export this material
                                if (!primitiveMaterialsToExport.Exists(m => m == material))
                                {
                                    primitiveMaterialsToExport.Add(material);
                                }

                                pMaterial = string.Format("#{0}", material.name);
                            }

                        }

                        //withCollisions
                        if (dclObject)
                        {
                            if (DclPrimitiveHelper.ShouldGameObjectExportAsAPrimitive(tra.gameObject))
                            {
                                if (dclObject.withCollision == true) extraProperties.Append(" withCollisions={true}");
                            }
                        }

                        //Statistics
                        if (statistics != null)
                        {
                            statistics.triangleCount += meshFilter.sharedMesh.triangles.LongLength / 3;
                        }
                    }
                    else
                    {
                        //GLTF

                        //export as a glTF model
                        if (meshesToExport != null)
                        {
                            meshesToExport.Add(tra.gameObject);
                        }

                        nodeName = "gltf-model";
                        nodeType = EDclNodeType.gltf;
                        // TODO: delete postion info (by alking)
                        // position = Vector3.zero;
                        // eulerAngles = Vector3.zero;
                        // scale = Vector3.zero;
                        extraProperties.AppendFormat(" src=\"./unity_assets/{0}.gltf\"", tra.name);

                        //Statistics
                        if (statistics != null)
                        {
                            statistics.triangleCount += meshFilter.sharedMesh.triangles.LongLength / 3;
                            statistics.bodyCount += 1;
                        }
                    }
                }
                else if (tra.GetComponent<TextMesh>() && tra.GetComponent<MeshRenderer>()) //TextMesh
                {

                    nodeName = "text";
                    nodeType = EDclNodeType.text;
                    var tm = tra.GetComponent<TextMesh>();
                    extraProperties.AppendFormat(" value=\"{0}\"", tm.text);
                    scale *= tm.fontSize * 0.5f;
                    //extraProperties.AppendFormat(" fontS=\"{0}\"", 100);
                    pColor = ToHexString(tm.color);
                    var rdrr = tra.GetComponent<MeshRenderer>();
                    if (rdrr)
                    {
                        var width = rdrr.bounds.extents.x;
                        var height = rdrr.bounds.extents.y * 1;
                        extraProperties.AppendFormat(" width={{{0}}}", width);
                        extraProperties.AppendFormat(" height={{{0}}}", height);
                    }
                }

                if (tra.GetComponent<MeshRenderer>())
                {
                    var meshRenderer = tra.GetComponent<MeshRenderer>();

                    //Statistics
                    if (statistics != null)
                    {
                        var curHeight = meshRenderer.bounds.max.y;
                        if (curHeight > statistics.maxHeight) statistics.maxHeight = curHeight;
                    }

                    //Warnings
                    if (warningRecorder != null)
                    {
                        //OutOfLand
                        if (_sceneMeta)
                        {
                            var isOutOfLand = false;
                            var startParcel = SceneUtil.GetParcelCoordinates(meshRenderer.bounds.min);
                            var endParcel = SceneUtil.GetParcelCoordinates(meshRenderer.bounds.max);
                            for (int x = startParcel.x; x <= endParcel.x; x++)
                            {
                                for (int y = startParcel.y; y <= endParcel.y; y++)
                                {
                                    if (!_sceneMeta.parcels.Exists(parcel => parcel == new ParcelCoordinates(x, y)))
                                    {
                                        warningRecorder.OutOfLandWarnings.Add(
                                            new SceneWarningRecorder.OutOfLand(meshRenderer));
                                        isOutOfLand = true;
                                        break;
                                    }
                                }

                                if (isOutOfLand) break;
                            }
                        }
                    }
                }

                if (nodeName == null)
                {
                    nodeName = "entity";
                    nodeType = EDclNodeType.entity;
                }

                if (pColor != null)
                {
                    extraProperties.AppendFormat(" color=\"{0}\"", pColor);
                }

                if (pMaterial != null)
                {
                    extraProperties.AppendFormat(" material=\"{0}\"", pMaterial);
                }

                if (dclObject)
                {
                    if (dclObject.visible != true) extraProperties.Append(" visible={false}");
                }
            }

            StringBuilder xmlNode = null;
            StringBuilder xmlNodeTail = null;
            StringBuilder childrenXmlBuilder = null;
            if (xmlBuilder != null)
            {
                xmlNode = new StringBuilder();
                xmlNode.AppendIndent(indentUnit, indentLevel);
                if (nodeType == EDclNodeType.CustomNode)
                {
                    xmlNode.AppendFormat("<{0}{1}>", nodeName, extraProperties);
                }
                else
                {
                    xmlNode.AppendFormat("<{0} position={{{1}}} scale={{{2}}} rotation={{{3}}}{4}>", nodeName,
                        Vector3ToJSONString(position), Vector3ToJSONString(scale), Vector3ToJSONString(eulerAngles),
                        extraProperties);
                }

                xmlNodeTail = new StringBuilder().AppendFormat("</{0}>\n", nodeName);
                childrenXmlBuilder = new StringBuilder();
            }

            if (gameObjectToNodeTypeDict != null) gameObjectToNodeTypeDict.Add(tra.gameObject, nodeType);

            if (nodeType != EDclNodeType.gltf) //gltf node will force to pack all its children, so should not traverse into it again.
            {
                foreach (Transform child in tra)
                {
                    RecursivelyTraverseTransform(child, childrenXmlBuilder, meshesToExport, indentLevel + 1, statistics,
                        warningRecorder, gameObjectToNodeTypeDict);
                }
            }

            if (xmlBuilder != null)
            {
                if (childrenXmlBuilder.Length > 0)
                {
                    xmlNode.Append("\n");
                    xmlNode.Append(childrenXmlBuilder);
                    xmlNode.AppendIndent(indentUnit, indentLevel);
                }
                xmlNode.Append(xmlNodeTail);
                xmlBuilder.Append(xmlNode);
            }
        }


        #region Utils


        public static void ParseTextToCoordinates(string text, List<ParcelCoordinates> coordinates)
        {
            coordinates.Clear();
            var lines = text.Replace("\r", "").Split('\n');
            foreach (var line in lines)
            {
                var elements = line.Trim().Split(',');
                if (elements.Length == 0) continue;
                if (elements.Length != 2)
                {
                    throw new Exception("A line does not have exactly 2 elements!");
                }

                var x = int.Parse(elements[0]);
                var y = int.Parse(elements[1]);
                coordinates.Add(new ParcelCoordinates(x, y));
            }
        }

        public static StringBuilder ParcelToStringBuilder(ParcelCoordinates parcel)
        {
            return new StringBuilder().Append(parcel.x).Append(',').Append(parcel.y);
        }

        public static StringBuilder WarningToStringBuilder(string warning)
        {
            return new StringBuilder().Append(warning);
        }

        public static string Vector3ToJSONString(Vector3 v)
        {
            return string.Format("{{x:{0},y:{1},z:{2}}}", v.x, v.y, v.z);
        }

        /// <summary>
        /// Color to HEX string(e.g. #AAAAAA)
        /// </summary>
        private static string ToHexString(Color color)
        {
            var color256 = (Color32)color;
            string R = Convert.ToString(color256.r, 16);
            if (R == "0")
                R = "00";
            string G = Convert.ToString(color256.g, 16);
            if (G == "0")
                G = "00";
            string B = Convert.ToString(color256.b, 16);
            if (B == "0")
                B = "00";
            string HexColor = "#" + R + G + B;
            return HexColor.ToUpper();
        }

        public static string ParcelToString(ParcelCoordinates parcel)
        {
            return string.Format("\"{0},{1}\"", parcel.x, parcel.y);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="material"></param>
        /// <param name="xml">Will append an xml line like <material id="mat01" emissiveColor = "#AA00FF"/></param>
        public static void TraverseMaterial(Material material, StringBuilder xml, SceneWarningRecorder warningRecorder)
        {
            //Check is it a Unity Standard Material
            if (material.shader.name != "Standard")
            {
                warningRecorder.UnsupportedShaderWarnings.Add(new SceneWarningRecorder.UnsupportedShader(material));
            }

            var albedoTex = material.GetTexture("_MainTex");
            var refractionTexture = material.GetTexture("_MetallicGlossMap");
            var bumpTexture = material.GetTexture("_BumpMap");
            var emisiveTexture = material.GetTexture("_EmissionMap");

            if (albedoTex)
            {
                primitiveTexturesToExport.Add(albedoTex);
            }
            if (refractionTexture)
            {
                primitiveTexturesToExport.Add(refractionTexture);
            }
            if (bumpTexture)
            {
                primitiveTexturesToExport.Add(bumpTexture);
            }
            if (emisiveTexture)
            {
                primitiveTexturesToExport.Add(emisiveTexture);
            }

            if (xml != null)
            {
                xml.Append("<material");
                xml.AppendFormat(" id=\"{0}\"", material.name);
                xml.AppendFormat(" albedoColor=\"{0}\"", ToHexString(material.color));
                if (albedoTex)
                {
                    xml.AppendFormat(" albedoTexture=\"{0}\"", GetTextureRelativePath(albedoTex));
                }
                if (refractionTexture)
                {
                    xml.AppendFormat(" refractionTexture=\"{0}\"", GetTextureRelativePath(refractionTexture));
                }
                if (bumpTexture)
                {
                    xml.AppendFormat(" bumpTexture=\"{0}\"", GetTextureRelativePath(bumpTexture));
                }
                if (emisiveTexture)
                {
                    xml.AppendFormat(" emisiveTexture=\"{0}\"", GetTextureRelativePath(emisiveTexture));
                }
                xml.AppendFormat(" emissiveColor=\"{0}\"", ToHexString(material.GetColor("_EmissionColor")));
                xml.AppendFormat(" metallic={{{0}}}", material.GetFloat("_Metallic"));
                xml.AppendFormat(" roughness={{{0}}}", 1 - material.GetFloat("_Glossiness"));

                xml.Append("/>");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texture"></param>
        /// <returns>false if </returns>
        static void CheckTextureValidity(Texture texture, SceneWarningRecorder warningRecorder)
        {
            if (!IsTextureSizeValid(texture.width) || !IsTextureSizeValid(texture.height))
            {
                warningRecorder.InvalidTextureWarnings.Add(new SceneWarningRecorder.InvalidTexture(texture));
            }
        }

        static bool IsTextureSizeValid(int x)
        {
            if ((x != 0) && ((x & (x - 1)) == 0))
            {
                if (1 <= x && x <= 512)
                {
                    return true;
                }
            }

            return false;
        }

        public static string GetTextureRelativePath(Texture texture)
        {
            var relPath = AssetDatabase.GetAssetPath(texture);
            if (string.IsNullOrEmpty(relPath))
            {
                //TODO: this is a built-in asset
                relPath = texture.name + ".png";
            }
            else
            {
                
            }
            return "./unity_assets/" + relPath;
        }

        #endregion
    }
}