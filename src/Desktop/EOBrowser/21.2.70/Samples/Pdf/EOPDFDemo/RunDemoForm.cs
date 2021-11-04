using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EOPDFDemo
{
    public partial class RunDemoForm : Form
    {
        private MainForm m_MainForm;
        private Demo m_Demo;
        private byte[] m_Result;
        private string m_szError;
        private bool m_bStarted;

        public RunDemoForm(
            MainForm mainForm, Demo demo)
        {
            InitializeComponent();
            m_MainForm = mainForm;
            m_Demo = demo;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Prevent re-entry
            if (m_bStarted)
                return;
            m_bStarted = true;

            m_MainForm.LoadResult();
            MemoryStream ms = new MemoryStream();
            m_szError = m_Demo.RunDemo(ms, m_MainForm);
            if (m_szError == null)
                m_Result = ms.ToArray();
            Close();
        }

        public string Error
        {
            get
            {
                return m_szError;
            }
        }

        public byte[] Result
        {
            get
            {
                return m_Result;
            }
        }
    }
}
