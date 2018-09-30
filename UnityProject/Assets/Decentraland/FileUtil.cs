#if UNITY_EDITOR
using UnityEngine;
using System.IO;

namespace Dcl
{
    public class FileUtil
    {
        /// <summary>
        /// Find an valid path ending with the given string under Assets/ folder.
        /// </summary>
        /// <param name="partOrPath">The characteristic string to match</param>
        /// <returns></returns>
        public static string FindFolder(string partOrPath)
        {
            return "Assets/" + FindFolder(Application.dataPath, partOrPath).Remove(0, Application.dataPath.Length + 1);
        }
        /// <summary>
        /// Find an valid path ending with the given string.
        /// </summary>
        /// <param name="parentFolder">Under which folder to search</param>
        /// <param name="partOrPath">The characteristic string to match</param>
        /// <returns></returns>
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