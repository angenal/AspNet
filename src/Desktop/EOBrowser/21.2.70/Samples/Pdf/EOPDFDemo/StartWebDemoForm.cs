using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace EOPDFDemo
{
    public partial class StartWebDemoForm : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        private const int WM_USER = 0x400;

        private const string WebDemoWndName = "Essential Objects RunWebDemo App";

        private enum State
        {
            NotStarted,

            Started,

            Failed,

            Done,
        }

        private int m_nTicks;
        private State m_State = State.NotStarted;
        private IntPtr m_hDemoAppWnd;

        private StartWebDemoForm()
        {
            InitializeComponent();
        }

        public static string GetWebDemoUrl(Form owner, string fileName)
        {
            //Try to find RunWebDemo.exe's main window
            IntPtr hWnd = FindWindow(null, WebDemoWndName);
            if (hWnd == IntPtr.Zero)
            {
                MessageBox.Show(owner, 
                    "This demo accesses server side demo page in EO.Pdf Web Demo application. Click OK to start the Web Demo application.", 
                    owner.Text, MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

                //Try to start the Web Demo application
                using (StartWebDemoForm form = new StartWebDemoForm())
                {
                    form.ShowDialog(owner);

                    hWnd = form.m_hDemoAppWnd;

                    if (hWnd == IntPtr.Zero)
                    {
                        MessageBox.Show(owner,
                            "Failed to start EO Web Demo application. Please " +
                            "try to manually start it by selecting Samples -> " +
                            "EO.Pdf Web Demo from EO.Pdf program group in your " +
                            "start menu.", owner.Text,
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return null;
                    }
                }
            }

            //Send a message to the main window to get port number
            int port = SendMessage(hWnd, WM_USER + 100, IntPtr.Zero, IntPtr.Zero);
            if (port == 0)
                return string.Empty;

            return string.Format("http://localhost:{0}/PdfWeb/{1}", port, fileName);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_nTicks++;

            if (m_State == State.NotStarted)
            {
                m_State = State.Started;

                //Start the process
                string exeDir = MainForm.GetInstallDir();
                string runWebDemoExePath = Path.Combine(exeDir, "RunWebDemo.exe");
                try
                {
                    Process process = Process.Start(runWebDemoExePath, "/silent /app=PdfWeb");
                }
                catch
                {
                    m_State = State.Failed;

                    Close();
                }
            }
            else if (m_State == State.Started)
            {
                m_hDemoAppWnd = FindWindow(null, WebDemoWndName);
                if (m_hDemoAppWnd != IntPtr.Zero)
                {
                    m_State = State.Done;

                    Close();
                }
                else if (m_nTicks > 100)
                {
                    m_State = State.Failed;

                    Close();
                }
            }
        }
    }
}
