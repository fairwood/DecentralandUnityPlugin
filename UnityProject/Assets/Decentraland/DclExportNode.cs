using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;
using UnityEditor;

namespace Dcl
{

    public class DclExportNode
    {
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
            exportMaterialList = new List<Material>();
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

                        exportStr.AppendFormat(NewMaterial, materialName);
                        exportStr.AppendFormat(SetMaterialAlbedoColor, materialName, ToJsColorCtor(material.color));
                        exportStr.AppendFormat(SetMaterialMetallic, materialName, material.GetFloat("_Metallic"));
                        exportStr.AppendFormat(SetMaterialRoughness, materialName, 1 - material.GetFloat("_Glossiness"));
                        var albedoTex = material.HasProperty("_MainTex") ? material.GetTexture("_MainTex") : null;
                        if (albedoTex)
                        {
                            exportStr.AppendFormat(SetMaterialAlbedoTexture, materialName, GetTextureRelativePath(albedoTex));
                        }

                        bool b = material.IsKeywordEnabled("_ALPHATEST_ON") ||
                                 material.IsKeywordEnabled("_ALPHABLEND_ON") ||
                                 material.IsKeywordEnabled("_ALPHAPREMULTIPLY_ON");
                        if (b)
                        {
                            exportStr.AppendFormat(SetMaterialAlbedoTextureHasAlpha, materialName);
                            exportStr.AppendFormat(SetMaterialAlpha, materialName, material.color.a);
                        }

                        var bumpTexture = material.HasProperty("_BumpMap") ? material.GetTexture("_BumpMap") : null;
                        if (bumpTexture)
                        {
                            exportStr.AppendFormat(SetMaterialBumptexture, materialName, GetTextureRelativePath(bumpTexture));
                        }

                        var refractionTexture = material.HasProperty("_MetallicGlossMap")
                            ? material.GetTexture("_MetallicGlossMap")
                            : null;
                        if (refractionTexture)
                        {
                            exportStr.AppendFormat(SetMaterialRefractionTexture, materialName, GetTextureRelativePath(refractionTexture));
                        }

                        Texture emissiveTexture = null;
                        if (material.IsKeywordEnabled("_EMISSION"))
                        {
                            exportStr.AppendFormat(SetMaterialEmissiveColor, materialName, ToJsColorCtor(material.GetColor("_EmissionColor")));
                            //					        exportStr.AppendFormat(SetMaterialEmissiveIntensity, materialName, material.GetColor("_EmissionColor")); TODO:

                            emissiveTexture = material.HasProperty("_EmissionMap")
                                ? material.GetTexture("_EmissionMap")
                                : null;
                            if (emissiveTexture)
                            {
                                exportStr.AppendFormat(SetMaterialEmissiveTexture, materialName, GetTextureRelativePath(emissiveTexture));
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

                    exportStr.AppendFormat(SetMaterial, entityName, materialName);

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
                exportStr.AppendFormat(SetShape, entityName, shapeName);
                exportMaterial(tra, entityName, exportStr);
            }
            else
            {
                //gltf
                string gltfPath = string.Format("./unity_assets/{0}.gltf", SceneTraverser.CalcName(tra.gameObject));
                exportStr.AppendFormat(SetGLTFshape, entityName, gltfPath);


                //export as a glTF model
                if (meshesToExport != null)
                {
                    meshesToExport.Add(tra.gameObject);
                }
            }

            if (dclObject && dclObject.withCollision)
            {
                exportStr.AppendFormat("{0}.getComponent({1}).withCollisions = true\n", entityName, shapeName);
            }

            if (dclObject && !dclObject.visible)
            {
                exportStr.AppendFormat("{0}.getComponent(Shape).visible = false\n", entityName);
            }

        }

        static void ExportText(Transform tra, string entityName, StringBuilder exportStr)
        {
            if (!(tra.GetComponent<TextMesh>() && tra.GetComponent<MeshRenderer>()))
            {
                return;
            }

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
                exportStr.AppendFormat(NewEntityWithName, entityName, tra.name);
                if (parentEntityName != null)
                {
                    exportStr.AppendFormat(SetParent, entityName, parentEntityName);
                }

                exportStr.AppendFormat(AddEntity, entityName);
                exportStr.AppendFormat(SetTransform, entityName, position.x, position.y,
                    position.z);
                exportStr.AppendFormat(SetRotation, entityName, rotation.x, rotation.y, rotation.z,
                    rotation.w);
                exportStr.AppendFormat(SetScale, entityName, scale.x, scale.y, scale.z);
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