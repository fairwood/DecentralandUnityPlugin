using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Dcl
{
	public enum LanguageStringValue{
		KeepTheseNumbersSmaller=0,
		Document,
		DCLProjectPath,
		DCLNowProjectPath,
		SelectDCLProjectPath,
		OnlyStandardShaderSupported,
		TextureSizeMustBe,
		ParcelsCount,
		Base,
		Edit,
		DCLExporter,
		Statistics,
		Refresh,
		Triangles,
		Entities,
		Bodies,
		Materials,
		Textures,
		Height,
		OutofLandRange,
		UnsupportedShader,
		InvalidTextureSize,
		ClickWarning,
		OwnerInfo,
		OwnerInfoAddress,
		OwnerInfoName,
		OwnerInfoEmail,
		StandardExport,
		Export,
		InitProject,
		ConfirmInitDCLProject,
		InitDCLProjectAreYouSure,
		YES,
		NO,
		SelectValidProjectFolder,
		RunProject,
		ConfimRunDCLProject,
		RunDCLProjectAreYouSure,
		DCLStartWait10Seconds,
		ExportForNowSh,
		LastType
	}

    public static class LabelLocalization
    {
        public enum ELanguage
        {
            EN,
            CN
        }

		private static ELanguage Language = ELanguage.EN;
		private static string[] languageString = null;
		public static void loadLanguageStringFromFile(){
			int length = (int)LanguageStringValue.LastType;
			languageString = new string[length];
			string path = "Assets/Localization/language.txt";
			StreamReader reader = new StreamReader(path); 


			while (!reader.EndOfStream && reader.ReadLine () != Language.ToString ()) {
				
			}

			for (int i = 0; i < length; ++i) {
				if (reader.EndOfStream) {
					break;
				}
				languageString [i] = reader.ReadLine ();
			}

			reader.Close ();
		}

		[MenuItem("EnumTest/enum2String", false)]
		static void enumTest(){
			Debug.Log (Language.ToString ()+(int)LanguageStringValue.SelectDCLProjectPath);
		}

		public static string getString(LanguageStringValue lsv){
			if(languageString==null) 
			{
				loadLanguageStringFromFile ();
			}

			return languageString [(int)lsv];
		}
        
    }
}