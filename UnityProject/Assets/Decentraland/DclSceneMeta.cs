using System;
using UnityEngine;
using System.Collections.Generic;

namespace Dcl
{
    [ExecuteInEditMode]
    public class DclSceneMeta : MonoBehaviour
    {
        [SerializeField] [HideInInspector] public List<ParcelCoordinates> parcels = new List<ParcelCoordinates>
        {
            new ParcelCoordinates(57, -11),
        };

        [SerializeField] [HideInInspector] public string ethAddress;
        [SerializeField] [HideInInspector] public string contactName;
        [SerializeField] [HideInInspector] public string email;

        public SceneToGlTFWiz sceneToGlTFWiz;

        public SceneStatistics sceneStatistics = new SceneStatistics();
        public SceneWarningRecorder sceneWarningRecorder = new SceneWarningRecorder();

        private void Awake()
        {
            sceneToGlTFWiz = GetComponent<SceneToGlTFWiz>();
            if (!sceneToGlTFWiz) sceneToGlTFWiz = gameObject.AddComponent<SceneToGlTFWiz>();
        }

        void Update()// OnDrawGizmos()
        {
            if (parcels.Count > 0)
            {
                var baseParcel = parcels[0];
                //            Gizmos.color = new Color(0.7, 0);
                foreach (var parcel in parcels)
                {
                    var pos = new Vector3((parcel.x - baseParcel.x) * 10, 0, (parcel.y - baseParcel.y) * 10);
                    //Gizmos.DrawWireCube(pos, new Vector3(10, 0f, 10));
                    //Gizmos.DrawCube(pos, new Vector3(10, 0f, 10));
                    //Gizmos.DrawMesh(PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Plane), pos);
                    Graphics.DrawMesh(PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Plane), pos, Quaternion.identity, PrimitiveHelper.GetDefaultMaterial(), 0);
                }
            }

            foreach (var outOfLandWarning in sceneWarningRecorder.OutOfLandWarnings)
            {
                var oriColor = Gizmos.color;
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(outOfLandWarning.meshRenderer.bounds.center, outOfLandWarning.meshRenderer.bounds.size);
                Gizmos.color = oriColor;
            }
        }

        public void RefreshStatistics()
        {
            sceneStatistics = new SceneStatistics();
            sceneWarningRecorder = new SceneWarningRecorder();
            SceneTraverser.TraverseAllScene(null, null, sceneStatistics, sceneWarningRecorder);
        }
    }

    [Serializable]
    public struct ParcelCoordinates
    {
        public ParcelCoordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int x;
        public int y;

        public static bool operator ==(ParcelCoordinates a, ParcelCoordinates b)
        {
            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(ParcelCoordinates a, ParcelCoordinates b)
        {
            return !(a == b);
        }

        public bool Equals(ParcelCoordinates other)
        {
            return x == other.x && y == other.y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ParcelCoordinates && Equals((ParcelCoordinates)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (x * 397) ^ y;
            }
        }

        public override string ToString()
        {
            return string.Format("{0},{1}", x, y);
        }
    }

    public class SceneStatistics
    {
        public long triangleCount;
        public int entityCount;
        public int bodyCount;
        public float materialCount;
        public float textureCount;
        public float maxHeight;
    }
}