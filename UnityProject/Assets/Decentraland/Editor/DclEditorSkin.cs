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


        #region Shapes

        public static Texture2D Cube
        {
            get
            {
                return EditorGUIUtility.FindTexture("PreMatCube");
            }
        }
        public static Texture2D Quad
        {
            get
            {
                return EditorGUIUtility.FindTexture("PreMatQuad");
            }
        }
        public static Texture2D Sphere
        {
            get
            {
                return EditorGUIUtility.FindTexture("PreMatSphere");
            }
        }
        public static Texture2D Cylinder
        {
            get
            {
                return EditorGUIUtility.FindTexture("PreMatCylinder");
            }
        }
        public static Texture2D Torus
        {
            get { return EditorGUIUtility.FindTexture("PreMatTorus"); }
        }
        public static Texture2D Mesh
        {
            get { return EditorGUIUtility.IconContent("Mesh Icon").image as Texture2D; }
        }
        public static Texture2D PrefabModel
        {
            get
            {
                return EditorGUIUtility.FindTexture("PrefabModel Icon");
            }
        }
        #endregion


        #region Only In DCL Package

        private static Texture2D _entity;
        public static Texture2D Entity
        {
            get
            {
                if (!_entity)
                {
                    var internalFolder = FileUtil.FindFolder("Decentraland/Internal");
                    if (internalFolder.EndsWith("/"))
                        internalFolder = internalFolder.Remove(internalFolder.LastIndexOf("/"), 1);
                    _entity = (Texture2D)AssetDatabase.LoadAssetAtPath(
                        string.Format("{0}/Icons/entity.png", internalFolder), typeof(Texture2D));
                }
                return _entity;
            }
        }
        private static Texture2D _cone;
        public static Texture2D Cone
        {
            get
            {
                if (!_cone)
                {
                    var internalFolder = FileUtil.FindFolder("Decentraland/Internal");
                    if (internalFolder.EndsWith("/"))
                        internalFolder = internalFolder.Remove(internalFolder.LastIndexOf("/"), 1);
                    _cone = (Texture2D) AssetDatabase.LoadAssetAtPath(
                        string.Format("{0}/Icons/cone.png", internalFolder), typeof(Texture2D));
                }
                return _cone;
            }
        }
        private static Texture2D _followup;
        public static Texture2D FollowUp
        {
            get
            {
                if (!_followup)
                {
                    var internalFolder = FileUtil.FindFolder("Decentraland/Internal");
                    if (internalFolder.EndsWith("/"))
                        internalFolder = internalFolder.Remove(internalFolder.LastIndexOf("/"), 1);
                    _followup = (Texture2D)AssetDatabase.LoadAssetAtPath(
                        string.Format("{0}/Icons/followup.png", internalFolder), typeof(Texture2D));
                }
                return _followup;
            }
        }
        private static Texture2D _text;
        public static Texture2D Text
        {
            get
            {
                if (!_text)
                {
                    var internalFolder = FileUtil.FindFolder("Decentraland/Internal");
                    if (internalFolder.EndsWith("/"))
                        internalFolder = internalFolder.Remove(internalFolder.LastIndexOf("/"), 1);
                    _text = (Texture2D)AssetDatabase.LoadAssetAtPath(
                        string.Format("{0}/Icons/text.png", internalFolder), typeof(Texture2D));
                }
                return _text;
            }
        }
        private static Texture2D _customNode;
        public static Texture2D CustomNode
        {
            get
            {
                if (!_customNode)
                {
                    var internalFolder = FileUtil.FindFolder("Decentraland/Internal");
                    if (internalFolder.EndsWith("/"))
                        internalFolder = internalFolder.Remove(internalFolder.LastIndexOf("/"), 1);
                    _customNode = (Texture2D)AssetDatabase.LoadAssetAtPath(
                        string.Format("{0}/Icons/custom_node.png", internalFolder), typeof(Texture2D));
                }
                return _customNode;
            }
        }

		private static Texture2D _video;
		public static Texture2D Video
		{
			get
			{
				if (!_video)
				{
					var internalFolder = FileUtil.FindFolder("Decentraland/Internal");
					if (internalFolder.EndsWith("/"))
						internalFolder = internalFolder.Remove(internalFolder.LastIndexOf("/"), 1);
					_video = (Texture2D)AssetDatabase.LoadAssetAtPath(
						string.Format("{0}/Icons/video.png", internalFolder), typeof(Texture2D));
				}
				return _video;
			}
		}

		private static Sprite _videoPanel;
		public static Sprite VideoPanel
		{
			get
			{
				
				if (!_videoPanel)
				{
					var internalFolder = FileUtil.FindFolder("Decentraland/Internal");
					if (internalFolder.EndsWith("/"))
						internalFolder = internalFolder.Remove(internalFolder.LastIndexOf("/"), 1);
					_videoPanel = (Sprite)AssetDatabase.LoadAssetAtPath(
						string.Format("{0}/Images/video_panel.png", internalFolder), typeof(Sprite));
				}
				return _videoPanel;
			}
		}

        #endregion
    }
}