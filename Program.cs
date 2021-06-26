using System;
using System.Windows.Forms;

namespace ArdeshirV.Applications.KnightsTour
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static int Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain(args));
            return 0;
        }
    }
}