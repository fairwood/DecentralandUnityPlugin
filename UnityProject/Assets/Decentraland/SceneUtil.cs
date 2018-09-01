#if UNITY_EDITOR
using UnityEngine;

namespace Dcl
{
    public static class SceneUtil
    {
        public static ParcelCoordinates GetParcelCoordinates(Vector3 worldPosition)
        {
            var coordinates = new ParcelCoordinates();
            var baseParcel = new ParcelCoordinates(0, 0);
            var sceneMeta = Object.FindObjectOfType<DclSceneMeta>();
            if (sceneMeta && sceneMeta.parcels.Count > 0) baseParcel = sceneMeta.parcels[0];
            coordinates.x = Mathf.RoundToInt(worldPosition.x / 10) + baseParcel.x;
            coordinates.y = Mathf.RoundToInt(worldPosition.z / 10) + baseParcel.y;
            return coordinates;
        }
    }
}

#endif