using System.Text;
using UnityEngine;
using UnityEditor;

namespace Dcl
{

    [CustomEditor(typeof(DclObject))]
    public class DclObjectInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var go = (target as DclObject).gameObject;

            //XML Preview

//            EditorGUI.indentLevel = 1;
            var style = EditorStyles.foldout;
            style.fontStyle = FontStyle.Bold;
            if (EditorUtil.GUILayout.AutoSavedFoldout("DclObjectXml", "XML Preview", true, style, false))
            {
                EditorGUILayout.BeginVertical("box");
                var xml = new StringBuilder();
                SceneTraverser.RecursivelyTraverseTransform(go.transform, xml, null, 0, null, null, null);
                style = EditorStyles.label;
                style.wordWrap = true;
                EditorGUILayout.TextArea(xml.ToString(), style);
                EditorGUILayout.EndVertical();
            }
        }
    }
}