using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EO.TabbedBrowser
{
    /// <summary>
    /// Interaction logic for PdfViewer.xaml
    /// </summary>
    public partial class PdfViewer : Window
    {
        private EO.WebBrowser.FindSession m_FindSession;

        public PdfViewer()
        {
            InitializeComponent();
        }

        private void ShowError(string error)
        {
            MessageBox.Show(this, error, Title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void pdfViewer1_IsReadyChanged(object sender, EventArgs e)
        {
            tbOpen.IsEnabled = pdfViewer1.IsReady;
        }

        private void tbOpen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".pdf";
            dlg.Filter = "PDF Files (*.pdf)|*.pdf";
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    pdfViewer1.Load(dlg.FileName);
                    tbClose.IsEnabled = true;
                    tbPrint.IsEnabled = true;
                    txtSearch.IsEnabled = true;
                    tbSearch.IsEnabled = true;
                }
                catch (Exception ex)
                {
                    ShowError(ex.Message);
                }
            }
        }

        private void tbClose_Click(object sender, RoutedEventArgs e)
        {
            pdfViewer1.Clear();
            tbClose.IsEnabled = false;
            tbPrint.IsEnabled = false;
            txtSearch.IsEnabled = false;
            tbSearch.IsEnabled = false;
        }

        private void tbPrint_Click(object sender, RoutedEventArgs e)
        {
            pdfViewer1.Print();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (m_FindSession != null)
            {
                m_FindSession.Stop();
                m_FindSession = null;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                tbSearch_Click(this, null);
        }

        private void tbSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text.Length == 0)
                return;

            if (m_FindSession == null)
                m_FindSession = pdfViewer1.StartFindSession(txtSearch.Text, false);
            else
                m_FindSession.Next();
        }

        private void pdfViewer1_LaunchUrl(object sender, WebBrowser.LaunchUrlEventArgs e)
        {
            //For demonstration purpose, here we load the Url with the
            //default browser. You can add code to display a confirm dialog
            //here
            System.Diagnostics.Process.Start(e.Url);
        }
    }
}
