using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
namespace Properties4Net
{
    /// <summary>
    /// file = basename_LOCALE.properties
    /// eg:exceptions_en_GB.properties,exceptions_zh_CN.properties
    /// </summary>
    public class MessageSource
    {
        private Properties def = null;

        private Dictionary<string, Properties> map = new Dictionary<string, Properties>();

		private string dir;

		private string basename;

        public string Dir { get { return this.dir; } }

        public string BaseName { get { return this.basename; } }

        public MessageSource(string dir, string basename)
        {
			this.dir = dir;
			this.basename = basename;
            LoadDir(dir,basename);
        }

        private void LoadDir(string dir, string basename)
        {
            if(!Directory.Exists(dir))
            {
                throw new IOException(string.Format("dir {0} not found",dir));
            }
            string[] files = Directory.GetFiles(dir);

            foreach(string file in files)
            {
                string fileName = Path.GetFileName(file);
                string pattern = string.Format("^{0}_?[a-z_A-Z]*.properties$",basename);
                Match match = Regex.Match(fileName, pattern);
                if(!match.Success)
                {
                    continue;
                }
                if(string.Format("{0}.properties",basename).Equals(fileName))
                {
                    this.def = new Properties(file);
                }
                else
                {
                    int extIdx = fileName.LastIndexOf('.');
                    string name = fileName.Substring(0,extIdx);
                    name = name.Substring(basename.Length+1);
                    map.Add(name, new Properties(file));
                }
            }

        }

        private string GetMessage2(string code, Object[] args, string defaultV, Properties properties)
        {
            string v = properties[code];
            if(string.IsNullOrEmpty(v))
            {
                return defaultV;
            }
            if(args == null || args.Length < 1)
            {
                return v;
            }

            return string.Format(v,args);
        }

        public string GetMessage(string code, Object[] args, string defaultV, string locale)
        {
            if(map.ContainsKey(locale))
            {
                Properties properties = map[locale];
                return GetMessage2(code, args, defaultV, properties);
            }
            if(this.def == null)
            {
                return defaultV;
            }
            return GetMessage2(code, args, defaultV, this.def);
        }

        public string GetMessage(string code, Object[] args, string locale)
        {
            return GetMessage(code,args,null,locale);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if(this.def != null)
            {
                sb.AppendLine("====== default properties ======");
                sb.Append(this.def);
                sb.AppendLine();
            }

            foreach (String k in map.Keys)
            {
                sb.AppendLine(string.Format("====== {0} properties ======",k));
                sb.Append(map[k]);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
