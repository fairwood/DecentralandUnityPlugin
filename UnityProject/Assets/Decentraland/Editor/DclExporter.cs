using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DclExporter : EditorWindow
{
    [MenuItem("Decentraland/Scene Exporter")]
    static void Init()
    {
        var window = (DclExporter)GetWindow(typeof(DclExporter));
        window.Show();
    }

    void OnGUI()
    {
        var parcelCount = 16;

		EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(string.Format("Parcels({0})", parcelCount));
        GUILayout.Button("Edit");
        EditorGUILayout.EndHorizontal();
        if (GUILayout.Button("Hey")){
            GetSceneFileTemplate();
        }
    }

    string GetSceneFileTemplate()
    {
        var guids = AssetDatabase.FindAssets("dcl_scene_template");
        if (guids.Length <= 0)
        {
            if (EditorUtility.DisplayDialog("Cannot find dcl_scene_template.txt in the project!", "Please re-install Decentraland Unity Plugin asset to fix this problem.", "Re-install", "Back"))
            {
                //TODO:
            }
            return null;
        }
        var path = AssetDatabase.GUIDToAssetPath(guids[0]);
        Debug.Log("Path:" + path);
        var template = AssetDatabase.LoadAssetAtPath(path, typeof(TextAsset)) as TextAsset;
        Debug.Log("Txt:" + template.text);
        return template.text;
    }
}