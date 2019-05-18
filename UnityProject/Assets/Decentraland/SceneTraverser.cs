using System;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Linq;
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

    public class ResourceRecorder
    {
        public List<GameObject> meshesToExport;
        public List<Material> primitiveMaterialsToExport;
        public List<Texture> primitiveTexturesToExport;
        public List<Texture> gltfTextures;
        public List<AudioClip> audioClipsToExport;
        public List<string> audioSourceAddFunctions = new List<string>();

        public ResourceRecorder()
        {
            meshesToExport = new List<GameObject>();
            primitiveMaterialsToExport = new List<Material>();
            primitiveTexturesToExport = new List<Texture>();
            gltfTextures = new List<Texture>();
            audioClipsToExport = new List<AudioClip>();
        }
    }

    public static class SceneTraverser
    {

        const string indentUnit = "  ";

        public static ResourceRecorder resourceRecorder;


        private static DclSceneMeta _sceneMeta;

        //public  static readonly  Dictionary<GameObject, EDclNodeType> GameObjectToNodeTypeDict = new Dictionary<GameObject, EDclNodeType>();


        public static ResourceRecorder TraverseAllScene(StringBuilder exportStr, SceneStatistics statistics,
            SceneWarningRecorder warningRecorder)
        {
            var rootGameObjects = new List<GameObject>();
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var roots = SceneManager.GetSceneAt(i).GetRootGameObjects();
                rootGameObjects.AddRange(roots);
            }

            _sceneMeta = Object.FindObjectOfType<DclSceneMeta>();

            resourceRecorder = new ResourceRecorder();

            //GameObjectToNodeTypeDict.Clear();

            //====== Start Traversing ======
            foreach (var rootGO in rootGameObjects)
            {
                RecursivelyTraverseTransform(rootGO.transform, exportStr, resourceRecorder, 4, statistics,
                    warningRecorder);
            }

            //Append PlayAudio functions
            if (exportStr != null)
            {
                if (resourceRecorder.audioSourceAddFunctions.Count > 0)
                {
                    exportStr.AppendLine();
                    exportStr.AppendLine("Input.instance.subscribe(\"BUTTON_UP\", e => {");
                    foreach (var functionName in resourceRecorder.audioSourceAddFunctions)
                    {
                        exportStr.AppendIndent(indentUnit, 1).AppendFormat("{0}()\n", functionName);
                    }

                    exportStr.AppendLine("})\n");
                }
            }

            if (statistics != null)
            {
                statistics.textureCount = resourceRecorder.primitiveTexturesToExport.Count +
                                          resourceRecorder.gltfTextures.Count;
            }

            return resourceRecorder;
        }

        public static void RecursivelyTraverseTransform(Transform tra, StringBuilder exportStr,
            ResourceRecorder resourceRecorder, int indentLevel, SceneStatistics statistics,
            SceneWarningRecorder warningRecorder)
        {
            if (!tra.gameObject.activeInHierarchy) return;
            if (tra.gameObject.GetComponent<DclSceneMeta>()) return; //skip .dcl

            var dclObject = tra.GetComponent<DclObject>() ?? tra.gameObject.AddComponent<DclObject>();

            dclObject.dclNodeType = EDclNodeType.entity;

            var entityName = GetIdentityName(tra.gameObject);

            if (statistics != null)
            {
                statistics.entityCount += 1;
            }

            var position = tra.localPosition;
            var scale = tra.localScale;
            var rotation = tra.localRotation;


            if (exportStr != null)
            {
                exportStr.AppendFormat(NewEntityWithName, entityName, tra.name);

                if (tra.parent)
                {
                    //Set Parent
                    exportStr.AppendFormat(SetParent, entityName, GetIdentityName(tra.parent.gameObject));
                }
                else
                {
                    //Entity
                    exportStr.AppendFormat(AddEntity, entityName);
                }

                //Transform
                exportStr.AppendFormat(SetTransform, entityName, position.x, position.y, position.z);
                exportStr.AppendFormat(SetRotation, entityName, rotation.x, rotation.y, rotation.z, rotation.w);
                exportStr.AppendFormat(SetScale, entityName, scale.x, scale.y, scale.z);

            }

            ProcessShape(tra, entityName, exportStr, resourceRecorder, statistics);

            if (exportStr != null && dclObject.dclNodeType == EDclNodeType.gltf
            ) //reverse 180° along local y-axis because of DCL's special purpose.
            {
                rotation = Quaternion.AngleAxis(180, tra.up) * rotation;
                exportStr.AppendFormat(SetRotation, entityName, rotation.x, rotation.y, rotation.z, rotation.w);
            }

            if (dclObject.dclNodeType != EDclNodeType.gltf)
            {
                ProcessText(tra, entityName, exportStr, statistics);
            }

            if (dclObject.dclNodeType != EDclNodeType.gltf)
            {
                ProcessMaterial(tra, false, entityName, resourceRecorder.primitiveMaterialsToExport, exportStr,
                    statistics);

                if (tra.GetComponent<MeshRenderer>())
                {
                    var meshFilter = tra.GetComponent<MeshFilter>();
                    var meshRenderer = tra.GetComponent<MeshRenderer>();

                    //Statistics
                    if (statistics != null)
                    {
                        if (meshFilter && meshFilter.sharedMesh)
                        {
                            statistics.triangleCount += meshFilter.sharedMesh.triangles.LongLength / 3;
                            statistics.bodyCount += 1;
                        }

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

                if (dclObject)
                {
                    //TODO： if (dclObject.visible != true) extraProperties.Append(" visible={false}");
                }

                //GameObjectToNodeTypeDict.Add(tra.gameObject, nodeType);

                foreach (Transform child in tra)
                {
                    RecursivelyTraverseTransform(child, exportStr, resourceRecorder, indentLevel + 1, statistics,
                        warningRecorder);
                }
            }
            else
            {
                if (statistics != null) statistics.gltfMaterials.Clear();
                RecursivelyTraverseIntoGLTF(tra, 0, statistics, warningRecorder);
                if (statistics != null)
                {
                    statistics.materialCount += statistics.gltfMaterials.Count;
                }
            }

            ProcessAudio(tra, entityName, exportStr);
        }

        public static void RecursivelyTraverseIntoGLTF(Transform tra, int layerUnderGLTFRoot,
            SceneStatistics statistics, SceneWarningRecorder warningRecorder)
        {
            if (!tra.gameObject.activeInHierarchy) return;
            if (tra.gameObject.GetComponent<DclSceneMeta>()) return; //skip .dcl

            var dclObject = tra.GetComponent<DclObject>() ?? tra.gameObject.AddComponent<DclObject>();

            if (layerUnderGLTFRoot > 0) dclObject.dclNodeType = EDclNodeType.ChildOfGLTF;

            if (tra.GetComponent<MeshRenderer>())
            {
                var meshFilter = tra.GetComponent<MeshFilter>();
                var meshRenderer = tra.GetComponent<MeshRenderer>();

                //Statistics
                if (statistics != null)
                {
                    if (meshFilter && meshFilter.sharedMesh)
                    {
                        statistics.triangleCount += meshFilter.sharedMesh.triangles.LongLength / 3;
                        statistics.bodyCount += 1;
                    }

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

            ProcessMaterial(tra, true, null, statistics.gltfMaterials, null, statistics);

            foreach (Transform child in tra)
            {
                RecursivelyTraverseIntoGLTF(child, layerUnderGLTFRoot + 1, statistics, warningRecorder);
            }
        }

        #region Utils


        private const string NewEntity = "var {0} = new Entity()\n";
        private const string NewEntityWithName = "var {0} = new Entity(\"{1}\")\n";
        private const string AddEntity = "engine.addEntity({0})\n";

        private const string SetTransform =
            "{0}.addComponent(new Transform({{ position: new Vector3({1}, {2}, {3}) }}))\n";

        private const string SetRotation = "{0}.getComponent(Transform).rotation.set({1}, {2}, {3}, {4})\n";
        private const string SetScale = "{0}.getComponent(Transform).scale.set({1}, {2}, {3})\n";
        private const string SetShape = "{0}.addComponent(new {1}())\n";
        private const string SetGLTFshape = "{0}.addComponent(new GLTFShape(\"{1}\"))\n";
        private const string SetParent = "{0}.setParent({1})\n";
        private const string NewMaterial = "var {0} = new Material()\n";
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

        public static void ProcessMaterial(Transform tra, bool isOnOrUnderGLTF, string entityName,
            List<Material> materialsToExport, StringBuilder exportStr, SceneStatistics statistics)
        {
            var rdrr = tra.GetComponent<MeshRenderer>();
            if (rdrr && tra.GetComponent<MeshFilter>())
            {
                List<Material> materialList;
                if (isOnOrUnderGLTF)
                {
                    materialList = rdrr.sharedMaterials.ToList();
                }
                else
                {
                    materialList = new List<Material>();
                    if (rdrr.sharedMaterial) materialList.Add(rdrr.sharedMaterial);
                }

                foreach (var material in materialList)
                {
                    if (material && material != PrimitiveHelper.GetDefaultMaterial())
                    {
                        string materialName = "material" + Mathf.Abs(material.GetInstanceID());
                        if (!materialsToExport.Contains(material))
                        {
                            materialsToExport.Add(material);

                            if (exportStr != null)
                            {
                                exportStr.AppendFormat(NewMaterial, materialName);
                                exportStr.AppendFormat(SetMaterialAlbedoColor, materialName,
                                    ToJsColorCtor(material.color));
                                exportStr.AppendFormat(SetMaterialMetallic, materialName,
                                    material.GetFloat("_Metallic"));
                                exportStr.AppendFormat(SetMaterialRoughness, materialName,
                                    1 - material.GetFloat("_Glossiness"));
                            }

                            var albedoTex = material.HasProperty("_MainTex") ? material.GetTexture("_MainTex") : null;
                            if (exportStr != null && albedoTex)
                            {
                                exportStr.AppendFormat(SetMaterialAlbedoTexture, materialName,
                                    GetTextureRelativePath(albedoTex));
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
                                exportStr.AppendFormat(SetMaterialBumptexture, materialName,
                                    GetTextureRelativePath(bumpTexture));
                            }

                            var refractionTexture = material.HasProperty("_MetallicGlossMap")
                                ? material.GetTexture("_MetallicGlossMap")
                                : null;
                            if (exportStr != null && refractionTexture)
                            {
                                exportStr.AppendFormat(SetMaterialRefractionTexture, materialName,
                                    GetTextureRelativePath(refractionTexture));
                            }

                            Texture emissiveTexture = null;
                            if (material.IsKeywordEnabled("_EMISSION"))
                            {
                                if (exportStr != null)
                                {
                                    exportStr.AppendFormat(SetMaterialEmissiveColor, materialName,
                                        ToJsColorCtor(material.GetColor("_EmissionColor")));
                                    //					        exportStr.AppendFormat(SetMaterialEmissiveIntensity, materialName, material.GetColor("_EmissionColor")); TODO:
                                }

                                emissiveTexture = material.HasProperty("_EmissionMap")
                                    ? material.GetTexture("_EmissionMap")
                                    : null;
                                if (exportStr != null && emissiveTexture)
                                {
                                    exportStr.AppendFormat(SetMaterialEmissiveTexture, materialName,
                                        GetTextureRelativePath(emissiveTexture));
                                }
                            }

                            var textureList = isOnOrUnderGLTF
                                ? resourceRecorder.gltfTextures
                                : resourceRecorder.primitiveTexturesToExport;
                            if (albedoTex)
                            {
                                if (!textureList.Contains(albedoTex)) textureList.Add(albedoTex);
                            }

                            if (refractionTexture)
                            {
                                if (!textureList.Contains(refractionTexture)) textureList.Add(refractionTexture);
                            }

                            if (bumpTexture)
                            {
                                if (!textureList.Contains(bumpTexture)) textureList.Add(bumpTexture);
                            }

                            if (emissiveTexture)
                            {
                                if (!textureList.Contains(emissiveTexture)) textureList.Add(emissiveTexture);
                            }

                            if (!isOnOrUnderGLTF)
                            {
                                if (statistics != null) statistics.materialCount += 1;
                            }
                        }

                        if (exportStr != null)
                        {
                            exportStr.AppendFormat(SetMaterial, entityName, materialName);
                        }
                    }
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

        public static void ProcessShape(Transform tra, string entityName, StringBuilder exportStr,
            ResourceRecorder resourceRecorder, SceneStatistics statistics)
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
            }

            if (shapeName != null)
            {
                //Primitive
                if (exportStr != null)
                {
                    exportStr.AppendFormat(SetShape, entityName, shapeName);
                }
            }
            else
            {
                //gltf - root
                dclObject.dclNodeType = EDclNodeType.gltf;

                if (exportStr != null)
                {
                    string gltfPath = string.Format("./unity_assets/{0}.gltf", GetIdentityName(tra.gameObject));
                    exportStr.AppendFormat(SetGLTFshape, entityName, gltfPath);
                }

                //export as a glTF model
                if (resourceRecorder != null)
                {
                    resourceRecorder.meshesToExport.Add(tra.gameObject);
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
        }

        public static void ProcessText(Transform tra, string entityName, StringBuilder exportStr,
            SceneStatistics statistics)
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
                        exportStr.AppendFormat("{0}.getComponent(TextShape).hAlign = \"{1}\"\n", entityName,
                            "\"right\"");
                        exportStr.AppendFormat("{0}.getComponent(TextShape).vAlign = \"{1}\"\n", entityName,
                            "\"bottom\"");
                        break;
                    case TextAnchor.UpperCenter:
                        exportStr.AppendFormat("{0}.getComponent(TextShape).vAlign = \"{1}\"\n", entityName,
                            "\"bottom\"");
                        break;
                    case TextAnchor.UpperRight:
                        exportStr.AppendFormat("{0}.getComponent(TextShape).hAlign = \"{1}\"\n", entityName,
                            "\"left\"");
                        exportStr.AppendFormat("{0}.getComponent(TextShape).vAlign = \"{1}\"\n", entityName,
                            "\"bottom\"");
                        break;
                    case TextAnchor.MiddleLeft:
                        exportStr.AppendFormat("{0}.getComponent(TextShape).hAlign = \"{1}\"\n", entityName,
                            "\"right\"");
                        break;
                    case TextAnchor.MiddleCenter:

                        break;
                    case TextAnchor.MiddleRight:
                        exportStr.AppendFormat("{0}.getComponent(TextShape).hAlign = \"{1}\"\n", entityName,
                            "\"left\"");
                        break;
                    case TextAnchor.LowerLeft:
                        exportStr.AppendFormat("{0}.getComponent(TextShape).hAlign = \"{1}\"\n", entityName,
                            "\"right\"");
                        exportStr.AppendFormat("{0}.getComponent(TextShape).vAlign = \"{1}\"\n", entityName, "\"top\"");
                        break;
                    case TextAnchor.LowerCenter:
                        exportStr.AppendFormat("{0}.getComponent(TextShape).vAlign = \"{1}\"\n", entityName, "\"top\"");
                        break;
                    case TextAnchor.LowerRight:
                        exportStr.AppendFormat("{0}.getComponent(TextShape).hAlign = \"{1}\"\n", entityName,
                            "\"left\"");
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

        public static void ProcessAudio(Transform tra, string entityName, StringBuilder exportStr)
        {
            var audioSource = tra.GetComponent<AudioSource>();
            if (audioSource && exportStr != null)
            {
                var audioClip = audioSource.clip;
                string audioClipRelPath = null;
                if (audioClip)
                {
                    audioClipRelPath = string.Format("'{0}'", GetAudioClipRelativePath(audioClip));
                    resourceRecorder.audioClipsToExport.Add(audioClip);
                }

                var playFunctionName = "playAudioSource" + Mathf.Abs(audioSource.GetInstanceID());
                exportStr.AppendFormat(
                    @"var audioSource = new AudioSource(new AudioClip({0}))
var {1} = () => {{
{2}{3}.addComponent(audioSource)"
                    , audioClipRelPath, playFunctionName, indentUnit, entityName);
                exportStr.AppendLine();
                exportStr.AppendIndent(indentUnit, 1).AppendFormat("audioSource.playing = {0}\n",
                    BoolToString(audioSource.playOnAwake));
                exportStr.AppendIndent(indentUnit, 1)
                    .AppendFormat("audioSource.loop = {0}\n", BoolToString(audioSource.loop));
                exportStr.AppendIndent(indentUnit, 1).AppendFormat("audioSource.volume = {0}\n", audioSource.volume);
                exportStr.AppendIndent(indentUnit, 1).AppendFormat("audioSource.pitch = {0}\n", audioSource.pitch);
                exportStr.Append("}\n");

                resourceRecorder.audioSourceAddFunctions.Add(playFunctionName);
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

        public static string GetAudioClipRelativePath(AudioClip audioClip)
        {
            var relPath = AssetDatabase.GetAssetPath(audioClip);
            if (string.IsNullOrEmpty(relPath))
            {
                //this is a built-in asset
                Debug.LogError("AudioClip should not be built-in assets!");
            }
            else
            {

            }

            string str = "unity_assets/" + relPath;
            return str;
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
            var color256 = (Color32) color;
            return String.Format("#{0:X2}{1:X2}{2:X2}", color256.r, color256.g, color256.b);
        }

        public static string BoolToString(bool b)
        {
            return b ? "true" : "false";
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