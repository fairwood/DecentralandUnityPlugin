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
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
    
            var process = Process.Start(processInfo);
            
            process.WaitForExit();
            process.Close();
        }

        [MenuItem("Decentraland/Create DCL Project")]
        static void DclInit(){
            //TODO:先要定位到文件夹
            //ExecuteCommand("dcl init");
        }
    }
}