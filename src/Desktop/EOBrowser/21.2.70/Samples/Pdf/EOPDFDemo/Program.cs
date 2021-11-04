using System;
using System.Threading;
using System.Windows.Forms;

namespace EOPDFDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(OnException);

            EO.Pdf.Runtime.AddLicense(Properties.Resources.ResourceManager.GetString("L21"));
            EO.WebBrowser.Runtime.AddLicense(Properties.Resources.ResourceManager.GetString("L21"));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void OnException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString());
        }
    }
}
