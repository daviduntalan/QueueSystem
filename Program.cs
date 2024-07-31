/*
Build Events > Pre-build event command line:
-------------------------------------------
if exist "$(TargetPath).locked" del "$(TargetPath).locked"
if exist "$(TargetPath)" if not exist "$(TargetPath).locked" move "$(TargetPath)" "$(TargetPath).locked"
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Queue_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLandingPage());
        }
    }
}
