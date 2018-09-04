using UnityEngine;
using System.Collections.Generic;
using Dcl;
using UnityEditor;

[InitializeOnLoad]
public class DclCustomHierarchy
{

    static Texture2D texture;
    static List<int> markedObjects;

    static DclCustomHierarchy()
    {
        // Init
        texture = DclEditorSkin.ErrorIcon;
        EditorApplication.update += UpdateCB;
        EditorApplication.hierarchyWindowItemOnGUI += HierarchyItemCB;
    }

    static void UpdateCB()
    {
        // Check here
        GameObject[] go = Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];

        markedObjects = new List<int>();
        foreach (GameObject g in go)
        {
            markedObjects.Add(g.GetInstanceID());
        }

    }

    static void HierarchyItemCB(int instanceID, Rect selectionRect)
    {
        // place the icoon to the right of the list:
        Rect r = new Rect(selectionRect);
        r.x = r.xMin-30;
        r.width = 18;

        if (markedObjects.Contains(instanceID))
        {
            // Draw the texture if it's a light (e.g.)
            GUI.Label(r, new GUIContent(texture, "Hahaha tooltip"));
        }
    }
}
