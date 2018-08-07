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

    }
}