using System;
using System.IO;
using PythonScriptLauncher.Utils;

namespace PythonScriptLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            

            string[] drives = System.IO.Directory.GetLogicalDrives();

            foreach (string drive in drives)
            {
                Console.WriteLine("Testing for path in: ", drive);
                if (Directory.Exists(@$"{drive}PythonScripts\SysInfo\"))
                {
                    Console.WriteLine($"Path found in {drive} drive!");
                    Console.WriteLine("Launching Python script!");
                    
                    LaunchPowerShell computerInfo = new LaunchPowerShell(@"D:\Python\python.exe", @"D:\PythonScripts\SysInfo\main.py");
                    computerInfo.Start();

                    Console.WriteLine("End of execution!");

                }


            }


        }
    }
}
