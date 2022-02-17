using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PythonScriptLauncher.Utils
{
    class LaunchPowerShell
    {
        #region Constants



        #endregion

        #region Properties, Fields (champs), and Class Initializations
        /// <summary>
        /// Defines all of the properites of the class.
        /// </summary>
        private ProcessStartInfo startInfo = new ProcessStartInfo();
        private bool m_verbose = true;
        private bool m_verb = true;


        public bool RunAsAdmin
        {   
            get { return m_verb; }
            set { m_verb = value; }
        }

        public bool Verbose
        {
            get { return m_verbose; }
            set { m_verbose = value; }
        
        }
        #endregion

        #region Methods and Constructors
        public LaunchPowerShell(string pathOfExecution, string nameOfFile)
        {

            try
            {
                startInfo.FileName = @"powershell.exe";

                if (m_verb)
                    startInfo.Verb = "runas";

                startInfo.Arguments = $@"& '{pathOfExecution}' {nameOfFile}";
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }


        public void Start()
        {
            try
            {
                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();

                if (m_verbose)
                {
                    string output = process.StandardOutput.ReadToEnd();
                    Console.WriteLine(output);

                    string errors = process.StandardError.ReadToEnd();
                    if (!(string.IsNullOrEmpty(errors) == false))
                        Console.WriteLine(errors);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion





    }
}
