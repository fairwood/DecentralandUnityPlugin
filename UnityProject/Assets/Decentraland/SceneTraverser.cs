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

		public static string CalcName(Object _object){
			string name = "";
			PrefabType t = PrefabUtility.GetPrefabType (_object);
			switch (t) {
			case PrefabType.PrefabInstance:
			case PrefabType.ModelPrefabInstance:
				{
					PropertyModification[] pm = PrefabUtility.GetPropertyModifications (_object);

					bool change = false;
					foreach (var v in pm) {
						if( !(v.propertyPath=="m_LocalPosition.x" ||
							v.propertyPath=="m_LocalPosition.y" ||
							v.propertyPath=="m_LocalPosition.z" ||
							v.propertyPath=="m_LocalRotation.x" ||
							v.propertyPath=="m_LocalRotation.y" ||
							v.propertyPath=="m_LocalRotation.z" ||
							v.propertyPath=="m_LocalRotation.w" ||
							v.propertyPath=="m_RootOrder" ||
							v.propertyPath=="m_Name") ){

							change = true;
							break;
							//Debug.Log (v.propertyPath);
						}
					}

					if (change == true) {
						name = _object.name + Mathf.Abs(_object.GetInstanceID ());
					} else {
						Object o = PrefabUtility.GetCorrespondingObjectFromSource (_object);
						name = o.name + Mathf.Abs(o.GetInstanceID ());
					}
				}
				break;
			default:
				name = _object.name + Mathf.Abs(_object.GetInstanceID ());
				break;
			}

			return name;
		}

		public static void TraverseAllSceneNewSdk(StringBuilder exportStr)
		{
			var rootGameObjects = new List<GameObject>();
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				var roots = SceneManager.GetSceneAt(i).GetRootGameObjects();
				rootGameObjects.AddRange(roots);
			}

			//====== Start Traversing ======
			DclExportNode.Init();
			foreach (var rootGO in rootGameObjects)
			{
				//RecursivelyTraverseTransform(rootGO.transform, xmlBuilder, meshesToExport, 4, statistics, warningRecorder, GameObjectToNodeTypeDict);
				DclExportNode.RecursivelyTraverseUnityNode(rootGO.transform, exportStr, null);
			}
			Debug.Log (exportStr.ToString ());
//			return;
//
//			foreach (var material in primitiveMaterialsToExport)
//			{
//				var materialXml = xmlBuilder != null ? new StringBuilder() : null;
//				TraverseMaterial(material, materialXml, warningRecorder);
//
//				//Append materials
//				if (xmlBuilder != null)
//				{
//					xmlBuilder.AppendIndent(indentUnit, 4);
//					xmlBuilder.Append(materialXml).Append("\n");
//				}
//			}
//
//			//Check textures
//			if (warningRecorder != null)
//			{
//				foreach (var texture in primitiveTexturesToExport)
//				{
//					CheckTextureValidity(texture, warningRecorder);
//				}
//			}
//
//			statistics.materialCount += primitiveMaterialsToExport.Count; //TODO: include glTF's materials
//			statistics.textureCount += primitiveTexturesToExport.Count; //TODO: include glTF's textures
//
//			if (xmlBuilder != null)
//			{
//				xmlBuilder.AppendIndent(indentUnit, 3);
//				xmlBuilder.Append("</scene>");
//			}
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
            if (tra.gameObject.GetComponent<DclSceneMeta>()) return;

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

				if(customNode.propertyPairs!=null){
					foreach (var propertyPair in customNode.propertyPairs)
					{
						extraProperties.AppendFormat(" {0}={1}", propertyPair.name, propertyPair.value);
					}
				}
            }
            else
            {

				if (tra.GetComponent<MeshFilter>() && tra.GetComponent<MeshRenderer>()) //Primitives & glTF
                {
					if (dclObject) {
						switch (dclObject.dclPrimitiveType) {
						case DclPrimitiveType.box:
							nodeName = "box";
							nodeType = EDclNodeType.box;
							break;
						case DclPrimitiveType.sphere:
							nodeName = "sphere";
							nodeType = EDclNodeType.sphere;
							break;
						case DclPrimitiveType.plane:
							nodeName = "plane";
							nodeType = EDclNodeType.plane;
							break;
						case DclPrimitiveType.cylinder:
							nodeName = "cylinder";
							nodeType = EDclNodeType.cylinder;
							break;
						case DclPrimitiveType.cone:
							nodeName = "cone";
							nodeType = EDclNodeType.cone;
							break;
						}
					}
                    var meshFilter = tra.GetComponent<MeshFilter>();

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
								if (primitiveMaterialsToExport!=null && !primitiveMaterialsToExport.Exists(m => m == material))
                                {
                                    primitiveMaterialsToExport.Add(material);
                                }

                                pMaterial = string.Format("#{0}", material.name);
                            }

                        }

                        //withCollisions
                        if (dclObject)
                        {
							if(dclObject.dclPrimitiveType!=DclPrimitiveType.other)
                            {
                                if (dclObject.withCollision == true) extraProperties.Append(" withCollisions={true}");
                            }
                        }

                        //Statistics
                        if (statistics != null)
                        {
							switch (dclObject.dclPrimitiveType) {
							case DclPrimitiveType.box:
								statistics.triangleCount += 12;
								break;
							case DclPrimitiveType.sphere:
								statistics.triangleCount += 4624;
								break;
							case DclPrimitiveType.plane:
								statistics.triangleCount += 4;
								break;
							case DclPrimitiveType.cylinder:
								statistics.triangleCount += 144;
								break;
							case DclPrimitiveType.cone:
								statistics.triangleCount += 108;
								break;
							}

							statistics.bodyCount += 1;
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

						//if tra is a prefab and do not get any change. use the prefab's name

                        //extraProperties.AppendFormat(" src=\"./unity_assets/{0}.gltf\"", tra.name);
						extraProperties.AppendFormat(" src=\"./unity_assets/{0}.gltf\"", CalcName(tra.gameObject));

                        //Statistics
                        if (statistics != null)
                        {
                            statistics.triangleCount += meshFilter.sharedMesh.triangles.LongLength / 3;
                            statistics.bodyCount += 1;
                        }

						if (statistics != null) {
							Mesh m = meshFilter.sharedMesh;

							Renderer mr = tra.GetComponent<MeshRenderer> ();
							if (mr == null) {
								mr = tra.GetComponent<SkinnedMeshRenderer> ();
							}

							var sm = mr.sharedMaterials;
							for (int i = 0; i < sm.Length; ++i) 
							{
								Material ma = sm [i];
								if (ma != null) 
								{
									statistics.materialCount += 1;
									Shader shader = ma.shader;
									for(int j=0; j<ShaderUtil.GetPropertyCount(shader); j++)
									{
										if (ShaderUtil.GetPropertyType (shader, j) == ShaderUtil.ShaderPropertyType.TexEnv) 
										{
											Texture texture = ma.GetTexture (ShaderUtil.GetPropertyName (shader, j));
											if (texture != null) {statistics.textureCount += 1;}
										}
									}
								}
							}

						}

                    }
                }
                else if (tra.GetComponent<TextMesh>() && tra.GetComponent<MeshRenderer>()) //TextMesh
                {

                    nodeName = "text";
                    nodeType = EDclNodeType.text;
                    var tm = tra.GetComponent<TextMesh>();
                    extraProperties.AppendFormat(" value=\"{0}\"", tm.text);
                    //scale *= tm.fontSize * 0.5f;
                    //extraProperties.AppendFormat(" fontS=\"{0}\"", 100);
                    pColor = ToHexString(tm.color);
                    var rdrr = tra.GetComponent<MeshRenderer>();
                    if (rdrr)
                    {
						
						var width = Math.Min(32, rdrr.bounds.size.x*2 / tra.lossyScale.x);//rdrr.bounds.extents.x*2;
						var height = Math.Min(32, rdrr.bounds.size.y*2 / tra.lossyScale.y);//rdrr.bounds.extents.y * 2;

                        extraProperties.AppendFormat(" width={{{0}}}", width);
                        extraProperties.AppendFormat(" height={{{0}}}", height);
                    }
					extraProperties.AppendFormat(" fontSize={{{0}}}", tm.fontSize==0 ? 13f*38f : tm.fontSize*38f);

					switch (tm.anchor) {
					case TextAnchor.UpperLeft:
						extraProperties.AppendFormat(" hAlign=\"right\"");
						extraProperties.AppendFormat(" vAlign=\"bottom\"");
						break;
					case TextAnchor.UpperCenter:
						extraProperties.AppendFormat(" vAlign=\"bottom\"");
						break;
					case TextAnchor.UpperRight:
						extraProperties.AppendFormat(" hAlign=\"left\"");
						extraProperties.AppendFormat(" vAlign=\"bottom\"");
						break;
					case TextAnchor.MiddleLeft:
						extraProperties.AppendFormat(" hAlign=\"right\"");
						break;
					case TextAnchor.MiddleCenter:
						
						break;
					case TextAnchor.MiddleRight:
						extraProperties.AppendFormat(" hAlign=\"left\"");
						break;
					case TextAnchor.LowerLeft:
						extraProperties.AppendFormat(" hAlign=\"right\"");
						extraProperties.AppendFormat(" vAlign=\"top\"");
						break;
					case TextAnchor.LowerCenter:
						extraProperties.AppendFormat(" vAlign=\"top\"");
						break;
					case TextAnchor.LowerRight:
						extraProperties.AppendFormat(" hAlign=\"left\"");
						extraProperties.AppendFormat(" vAlign=\"top\"");
						break;
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
            return String.Format("#{0:X2}{1:X2}{2:X2}", color256.r, color256.g, color256.b);
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

			var albedoTex = material.HasProperty("_MainTex") ? material.GetTexture("_MainTex") : null;
			var refractionTexture = material.HasProperty("_MetallicGlossMap") ? material.GetTexture("_MetallicGlossMap") : null;
			var bumpTexture = material.HasProperty("_BumpMap") ? material.GetTexture("_BumpMap") : null;
			var emisiveTexture = material.HasProperty("_EmissionMap") ? material.GetTexture("_EmissionMap") : null;

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
				xml.AppendFormat(" alpha={{{0}}}", material.color.a);
                if (albedoTex)
                {
                    xml.AppendFormat(" albedoTexture=\"{0}\"", GetTextureRelativePath(albedoTex));
					bool b = !(material.IsKeywordEnabled ("_ALPHATEST_ON")==false && material.IsKeywordEnabled ("_ALPHABLEND_ON")==false && material.IsKeywordEnabled ("_ALPHAPREMULTIPLY_ON")==false);

					if (b) {
						xml.Append (" hasAlpha={true}");
					}else{
						xml.Append (" hasAlpha={false}");
					}
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