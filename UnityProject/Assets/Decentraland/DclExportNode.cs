using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System;
using UnityEditor;

namespace Dcl
{




//	public class DclExportNode{
//		public static DclExportNodeScene parseXmlText(StringBuilder str){
//			Debug.Log ("Export start");
//
//			string test = "<scene position={{x:5,y:0,z:5}}></scene>";
//			var serializer = new XmlSerializer(typeof(DclExportNodeScene));
//
//			DclExportNodeScene scene =  serializer.Deserialize(new StringReader(test)) as DclExportNodeScene;
//			//DclExportNodeScene scene =  serializer.Deserialize(new StringReader(str.ToString())) as DclExportNodeScene;
//			Debug.Log (scene.position);
//			Debug.Log("Export end");
//			return scene;
//		}
//	}
//	//[XmlRoot("scene")]
//	public class DclExportNodeScene{
//		public Vector3 position;
//	}




    public class DclExportNode
    {

        static Dictionary<string, string> dict_ExportCode = null;
        static List<Material> exportMaterialList = null;

        private static string ToJsColorCtor(Color color)
        {
            return String.Format("new Color3({0}, {1}, {2})", color.r, color.g, color.b);
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

            string str = "./unity_assets/" + relPath;
            return str;
            //replace space by zcy
            //return str.Replace (" ", string.Empty);
        }

        public static void Init()
        {
            dict_ExportCode = new Dictionary<string, string>();
            dict_ExportCode.Add("new entity", "const {0} = new Entity()\n");
            dict_ExportCode.Add("new entity with name", "const {0} = new Entity() //{1}\n");
            dict_ExportCode.Add("add entity", "engine.addEntity({0})\n");
            dict_ExportCode.Add("set transform",
                "{0}.set(new Transform({{ position: new Vector3({1}, {2}, {3}) }}))\n");
            dict_ExportCode.Add("set rotation", "{0}.get(Transform).rotation.set({1}, {2}, {3}, {4})\n");
            dict_ExportCode.Add("set scale", "{0}.get(Transform).scale.set({1}, {2}, {3})\n");
            dict_ExportCode.Add("set shape", "{0}.set(new {1}())\n");
            dict_ExportCode.Add("set GLTFshape", "{0}.set(new GLTFShape(\"{1}\"))\n");
            dict_ExportCode.Add("set parent", "{0}.setParent({1})\n");
            dict_ExportCode.Add("new material", "const {0} = new Material()\n");
            dict_ExportCode.Add("set material albedoColor", "{0}.albedoColor = {1}\n");
            dict_ExportCode.Add("set material metallic", "{0}.metallic = {1}\n");
            dict_ExportCode.Add("set material roughness", "{0}.roughness = {1}\n");
            dict_ExportCode.Add("set material albedoTexture", "{0}.albedoTexture = \"{1}\"\n");
            dict_ExportCode.Add("set material albedoTexture alpha true", "{0}.hasAlpha = true\n");
            dict_ExportCode.Add("set material alpha", "{0}.alpha = {1}\n");
            dict_ExportCode.Add("set material bumptexture", "{0}.bumpTexture = \"{1}\"\n");
            dict_ExportCode.Add("set material", "{0}.set({1})\n");

            //childEntity.parent = parentEntity

            exportMaterialList = new List<Material>();
        }

        private const string SetMaterialEmissiveColor = "{0}.emissiveColor = {1}\n";
        private const string SetMaterialRefractionTexture = "{0}.refractionTexture = \"{1}\"\n";
        private const string SetMaterialEmissiveIntensity = "{0}.emissiveIntensity = {1}\n";
        private const string SetMaterialEmissiveTexture = "{0}.emissiveTexture = \"{1}\"\n";

        public static void exportMaterial(Transform tra, string entityName, StringBuilder exportStr)
        {

            var rdrr = tra.GetComponent<MeshRenderer>();
            if (rdrr && rdrr.sharedMaterial)
            {
                var material = rdrr.sharedMaterial;
                if (material != PrimitiveHelper.GetDefaultMaterial())
                {
                    string materialName = "material" + Mathf.Abs(material.GetInstanceID());
                    Debug.Log(material.name);
                    if (!exportMaterialList.Contains(material))
                    {
                        exportMaterialList.Add(material);

                        exportStr.AppendFormat(dict_ExportCode["new material"], materialName);
                        exportStr.AppendFormat(dict_ExportCode["set material albedoColor"], materialName,
                            ToJsColorCtor(material.color));
                        exportStr.AppendFormat(dict_ExportCode["set material metallic"], materialName,
                            material.GetFloat("_Metallic"));
                        exportStr.AppendFormat(dict_ExportCode["set material roughness"], materialName,
                            1 - material.GetFloat("_Glossiness"));
                        var albedoTex = material.HasProperty("_MainTex") ? material.GetTexture("_MainTex") : null;
                        if (albedoTex)
                        {
                            exportStr.AppendFormat(dict_ExportCode["set material albedoTexture"], materialName,
                                GetTextureRelativePath(albedoTex));

                        }

                        bool b = material.IsKeywordEnabled("_ALPHATEST_ON") ||
                                 material.IsKeywordEnabled("_ALPHABLEND_ON") ||
                                 material.IsKeywordEnabled("_ALPHAPREMULTIPLY_ON");
                        if (b)
                        {
                            exportStr.AppendFormat(dict_ExportCode["set material albedoTexture alpha true"],
                                materialName);
                            exportStr.AppendFormat(dict_ExportCode["set material alpha"], materialName,
                                material.color.a);
                        }

                        var bumpTexture = material.HasProperty("_BumpMap") ? material.GetTexture("_BumpMap") : null;
                        if (bumpTexture)
                        {
                            exportStr.AppendFormat(dict_ExportCode["set material bumptexture"], materialName,
                                GetTextureRelativePath(bumpTexture));
                        }

                        var refractionTexture = material.HasProperty("_MetallicGlossMap")
                            ? material.GetTexture("_MetallicGlossMap")
                            : null;
                        if (refractionTexture)
                        {
                            exportStr.AppendFormat(SetMaterialRefractionTexture, materialName,
                                GetTextureRelativePath(refractionTexture));
                        }

                        Texture emissiveTexture = null;
                        if (material.IsKeywordEnabled("_EMISSION"))
                        {
                            exportStr.AppendFormat(SetMaterialEmissiveColor, materialName,
                                ToJsColorCtor(material.GetColor("_EmissionColor")));
//					        exportStr.AppendFormat(SetMaterialEmissiveIntensity, materialName, material.GetColor("_EmissionColor")); TODO:

                            emissiveTexture = material.HasProperty("_EmissionMap")
                                ? material.GetTexture("_EmissionMap")
                                : null;
                            if (emissiveTexture)
                            {
                                exportStr.AppendFormat(SetMaterialEmissiveTexture, materialName,
                                    GetTextureRelativePath(emissiveTexture));
                            }
                        }

                        if (albedoTex)
                        {
                            SceneTraverser.primitiveTexturesToExport.Add(albedoTex);
                        }

                        if (refractionTexture)
                        {
                            SceneTraverser.primitiveTexturesToExport.Add(refractionTexture);
                        }

                        if (bumpTexture)
                        {
                            SceneTraverser.primitiveTexturesToExport.Add(bumpTexture);
                        }

                        if (emissiveTexture)
                        {
                            SceneTraverser.primitiveTexturesToExport.Add(emissiveTexture);
                        }
                    }

                    exportStr.AppendFormat(dict_ExportCode["set material"], entityName, materialName);

                }

            }
//			const myMaterial = new Material()
//			myMaterial.albedoColor = "#FF0000"
//			myMaterial.metallic = 0.9
//			myMaterial.roughness = 0.1
//			myEntity.set(myMaterial)
//			myMaterial.albedoTexture = "materials/wood.png"
//			myMaterial.bumpTexture = "materials/woodBump.png"

//			myMaterial.hasAlpha = true

        }

        static void ExportShape(Transform tra, string entityName, StringBuilder exportStr, List<GameObject> meshesToExport)
        {
            if (!(tra.GetComponent<MeshFilter>() && tra.GetComponent<MeshRenderer>()))
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
                        shapeName = "BoxShape";
                        break;
                    case DclPrimitiveType.sphere:
                        shapeName = "SphereShape";
                        break;
                    case DclPrimitiveType.plane:
                        shapeName = "PlaneShape";
                        break;
                    case DclPrimitiveType.cylinder:
                        shapeName = "CylinderShape";
                        break;
                    case DclPrimitiveType.cone:
                        shapeName = "ConeShape";
                        break;
                }
            }

            if (shapeName != null)
            {
                //Primitive
                exportStr.AppendFormat(dict_ExportCode["set shape"], entityName, shapeName);
                exportMaterial(tra, entityName, exportStr);
            }
            else
            {
                //gltf
                string gltfPath = string.Format("./unity_assets/{0}.gltf", SceneTraverser.CalcName(tra.gameObject));
                exportStr.AppendFormat(dict_ExportCode["set GLTFshape"], entityName, gltfPath);


                //export as a glTF model
                if (meshesToExport != null)
                {
                    meshesToExport.Add(tra.gameObject);
                }
            }

            if (dclObject && dclObject.withCollision)
            {
                exportStr.AppendFormat("{0}.get({1}).withCollisions = true\n", entityName, shapeName);
            }

            if (dclObject && !dclObject.visible)
            {
                exportStr.AppendFormat("{0}.get(Shape).visible = false\n", entityName);
            }

        }

        static void ExportText(Transform tra, string entityName, StringBuilder exportStr)
        {
            if (!(tra.GetComponent<TextMesh>() && tra.GetComponent<MeshRenderer>()))
            {
                return;
            }

            exportStr.AppendFormat("{0}.set(new TextShape())\n", entityName);

            var tm = tra.GetComponent<TextMesh>();
            var str = System.Text.RegularExpressions.Regex.Escape(tm.text);
            exportStr.AppendFormat("{0}.get(TextShape).value = \"{1}\"\n", entityName, str);
            //scale *= tm.fontSize * 0.5f;
            //exportStr.AppendFormat(" fontS=\"{0}\"", 100);
            var color = ToJsColorCtor(tm.color);
            exportStr.AppendFormat("{0}.get(TextShape).color = {1}\n", entityName, color);

            var rdrr = tra.GetComponent<MeshRenderer>();
            if (rdrr)
            {

                var width = Math.Min(32, rdrr.bounds.size.x * 2 / tra.lossyScale.x); //rdrr.bounds.extents.x*2;
                var height = Math.Min(32, rdrr.bounds.size.y * 2 / tra.lossyScale.y); //rdrr.bounds.extents.y * 2;

                exportStr.AppendFormat("{0}.get(TextShape).width = {1}\n", entityName, width);
                exportStr.AppendFormat("{0}.get(TextShape).height = {1}\n", entityName, height);
            }

            var fontSize = tm.fontSize == 0 ? 13f * 38f : tm.fontSize * 38f;
            exportStr.AppendFormat("{0}.get(TextShape).fontSize = {1}\n", entityName, fontSize);

            switch (tm.anchor)
            {
                case TextAnchor.UpperLeft:
                    exportStr.AppendFormat("{0}.get(TextShape).hAlign = \"{1}\"\n", entityName, "\"right\"");
                    exportStr.AppendFormat("{0}.get(TextShape).vAlign = \"{1}\"\n", entityName, "\"bottom\"");
                    break;
                case TextAnchor.UpperCenter:
                    exportStr.AppendFormat("{0}.get(TextShape).vAlign = \"{1}\"\n", entityName, "\"bottom\"");
                    break;
                case TextAnchor.UpperRight:
                    exportStr.AppendFormat("{0}.get(TextShape).hAlign = \"{1}\"\n", entityName, "\"left\"");
                    exportStr.AppendFormat("{0}.get(TextShape).vAlign = \"{1}\"\n", entityName, "\"bottom\"");
                    break;
                case TextAnchor.MiddleLeft:
                    exportStr.AppendFormat("{0}.get(TextShape).hAlign = \"{1}\"\n", entityName, "\"right\"");
                    break;
                case TextAnchor.MiddleCenter:

                    break;
                case TextAnchor.MiddleRight:
                    exportStr.AppendFormat("{0}.get(TextShape).hAlign = \"{1}\"\n", entityName, "\"left\"");
                    break;
                case TextAnchor.LowerLeft:
                    exportStr.AppendFormat("{0}.get(TextShape).hAlign = \"{1}\"\n", entityName, "\"right\"");
                    exportStr.AppendFormat("{0}.get(TextShape).vAlign = \"{1}\"\n", entityName, "\"top\"");
                    break;
                case TextAnchor.LowerCenter:
                    exportStr.AppendFormat("{0}.get(TextShape).vAlign = \"{1}\"\n", entityName, "\"top\"");
                    break;
                case TextAnchor.LowerRight:
                    exportStr.AppendFormat("{0}.get(TextShape).hAlign = \"{1}\"\n", entityName, "\"left\"");
                    exportStr.AppendFormat("{0}.get(TextShape).vAlign = \"{1}\"\n", entityName, "\"top\"");
                    break;
            }

        }

        public static void RecursivelyTraverseUnityNode(Transform tra, StringBuilder exportStr, List<GameObject> meshesToExport, string parentEntityName)
        {
            if (!tra.gameObject.activeInHierarchy) return;
            //TODO: Hide empty
            if (tra.gameObject.GetComponent<DclSceneMeta>()) return;


            GameObject obj = tra.gameObject;
            var position = tra.localPosition;
            var scale = tra.localScale;
            var rotation = tra.localRotation;

            string entityName = "entity" + Mathf.Abs(obj.GetInstanceID());
            entityName = entityName.Replace(" ", string.Empty);

            if (exportStr != null)
            {
                exportStr.AppendFormat(dict_ExportCode["new entity with name"], entityName, tra.name);
                if (parentEntityName != null)
                {
                    exportStr.AppendFormat(dict_ExportCode["set parent"], entityName, parentEntityName);
                }

                exportStr.AppendFormat(dict_ExportCode["add entity"], entityName);
                exportStr.AppendFormat(dict_ExportCode["set transform"], entityName, position.x, position.y,
                    position.z);
                exportStr.AppendFormat(dict_ExportCode["set rotation"], entityName, rotation.x, rotation.y, rotation.z,
                    rotation.w);
                exportStr.AppendFormat(dict_ExportCode["set scale"], entityName, scale.x, scale.y, scale.z);
                //exportStr.AppendFormat (dict_ExportCode ["set shape"], entityName, "BoxShape");
                ExportShape(tra, entityName, exportStr, meshesToExport);
                ExportText(tra, entityName, exportStr);

                exportStr.Append('\n');
            }


            foreach (Transform child in tra)
            {
                RecursivelyTraverseUnityNode(child, exportStr, meshesToExport, entityName);
            }
        }


    }
}