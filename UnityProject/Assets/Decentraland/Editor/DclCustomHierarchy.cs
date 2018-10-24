using System;
using UnityEngine;
using System.Collections.Generic;
using Dcl;
using UnityEditor;
using Object = UnityEngine.Object;

[InitializeOnLoad]
public class DclCustomHierarchy
{
    static List<int> markedObjects;

    static DclCustomHierarchy()
    {
        // Init
        EditorApplication.update += UpdateCB;
        EditorApplication.hierarchyWindowItemOnGUI += HierarchyItemCB;
    }

    static void UpdateCB()
    {
        // Check here
        GameObject[] go = Object.FindObjectsOfType(typeof(GameObject)) as GameObject[];

        markedObjects = new List<int>();
        foreach (GameObject g in go)
        {
            markedObjects.Add(g.GetInstanceID());
        }

    }

    static void HierarchyItemCB(int instanceID, Rect selectionRect)
    {
        // place the icoon to the right of the list:
        Rect r = new Rect(selectionRect);
        r.x = r.xMin - 30;
        r.width = 24;

        var go = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

        EDclNodeType nodeType = EDclNodeType._none;
        Texture2D tex = null;
        if (go)
        {
            if (SceneTraverser.GameObjectToNodeTypeDict.TryGetValue(go, out nodeType))
            {
                switch (nodeType)
                {
                case EDclNodeType.entity:
                    tex = DclEditorSkin.Entity;
                    break;
                case EDclNodeType.box:
                    tex = DclEditorSkin.Cube;
                    break;
                case EDclNodeType.sphere:
                    tex = DclEditorSkin.Sphere;
                    break;
                case EDclNodeType.plane:
                    tex = DclEditorSkin.Quad;
                    break;
                case EDclNodeType.cylinder:
                    tex = DclEditorSkin.Cylinder;
                    break;
                case EDclNodeType.cone:
                    tex = DclEditorSkin.Cone;
                    break;
                case EDclNodeType.circle:
                    tex = DclEditorSkin.Sphere;
                    break;
                case EDclNodeType.text:
                    tex = DclEditorSkin.Text;
                    break;
                case EDclNodeType.gltf:
                    tex = DclEditorSkin.Mesh;
                    break;
				case EDclNodeType.CustomNode:
					{
						DclCustomNode node = go.GetComponent<DclCustomNode> ();
						if (node.nodeName == "video") {
							tex = DclEditorSkin.Video;
						} else {
							tex = DclEditorSkin.CustomNode;
						}
						
					}
                break;
                default:
                    break;
                }
            }
            else
            {
                if (IsChildOfGLTF(go.transform))
                {
                    nodeType = EDclNodeType.ChildOfGLTF;
                    tex = DclEditorSkin.FollowUp;
                }
            }
        }

        if (tex)
        {
            GUI.Label(r, new GUIContent(tex, GetTooltipForNodeTypeIcon(nodeType)));
        }
    }

    static bool IsChildOfGLTF(Transform t)
    {
        var parent = t.parent;
        if (!parent) return false;
        EDclNodeType nodeType = EDclNodeType._none;
        if (SceneTraverser.GameObjectToNodeTypeDict.TryGetValue(parent.gameObject, out nodeType))
        {
            if (nodeType == EDclNodeType.gltf) return true;
            return false;
        }
        else
        {
            return IsChildOfGLTF(parent);
        }
    }

    static string GetTooltipForNodeTypeIcon(EDclNodeType nodeType)
    {
        switch (nodeType)
        {
            case EDclNodeType.entity:
                return "<entity>";
            case EDclNodeType.box:
                return "<box>";
            case EDclNodeType.sphere:
                return "<sphere>";
            case EDclNodeType.plane:
                return "<plane>";
            case EDclNodeType.cylinder:
                return "<cylinder>";
            case EDclNodeType.cone:
                return "<cone>";
            case EDclNodeType.circle:
                return "<circle>";
            case EDclNodeType.text:
                return "<text>";
            case EDclNodeType.gltf:
                return "<gltf-model>";
            case EDclNodeType.ChildOfGLTF:
                return "will be contained in its parent's gltf file";
            case EDclNodeType.CustomNode:
                return "a customized node";
            default:
                return null;
        }
    }
}
