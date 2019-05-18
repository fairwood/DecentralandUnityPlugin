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
		public Material m_GroundMaterial;

		public readonly Vector3 parcelPosOffset = new Vector3(8f, 0f, 8f);

        private void Awake()
        {
            sceneToGlTFWiz = GetComponent<SceneToGlTFWiz>();
            if (!sceneToGlTFWiz) sceneToGlTFWiz = gameObject.AddComponent<SceneToGlTFWiz>();
			m_GroundMaterial = new Material(PrimitiveHelper.GetDefaultMaterial().shader);
			m_GroundMaterial.color = Color.gray;
        }

        void Update()// OnDrawGizmos()
        {
            if (parcels.Count > 0)
            {
                var baseParcel = parcels[0];
                var mtr = new Matrix4x4();
                foreach (var parcel in parcels)
                {
                    var pos = new Vector3((parcel.x - baseParcel.x) * 16, 0, (parcel.y - baseParcel.y) * 16);
					pos += parcelPosOffset;
                    mtr.SetTRS(pos, Quaternion.identity, new Vector3(1.6f, 1f, 1.6f));
					Graphics.DrawMesh(PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Plane), mtr, m_GroundMaterial, 0);
                }
            }
        }

        void OnDrawGizmos()
        {
            foreach (var outOfLandWarning in sceneWarningRecorder.OutOfLandWarnings)
            {
                var oriColor = Gizmos.color;
                Gizmos.color = Color.red;
                if (outOfLandWarning.meshRenderer)
                {
                    Gizmos.DrawWireCube(outOfLandWarning.meshRenderer.bounds.center, outOfLandWarning.meshRenderer.bounds.size);
                }
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
        public readonly List<Material> gltfMaterials = new List<Material>(); //to record the materials inside a GLTF model. clear this when traverse into a new GLTF object.
    }
}