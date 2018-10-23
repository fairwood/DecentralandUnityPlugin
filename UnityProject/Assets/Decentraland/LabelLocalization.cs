using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using Properties4Net;

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
        Save,
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
        CoordinatesFormatError,
		LastType
	}

    public static class LabelLocalization
    {
        public enum ELanguage
        {
            EN,
            CN
        } 

		public static ELanguage Language = ELanguage.EN;
		private static MessageSource s_messageSource = null;
		private static string[] languageString = null;
		public static void loadLanguageStringFromFile(){
			s_messageSource = new MessageSource("Assets/Decentraland/Editor/Localization","language"); 

			int length = (int)LanguageStringValue.LastType;
			languageString = new string[length];
			for (int i = 0; i < length; ++i) {
				LanguageStringValue l = (LanguageStringValue)i;
				languageString [i] = s_messageSource.GetMessage(l.ToString(), null, Language.ToString());
			}
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