using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DclSceneMeta : MonoBehaviour
{
    [SerializeField][HideInInspector]
    public List<ParcelCoordinates> parcels = new List<ParcelCoordinates>
    {
        new ParcelCoordinates(30, -15),
        new ParcelCoordinates(30, -16),
    };

    [SerializeField] [HideInInspector] public string exportPath;

    void OnDrawGizmos()
    {
        if (parcels.Count > 0)
        {
            var baseParcel = parcels[0];
//            Gizmos.color = new Color(0.7, 0);
            foreach (var parcel in parcels)
            {
                var pos = new Vector3((parcel.x - baseParcel.x) * 10, 0, (parcel.y - baseParcel.y) * 10);
                Gizmos.DrawCube(pos, new Vector3(10, 0f, 10));
            }
        }
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
}