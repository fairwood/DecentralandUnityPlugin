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

            return gameObject;
        }

        public static Mesh GetDclPrimitiveMesh(DclPrimitiveType type)
        {
            if (!dclPrimitiveMeshes.ContainsKey(type))
            {
                var meshFolder = FileUtil.FindFolder("Decentraland/Internal");
                if (meshFolder.EndsWith("/")) meshFolder = meshFolder.Remove(meshFolder.LastIndexOf("/"), 1);
                var mesh = LoadAssetAtPath<Mesh>(String.Format("{0}/{1}.asset", meshFolder, type.ToString()));
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
                        if (meshFilter.sharedMesh == PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Cube))
                        {
                            meshFilter.sharedMesh = DclPrimitiveHelper.GetDclPrimitiveMesh(DclPrimitiveType.box);
                            converted = true;
                        }
                        else if (meshFilter.sharedMesh == PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Sphere))
                        {
                            meshFilter.sharedMesh = DclPrimitiveHelper.GetDclPrimitiveMesh(DclPrimitiveType.sphere);
                            converted = true;
                        }
                        else if (meshFilter.sharedMesh == PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Quad))
                        {
                            meshFilter.sharedMesh = DclPrimitiveHelper.GetDclPrimitiveMesh(DclPrimitiveType.plane);
                            converted = true;
                        }
                        else if (meshFilter.sharedMesh == PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Cylinder))
                        {
                            meshFilter.sharedMesh = DclPrimitiveHelper.GetDclPrimitiveMesh(DclPrimitiveType.cylinder);
                            converted = true;
                        }

                        if (converted)
                        {
                            var dclObj = gameObject.GetComponent<DclObject>();
                            if (!dclObj)
                            {
                                dclObj = gameObject.AddComponent<DclObject>();
                            }
                            dclObj.withCollision = gameObject.GetComponent<Collider>() != null;
                            EditorSceneManager.MarkSceneDirty(gameObject.scene);
                        }
                    }
                }
                //TODO:注册撤销功能
            }
        }
    }

    public enum DclPrimitiveType
    {
        box,
        circle,//TODO: not supported as primitive yet
        plane,
        sphere,
        cylinder,
        cone,
    }
}