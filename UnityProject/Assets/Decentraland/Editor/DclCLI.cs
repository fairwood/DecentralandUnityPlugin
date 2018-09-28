using System;
using System.Threading;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

namespace Dcl
{
    public class DclCLI
    {
        public static void ExecuteCommand(string cmd)
        {
            var thread = new Thread(delegate() { Command(cmd); });
            thread.Start();
        }

        static void Command(string cmd)
        {
            UnityEngine.Debug.Log(String.Format("exec cmd {0}",cmd));
            string exe = "";
#if UNITY_EDITOR_OSX
            exe = "/bin/bash";
#else
            exe = "cmd.exe";

#endif
            var processInfo = new ProcessStartInfo(exe, cmd);
            processInfo.CreateNoWindow = false;
            processInfo.UseShellExecute = false;
            var process = Process.Start(processInfo);
            process.WaitForExit();
            process.Close();
        }

        public static void DclInit(string path)
        {
#if UNITY_EDITOR_OSX
            // string bash = string.Format("{0}/bash/dcl_init.sh",Application.dataPath);
            // string cmd = string.Format("-c '{0} {1}'",bash,path);
            // string from = String.Format("{0}/Decentraland/template/*",Application.dataPath);
            // string cmd = String.Format("-c 'cd {0};source $HOME/.bash_profile; cp {1} {0};rm {0}/*.meta;npm install'",path,from);
            string cmd = String.Format("-c 'source $HOME/.bash_profile;open -a Terminal {0}'", path);
            ExecuteCommand(cmd);
#else
            var cmd = string.Format("/k cd /d {0} & dcl init", path);
            ExecuteCommand(cmd);
#endif
        }

        public static void DclStart(string path)
        {
#if UNITY_EDITOR_OSX
            string cmd = "";
            string bash = string.Format("{0}/bash", Application.dataPath);
            // kill dcl first
            cmd = String.Format("-c 'source $HOME/.bash_profile;cd {0};sh dcl_kill.sh > /tmp/dcl_kill.log;'", bash);
            ExecuteCommand(cmd);
            Thread.Sleep(3000);
            cmd = String.Format("-c 'source $HOME/.bash_profile;cd {0};dcl start >/tmp/dcl_start.log'", path);
            ExecuteCommand(cmd);
#else
            var cmd = string.Format("/k cd /d {0} & dcl start", path);
            ExecuteCommand(cmd);
#endif
        }
    }
}