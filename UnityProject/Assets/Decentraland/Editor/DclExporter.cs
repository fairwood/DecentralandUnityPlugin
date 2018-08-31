using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dcl
{
    public class DclExporter : EditorWindow
    {
        const int SPACE_SIZE = 5;

        [MenuItem("Decentraland/Scene Exporter")]
        static void Init()
        {
            var window = (DclExporter)GetWindow(typeof(DclExporter));
            window.Show();
            window.minSize = new Vector2(100, 200);
        }

        private DclSceneMeta sceneMeta;

        public List<string> warnings = new List<string>
        {
            //        "Out of land range! at (12,-32)",
            //        "Too many triangles! at (12,-32)",
            //        "Too large texture! at (12,-32)",
            //        "Unsupported shader! at (12,-32)"
        };

        private bool editParcelsMode;
        private string editParcelsText;

        private string exportPath;
        
        void OnGUI()
        {
            if (!sceneMeta)
            {
                CheckAndGetDclSceneMetaObject();
            }

            #region Parcels

            var parcels = sceneMeta.parcels;
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label(string.Format("Parcels({0})", parcels.Count), EditorStyles.boldLabel, GUILayout.Width(100));
            if (editParcelsMode)
            {
                if (GUILayout.Button("Save"))
                {
                    CheckAndGetDclSceneMetaObject();
                    try
                    {
                        var newParcels = new List<ParcelCoordinates>();
                        ParseTextToCoordinates(editParcelsText, newParcels);
                        parcels = newParcels;
                        sceneMeta.parcels = parcels;
                        editParcelsMode = false;
                    }
                    catch (Exception e)
                    {
                        Debug.LogError(e.Message);
                        EditorUtility.DisplayDialog("Invalid Format", e.Message, "OK");
                    }

                    EditorUtility.SetDirty(sceneMeta);
                    EditorSceneManager.MarkSceneDirty(sceneMeta.gameObject.scene);

                }

                if (GUILayout.Button("X", GUILayout.Width(20)))
                {
                    editParcelsMode = false;
                    CheckAndGetDclSceneMetaObject();
                }
            }
            else
            {
                if (GUILayout.Button("Edit"))
                {
                    var sb = new StringBuilder();
                    if (parcels.Count > 0)
                    {
                        sb.Append(ParcelToStringBuilder(parcels[0]));
                        for (int i = 1; i < parcels.Count; i++)
                        {
                            sb.Append('\n').Append(ParcelToStringBuilder(parcels[i]));
                        }
                    }
                    editParcelsText = sb.ToString();
                    editParcelsMode = true;
                    CheckAndGetDclSceneMetaObject();
                }
            }
            EditorGUILayout.EndHorizontal();
            if (editParcelsMode)
            {
                editParcelsText = EditorGUILayout.TextArea(editParcelsText, GUILayout.Height(200));
            }
            else
            {
                var sb = new StringBuilder();
                if (parcels.Count > 0)
                {
                    sb.Append(ParcelToStringBuilder(parcels[0])).Append(" (base)");
                    for (int i = 1; i < parcels.Count; i++)
                    {
                        sb.Append('\n').Append(ParcelToStringBuilder(parcels[i]));
                    }
                }
                EditorGUILayout.LabelField(sb.ToString(), GUILayout.Height(200));
            }


            #endregion

            InfoGUI();
            GUILayout.Space(SPACE_SIZE);

            ShowWarningsSector();
            GUILayout.Space(SPACE_SIZE);

            EditorGUI.BeginChangeCheck();

            OptionsGUI();
            GUILayout.Space(SPACE_SIZE);

            GUILayout.Label("Owner Info(optional)", EditorStyles.boldLabel);
            sceneMeta.ethAddress = EditorGUILayout.TextField("Address", sceneMeta.ethAddress);
            sceneMeta.contactName = EditorGUILayout.TextField("Name", sceneMeta.contactName);
            sceneMeta.email = EditorGUILayout.TextField("Email", sceneMeta.email);

            GUILayout.Label("Export Path", EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal();
            exportPath = EditorPrefs.GetString("DclExportPath");
            var newExportPath = EditorGUILayout.TextField(exportPath);
            if (GUILayout.Button("...", GUILayout.Width(24)))
            {
                newExportPath = EditorUtility.OpenFolderPanel("Select the folder to export", exportPath, "");
                if (string.IsNullOrEmpty(newExportPath)) newExportPath = exportPath;
            }
            if (newExportPath != exportPath)
            {
                exportPath = newExportPath;
                EditorPrefs.SetString("DclExportPath", newExportPath);
            }

            EditorGUILayout.EndHorizontal();


            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(sceneMeta);
                EditorSceneManager.MarkSceneDirty(sceneMeta.gameObject.scene);
            }

            GUILayout.Space(SPACE_SIZE);

            GUILayout.BeginHorizontal(); GUILayout.FlexibleSpace();
            var oriColor = GUI.backgroundColor;
            GUI.backgroundColor = Color.green;
            if (GUILayout.Button("Export", GUILayout.Width(220), GUILayout.Height(32)))
            {
                Export();
            }
            GUI.backgroundColor = oriColor;
            GUILayout.FlexibleSpace(); GUILayout.EndHorizontal();

            GUILayout.Space(SPACE_SIZE * 2);

            #region Help Link

            string url = "https://github.com/fairwood/DecentralandUnityPlugin";
            if (GUILayout.Button(string.Format(LabelLocalization.Document, url), EditorStyles.helpBox))
            {
                Application.OpenURL(url);
            }

            #endregion
        }

        void InfoGUI()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Statistics", EditorStyles.boldLabel, GUILayout.Width(100));
            if (GUILayout.Button("Refresh"))
            {
                sceneMeta.RefreshStatistics();
            }
            EditorGUILayout.EndHorizontal();
            GUILayout.Label(LabelLocalization.KeepTheseNumbersSmaller, EditorStyles.centeredGreyMiniLabel);
            var n = sceneMeta.parcels.Count;
            var sceneStatistics = sceneMeta.sceneStatistics;
            EditorGUILayout.LabelField("Triangles", string.Format("{0} / {1}", sceneStatistics.triangleCount, LimitationConfigs.GetMaxTriangles(n)));
            EditorGUILayout.LabelField("Entities", string.Format("{0} / {1}", sceneStatistics.entityCount, LimitationConfigs.GetMaxTriangles(n)));
            EditorGUILayout.LabelField("Bodies", string.Format("{0} / {1}", sceneStatistics.bodyCount, LimitationConfigs.GetMaxBodies(n)));
            EditorGUILayout.LabelField("Materials", string.Format("{0} / {1}", sceneStatistics.materialCount, LimitationConfigs.GetMaxMaterials(n)));
            EditorGUILayout.LabelField("Textures", string.Format("{0} / {1}", sceneStatistics.textureCount, LimitationConfigs.GetMaxTextures(n)));
            EditorGUILayout.LabelField("Height", string.Format("{0} / {1}", sceneStatistics.maxHeight, LimitationConfigs.GetMaxHeight(n)));
        }

        private float nextTimeRefresh = 0;
        private void Update()
        {
            if (Time.realtimeSinceStartup > nextTimeRefresh)
            {
                sceneMeta.RefreshStatistics();
                Repaint();
                nextTimeRefresh = Time.realtimeSinceStartup + 2;
            }
        }

        void ShowWarningsSector()
        {
            var oriColor = GUI.contentColor;
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label(string.Format("Warnings({0})", warnings.Count));
            EditorGUILayout.EndHorizontal();
            var sb = new StringBuilder();
            if (warnings.Count > 0)
            {
                GUILayout.Label("Click the warning to focus in the scene", EditorStyles.centeredGreyMiniLabel);

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

        void OptionsGUI()
        {
            GUILayout.Label("Options", EditorStyles.boldLabel);
            //mExportPBR = EditorGUILayout.Toggle("Export PBR Material", mExportPBR);
            //mExportAnimation = EditorGUILayout.Toggle("Export animation (beta)", mExportAnimation);
            //mConvertImage = EditorGUILayout.Toggle("Convert Images", mConvertImage);
            //mBuildZip = EditorGUILayout.Toggle("Build Zip", mBuildZip);
        }

        string GetSceneTsxFileTemplate()
        {
            var guids = AssetDatabase.FindAssets("dcl_scene_tsx_template");
            if (guids.Length <= 0)
            {
                if (EditorUtility.DisplayDialog("Cannot find dcl_scene_tsx_template.txt in the project!",
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

        string GetSceneJsonFileTemplate()
        {
            var guids = AssetDatabase.FindAssets("dcl_scene_json_template");
            if (guids.Length <= 0)
            {
                if (EditorUtility.DisplayDialog("Cannot find dcl_scene_json_template.txt in the project!",
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

        string GetParcelsString()
        {
            /*
          "30,-15",
          "30,-16",
          "31,-15"*/
            var sb = new StringBuilder();
            if (sceneMeta.parcels.Count > 0)
            {
                const string indentUnit = "  ";
                sb.AppendIndent(indentUnit, 3).Append(ParcelToString(sceneMeta.parcels[0]));
                for (var i = 1; i < sceneMeta.parcels.Count; i++)
                {
                    sb.Append(",\n");
                    sb.AppendIndent(indentUnit, 3).Append(ParcelToString(sceneMeta.parcels[i]));
                }
            }

            return sb.ToString();
        }

        void CheckAndGetDclSceneMetaObject()
        {
            var rootGameObjects = new List<GameObject>();
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var roots = SceneManager.GetSceneAt(i).GetRootGameObjects();
                rootGameObjects.AddRange(roots);
            }

            foreach (var go in rootGameObjects)
            {
                if (go.name == ".dcl")
                {
                    sceneMeta = go.GetComponent<DclSceneMeta>();
                    if (!sceneMeta)
                    {
                        sceneMeta = go.AddComponent<DclSceneMeta>();
                        EditorUtility.SetDirty(sceneMeta);
                        EditorSceneManager.MarkSceneDirty(go.scene);
                    }

                    return;
                }
            }

            //Did not find .dcl object. Create one.
            var o = new GameObject(".dcl");
            sceneMeta = o.AddComponent<DclSceneMeta>();
            EditorUtility.SetDirty(sceneMeta);
            EditorSceneManager.MarkSceneDirty(o.scene);
        }

        void Export()
        {
            if (string.IsNullOrEmpty(exportPath))
            {
                EditorUtility.DisplayDialog("NO Path!", "You must assign the export path!", null, "OK");
                return;
            }

            if (!Directory.Exists(exportPath)) Directory.CreateDirectory("exportPath");

            //delete all files in exportPath/unity_assets/

            var unityAssetsFolderPath = Path.Combine(exportPath, "unity_assets/");
            if (Directory.Exists(unityAssetsFolderPath))
            {
                ClearFolder(unityAssetsFolderPath);
            }
            else
            {
                Directory.CreateDirectory(unityAssetsFolderPath);
            }

            var meshesToExport = new List<GameObject>();
            var sceneXmlBuilder = new StringBuilder();
            var statistics = new SceneStatistics();

            SceneTraverser.TraverseAllScene(sceneXmlBuilder, meshesToExport, statistics);

            var sceneXml = sceneXmlBuilder.ToString();

            //scene.tsx
            var fileTxt = GetSceneTsxFileTemplate();
            fileTxt = fileTxt.Replace("{XML}", sceneXml);
            var filePath = Path.Combine(exportPath, "scene.tsx");
            File.WriteAllText(filePath, fileTxt);

            //glTF in unity_asset
            foreach (var go in meshesToExport)
            {
                sceneMeta.sceneToGlTFWiz.ExportGameObject(go, Path.Combine(unityAssetsFolderPath, go.name + ".gltf"), null, false, true, false, false);
            }

            //textures
            var primitiveTexturesToExport = SceneTraverser.primitiveTexturesToExport;
            foreach (var texture in primitiveTexturesToExport)
            {
                var relPath = AssetDatabase.GetAssetPath(texture);
                if (string.IsNullOrEmpty(relPath))
                {
                    //TODO: built-in asset
                }
                else
                {
                    var path = Application.dataPath; //<path to project folder>/Assets
                    path = path.Remove(path.Length - 6, 6) + relPath;
                    var toPath = unityAssetsFolderPath + relPath;
                    var directoryPath = Path.GetDirectoryName(toPath);
                    if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
                    File.Copy(path, toPath, true);
                }
            }

            //scene.json
            fileTxt = GetSceneJsonFileTemplate();
            fileTxt = fileTxt.Replace("{ETH_ADDRESS}", sceneMeta.ethAddress);
            fileTxt = fileTxt.Replace("{CONTACT_NAME}", sceneMeta.contactName);
            fileTxt = fileTxt.Replace("{CONTACT_EMAIL}", sceneMeta.email);
            var parcelsString = GetParcelsString();
            fileTxt = fileTxt.Replace("{PARCELS}", parcelsString);
            if (sceneMeta.parcels.Count > 0)
            {
                fileTxt = fileTxt.Replace("{BASE}", ParcelToString(sceneMeta.parcels[0]));
            }
            filePath = Path.Combine(exportPath, "scene.json");
            File.WriteAllText(filePath, fileTxt);

            Debug.Log("===Export Complete===");
        }

        #region Utils
        
        public static void ParseTextToCoordinates(string text, List<ParcelCoordinates> coordinates)
        {
            coordinates.Clear();
            var lines = text.Replace("\r", "").Split('\n');
            foreach (var line in lines)
            {
                var elements = line.Trim().Split(',');
                if (elements.Length == 0) continue;
                if (elements.Length != 2)
                {
                    throw new Exception("A line does not have exactly 2 elements!");
                }

                var x = int.Parse(elements[0]);
                var y = int.Parse(elements[1]);
                coordinates.Add(new ParcelCoordinates(x, y));
            }
        }

        public static StringBuilder ParcelToStringBuilder(ParcelCoordinates parcel)
        {
            return new StringBuilder().Append(parcel.x).Append(',').Append(parcel.y);
        }

        public static StringBuilder WarningToStringBuilder(string warning)
        {
            return new StringBuilder().Append(warning);
        }

        public static string Vector3ToJSONString(Vector3 v)
        {
            return string.Format("{{x:{0},y:{1},z:{2}}}", v.x, v.y, v.z);
        }

        /// <summary>
        /// Color to HEX string(e.g. #AAAAAA)
        /// </summary>
        private static string ToHexString(Color color)
        {
            var color256 = (Color32)color;
            string R = Convert.ToString(color256.r, 16);
            if (R == "0")
                R = "00";
            string G = Convert.ToString(color256.g, 16);
            if (G == "0")
                G = "00";
            string B = Convert.ToString(color256.b, 16);
            if (B == "0")
                B = "00";
            string HexColor = "#" + R + G + B;
            return HexColor.ToUpper();
        }

        public static string ParcelToString(ParcelCoordinates parcel)
        {
            return string.Format("\"{0},{1}\"", parcel.x, parcel.y);
        }

        /// <summary>
        /// Clear all content including files & folders in a folder
        /// by [x_蜡笔小新](https://www.cnblogs.com/XuPengLB/p/6393117.html)
        /// </summary>
        /// <param name="dir"></param>
        public static void ClearFolder(string dir)
        {
            foreach (string d in Directory.GetFileSystemEntries(dir))
            {
                if (File.Exists(d))
                {
                    try
                    {
                        FileInfo fi = new FileInfo(d);
                        if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                            fi.Attributes = FileAttributes.Normal;
                        File.Delete(d);//直接删除其中的文件 
                    }
                    catch
                    {

                    }
                }
                else
                {
                    try
                    {
                        DirectoryInfo d1 = new DirectoryInfo(d);
                        if (d1.GetFiles().Length != 0)
                        {
                            ClearFolder(d1.FullName);////递归删除子文件夹
                        }
                        Directory.Delete(d);
                    }
                    catch
                    {

                    }
                }
            }
        }

        #endregion
    }
}