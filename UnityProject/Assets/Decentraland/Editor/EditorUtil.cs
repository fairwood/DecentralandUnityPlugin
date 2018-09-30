using UnityEditor;
using UnityEngine;

namespace Dcl
{
    public static class EditorUtil
    {
        public static class GUILayout
        {
            public static bool AutoSavedFoldout(string saveKey, string content, bool toggleOnLabelClick, GUIStyle style,
                bool defaultFoldout = true)
            {
                var oriFoldout = EditorPrefs.GetBool(saveKey, defaultFoldout);
                var foldout = style == null
                    ? EditorGUILayout.Foldout(oriFoldout, content, toggleOnLabelClick)
                    : EditorGUILayout.Foldout(oriFoldout, content, toggleOnLabelClick, style);
                if (oriFoldout != foldout)
                {
                    EditorPrefs.SetBool(saveKey, foldout);
                }

                return foldout;
            }
        }
    }
}