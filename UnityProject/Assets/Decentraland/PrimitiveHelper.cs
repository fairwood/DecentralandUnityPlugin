using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Dcl
{
    public static class PrimitiveHelper
    {
        private static Dictionary<PrimitiveType, Mesh> primitiveMeshes = new Dictionary<PrimitiveType, Mesh>();

        private static Material defaultMaterial;

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
                GameObject gameObject = GameObject.CreatePrimitive(type);
                Mesh mesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
                GameObject.DestroyImmediate(gameObject);
                primitiveMeshes[type] = mesh;
            }

            return primitiveMeshes[type];
        }

        public static Material GetDefaultMaterial()
        {
            if (!defaultMaterial)
            {
                GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
                defaultMaterial = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
                GameObject.DestroyImmediate(gameObject);
            }

            return defaultMaterial;
        }
    }
}