using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace EOPDFDemo.Demos
{
    public partial class PdfViewer : Form
    {
        private EO.WebBrowser.FindSession m_FindSession;

        public PdfViewer()
        {
            InitializeComponent();
        }

        private void ShowError(string error)
        {
            MessageBox.Show(this, error, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void pdfViewer1_IsReadyChanged(object sender, EventArgs e)
        {
            tbOpen.Enabled = pdfViewer1.IsReady;
        }

        private void tbOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    pdfViewer1.Load(openFileDialog1.FileName);
                    tbClose.Enabled = true;
                    tbPrint.Enabled = true;
                    txtSearch.Enabled = true;
                    tbSearch.Enabled = true;
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
        }

        private void tbClose_Click(object sender, EventArgs e)
        {
            pdfViewer1.Clear();
            tbClose.Enabled = false;
            tbPrint.Enabled = false;
            txtSearch.Enabled = false;
            tbSearch.Enabled = false;
        }

        private void tbPrint_Click(object sender, EventArgs e)
        {
            pdfViewer1.Print();
        }

        private void tbSearchText_TextChanged(object sender, EventArgs e)
        {
            if (m_FindSession != null)
            {
                m_FindSession.Stop();
                m_FindSession = null;
            }
        }

        private void tbSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbSearch_Click(this, EventArgs.Empty);
        }

        private void tbSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
                return;

            if (m_FindSession == null)
                m_FindSession = pdfViewer1.StartFindSession(txtSearch.Text, false);
            else
                m_FindSession.Next();
        }

        private void pdfViewer1_LaunchUrl(object sender, EO.WebBrowser.LaunchUrlEventArgs e)
        {
            //For demonstration purpose, here we load the Url with the
            //default browser. You can add code to display a confirm dialog
            //here
            System.Diagnostics.Process.Start(e.Url);
        }
    }

    public class PdfViewerDemo : Demo
    {
        public PdfViewerDemo(string path)
            : base(path)
        {
        }

        public override bool HasPdfResult()
        {
            return false;
        }

        public override string RunDemo(Stream result, IDemoArgs args)
        {
            PdfViewer viewer = new Demos.PdfViewer();
            viewer.Show();
            return null;
        }

        public override string GetInstructions()
        {
            return @"
<p>
EO.Pdf PdfViewer can be used to display and print a PDF file.
Two flavors of PdfViewer class are provided: EO.WinForm.PdfViewer
for Windows Forms and EO.Wpf.PdfViewer for WPF. Click the button
below to launch a Windows Form that uses the EO.WinForm.PdfViewer
control.
</p>
";
        }
    }
}
