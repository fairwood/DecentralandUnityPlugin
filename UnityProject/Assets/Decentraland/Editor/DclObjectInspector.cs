using System.Text;
using UnityEngine;
using UnityEditor;

namespace Dcl
{

    [CustomEditor(typeof(DclObject))]
    [CanEditMultipleObjects]
    public class DclObjectInspector : Editor
    {
        SerializedProperty visible;
        SerializedProperty withCollision;

        void OnEnable()
        {
            visible = serializedObject.FindProperty("visible");
            withCollision = serializedObject.FindProperty("withCollision");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var dclObject = target as DclObject;
            var go = dclObject.gameObject;

            EditorGUILayout.LabelField("Type", dclObject.dclNodeType.ToString());

            EditorGUILayout.PropertyField(visible, new GUIContent("visible"));

			//to do : rebuild primitive mesh when mesh parameter changed

			if(dclObject.dclPrimitiveType!=DclPrimitiveType.other)
            {
                EditorGUILayout.PropertyField(withCollision, new GUIContent("withCollision", "Only available for primitives"));
            }


            /*//XML Preview
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
            */
            serializedObject.ApplyModifiedProperties();
        }
    }
}