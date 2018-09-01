using UnityEditor;
using UnityEngine;

namespace Dcl
{
    public static class DclEditorSkin
    {

        public static Texture2D InfoIcon
        {
            get
            {
                return EditorGUIUtility.FindTexture("d_console.infoicon");
            }
        }

        public static Texture2D InfoIconSmall
        {
            get
            {
                return EditorGUIUtility.FindTexture("d_console.infoicon.sml");
            }
        }

        public static Texture2D WarningIcon
        {
            get
            {
                return EditorGUIUtility.FindTexture("d_console.warnicon");
            }
        }

        public static Texture2D WarningIconSmall
        {
            get
            {
                return EditorGUIUtility.FindTexture("d_console.warnicon.sml");
            }
        }

        public static Texture2D ErrorIcon
        {
            get
            {
                return EditorGUIUtility.FindTexture("d_console.erroricon");
            }
        }

        public static Texture2D ErrorIconSmall
        {
            get
            {
                return EditorGUIUtility.FindTexture("d_console.erroricon.sml");
            }
        }
    }
}