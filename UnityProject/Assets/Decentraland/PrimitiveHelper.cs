using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Dcl
{
    public static class PrimitiveHelper
    {
        private static Dictionary<PrimitiveType, Mesh> primitiveMeshes = new Dictionary<PrimitiveType, Mesh>();

        public static GameObject CreatePrimitive(PrimitiveType type, bool withCollider)
        {
            if (withCollider) { return GameObject.CreatePrimitive(type); }

            GameObject gameObject = new GameObject(type.ToString());
            MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
            meshFilter.sharedMesh = GetPrimitiveMesh(type);
            gameObject.AddComponent<MeshRenderer>();

            return gameObject;
        }

        public static Mesh GetPrimitiveMesh(PrimitiveType type)
        {
            if (!primitiveMeshes.ContainsKey(type))
            {
                CreatePrimitiveMesh(type);
            }

            return primitiveMeshes[type];
        }

        static Mesh _coneMesh;
        public static Mesh ConeMesh
        {
            get
            {
                if (!_coneMesh)
                {
                    var meshFolder = FileUtil.FindFolder("Decentraland/Internal");
                    if (meshFolder.EndsWith("/")) meshFolder = meshFolder.Remove(meshFolder.LastIndexOf("/"), 1);
                    _coneMesh = LoadAssetAtPath<Mesh>(string.Format("{0}/Cone.asset", meshFolder));
                }
                return _coneMesh;
            }
        }

        [MenuItem("Decentraland/TestCone")]
        static void TestCreateCone()
        {
            Debug.Log("TC52" + _coneMesh);
            Debug.Log("TC53" + ConeMesh.name);
        }

        private static Mesh CreatePrimitiveMesh(PrimitiveType type)
        {
            GameObject gameObject = GameObject.CreatePrimitive(type);
            Mesh mesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
            GameObject.DestroyImmediate(gameObject);

            primitiveMeshes[type] = mesh;
            return mesh;
        }

        internal static T LoadAssetAtPath<T>(string InPath) where T : UnityEngine.Object
        {
            return (T)AssetDatabase.LoadAssetAtPath(InPath, typeof(T));
        }
    }
}