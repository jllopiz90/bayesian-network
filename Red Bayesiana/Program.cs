using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Red_Bayesiana
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new App());
            }
            catch (Exception)
            {

                MessageBox.Show("La aplicacion ha cometido un error y debe cerrarse.\n Los cambios que no haya guardado seran perdidos.\nLamentamos las molestias ocasionadas.");
                Application.Exit();
            }
            
        }
    }
}
