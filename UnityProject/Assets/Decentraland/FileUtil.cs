#if UNITY_EDITOR
using UnityEngine;
using System.IO;

namespace Dcl
{
    public class FileUtil
    {

        public static string FindFolder(string partOrPath)
        {
            return "Assets/" + FindFolder(Application.dataPath, partOrPath).Remove(0, Application.dataPath.Length + 1);
        }
        public static string FindFolder(string parentFolder, string partOrPath)
        {
            var path = Path.Combine(parentFolder, partOrPath);
            if (Directory.Exists(path)) return path;
            foreach (var childDir in Directory.GetDirectories(parentFolder))
            {
                var res = FindFolder(childDir, partOrPath);
                if (res != null) return res;
            }
            return null;
        }
    }
}

#endif