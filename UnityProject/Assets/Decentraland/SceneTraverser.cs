using System;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

namespace Dcl
{
    public class SceneTraverser
    {

        const string indentUnit = "  ";

        public static void TraverseAllScene(StringBuilder xmlBuilder, List<GameObject> meshesToExport, SceneStatistics statistics)
        {
            var rootGameObjects = new List<GameObject>();
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var roots = SceneManager.GetSceneAt(i).GetRootGameObjects();
                rootGameObjects.AddRange(roots);
            }

            if (xmlBuilder != null)
            {
                xmlBuilder.AppendIndent(indentUnit, 3);
                xmlBuilder.AppendFormat("<scene position={{{0}}}>\n", Vector3ToJSONString(new Vector3(5, 0, 5)));
            }

            foreach (var rootGO in rootGameObjects)
            {
                RecursivelyTraverseTransform(rootGO.transform, xmlBuilder, meshesToExport, 4, statistics);
            }

            if (xmlBuilder != null)
            {
                xmlBuilder.AppendIndent(indentUnit, 3);
                xmlBuilder.Append("</scene>");
            }
        }

        static void RecursivelyTraverseTransform(Transform tra, StringBuilder xmlBuilder, List<GameObject> meshesToExport, int indentLevel, SceneStatistics statistics)
        {
            if (!tra.gameObject.activeInHierarchy) return;

            //TODO: Hide empty

            statistics.entityCount += 1;

            var components = tra.GetComponents<Component>();
            string nodeName = null;
            var position = tra.localPosition;
            var scale = tra.localScale;
            var eulerAngles = tra.localEulerAngles;
            string pColor = null;
            var extraProperties = new StringBuilder();

            foreach (var component in components)
            {
                if (component is Transform) continue;

                //Primitive
                if (component is MeshFilter)
                {
                    var meshFilter = component as MeshFilter;
                    if (meshFilter.sharedMesh == PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Cube))
                    {
                        nodeName = "box";
                    }
                    else if (meshFilter.sharedMesh == PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Sphere))
                    {
                        nodeName = "sphere";
                    }
                    else if (meshFilter.sharedMesh == PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Quad))
                    {
                        nodeName = "plane";
                    }
                    else if (meshFilter.sharedMesh == PrimitiveHelper.GetPrimitiveMesh(PrimitiveType.Cylinder))
                    {
                        nodeName = "cylinder";
                        extraProperties.Append(" radius={0.5}");
                    }
                    else if (meshFilter.sharedMesh == PrimitiveHelper.ConeMesh)
                    {
                        nodeName = "cone";
                    }

                    if (nodeName != null)
                    {
                        //read color
                        var rdrr = tra.GetComponent<MeshRenderer>();
                        if (rdrr && rdrr.sharedMaterial)
                        {
                            var matColor = rdrr.sharedMaterial.color;
                            pColor = ToHexString(matColor);
                        }

                        //Collider
                        if (tra.GetComponent<Collider>())
                        {
                            extraProperties.Append(" withCollisions={true}");
                        }

                        //Statistics
                        statistics.triangleCount += meshFilter.sharedMesh.triangles.LongLength / 3;
                    }
                }

                //Other Model
                if (nodeName == null)
                {
                    if (component is MeshFilter)
                    {
                        var meshFilter = component as MeshFilter;
                        //export as a glTF model
                        if (meshesToExport != null)
                        {
                            meshesToExport.Add(tra.gameObject);
                        }
                        nodeName = "gltf-model";
                        position = Vector3.zero;
                        eulerAngles = Vector3.zero;
                        scale = Vector3.zero;
                        extraProperties.AppendFormat(" src=\"./unity_assets/{0}.gltf\"", tra.name);
                        
                        //Statistics
                        statistics.triangleCount += meshFilter.sharedMesh.triangles.LongLength / 3;
                        statistics.bodyCount += 1;
                    }
                }


                //TextMesh
                if (component is TextMesh)
                {
                    nodeName = "text";
                    var tm = component as TextMesh;
                    extraProperties.AppendFormat(" value=\"{0}\"", tm.text);
                    scale *= tm.fontSize * 0.5f;
                    //extraProperties.AppendFormat(" fontS=\"{0}\"", 100);
                    pColor = ToHexString(tm.color);
                    var rdrr = tra.GetComponent<MeshRenderer>();
                    if (rdrr)
                    {
                        var width = rdrr.bounds.extents.x * 2;
                        extraProperties.AppendFormat(" width={{{0}}}", width);
                    }
                }

                if (component is MeshRenderer)
                {
                    var meshRenderer = component as MeshRenderer;
                    //Statistics
                    var curHeight = meshRenderer.bounds.max.y;
                    if (curHeight > statistics.maxHeight) statistics.maxHeight = curHeight;
                }
            }
            if (nodeName == null)
            {
                nodeName = "entity";
            }
            if (pColor != null)
            {
                extraProperties.AppendFormat(" color=\"{0}\"", pColor);
            }

            StringBuilder xmlNode = null;
            StringBuilder xmlNodeTail = null;
            StringBuilder childrenXmlBuilder = null;
            if (xmlBuilder != null)
            {
                xmlNode = new StringBuilder();
                xmlNode.AppendIndent(indentUnit, indentLevel);
                xmlNode.AppendFormat("<{0} position={{{1}}} scale={{{2}}} rotation={{{3}}}{4}>", nodeName, Vector3ToJSONString(position), Vector3ToJSONString(scale), Vector3ToJSONString(eulerAngles), extraProperties);
                xmlNodeTail = new StringBuilder().AppendFormat("</{0}>\n", nodeName);
                childrenXmlBuilder = new StringBuilder();
            }

            foreach (Transform child in tra)
            {
                RecursivelyTraverseTransform(child, childrenXmlBuilder, meshesToExport, indentLevel + 1, statistics);
            }

            if (xmlBuilder != null)
            {
                if (childrenXmlBuilder.Length > 0)
                {
                    xmlNode.Append("\n");
                    xmlNode.Append(childrenXmlBuilder);
                    xmlNode.AppendIndent(indentUnit, indentLevel);
                }
                xmlNode.Append(xmlNodeTail);
                xmlBuilder.Append(xmlNode);
            }
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

        #endregion
    }
}