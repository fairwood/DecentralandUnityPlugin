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
			worldPosition -= sceneMeta.parcelPosOffset;
            if (sceneMeta && sceneMeta.parcels.Count > 0) baseParcel = sceneMeta.parcels[0];
			coordinates.x = Mathf.RoundToInt(worldPosition.x / 16) + baseParcel.x;
			coordinates.y = Mathf.RoundToInt(worldPosition.z / 16) + baseParcel.y;
            return coordinates;
        }
    }
}

#endif