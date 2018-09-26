using System;

namespace Dcl
{
    public static class LabelLocalization
    {
        public enum ELanguage
        {
            EN,
            CN,
        }

        public static ELanguage Language = ELanguage.EN;

        public static string KeepTheseNumbersSmaller
        {
            get
            {
                switch (Language)
                {
                    case ELanguage.CN:
                        return "以下指标不能超出右边的数字限制";
                    default:
                        return "Keep these numbers smaller than the right";
                }
            }
        }
        public static string Document
        {
            get
            {
                switch (Language)
                {
                    case ELanguage.CN:
                        return "文档：{0}";
                    default:
                        return "Document: {0}";
                }
            }
        }
        public static string DCLProjectPath
        {
            get
            {
                switch (Language)
                {
                    case ELanguage.CN:
                        return "DCL工程文件夹";
                    default:
                        return "DCL Project Path";
                }
            }
        }
        public static string SelectDCLProjectPath
        {
            get
            {
                switch (Language)
                {
                    case ELanguage.CN:
                        return "选择DCL工程文件夹";
                    default:
                        return "Select the DCL Project folder";
                }
            }
        }

        public static string DragPrefabHere
        {
            get
            {
                switch (Language)
                {
                    case ELanguage.CN:
                        return "将prefab拖至此";
                    default:
                        return "drag prefab here";
                }

            }

        }
        
        public static string OnlyStandardShaderSupported
        {
            get
            {
                switch (Language)
                {
                    case ELanguage.CN:
                        return "只支持Standard材质";
                    default:
                        return "Only Standard Shader is supported";
                }
            }
        }
        public static string TextureSizeMustBe
        {
            get
            {
                switch (Language)
                {
                    case ELanguage.CN:
                        return "贴图的边长必须是1,2,4,8,..., 512";
                    default:
                        return "Texture sizes must be one of 1,2,4,8,..., 512";
                }
            }
        }
    }
}