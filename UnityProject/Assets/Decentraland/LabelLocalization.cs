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
    }
}