using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dcl
{

	public static class LanguageChoose
	{
		private const string menu_CN = "Decentraland/Language/中文";
		private const string menu_EN = "Decentraland/Language/English";

		private static void ClearChecked()
		{
			Menu.SetChecked(menu_CN, false);
			Menu.SetChecked(menu_EN, false);
		}

		private static void chooseLanguage(LabelLocalization.ELanguage l){
			LabelLocalization.Language = l;
			LabelLocalization.loadLanguageStringFromFile ();
		}

		[MenuItem(menu_CN)]
		private static void CN()
		{
			chooseLanguage(LabelLocalization.ELanguage.CN);

			ClearChecked();
			Menu.SetChecked(menu_CN, true);
		}

		[MenuItem(menu_EN)]
		private static void EN()
		{
			chooseLanguage(LabelLocalization.ELanguage.EN);

			ClearChecked();
			Menu.SetChecked(menu_EN, true);
		}

	}

    public class DclExporter : EditorWindow
    {
        const int SPACE_SIZE = 5;

        [MenuItem("Decentraland/Scene Exporter", false, 1)]
        static void Init()
        {
            var window = (DclExporter) GetWindow(typeof(DclExporter));
			window.titleContent = new GUIContent(LabelLocalization.getString(LanguageStringValue.DCLExporter));
            window.Show();
            window.minSize = new Vector2(240, 400);
        }

        private DclSceneMeta sceneMeta;

        private bool editParcelsMode;
        private string editParcelsText;

        private string exportPath;

        private GameObject prefab;

        void OnGUI()
        {
            if (!sceneMeta)
            {
                CheckAndGetDclSceneMetaObject();
            }

            ParcelGUI();
            GUILayout.Space(SPACE_SIZE);

            StatGUI();
            GUILayout.Space(SPACE_SIZE);

            EditorGUI.BeginChangeCheck();

            //OptionsGUI(); no use yet
            //GUILayout.Space(SPACE_SIZE);

            OwnerGUI();
            GUILayout.Space(SPACE_SIZE);
            
            ExportForDCLGUI();
            GUILayout.Space(SPACE_SIZE);
            
            ExportForNowGUI();
            GUILayout.Space(SPACE_SIZE * 3);
            
            #region Help Link

            string url = "https://github.com/fairwood/DecentralandUnityPlugin";
			if (GUILayout.Button(string.Format(LabelLocalization.getString(LanguageStringValue.Document), url), EditorStyles.helpBox))
            {
                Application.OpenURL(url);
            }

            #endregion

            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(sceneMeta);
                EditorSceneManager.MarkSceneDirty(sceneMeta.gameObject.scene);
            }
        }

        void ParcelGUI()
        {
            EditorGUILayout.BeginVertical("box");
            var parcels = sceneMeta.parcels;
            EditorGUILayout.BeginHorizontal();
            var style = EditorStyles.foldout;
            style.fontStyle = FontStyle.Bold;
			var foldout = EditorUtil.GUILayout.AutoSavedFoldout("DclFoldParcel", string.Format(LabelLocalization.getString(LanguageStringValue.ParcelsCount), parcels.Count), true, style);
            if (foldout)
            {
                if (editParcelsMode)
                {
                    if (GUILayout.Button(LabelLocalization.getString(LanguageStringValue.Save)))
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
                            EditorUtility.DisplayDialog(LabelLocalization.getString(LanguageStringValue.CoordinatesFormatError), 
                                @"57,-11
57,-12
57,-13", "OK");
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
					if (GUILayout.Button(LabelLocalization.getString(LanguageStringValue.Edit)))
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
            }

            EditorGUILayout.EndHorizontal();
            EditorGUI.indentLevel = 1;
            if (foldout)
            {
                if (editParcelsMode)
                {
                    editParcelsText = EditorGUILayout.TextArea(editParcelsText, GUILayout.Height(120));
                }
                else
                {
                    var sb = new StringBuilder();
                    if (parcels.Count > 0)
                    {
						sb.Append(ParcelToStringBuilder(parcels[0])).Append(LabelLocalization.getString(LanguageStringValue.Base));
                        for (int i = 1; i < parcels.Count; i++)
                        {
                            sb.Append('\n').Append(ParcelToStringBuilder(parcels[i]));
                        }
                    }

                    EditorGUILayout.LabelField(sb.ToString(), GUILayout.Height(120));
                }
            }
            
            EditorGUI.indentLevel = 0;
            EditorGUILayout.EndVertical();
        }

        #region StatGUI

        void StatGUI()
        {
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.BeginHorizontal();
			var foldout = EditorUtil.GUILayout.AutoSavedFoldout("DclFoldStat", LabelLocalization.getString(LanguageStringValue.Statistics), true, null);
            if (foldout)
            {
				if (GUILayout.Button(LabelLocalization.getString(LanguageStringValue.Refresh)))
                {
                    sceneMeta.RefreshStatistics();
                }
            }

            EditorGUILayout.EndHorizontal();

            EditorGUI.indentLevel = 1;
            if (foldout)
            {
				GUILayout.Label(LabelLocalization.getString(LanguageStringValue.KeepTheseNumbersSmaller), EditorStyles.centeredGreyMiniLabel);
                var n = sceneMeta.parcels.Count;
                var sceneStatistics = sceneMeta.sceneStatistics;
				StatisticsLineGUI(LabelLocalization.getString(LanguageStringValue.Triangles), sceneStatistics.triangleCount, LimitationConfigs.GetMaxTriangles(n));
				StatisticsLineGUI(LabelLocalization.getString(LanguageStringValue.Entities), sceneStatistics.entityCount, LimitationConfigs.GetMaxTriangles(n));
				StatisticsLineGUI(LabelLocalization.getString(LanguageStringValue.Bodies), sceneStatistics.bodyCount, LimitationConfigs.GetMaxBodies(n));
				StatisticsLineGUI(LabelLocalization.getString(LanguageStringValue.Materials), sceneStatistics.materialCount, LimitationConfigs.GetMaxMaterials(n));
				StatisticsLineGUI(LabelLocalization.getString(LanguageStringValue.Textures), sceneStatistics.textureCount, LimitationConfigs.GetMaxTextures(n));
				StatisticsLineGUI(LabelLocalization.getString(LanguageStringValue.Height), sceneStatistics.maxHeight, LimitationConfigs.GetMaxHeight(n));
            }

            WarningsGUI();
            EditorGUI.indentLevel = 0;
            EditorGUILayout.EndVertical();
        }

        void StatisticsLineGUI(string indexName, long leftValue, long rightValue)
        {
            var oriColor = GUI.contentColor;
            EditorGUILayout.BeginHorizontal();
            if (leftValue > rightValue)
            {
                GUILayout.Label(DclEditorSkin.WarningIconSmall, GUILayout.Width(20));
                GUI.contentColor = Color.yellow;
            }
            EditorGUILayout.LabelField(indexName, string.Format("{0} / {1}", leftValue, rightValue));
            EditorGUILayout.EndHorizontal();
            GUI.contentColor = oriColor;
        }

        void StatisticsLineGUI(string indexName, float leftValue, float rightValue)
        {
            var oriColor = GUI.contentColor;
            EditorGUILayout.BeginHorizontal();
            if (leftValue > rightValue)
            {
                GUILayout.Label(DclEditorSkin.WarningIconSmall, GUILayout.Width(20));
                GUI.contentColor = Color.yellow;
            }
            EditorGUILayout.LabelField(indexName, string.Format("{0} / {1}", leftValue, rightValue));
            EditorGUILayout.EndHorizontal();
            GUI.contentColor = oriColor;
        }

        #endregion

        #region WarningsGUI

        void WarningsGUI()
        {
            var foldout = EditorPrefs.GetBool("DclFoldStat", true);
            if (foldout)
            {
                var warningCount = sceneMeta.sceneWarningRecorder.OutOfLandWarnings.Count +
                                   sceneMeta.sceneWarningRecorder.UnsupportedShaderWarnings.Count +
                                   sceneMeta.sceneWarningRecorder.InvalidTextureWarnings.Count;
                
                if (warningCount > 0)
                {
					GUILayout.Label(LabelLocalization.getString(LanguageStringValue.ClickWarning), EditorStyles.centeredGreyMiniLabel);

                    foreach (var outOfLandWarning in sceneMeta.sceneWarningRecorder.OutOfLandWarnings)
                    {
						WarningLineGUI(string.Format(LabelLocalization.getString(LanguageStringValue.OutofLandRange), outOfLandWarning.meshRenderer.name),
                            null, outOfLandWarning.meshRenderer.gameObject);
                    }

                    foreach (var warning in sceneMeta.sceneWarningRecorder.UnsupportedShaderWarnings)
                    {
                        var path = AssetDatabase.GetAssetPath(warning.renderer);
						WarningLineGUI(string.Format(LabelLocalization.getString(LanguageStringValue.UnsupportedShader), warning.renderer.name),
							LabelLocalization.getString(LanguageStringValue.OnlyStandardShaderSupported), path);
                    }

                    foreach (var warning in sceneMeta.sceneWarningRecorder.InvalidTextureWarnings)
                    {
                        var path = AssetDatabase.GetAssetPath(warning.renderer);
						WarningLineGUI(string.Format(LabelLocalization.getString(LanguageStringValue.InvalidTextureSize), warning.renderer.name),
							LabelLocalization.getString(LanguageStringValue.TextureSizeMustBe), path);
                    }
                }
            }
        }

        void WarningLineGUI(string text, string hintMessage, GameObject gameObject)
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label(DclEditorSkin.WarningIconSmall, GUILayout.Width(20));
            var oriColor = GUI.contentColor;
            GUI.contentColor = Color.yellow;
            if (GUILayout.Button(text, EditorStyles.label))
            {
                if (hintMessage != null) ShowNotification(new GUIContent(hintMessage));
                EditorGUIUtility.PingObject(gameObject);
            }

            EditorGUILayout.EndHorizontal();
            GUI.contentColor = oriColor;
        }

        void WarningLineGUI(string text, string hintMessage, string assetPath)
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label(DclEditorSkin.WarningIconSmall, GUILayout.Width(20));
            var oriColor = GUI.contentColor;
            GUI.contentColor = Color.yellow;
            if (GUILayout.Button(text, EditorStyles.label))
            {
                if (hintMessage != null) ShowNotification(new GUIContent(hintMessage));
                Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(assetPath);
            }

            EditorGUILayout.EndHorizontal();
            GUI.contentColor = oriColor;
        }

        #endregion

        void OptionsGUI()
        {
            EditorGUILayout.BeginVertical("box");

            var oriFoldout = EditorPrefs.GetBool("DclFoldOptions");
            var foldout = EditorGUILayout.Foldout(oriFoldout, "Options", true);
            if (foldout)
            {
                //mExportPBR = EditorGUILayout.Toggle("Export PBR Material", mExportPBR);
                //mExportAnimation = EditorGUILayout.Toggle("Export animation (beta)", mExportAnimation);
                //mConvertImage = EditorGUILayout.Toggle("Convert Images", mConvertImage);
                //mBuildZip = EditorGUILayout.Toggle("Build Zip", mBuildZip);
            }

            if (foldout != oriFoldout) EditorPrefs.SetBool("DclFoldOptions", foldout);

            EditorGUILayout.EndVertical();
        }

        void OwnerGUI()
        {
            EditorGUILayout.BeginVertical("box");

            var oriFoldout = EditorPrefs.GetBool("DclBoldOwner");
			var foldout = EditorGUILayout.Foldout(oriFoldout, LabelLocalization.getString(LanguageStringValue.OwnerInfo), true);
            if (foldout)
            {
                EditorGUI.indentLevel = 1;
				sceneMeta.ethAddress = EditorGUILayout.TextField(LabelLocalization.getString(LanguageStringValue.OwnerInfoAddress), sceneMeta.ethAddress);
				sceneMeta.contactName = EditorGUILayout.TextField(LabelLocalization.getString(LanguageStringValue.OwnerInfoName), sceneMeta.contactName);
				sceneMeta.email = EditorGUILayout.TextField(LabelLocalization.getString(LanguageStringValue.OwnerInfoEmail), sceneMeta.email);
                EditorGUI.indentLevel = 0;
            }

            if (foldout != oriFoldout) EditorPrefs.SetBool("DclBoldOwner", foldout);

            EditorGUILayout.EndVertical();
        }

        void ExportForDCLGUI()
        {
            EditorGUILayout.BeginVertical("box");
            
			var foldout = EditorUtil.GUILayout.AutoSavedFoldout("DclExportForDCL", LabelLocalization.getString(LanguageStringValue.StandardExport), true, null);
            if (foldout)
            {
				GUILayout.Label(LabelLocalization.getString(LanguageStringValue.DCLProjectPath), EditorStyles.boldLabel);
                EditorGUILayout.BeginHorizontal();
                exportPath = EditorPrefs.GetString("DclExportPath");
                var newExportPath = EditorGUILayout.TextField(exportPath);
                if (GUILayout.Button("...", GUILayout.Width(24), GUILayout.Height(24)))
                {
					newExportPath = EditorUtility.OpenFolderPanel(LabelLocalization.getString(LanguageStringValue.SelectDCLProjectPath), exportPath, "");
                    if (string.IsNullOrEmpty(newExportPath)) newExportPath = exportPath;
                }

                if (newExportPath != exportPath)
                {
                    exportPath = newExportPath;
                    EditorPrefs.SetString("DclExportPath", newExportPath);
                }

                EditorGUILayout.EndHorizontal();
                

                GUILayout.Space(SPACE_SIZE);

                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                var oriColor = GUI.backgroundColor;
                GUI.backgroundColor = Color.green;
				if (GUILayout.Button(LabelLocalization.getString(LanguageStringValue.Export), GUILayout.Width(220), GUILayout.Height(32)))
                {
                    Export();
                }

                GUI.backgroundColor = oriColor;
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();

                GUILayout.Space(SPACE_SIZE * 2);

                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
				if (GUILayout.Button(LabelLocalization.getString(LanguageStringValue.InitProject), GUILayout.Width(105)))
                {
                    if (Directory.Exists(exportPath))
                    {
						if (EditorUtility.DisplayDialog(LabelLocalization.getString(LanguageStringValue.ConfirmInitDCLProject),
							string.Format(LabelLocalization.getString(LanguageStringValue.InitDCLProjectAreYouSure), exportPath), LabelLocalization.getString(LanguageStringValue.YES),
							LabelLocalization.getString(LanguageStringValue.NO)))
                        {
                            DclCLI.DclInit(exportPath);
                        }
                    }
                    else
                    {
						ShowNotification(new GUIContent(LabelLocalization.getString(LanguageStringValue.SelectValidProjectFolder)));
                    }
                }

				if (GUILayout.Button(LabelLocalization.getString(LanguageStringValue.RunProject), GUILayout.Width(105)))
                {
                    if (Directory.Exists(exportPath))
                    {
						if (EditorUtility.DisplayDialog(LabelLocalization.getString(LanguageStringValue.ConfimRunDCLProject),
							string.Format(LabelLocalization.getString(LanguageStringValue.RunDCLProjectAreYouSure), exportPath), LabelLocalization.getString(LanguageStringValue.YES),
							LabelLocalization.getString(LanguageStringValue.NO)))
                        {
                            DclCLI.DclStart(exportPath);
							ShowNotification(new GUIContent(LabelLocalization.getString(LanguageStringValue.DCLStartWait10Seconds)));
                        }
                    }
                    else
                    {
						ShowNotification(new GUIContent(LabelLocalization.getString(LanguageStringValue.SelectValidProjectFolder)));
                    }
                }

                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();

                GUILayout.Space(SPACE_SIZE * 2);
            }

            EditorGUILayout.EndVertical();
        }

        void ExportForNowGUI()
        {
            EditorGUILayout.BeginVertical("box");

			var foldout = EditorUtil.GUILayout.AutoSavedFoldout("DclExportForNow", LabelLocalization.getString(LanguageStringValue.ExportForNowSh), true, null);
            if (foldout)
            {
				GUILayout.Label(LabelLocalization.getString(LanguageStringValue.DCLNowProjectPath), EditorStyles.boldLabel);
                EditorGUILayout.BeginHorizontal();
                exportPath = EditorPrefs.GetString("DclNowExportPath");
                var newExportPath = EditorGUILayout.TextField(exportPath);
                if (GUILayout.Button("...", GUILayout.Width(24), GUILayout.Height(24)))
                {
					newExportPath = EditorUtility.OpenFolderPanel(LabelLocalization.getString(LanguageStringValue.SelectDCLProjectPath), exportPath, "");
                    if (string.IsNullOrEmpty(newExportPath)) newExportPath = exportPath;
                }

                if (newExportPath != exportPath)
                {
                    exportPath = newExportPath;
                    EditorPrefs.SetString("DclNowExportPath", newExportPath);
                }

                EditorGUILayout.EndHorizontal();
                
                GUILayout.Space(SPACE_SIZE);

                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                var oriColor = GUI.backgroundColor;
                GUI.backgroundColor = Color.green;
				if (GUILayout.Button(LabelLocalization.getString(LanguageStringValue.Export), GUILayout.Width(220), GUILayout.Height(32)))
                {
                    Export();

                    //Add package.json & so on files
                    var templateFolder = FileUtil.FindFolder("Editor/now_template");
                    var filesToCopy = new string[]
                    {
                        "build.json",
                        "package.json",
                        "tsconfig.json",
                    };
                    foreach (var filename in filesToCopy)
                    {
                        UnityEditor.FileUtil.ReplaceFile(Path.Combine(templateFolder, filename), Path.Combine(exportPath, filename));
                    }
                }

                GUI.backgroundColor = oriColor;
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();

                GUILayout.Space(SPACE_SIZE * 2);
            }

            EditorGUILayout.EndVertical();
        }

        private DateTime nextTimeRefresh;

        private void Update()
        {
            if (DateTime.Now > nextTimeRefresh)
            {
                if (!sceneMeta)
                {
                    CheckAndGetDclSceneMetaObject();
                }

                sceneMeta.RefreshStatistics();
                Repaint();
                nextTimeRefresh = DateTime.Now.AddSeconds(1);
            }
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
            var template = AssetDatabase.LoadAssetAtPath(path, typeof(TextAsset)) as TextAsset;
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
            var template = AssetDatabase.LoadAssetAtPath(path, typeof(TextAsset)) as TextAsset;
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

        public static void ExportPrefab(GameObject prefab, string path)
        {
            GameObject go = Instantiate(prefab);
            go.name = prefab.name;
            SceneToGlTFWiz comp = go.AddComponent<SceneToGlTFWiz>();
            comp.ExportGameObjectAndChildren(go, Path.Combine(path, go.name + ".gltf"), null, false, true, false, false);
            DestroyImmediate(go);
        }

        /// <summary>
        /// Export scene.tsx, scene.json, unity_assets/
        /// </summary>
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
                //ClearFolder(unityAssetsFolderPath);
                UnityEditor.FileUtil.DeleteFileOrDirectory(unityAssetsFolderPath);
            }

            Directory.CreateDirectory(unityAssetsFolderPath);


            if (!Directory.Exists(Path.Combine(exportPath, "src"))){
                Directory.CreateDirectory(Path.Combine(exportPath, "src"));
            } 
            
            var meshesToExport = new List<GameObject>();
            var statistics = new SceneStatistics();

            StringBuilder exportStr = new StringBuilder();
            SceneTraverser.TraverseAllScene(exportStr, meshesToExport, statistics, null);
            
            File.WriteAllText(Path.Combine(exportPath, "src/game.ts"), exportStr.ToString());

            //glTF in unity_asset
            foreach (var go in meshesToExport)
            {
				string tempPath = Path.Combine (unityAssetsFolderPath, SceneTraverser.CalcName (go) + ".gltf");
				if (!File.Exists (tempPath)) {
					sceneMeta.sceneToGlTFWiz.ExportGameObjectAndChildren(go, tempPath,
						null, false, true, false, false);
				}
            }

            //textures
            var primitiveTexturesToExport = SceneTraverser.primitiveTexturesToExport;
            foreach (var texture in primitiveTexturesToExport)
            {
                var relPath = AssetDatabase.GetAssetPath(texture);
				//if (string.IsNullOrEmpty(relPath) || relPath.Contains("builtin"))
				if (string.IsNullOrEmpty(relPath))
                {
                    //built-in asset
                    var bytes = ((Texture2D) texture).EncodeToPNG();
					string str = Path.Combine (unityAssetsFolderPath, texture.name + ".png");
					File.WriteAllBytes(str.Replace(" ", string.Empty), bytes);
                }
                else
                {
                    var path = Application.dataPath; //<path to project folder>/Assets
                    path = path.Remove(path.Length - 6, 6) + relPath;
                    var toPath = unityAssetsFolderPath + relPath;
					//replace space by zcy
					//toPath = toPath.Replace (" ", string.Empty);
					var directoryPath = Path.GetDirectoryName(toPath);
                    if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
                    File.Copy(path, toPath, true);
                }
            }

            //scene.json
            {
                var fileTxt = GetSceneJsonFileTemplate();
                fileTxt = fileTxt.Replace("{ETH_ADDRESS}", sceneMeta.ethAddress);
                fileTxt = fileTxt.Replace("{CONTACT_NAME}", sceneMeta.contactName);
                fileTxt = fileTxt.Replace("{CONTACT_EMAIL}", sceneMeta.email);
                var parcelsString = GetParcelsString();
                fileTxt = fileTxt.Replace("{PARCELS}", parcelsString);
                if (sceneMeta.parcels.Count > 0)
                {
                    fileTxt = fileTxt.Replace("{BASE}", ParcelToString(sceneMeta.parcels[0]));
                }

                var filePath = Path.Combine(exportPath, "scene.json");
                File.WriteAllText(filePath, fileTxt);
            }

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

        public static string Vector3ToJSONString(Vector3 v)
        {
            return string.Format("{{x:{0},y:{1},z:{2}}}", v.x, v.y, v.z);
        }

        /// <summary>
        /// Color to HEX string(e.g. #AAAAAA)
        /// </summary>
        private static string ToHexString(Color color)
        {
            var color256 = (Color32) color;
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
                        File.Delete(d); //直接删除其中的文件 
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
                            ClearFolder(d1.FullName); ////递归删除子文件夹
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