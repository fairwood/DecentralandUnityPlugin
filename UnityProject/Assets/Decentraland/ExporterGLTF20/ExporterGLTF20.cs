/*
 * Forked from neil3d/Unity-glTF-Exporter
 * (https://github.com/neil3d/Unity-glTF-Exporter)
 * 
 */

#if UNITY_EDITOR

using System.IO;
using UnityEngine;
using UnityEditor;

/// <summary>
/// 将 Unity 的场景或者资源导出为 glTF 2.0 标准格式
/// </summary>
public class ExporterGLTF20 : EditorWindow {

    // Fields limits
    const int NAME_LIMIT = 48;
    const int DESC_LIMIT = 1024;
    const int TAGS_LIMIT = 50;

    const int SPACE_SIZE = 5;
    Vector2 DESC_SIZE = new Vector2(512, 64);

    GameObject mExporterGo;
    SceneToGlTFWiz mExporter;
    string mExportPath = "";

    string mStatus = "";
    string mResult = "";
    GUIStyle mTextAreaStyle;
    GUIStyle mStatusStyle;

    private bool mExportAnimation = true;
    private bool mExportPBR = true;
    private bool mBuildZip = false;
    private bool mConvertImage = true;
    private string mParamName = "";
    private string mParamDescription = "";
    private string mParamTags = "";

    void OnEnable() {
        this.minSize = new Vector2(400, 512);

        if (mExporterGo == null) {
            mExporterGo = new GameObject("Exporter");
            mExporter = mExporterGo.AddComponent<SceneToGlTFWiz>();
            mExporterGo.hideFlags = HideFlags.HideAndDontSave;
        }
    }

    void OnDisable() {
        if (mExporterGo != null) {
            GameObject.DestroyImmediate(mExporterGo);
            mExporterGo = null;
        }

    }

    void OnSelectionChange() {
        updateExporterStatus();
        Repaint();
    }

    void OnGUI() {

        if (mTextAreaStyle == null) {
            mTextAreaStyle = new GUIStyle(GUI.skin.textArea);
            mTextAreaStyle.fixedWidth = DESC_SIZE.x;
            mTextAreaStyle.fixedHeight = DESC_SIZE.y;
        }

        if (mStatusStyle == null) {
            mStatusStyle = new GUIStyle(EditorStyles.label);
            mStatusStyle.richText = true;
        }

        // Export path
        GUILayout.Label("Export Path", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        mExportPath = EditorGUILayout.TextField(mExportPath);
        if (GUILayout.Button("...", GUILayout.Width(48), GUILayout.Height(16))) {
            mExportPath = EditorUtility.OpenFolderPanel("Export Path", mExportPath, "");
        }
        GUILayout.EndHorizontal();

        // Model settings
        GUILayout.Label("Model properties", EditorStyles.boldLabel);

        // Model name
        GUILayout.Label("Name");
        mParamName = EditorGUILayout.TextField(mParamName);
        GUILayout.Label("(" + mParamName.Length + "/" + NAME_LIMIT + ")", EditorStyles.centeredGreyMiniLabel);
        EditorStyles.textField.wordWrap = true;
        GUILayout.Space(SPACE_SIZE);

        GUILayout.Label("Description");
        mParamDescription = EditorGUILayout.TextArea(mParamDescription, mTextAreaStyle);
        GUILayout.Label("(" + mParamDescription.Length + " / 1024)", EditorStyles.centeredGreyMiniLabel);
        GUILayout.Space(SPACE_SIZE);

        GUILayout.Label("Tags (separated by spaces)");
        mParamTags = EditorGUILayout.TextField(mParamTags);
        GUILayout.Label("'unity' and 'unity3D' added automatically (" + mParamTags.Length + "/50)", EditorStyles.centeredGreyMiniLabel);
        GUILayout.Space(SPACE_SIZE);

        GUILayout.Label("Options", EditorStyles.boldLabel);
        GUILayout.BeginVertical();
        mExportPBR = EditorGUILayout.Toggle("Export PBR Material", mExportPBR);
        mExportAnimation = EditorGUILayout.Toggle("Export animation (beta)", mExportAnimation);
        mConvertImage = EditorGUILayout.Toggle("Convert Images", mConvertImage);
        mBuildZip = EditorGUILayout.Toggle("Build Zip", mBuildZip);
        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();

        GUILayout.Space(SPACE_SIZE);

        bool enable = updateExporterStatus();

        GUILayout.Label("Status", EditorStyles.boldLabel);

        if (enable)
            GUILayout.Label(string.Format("<color=#0F0F0FFF>{0}</color>", mStatus), mStatusStyle);
        else
            GUILayout.Label(string.Format("<color=#F00F0FFF>{0}</color>", mStatus), mStatusStyle);

        if (mResult.Length > 0)
            GUILayout.Label(string.Format("<color=#0F0F0FFF>{0}</color>", mResult), mStatusStyle);


        GUILayout.Space(SPACE_SIZE);
        GUI.enabled = enable;
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Export Selection", GUILayout.Width(220), GUILayout.Height(32))) {
            if (!enable) {
                EditorUtility.DisplayDialog("Error", mStatus, "Ok");
            }
            else {
                string exportFileName = Path.Combine(mExportPath, mParamName + ".gltf");
                mExporter.ExportCoroutine(exportFileName, null, mBuildZip, mExportPBR, mExportAnimation, mConvertImage);
                mResult = string.Format("Exort Finished: {0}", exportFileName);
            }
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        // Banner
        GUILayout.Space(SPACE_SIZE*2);
        GUI.enabled = true;
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        string url = "https://neil3d.github.io/app/unity-gltf-exporter.html";
        if (GUILayout.Button("Document: "+ url, EditorStyles.helpBox)) {
            Application.OpenURL(url);
        }
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.Space(SPACE_SIZE * 2);
    }

    private bool updateExporterStatus() {
        mStatus = "";

        int nbSelectedObjects = Selection.GetTransforms(SelectionMode.Deep).Length;
        if (nbSelectedObjects == 0) {
            mStatus = "No object selected to export";
            return false;
        }

        if (mExportPath.Length == 0) {
            mStatus = "Please set export path";
            return false;
        }

        if (mParamName.Length > NAME_LIMIT) {
            mStatus = "Model name is too long";
            return false;
        }


        if (mParamName.Length == 0) {
            mStatus = "Please give a name to your model";
            return false;
        }


        if (mParamDescription.Length > DESC_LIMIT) {
            mStatus = "Model description is too long";
            return false;
        }


        if (mParamTags.Length > TAGS_LIMIT) {
            mStatus = "Model tags are too long";
            return false;
        }

        mStatus = "Export " + nbSelectedObjects + " object" + (nbSelectedObjects != 1 ? "s" : "");
        return true;
    }

    [MenuItem("Decentraland/glTF Exporter(trial)")]
    static void Init() {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX // edit: added Platform Dependent Compilation - win or osx standalone
        ExporterGLTF20 window = (ExporterGLTF20)EditorWindow.GetWindow(typeof(ExporterGLTF20));
        window.titleContent.text = "glTF 2.0 Exporter";
        window.Show();
#else // and error dialog if not standalone
		EditorUtility.DisplayDialog("Error", "Your build target must be set to standalone", "Okay");
#endif
    }
}

#endif