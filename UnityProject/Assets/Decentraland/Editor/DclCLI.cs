using System;
using System.Threading;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

namespace Dcl
{
    public class DclCLI
    {
        public static void ExecuteCommand (string cmd)
        {
            var thread = new Thread(delegate () {Command(cmd);});
            thread.Start();
        }
 
        static void Command (string cmd)
        {
            var processInfo = new ProcessStartInfo("cmd.exe", cmd);
            processInfo.CreateNoWindow = false;
            processInfo.UseShellExecute = false;
    
            var process = Process.Start(processInfo);
            
            process.WaitForExit();
            process.Close();
        }
        
        public static void DclInit(string path)
        {
            var cmd = string.Format("/k cd /d {0} & dcl init", path);
            ExecuteCommand(cmd);
        }
        
        public static void DclStart(string path)
        {
            var cmd = string.Format("/k cd /d {0} & dcl start", path);
            ExecuteCommand(cmd);
        }
    }
}