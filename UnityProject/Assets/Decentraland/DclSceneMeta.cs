using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DclSceneMeta : MonoBehaviour
{
    public static List<int[]> parcels = new List<int[]>
    {
        new int[] {30, -15},
        new int[] {30, -16},
    };

    void OnDrawGizmos()
    {
        if (parcels.Count > 0)
        {
            var baseParcel = parcels[0];
//            Gizmos.color = new Color(0.7, 0);
            foreach (var parcel in parcels)
            {
                var pos = new Vector3((parcel[0] - baseParcel[0]) * 10, 0, (parcel[1] - baseParcel[1]) * 10);
                Gizmos.DrawCube(pos, new Vector3(10, 0f, 10));
            }
        }
    }
}