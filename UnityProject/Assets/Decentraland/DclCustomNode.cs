using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

namespace Dcl
{
    [ExecuteInEditMode]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(DclObject))]
    [AddComponentMenu("DclCustomNode", 1)]
    public class DclCustomNode : MonoBehaviour
    {
        public bool position;
        public bool rotation;
        public bool scale;

        public string nodeName;
        public List<XmlPropertyPair> propertyPairs;
        
#if UNITY_EDITOR
        
        [MenuItem("GameObject/DCL Object/Custom Node", false, -90)]
        static void CreateCustomNode()
        {
            GameObject gameObject = new GameObject("Custom Node");
            gameObject.transform.position = SceneView.lastActiveSceneView.pivot;
            gameObject.AddComponent<DclCustomNode>();
        }

#endif

    }

    [Serializable]
    public struct XmlPropertyPair
    {
        public string name;
        public string value;
    }
}