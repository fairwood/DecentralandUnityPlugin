using System;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Properties4Net
{
    class Program
    {
        static void Main(string[] args)
        {
            string root = Environment.CurrentDirectory;
            Console.WriteLine(root);

            string fooPath = Path.Combine(root,"Data/Foo.properties");

            Properties properties = new Properties(fooPath);

            Console.WriteLine(properties);

            string dir = Path.Combine(root,"Data");

            MessageSource ms = new MessageSource(dir,"message");
            Console.WriteLine(ms);

            Console.WriteLine(ms.GetMessage("greet", new string[]{"alking"}, ""));

            Console.WriteLine(ms.GetMessage("greet", new string[]{"alking"}, "zh_CN"));

			Console.ReadLine();

        }

//		[MenuItem("Localization/test")]
//		public static void Test(){
//			string root = "Assets/Decentraland/Properties4Net-master/Properties4Net/";//Environment.CurrentDirectory;
//			Debug.Log(root);
//
//			string fooPath = Path.Combine(root,"Data/Foo.properties");
//
//			Properties properties = new Properties(fooPath);
//
//			Debug.Log (properties);
//
//			string dir = Path.Combine(root,"Data");
//
//			MessageSource ms = new MessageSource(dir,"message");
//			Debug.Log(ms);
//
//			//Debug.Log(ms.GetMessage("greet", new string[]{"alking"}, ""));
//
//			Debug.Log(ms.GetMessage("greet", new string[]{"alking"}, "zh_CN"));
//
//			//Console.ReadLine();
//		}
    }
}
