using System.Text;

namespace Dcl
{
    public static class TextUtils
    {
        public static StringBuilder AppendIndent(this StringBuilder sb, string indentUnit, int indentLevel)
        {
            for (int i = 0; i < indentLevel; i++)
            {
                sb.Append(indentUnit);
            }
            return sb;
        }
    }
}