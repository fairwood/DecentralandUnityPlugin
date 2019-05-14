﻿using System;
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

        public static List<Material> primitiveMaterialsToExport;
        public static List<Texture> primitiveTexturesToExport;

        private static DclSceneMeta _sceneMeta;

        //public  static readonly  Dictionary<GameObject, EDclNodeType> GameObjectToNodeTypeDict = new Dictionary<GameObject, EDclNodeType>();


        public static void TraverseAllScene(StringBuilder exportStr, List<GameObject> meshesToExport, SceneStatistics statistics, SceneWarningRecorder warningRecorder)
        {
            var rootGameObjects = new List<GameObject>();
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var roots = SceneManager.GetSceneAt(i).GetRootGameObjects();
                rootGameObjects.AddRange(roots);
            }

            _sceneMeta = Object.FindObjectOfType<DclSceneMeta>();
            primitiveMaterialsToExport = new List<Material>();
            primitiveTexturesToExport = new List<Texture>();
            //GameObjectToNodeTypeDict.Clear();
            
            //====== Start Traversing ======
            foreach (var rootGO in rootGameObjects)
            {
                RecursivelyTraverseTransform(rootGO.transform, exportStr, meshesToExport, 4, statistics, warningRecorder);
            }

            if (statistics != null)
            {
                statistics.textureCount = primitiveTexturesToExport.Count;
            }
        }

        public static void RecursivelyTraverseTransform(Transform tra,
            StringBuilder exportStr,
            List<GameObject> meshesToExport,
            int indentLevel,
            SceneStatistics statistics,
            SceneWarningRecorder warningRecorder)
        {
            if (!tra.gameObject.activeInHierarchy) return;
            if (tra.gameObject.GetComponent<DclSceneMeta>()) return;//skip .dcl

            var dclObject = tra.GetComponent<DclObject>() ?? tra.gameObject.AddComponent<DclObject>();
            if (dclObject.dclNodeType == EDclNodeType._none) dclObject.dclNodeType = EDclNodeType.entity;

            if (statistics != null)
            {
                statistics.entityCount += 1;
            }

            var position = tra.localPosition;
            var scale = tra.localScale;
            var rotation = tra.localRotation;

            var entityName = GetIdentityName(tra.gameObject);

            if (exportStr != null)
            {
                exportStr.AppendFormat(NewEntityWithName, entityName, tra.name);

                //set parent
                if (tra.parent)
                {
                    exportStr.AppendFormat(SetParent, entityName, GetIdentityName(tra.parent.gameObject));
                }

                //Entity
                exportStr.AppendFormat(AddEntity, entityName);
                //Transform
                exportStr.AppendFormat(SetTransform, entityName, position.x, position.y, position.z);
                exportStr.AppendFormat(SetRotation, entityName, rotation.x, rotation.y, rotation.z, rotation.w);
                exportStr.AppendFormat(SetScale, entityName, scale.x, scale.y, scale.z);

            }

            TraverseShape(tra, entityName, exportStr, meshesToExport, statistics);

            TraverseText(tra, entityName, exportStr, statistics);

            if (exportStr != null)
            {
                exportStr.Append('\n');
            }


            //        if (tra.GetComponent<DclCustomNode>())
            //        {
            //            var customNode = tra.GetComponent<DclCustomNode>();
            //            nodeName = customNode.nodeName;
            //            nodeType = EDclNodeType.CustomNode;

            //if(customNode.propertyPairs!=null){
            //	foreach (var propertyPair in customNode.propertyPairs)
            //	{
            //		extraProperties.AppendFormat(" {0}={1}", propertyPair.name, propertyPair.value);
            //	}
            //}
            //        }
            //        else
            //        {


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

            if (dclObject)
            {
                //TODO： if (dclObject.visible != true) extraProperties.Append(" visible={false}");
            }

            //GameObjectToNodeTypeDict.Add(tra.gameObject, nodeType);

            if (dclObject.dclNodeType != EDclNodeType.gltf) //gltf node will force to pack all its children, so should not traverse into it again.
            {
                foreach (Transform child in tra)
                {
                    RecursivelyTraverseTransform(child, exportStr, meshesToExport, indentLevel + 1, statistics, warningRecorder);
                }
            }
            else
            {
                foreach (Transform child in tra)
                {
                    RecursivelyTraverseUnderGLTF(child);
                }
            }
        }

        public static void RecursivelyTraverseUnderGLTF(Transform gltfNode)
        {
            var dclObject = gltfNode.GetComponent<DclObject>() ?? gltfNode.gameObject.AddComponent<DclObject>();
            dclObject.dclNodeType = EDclNodeType.ChildOfGLTF;
        }

        #region Utils

        public static string ToJsColorCtor(Color color)
        {
            return string.Format("new Color3({0}, {1}, {2})", color.r, color.g, color.b);
        }

        public static string GetIdentityName(GameObject go)
        {
            string entityName = "entity" + Mathf.Abs(go.GetInstanceID());
            entityName = entityName.Replace(" ", string.Empty);
            return entityName;
        }


        public static string GetTextureRelativePath(Texture texture)
        {
            var relPath = AssetDatabase.GetAssetPath(texture);
            if (string.IsNullOrEmpty(relPath))
            {
                //this is a built-in asset
                relPath = texture.name + ".png";
            }
            else
            {

            }

            string str = "unity_assets/" + relPath;
            return str;
        }

        private const string NewEntity = "const {0} = new Entity()\n";
        private const string NewEntityWithName = "const {0} = new Entity() //{1}\n";
        private const string AddEntity = "engine.addEntity({0})\n";
        private const string SetTransform = "{0}.addComponent(new Transform({{ position: new Vector3({1}, {2}, {3}) }}))\n";
        private const string SetRotation = "{0}.getComponent(Transform).rotation.set({1}, {2}, {3}, {4})\n";
        private const string SetScale = "{0}.getComponent(Transform).scale.set({1}, {2}, {3})\n";
        private const string SetShape = "{0}.addComponent(new {1}())\n";
        private const string SetGLTFshape = "{0}.addComponent(new GLTFShape(\"{1}\"))\n";
        private const string SetParent = "{0}.setParent({1})\n";
        private const string NewMaterial = "const {0} = new Material()\n";
        private const string SetMaterial = "{0}.addComponent({1})\n";
        private const string SetMaterialAlbedoColor = "{0}.albedoColor = {1}\n";
        private const string SetMaterialMetallic = "{0}.metallic = {1}\n";
        private const string SetMaterialRoughness = "{0}.roughness = {1}\n";
        private const string SetMaterialAlbedoTexture = "{0}.albedoTexture = new Texture(\"{1}\")\n";
        private const string SetMaterialAlbedoTextureHasAlpha = "{0}.hasAlpha = true\n";
        private const string SetMaterialAlpha = "{0}.alpha = {1}\n";
        private const string SetMaterialBumptexture = "{0}.bumpTexture = new Texture(\"{1}\")\n";
        private const string SetMaterialEmissiveColor = "{0}.emissiveColor = {1}\n";
        private const string SetMaterialRefractionTexture = "{0}.refractionTexture = new Texture(\"{1}\")\n";
        private const string SetMaterialEmissiveIntensity = "{0}.emissiveIntensity = {1}\n";
        private const string SetMaterialEmissiveTexture = "{0}.emissiveTexture = new Texture(\"{1}\")\n";

        public static void TraverseMaterial(Transform tra, string entityName, StringBuilder exportStr, SceneStatistics statistics)
        {

            var rdrr = tra.GetComponent<MeshRenderer>();
            if (rdrr && rdrr.sharedMaterial)
            {
                var material = rdrr.sharedMaterial;
                if (material != PrimitiveHelper.GetDefaultMaterial())
                {
                    string materialName = "material" + Mathf.Abs(material.GetInstanceID());
                    if (!primitiveMaterialsToExport.Contains(material))
                    {
                        primitiveMaterialsToExport.Add(material);

                        if (exportStr != null)
                        {
                            exportStr.AppendFormat(NewMaterial, materialName);
                            exportStr.AppendFormat(SetMaterialAlbedoColor, materialName, ToJsColorCtor(material.color));
                            exportStr.AppendFormat(SetMaterialMetallic, materialName, material.GetFloat("_Metallic"));
                            exportStr.AppendFormat(SetMaterialRoughness, materialName, 1 - material.GetFloat("_Glossiness"));
                        }
                        var albedoTex = material.HasProperty("_MainTex") ? material.GetTexture("_MainTex") : null;
                        if (exportStr != null && albedoTex)
                        {
                            exportStr.AppendFormat(SetMaterialAlbedoTexture, materialName, GetTextureRelativePath(albedoTex));
                        }

                        bool b = material.IsKeywordEnabled("_ALPHATEST_ON") ||
                                 material.IsKeywordEnabled("_ALPHABLEND_ON") ||
                                 material.IsKeywordEnabled("_ALPHAPREMULTIPLY_ON");
                        if (exportStr != null && b)
                        {
                            exportStr.AppendFormat(SetMaterialAlbedoTextureHasAlpha, materialName);
                            exportStr.AppendFormat(SetMaterialAlpha, materialName, material.color.a);
                        }

                        var bumpTexture = material.HasProperty("_BumpMap") ? material.GetTexture("_BumpMap") : null;
                        if (exportStr != null && bumpTexture)
                        {
                            exportStr.AppendFormat(SetMaterialBumptexture, materialName, GetTextureRelativePath(bumpTexture));
                        }

                        var refractionTexture = material.HasProperty("_MetallicGlossMap")
                            ? material.GetTexture("_MetallicGlossMap")
                            : null;
                        if (exportStr != null && refractionTexture)
                        {
                            exportStr.AppendFormat(SetMaterialRefractionTexture, materialName, GetTextureRelativePath(refractionTexture));
                        }

                        Texture emissiveTexture = null;
                        if (material.IsKeywordEnabled("_EMISSION"))
                        {
                            if (exportStr != null)
                            {
                                exportStr.AppendFormat(SetMaterialEmissiveColor, materialName, ToJsColorCtor(material.GetColor("_EmissionColor")));
                                //					        exportStr.AppendFormat(SetMaterialEmissiveIntensity, materialName, material.GetColor("_EmissionColor")); TODO:
                            }
                            emissiveTexture = material.HasProperty("_EmissionMap")
                                ? material.GetTexture("_EmissionMap")
                                : null;
                            if (exportStr != null && emissiveTexture)
                            {
                                exportStr.AppendFormat(SetMaterialEmissiveTexture, materialName, GetTextureRelativePath(emissiveTexture));
                            }
                        }

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

                        if (emissiveTexture)
                        {
                            primitiveTexturesToExport.Add(emissiveTexture);
                        }
                    }

                    if (exportStr != null)
                    {
                        exportStr.AppendFormat(SetMaterial, entityName, materialName);
                    }

                    if (statistics != null) statistics.materialCount += 1;
                }
            }
            //const myMaterial = new Material()
            //myMaterial.albedoColor = "#FF0000"
            //myMaterial.metallic = 0.9
            //myMaterial.roughness = 0.1
            //myEntity.addComponent(myMaterial)
            //myMaterial.albedoTexture = new Texture("materials/wood.png")
            //myMaterial.bumpTexture = new Texture"materials/woodBump.png")
            //myMaterial.hasAlpha = true

        }

        public static void TraverseShape(Transform tra, string entityName, StringBuilder exportStr, List<GameObject> meshesToExport, SceneStatistics statistics)
        {
            var meshFilter = tra.GetComponent<MeshFilter>();
            if (!(meshFilter && tra.GetComponent<MeshRenderer>()))
            {
                return;
            }

            var dclObject = tra.GetComponent<DclObject>();

            string shapeName = null;
            if (dclObject)
            {
                switch (dclObject.dclPrimitiveType)
                {
                    case DclPrimitiveType.box:
                        dclObject.dclNodeType = EDclNodeType.box;
                        shapeName = "BoxShape";
                        break;
                    case DclPrimitiveType.sphere:
                        dclObject.dclNodeType = EDclNodeType.sphere;
                        shapeName = "SphereShape";
                        break;
                    case DclPrimitiveType.plane:
                        dclObject.dclNodeType = EDclNodeType.plane;
                        shapeName = "PlaneShape";
                        break;
                    case DclPrimitiveType.cylinder:
                        dclObject.dclNodeType = EDclNodeType.cylinder;
                        shapeName = "CylinderShape";
                        break;
                    case DclPrimitiveType.cone:
                        dclObject.dclNodeType = EDclNodeType.cone;
                        shapeName = "ConeShape";
                        break;
                }
                
                //Statistics
                //if (statistics != null)
                //{
                //    switch (dclObject.dclPrimitiveType)
                //    {
                //        case DclPrimitiveType.box:
                //            statistics.triangleCount += 12;
                //            break;
                //        case DclPrimitiveType.sphere:
                //            statistics.triangleCount += 4624;
                //            break;
                //        case DclPrimitiveType.plane:
                //            statistics.triangleCount += 4;
                //            break;
                //        case DclPrimitiveType.cylinder:
                //            statistics.triangleCount += 144;
                //            break;
                //        case DclPrimitiveType.cone:
                //            statistics.triangleCount += 108;
                //            break;
                //    }
                //    statistics.bodyCount += 1;
                //}
            }

            if (shapeName != null)
            {
                //Primitive
                if (exportStr != null)
                {
                    exportStr.AppendFormat(SetShape, entityName, shapeName);
                }
                TraverseMaterial(tra, entityName, exportStr, statistics);
            }
            else
            {
                //gltf
                dclObject.dclNodeType = EDclNodeType.gltf;

                if (exportStr != null)
                {
                    string gltfPath = string.Format("./unity_assets/{0}.gltf", GetIdentityName(tra.gameObject));
                    exportStr.AppendFormat(SetGLTFshape, entityName, gltfPath);
                }

                //export as a glTF model
                if (meshesToExport != null)
                {
                    meshesToExport.Add(tra.gameObject);
                }
            }

            if (exportStr != null)
            {
                if (dclObject && dclObject.withCollision)
                {
                    exportStr.AppendFormat("{0}.getComponent({1}).withCollisions = true\n", entityName, shapeName);
                }

                if (dclObject && !dclObject.visible)
                {
                    exportStr.AppendFormat("{0}.getComponent(Shape).visible = false\n", entityName);
                }
            }

            if (statistics != null)
            {
                statistics.triangleCount += meshFilter.sharedMesh.triangles.LongLength / 3;
                statistics.bodyCount += 1;
            }
        }

        public static void TraverseText(Transform tra, string entityName, StringBuilder exportStr, SceneStatistics statistics)
        {
            if (!(tra.GetComponent<TextMesh>() && tra.GetComponent<MeshRenderer>()))
            {
                return;
            }

            if (exportStr != null)
            {
                exportStr.AppendFormat("{0}.addComponent(new TextShape())\n", entityName);

                var tm = tra.GetComponent<TextMesh>();
                var str = System.Text.RegularExpressions.Regex.Escape(tm.text);
                exportStr.AppendFormat("{0}.getComponent(TextShape).value = \"{1}\"\n", entityName, str);
                //scale *= tm.fontSize * 0.5f;
                //exportStr.AppendFormat(" fontS=\"{0}\"", 100);
                var color = ToJsColorCtor(tm.color);
                exportStr.AppendFormat("{0}.getComponent(TextShape).color = {1}\n", entityName, color);

                var rdrr = tra.GetComponent<MeshRenderer>();
                if (rdrr)
                {

                    var width = Math.Min(32, rdrr.bounds.size.x * 2 / tra.lossyScale.x); //rdrr.bounds.extents.x*2;
                    var height = Math.Min(32, rdrr.bounds.size.y * 2 / tra.lossyScale.y); //rdrr.bounds.extents.y * 2;

                    exportStr.AppendFormat("{0}.getComponent(TextShape).width = {1}\n", entityName, width);
                    exportStr.AppendFormat("{0}.getComponent(TextShape).height = {1}\n", entityName, height);
                }

                var fontSize = tm.fontSize == 0 ? 13f * 38f : tm.fontSize * 38f;
                exportStr.AppendFormat("{0}.getComponent(TextShape).fontSize = {1}\n", entityName, fontSize);

                switch (tm.anchor)
                {
                    case TextAnchor.UpperLeft:
                        exportStr.AppendFormat("{0}.getComponent(TextShape).hAlign = \"{1}\"\n", entityName, "\"right\"");
                        exportStr.AppendFormat("{0}.getComponent(TextShape).vAlign = \"{1}\"\n", entityName, "\"bottom\"");
                        break;
                    case TextAnchor.UpperCenter:
                        exportStr.AppendFormat("{0}.getComponent(TextShape).vAlign = \"{1}\"\n", entityName, "\"bottom\"");
                        break;
                    case TextAnchor.UpperRight:
                        exportStr.AppendFormat("{0}.getComponent(TextShape).hAlign = \"{1}\"\n", entityName, "\"left\"");
                        exportStr.AppendFormat("{0}.getComponent(TextShape).vAlign = \"{1}\"\n", entityName, "\"bottom\"");
                        break;
                    case TextAnchor.MiddleLeft:
                        exportStr.AppendFormat("{0}.getComponent(TextShape).hAlign = \"{1}\"\n", entityName, "\"right\"");
                        break;
                    case TextAnchor.MiddleCenter:

                        break;
                    case TextAnchor.MiddleRight:
                        exportStr.AppendFormat("{0}.getComponent(TextShape).hAlign = \"{1}\"\n", entityName, "\"left\"");
                        break;
                    case TextAnchor.LowerLeft:
                        exportStr.AppendFormat("{0}.getComponent(TextShape).hAlign = \"{1}\"\n", entityName, "\"right\"");
                        exportStr.AppendFormat("{0}.getComponent(TextShape).vAlign = \"{1}\"\n", entityName, "\"top\"");
                        break;
                    case TextAnchor.LowerCenter:
                        exportStr.AppendFormat("{0}.getComponent(TextShape).vAlign = \"{1}\"\n", entityName, "\"top\"");
                        break;
                    case TextAnchor.LowerRight:
                        exportStr.AppendFormat("{0}.getComponent(TextShape).hAlign = \"{1}\"\n", entityName, "\"left\"");
                        exportStr.AppendFormat("{0}.getComponent(TextShape).vAlign = \"{1}\"\n", entityName, "\"top\"");
                        break;
                }
            }

            if (statistics != null)
            {
                statistics.triangleCount += 4;
                statistics.bodyCount += 2;
            }
        }

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
            return String.Format("#{0:X2}{1:X2}{2:X2}", color256.r, color256.g, color256.b);
        }

        public static string ParcelToString(ParcelCoordinates parcel)
        {
            return string.Format("\"{0},{1}\"", parcel.x, parcel.y);
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

        /*
         * 
        public static string CalcName(Object _object)
        {
            string name = "";
            PrefabType t = PrefabUtility.GetPrefabType(_object);
            switch (t)
            {
                case PrefabType.PrefabInstance:
                case PrefabType.ModelPrefabInstance:
                    {
                        PropertyModification[] pm = PrefabUtility.GetPropertyModifications(_object);

                        bool change = false;
                        foreach (var v in pm)
                        {
                            if (!(v.propertyPath == "m_LocalPosition.x" ||
                                v.propertyPath == "m_LocalPosition.y" ||
                                v.propertyPath == "m_LocalPosition.z" ||
                                v.propertyPath == "m_LocalRotation.x" ||
                                v.propertyPath == "m_LocalRotation.y" ||
                                v.propertyPath == "m_LocalRotation.z" ||
                                v.propertyPath == "m_LocalRotation.w" ||
                                v.propertyPath == "m_RootOrder" ||
                                v.propertyPath == "m_Name"))
                            {

                                change = true;
                                break;
                                //Debug.Log (v.propertyPath);
                            }
                        }

                        if (change == true)
                        {
                            name = _object.name + Mathf.Abs(_object.GetInstanceID());
                        }
                        else
                        {
                            Object o = PrefabUtility.GetCorrespondingObjectFromSource(_object);
                            name = o.name + Mathf.Abs(o.GetInstanceID());
                        }
                    }
                    break;
                default:
                    name = _object.name + Mathf.Abs(_object.GetInstanceID());
                    break;
            }

            return name;
        }*/
        
        #endregion
    }
}
 