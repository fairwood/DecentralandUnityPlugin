using System.IO;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    string exportPath = "";
    
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
        exportPath = EditorGUILayout.TextField(exportPath);
        var oriColor = GUI.backgroundColor;
        GUI.backgroundColor = Color.green;
        if (GUILayout.Button("Export"))
        {
            Export();
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

    const string indentUnit = "  ";

    string GetSceneXml()
    {
        var rootGameObjects = new List<GameObject>();
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var roots = SceneManager.GetSceneAt(i).GetRootGameObjects();
            rootGameObjects.AddRange(roots);
        }


        var sceneXml = new StringBuilder();
        AppendIndent(sceneXml, indentUnit, 3);
        sceneXml.AppendFormat("<scene position={{{0}}}>\n", Vector3ToJSONString(new Vector3(5, 0, 5)));
        foreach (var rootGO in rootGameObjects)
        {
            sceneXml.Append(RecursivelyGetNodeXml(rootGO.transform, 4));
        }
        AppendIndent(sceneXml, indentUnit, 3);
        sceneXml.Append("</scene>");

        return sceneXml.ToString();
    }

    StringBuilder RecursivelyGetNodeXml(Transform tra, int indentLevel)
    {
        StringBuilder xmlNode = null;
        StringBuilder xmlNodeTail = null;
        var components = tra.GetComponents<Component>();
        string nodeName = null;
        var extraProperties = new StringBuilder();
        foreach (var component in components)
        {
            if (component is Transform) continue;
            if (component is MeshFilter)
            {
                var meshFilter = component as MeshFilter;
                if (meshFilter.sharedMesh == PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Cube))
                {
                    nodeName = "box";
                }
                else if (meshFilter.sharedMesh == PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Sphere))
                {
                    nodeName = "sphere";
                }
                else if (meshFilter.sharedMesh == PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Quad))
                {
                    nodeName = "plane";
                }
                else if (meshFilter.sharedMesh == PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Cylinder))
                {
                    nodeName = "cylinder";
                    extraProperties.Append(" radius={0.5}");
                }

            }
        }
        if (nodeName == null)
        {
            nodeName = "entity";
        }
        xmlNode = new StringBuilder();
        AppendIndent(xmlNode, indentUnit, indentLevel);
        xmlNode.AppendFormat("<{0} position={{{1}}} scale={{{2}}} rotation={{{3}}}{4}>", nodeName, Vector3ToJSONString(tra.localPosition), Vector3ToJSONString(tra.localScale), Vector3ToJSONString(tra.localEulerAngles), extraProperties);
        xmlNodeTail = new StringBuilder().AppendFormat("</{0}>\n", nodeName);

        var childrenXmls = new List<StringBuilder>();
        foreach (Transform child in tra)
        {
            var childXml = RecursivelyGetNodeXml(child, indentLevel + 1);
            if (childXml != null) childrenXmls.Add(childXml);
        }

        Debug.Log(tra.name);

        if (childrenXmls.Count == 0)
        {
            if (xmlNode == null)
            {
                return null;
            }
            else
            {
                return xmlNode.Append(xmlNodeTail);
            }
        }
        else
        {
            if (xmlNode == null)
            {
                foreach (var childXml in childrenXmls)
                {
                    xmlNode.Append(childXml);
                }
                return xmlNode.Append(xmlNodeTail);
            }
            else
            {
                xmlNode.Append("\n");
                foreach (var childXml in childrenXmls)
                {
                    xmlNode.Append(childXml);
                }
                AppendIndent(xmlNode, indentUnit, indentLevel);
                return xmlNode.Append(xmlNodeTail);
            }
        }
    }

    static StringBuilder AppendIndent(StringBuilder sb, string indentUnit, int indentLevel)
    {
        for (int i = 0; i < indentLevel; i++)
        {
            sb.Append(indentUnit);
        }
        return sb;
    }

    void Export()
    {
        if (string.IsNullOrEmpty(exportPath))
        {
            EditorUtility.DisplayDialog("NO Path!", "You must assign the export path!", null, "OK");
            return;
        }

        var fileTxt = GetSceneFileTemplate();
        var sceneXml = GetSceneXml();
        fileTxt = fileTxt.Replace("{XML}", sceneXml);

        if (!Directory.Exists(exportPath)) Directory.CreateDirectory("exportPath");
        var filePath = Path.Combine(exportPath, "scene.tsx");
        File.WriteAllText(filePath, fileTxt);
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

    public static string Vector3ToJSONString(Vector3 v)
    {
        return string.Format("{{x:{0},y:{1},z:{2}}}", v.x, v.y, v.z);
    }

    #endregion
}