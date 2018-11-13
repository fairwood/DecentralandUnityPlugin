using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System;
using UnityEditor;

namespace Dcl{




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




	public class DclExportNode{

		static Dictionary<string, string> dict_ExportCode = null;
		static List<Material> exportMaterialList = null;

		private static string ToHexString(Color color)
		{
			var color256 = (Color32)color;
			return String.Format("#{0:X2}{1:X2}{2:X2}", color256.r, color256.g, color256.b);
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

		public static void Init(){
			dict_ExportCode = new Dictionary<string, string>();
			dict_ExportCode.Add ("new entity", "const {0} = new Entity()\n");
			dict_ExportCode.Add ("add entity", "engine.addEntity({0})\n");
			dict_ExportCode.Add ("set transform", "{0}.set(new Transform({{ position: new Vector3({1}, {2}, {3}) }}))\n");
			dict_ExportCode.Add ("set rotation", "{0}.get(Transform).rotation.set({1}, {2}, {3})\n");
			dict_ExportCode.Add ("set scale", "{0}.get(Transform).scale.set({1}, {2}, {3})\n");
			dict_ExportCode.Add ("set shape", "{0}.set(new {1}())\n");
			dict_ExportCode.Add ("set GLTFshape", "{0}.set(new GLTFShape(\"{1}\"))\n");
			dict_ExportCode.Add ("set parent", "{0}.parent = {1}\n");
			dict_ExportCode.Add ("new material", "const {0} = new Material()\n");
			dict_ExportCode.Add ("set material albedoColor", "{0}.albedoColor = \"{1}\"\n");
			dict_ExportCode.Add ("set material metallic", "{0}.metallic = {1}\n");
			dict_ExportCode.Add ("set material roughness", "{0}.roughness = {1}\n");
			dict_ExportCode.Add ("set material albedoTexture", "{0}.albedoTexture = \"{1}\"\n");
			dict_ExportCode.Add ("set material albedoTexture aplha true", "{0}.hasAlpha = true\n");
			dict_ExportCode.Add ("set material bumptexture", "{0}.bumpTexture = \"{1}\"\n");
			dict_ExportCode.Add ("set material", "{0}.set({1})\n");

			//childEntity.parent = parentEntity

			exportMaterialList = new List<Material> ();
		}



		public static void exportMaterial(Transform tra, string entityName, StringBuilder exportStr){
		
			var rdrr = tra.GetComponent<MeshRenderer>();
			if (rdrr && rdrr.sharedMaterial) {
				var material = rdrr.sharedMaterial;
				if (material != PrimitiveHelper.GetDefaultMaterial ()) {
					string materialName = "material" + Mathf.Abs(material.GetInstanceID ());
					Debug.Log (material.name);
					if (!exportMaterialList.Contains (material)) {
						exportMaterialList.Add(material);

						exportStr.AppendFormat (dict_ExportCode ["new material"], materialName);
						exportStr.AppendFormat (dict_ExportCode ["set material albedoColor"], materialName, ToHexString(material.color));
						exportStr.AppendFormat (dict_ExportCode ["set material metallic"], materialName, material.GetFloat("_Metallic"));
						exportStr.AppendFormat (dict_ExportCode ["set material roughness"], materialName, 1 - material.GetFloat("_Glossiness"));
						var albedoTex = material.HasProperty("_MainTex") ? material.GetTexture("_MainTex") : null;
						if (albedoTex) {
							exportStr.AppendFormat (dict_ExportCode ["set material albedoTexture"], materialName, GetTextureRelativePath(albedoTex));
							bool b = !(material.IsKeywordEnabled ("_ALPHATEST_ON")==false && material.IsKeywordEnabled ("_ALPHABLEND_ON")==false && material.IsKeywordEnabled ("_ALPHAPREMULTIPLY_ON")==false);

							if (b) {
								exportStr.AppendFormat (dict_ExportCode ["set material albedoTexture aplha true"], materialName);
							}
						}
						var bumpTexture = material.HasProperty("_BumpMap") ? material.GetTexture("_BumpMap") : null;
						if (bumpTexture) {
							exportStr.AppendFormat (dict_ExportCode ["set material bumptexture"], materialName, GetTextureRelativePath(bumpTexture));
						}
					} 
					exportStr.AppendFormat (dict_ExportCode ["set material"], entityName, materialName);

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

		public static void exportShape(Transform tra, string entityName, StringBuilder exportStr){
			if ( !(tra.GetComponent<MeshFilter> () && tra.GetComponent<MeshRenderer> ()) ) {
				return;
			}

			var dclObject = tra.GetComponent<DclObject>();

			string shapeName=null;
			if (dclObject != null) {
				switch (dclObject.dclPrimitiveType) {
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

			if (shapeName != null) {
				//Primitive
				exportStr.AppendFormat (dict_ExportCode ["set shape"], entityName, shapeName);
				exportMaterial (tra, entityName, exportStr);
			}else{
				//gltf
				string gltfPath = string.Format ("./unity_assets/{0}.gltf", SceneTraverser.CalcName (tra.gameObject));
				exportStr.AppendFormat (dict_ExportCode ["set GLTFshape"], entityName, gltfPath);
			}

		}

		public static void RecursivelyTraverseUnityNode(Transform tra, StringBuilder exportStr, string parentEntityName){
			if (!tra.gameObject.activeInHierarchy) return;
			//TODO: Hide empty
			if (tra.gameObject.GetComponent<DclSceneMeta>()) return;

			GameObject obj = tra.gameObject;
			var position = tra.localPosition;
			var scale = tra.localScale;
			var eulerAngles = tra.localEulerAngles;


			string entityName = "entity" + Mathf.Abs(obj.GetInstanceID ());
			entityName = entityName.Replace (" ", string.Empty);
			exportStr.AppendFormat (dict_ExportCode ["new entity"], entityName);
			if (parentEntityName != null) {
				exportStr.AppendFormat (dict_ExportCode ["set parent"], entityName, parentEntityName);
			}
			exportStr.AppendFormat (dict_ExportCode ["add entity"], entityName);
			exportStr.AppendFormat (dict_ExportCode ["set transform"], entityName, position.x, position.y, position.z);
			exportStr.AppendFormat (dict_ExportCode ["set rotation"], entityName, eulerAngles.x, eulerAngles.y, eulerAngles.z);
			exportStr.AppendFormat (dict_ExportCode ["set scale"], entityName, scale.x, scale.y, scale.z);
			//exportStr.AppendFormat (dict_ExportCode ["set shape"], entityName, "BoxShape");
			exportShape(tra, entityName, exportStr);



			foreach (Transform child in tra)
			{
				RecursivelyTraverseUnityNode (child, exportStr, entityName);
			}
		}


	}
}
