using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
namespace Properties4Net
{
    public class Properties
    {
		private string path;

        public string Path{ get { return this.path; } }

        private Dictionary<string, string> map = new Dictionary<string, string>();

        public string this[string name]
        {
            get
            {
                if(map.ContainsKey(name))
                {
                    return map[name];
                }
                return null;
            }
        }

        public Properties(string path)
        {
			this.path = path;
            LoadFile(path);
        }

        private void LoadFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new IOException(string.Format("file {0} not exist", path));
            }

            string lineAcc = "";
            foreach (String line in File.ReadAllLines(path))
            {
                if(line.EndsWith("\\"))
                {
                    int idx = line.LastIndexOf('\\');
                    lineAcc = lineAcc + line.TrimStart().Substring(0, idx-1);

                }else{
                    lineAcc = lineAcc + line.TrimStart();
                    LoadLine(lineAcc);
                    lineAcc = "";
                }
            }
        }

        private void LoadLine(string line)
        {
            line = line.Trim();
            if(string.IsNullOrEmpty(line))
            {
                return;
            }
            if(line.StartsWith("#") || line.StartsWith("!"))
            {
                return;
            }
            int idx = -1;
            int idxTmp = 0;
            if((idxTmp = line.IndexOf('=')) != -1)
            {
                idx = idxTmp;
            }else if((idxTmp = line.IndexOf(':')) != -1)
            {
                idx = idxTmp;
            }

            if(idx == -1)
            {
                throw new Exception(string.Format("invalid line {0}",line));
            }

            string k = line.Substring(0, idx).Trim();
            k = DecodeUnicode(k);
            string v = line.Substring(idx + 1).Trim();
            v = DecodeUnicode(v);
            if (map.ContainsKey(k))
            {
                throw new Exception(string.Format("duplicate key {0}",k));
            }
            map.Add(k, v);
        }

        private string DecodeUnicode(string unicode)
        {
            if (string.IsNullOrEmpty(unicode))
            {
                return string.Empty;
            }
            return System.Text.RegularExpressions.Regex.Unescape(unicode);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(String k in map.Keys)
            {
                sb.Append(string.Format("{0}={1}\n",k,map[k]));
            }
            return sb.ToString();
        }
    }
}
