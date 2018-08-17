using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

public class DclExporter : EditorWindow
{
    [MenuItem("Decentraland/Scene Exporter")]
    static void Init()
    {
        var window = (DclExporter) GetWindow(typeof(DclExporter));
        window.Show();
    }

    public List<int[]> parcels = new List<int[]>
    {
        new int[] {30, -15},
        new int[] {30, -16},
    };

    public List<string> warnings = new List<string>
    {
        "Out of land range! at (12,-32)",
        "Too many triangles! at (12,-32)",
        "Too large texture! at (12,-32)",
        "Unsupported shader! at (12,-32)",
    };
    
    void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(string.Format("Parcels({0})", parcels.Count));
        GUILayout.Button("Edit");
        EditorGUILayout.EndHorizontal();
        //parcels
        var sb = new StringBuilder();
        if (parcels.Count > 0)
        {
            sb.Append(ParcelToStringBuilder(parcels[0]));
            for (int i = 1; i < parcels.Count; i++)
            {
                sb.Append('\n').Append(ParcelToStringBuilder(parcels[i]));
            }
        }

        EditorGUILayout.TextArea(sb.ToString(), GUILayout.Height(200));
        ShowWarningsSector();
        EditorGUILayout.LabelField("Export Path");
        EditorGUILayout.TextField("");
        var oriColor = GUI.backgroundColor;
        GUI.backgroundColor = Color.green;
        if (GUILayout.Button("Export"))
        {
            GetSceneFileTemplate();
        }
        GUI.backgroundColor = oriColor;
    }

    void ShowWarningsSector()
    {
        var oriColor = GUI.contentColor;
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(string.Format("Warnings({0})", parcels.Count));
        GUILayout.Button("Refresh");
        EditorGUILayout.EndHorizontal();
        var sb = new StringBuilder();
        if (warnings.Count > 0)
        {
            GUI.contentColor = new Color(0.8f, 0.8f, 0.8f);
            EditorGUILayout.LabelField("Click the warning to focus in the scene");

            sb.Append(WarningToStringBuilder(warnings[0]));
            for (int i = 1; i < warnings.Count; i++)
            {
                sb.Append('\n').Append(WarningToStringBuilder(warnings[i]));
            }
        }

        GUI.contentColor = new Color(1, 1f, 0f);
        EditorGUILayout.LabelField(sb.ToString(), GUILayout.Height(200));

        GUI.contentColor = oriColor;
    }

    string GetSceneFileTemplate()
    {
        var guids = AssetDatabase.FindAssets("dcl_scene_template");
        if (guids.Length <= 0)
        {
            if (EditorUtility.DisplayDialog("Cannot find dcl_scene_template.txt in the project!",
                "Please re-install Decentraland Unity Plugin asset to fix this problem.", "Re-install", "Back"))
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

    #region Utils

    public static StringBuilder ParcelToStringBuilder(int[] parcel)
    {
        return new StringBuilder().Append(parcel[0]).Append(',').Append(parcel[1]);
    }

    public static StringBuilder WarningToStringBuilder(string warning)
    {
        return new StringBuilder().Append(warning);
    }

    #endregion
}