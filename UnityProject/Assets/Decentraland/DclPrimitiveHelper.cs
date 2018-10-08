using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Dcl
{
    public static class DclPrimitiveHelper
    {
        private static Dictionary<DclPrimitiveType, Mesh> dclPrimitiveMeshes = new Dictionary<DclPrimitiveType, Mesh>();

		public static void ConvertToDclPrimitive(DclObject dclObject, PrimitiveType primitiveType){
			
			switch (primitiveType) {
			case PrimitiveType.Cube:
				dclObject.dclPrimitiveType = DclPrimitiveType.box;
				break;
			case PrimitiveType.Cylinder:
				dclObject.dclPrimitiveType = DclPrimitiveType.cylinder;
				break;
			case PrimitiveType.Sphere:
				dclObject.dclPrimitiveType = DclPrimitiveType.sphere;
				break;
			case PrimitiveType.Quad:
				dclObject.dclPrimitiveType = DclPrimitiveType.plane;
				break;
			}

			SetDclPrimitiveMesh (dclObject, dclObject.dclPrimitiveType);
		}

		public static void SetDclPrimitiveMesh(DclObject dclObject, DclPrimitiveType primitiveType){
			var meshFilter = dclObject.GetComponent<MeshFilter> ();
			switch (primitiveType) {
			case DclPrimitiveType.cone:
				{
					meshFilter.sharedMesh = Dcl.DclPrimitiveMeshBuilder.BuildCone (50, 0f, 0.5f, 1f, 0f, true, false);
				}
				break;
			case DclPrimitiveType.cylinder:
				{
					meshFilter.sharedMesh = Dcl.DclPrimitiveMeshBuilder.BuildCylinder (50, 1f, 1f, 2f, 0f, true, false); 
				}
				break;
			case DclPrimitiveType.box:
				{
					meshFilter.sharedMesh = Dcl.DclPrimitiveMeshBuilder.BuildCube (1f);
				}
				break;
			case DclPrimitiveType.plane:
				{
					meshFilter.sharedMesh = Dcl.DclPrimitiveMeshBuilder.BuildPlane (1f);
				}
				break;
			case DclPrimitiveType.sphere:
				{
					meshFilter.sharedMesh = Dcl.DclPrimitiveMeshBuilder.BuildSphere (0.5f);
				}
				break;

			}
		}

        public static GameObject CreateDclPrimitive(DclPrimitiveType type, bool withCollider = true,
            bool putOnFocusPosition = true)
        {
            GameObject gameObject = new GameObject(type.ToString());
            if (putOnFocusPosition)
            {
                gameObject.transform.position = SceneView.lastActiveSceneView.pivot;
            }

            MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
            meshFilter.sharedMesh = GetDclPrimitiveMesh(type);

            var meshRenderer = gameObject.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = PrimitiveHelper.GetDefaultMaterial();

            var dclObj = gameObject.AddComponent<DclObject>();
            dclObj.withCollision = withCollider;
			dclObj.dclPrimitiveType = type;

			SetDclPrimitiveMesh (dclObj, dclObj.dclPrimitiveType);

            return gameObject;
        }

        public static Mesh GetDclPrimitiveMesh(DclPrimitiveType type)
        {
			if(type==DclPrimitiveType.other){
				return null;
			}

			if (!dclPrimitiveMeshes.ContainsKey(type))
            {
                var meshFolder = FileUtil.FindFolder("Decentraland/Internal");
                if (meshFolder.EndsWith("/")) meshFolder = meshFolder.Remove(meshFolder.LastIndexOf("/"), 1);
                var mesh = LoadAssetAtPath<Mesh>(string.Format("{0}/{1}.asset", meshFolder, type.ToString()));
                dclPrimitiveMeshes[type] = mesh;
			}

            return dclPrimitiveMeshes[type];
        }

        internal static T LoadAssetAtPath<T>(string InPath) where T : UnityEngine.Object
        {
            return (T)AssetDatabase.LoadAssetAtPath(InPath, typeof(T));
        }

        [MenuItem("GameObject/DCL Object/Box", false, -100)]
        static void CreateBox()
        {
            CreateDclPrimitive(DclPrimitiveType.box);
        }
        [MenuItem("GameObject/DCL Object/Plane", false, -99)]
        static void CreatePlane()
        {
            CreateDclPrimitive(DclPrimitiveType.plane);
        }
        [MenuItem("GameObject/DCL Object/Sphere", false, -98)]
        static void CreateSphere()
        {
            CreateDclPrimitive(DclPrimitiveType.sphere);
        }
        [MenuItem("GameObject/DCL Object/Cylinder", false, -97)]
        static void CreateCylinder()
        {
            CreateDclPrimitive(DclPrimitiveType.cylinder);
        }
        [MenuItem("GameObject/DCL Object/Cone", false, -96)]
        static void CreateCone()
        {
            CreateDclPrimitive(DclPrimitiveType.cone);
        }

        [MenuItem("Decentraland/Convert To DCL Primitives...", false)]
        static void ConvertSelectionToDclPrimitives()
        {
            if (EditorUtility.DisplayDialog("Convert To DCL Primitives",
                "This operation will traverse all your selected objects and convert Unity Primitives to DCL Primitives. Are you sure to continue?",
                "Confirm", "Abort"))
            {
                foreach (var gameObject in Selection.gameObjects)
                {
                    var meshFilter = gameObject.GetComponent<MeshFilter>();
                    if (meshFilter)
                    {
                        var converted = false;
						PrimitiveType primitiveType = PrimitiveType.Cube;
                        if (meshFilter.sharedMesh == PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Cube))
                        {
							primitiveType = PrimitiveType.Cube;
                            converted = true;
                        }
                        else if (meshFilter.sharedMesh == PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Sphere))
                        {
							primitiveType = PrimitiveType.Sphere;
                            converted = true;
                        }
                        else if (meshFilter.sharedMesh == PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Quad))
                        {
							primitiveType = PrimitiveType.Quad;
                            converted = true;
                        }
                        else if (meshFilter.sharedMesh == PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Cylinder))
                        {
							primitiveType = PrimitiveType.Cylinder;
                            converted = true;
                        }

                        if (converted)
                        {
                            var dclObj = gameObject.GetComponent<DclObject>();
                            if (!dclObj)
                            {
                                dclObj = gameObject.AddComponent<DclObject>();
                            }
							DclPrimitiveHelper.ConvertToDclPrimitive (dclObj, primitiveType);
                            dclObj.withCollision = gameObject.GetComponent<Collider>() != null;
                            EditorSceneManager.MarkSceneDirty(gameObject.scene);
                        }
                    }
                }
                //TODO:注册撤销功能
            }
        }

        public static bool ShouldGameObjectExportAsAPrimitive(GameObject gameObject)
        {
            var meshFilter = gameObject.GetComponent<MeshFilter>();
            if (meshFilter)
            {
                foreach (DclPrimitiveType primitiveType in Enum.GetValues(typeof(DclPrimitiveType)))
                {
                    if (meshFilter.sharedMesh == DclPrimitiveHelper.GetDclPrimitiveMesh(primitiveType))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }

    public enum DclPrimitiveType
    {
        box=0,
        circle,//TODO: not supported as primitive yet
        plane,
        sphere,
        cylinder,
        cone,
		other,
    }
}