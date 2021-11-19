using EO.WebBrowser;
using System;
using System.IO;
using System.Linq;

namespace FullScreenBrowser
{
    public partial class MainWindow
    {
        //This event handler is called when a download starts
        void WebView_BeforeDownload(object sender, BeforeDownloadEventArgs e)
        {
            //下载限制的域名
            //e.Item.Url = "https://*.com/client/latest/installer.exe"
            string downloads = Properties.Resources.Downloads;
            if (!string.IsNullOrWhiteSpace(downloads))
            {
                var urls = downloads.Split(',', '，', ' ').Select(i => i.Trim()).Where(i => i.Length > 1);
                var url = new Uri(e.Item.Url).Authority.Split(':')[0];
                if (!urls.Any(i => url.EndsWith(i)))
                {
                    e.Item.Cancel();
                    return;
                }
            }
            //下载文件大小限制(MB)
            if (double.TryParse(Properties.Resources.DownloadSize, out double downloadSize) && downloadSize > 0)
            {
                double size = e.Item.TotalBytes / 1024.0 / 1024;
                //string filesize = size.ToString("f0") + "MB";
                if (size > downloadSize)
                {
                    e.Item.Cancel();
                    return;
                }
            }
            //e.Item.ContentDisposition = "attachment;filename=installer.exe"
            string filename = "", content = e.Item.ContentDisposition;
            //Modify save file path %TEMP% => tmpSaveFilePath
            if (!string.IsNullOrWhiteSpace(content) && content.Contains('=')) filename = content.Split('=').Last();
            else if (!string.IsNullOrWhiteSpace(e.FilePath)) filename = Path.GetFileName(e.FilePath);
            if (string.IsNullOrWhiteSpace(filename))
            {
                e.Item.Cancel();
                return;
            }
            e.FilePath = Path.Combine(m_SaveFilePath, filename); //WebView_FileDialog: e.DefaultFileName
            //e.ShowDialog = false; //Download directly without displaying save dialog

            //Add it to our download list
            m_Downloads.Add(e.Item);

            //Display the "Downloads" pane
            WebView webView = (WebView)sender;
            mnuDownloads_Click(webView, null);
        }

        //This event handler is called when a download has been canceled
        void WebView_DownloadCanceled(object sender, DownloadEventArgs e)
        {
            m_Downloads.Remove(e.Item);
        }

        void WebView_DownloadCompleted(object sender, DownloadEventArgs e)
        {
            WebView webView = (WebView)sender;
            if (webView.IsNewWindow && string.IsNullOrEmpty(webView.Url))
                webView.Close(false);
        }

        void WebView_FileDialog(object sender, FileDialogEventArgs e)
        {
            //图像文件(*.bmp, *.jpg)|*.bmp;*.jpg|所有文件(*.*)|*.*
            string path = e.DefaultFileName;
            if (e.Mode == FileDialogMode.Save)
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog()
                {
                    Title = "保存",
                    Filter = e.Filter,
                    InitialDirectory = m_SaveFilePath
                };
                if (!string.IsNullOrWhiteSpace(path))
                {
                    dlg.InitialDirectory = Path.GetDirectoryName(path);
                    dlg.FileName = Path.GetFileName(path);
                    dlg.DefaultExt = Path.GetExtension(path);
                    dlg.Filter = "所有文件(*." + dlg.DefaultExt.TrimStart('.') + ")|*." + dlg.DefaultExt.TrimStart('.');
                }
                bool? result = dlg.ShowDialog(this);
                if (result.HasValue && result.Value) e.Continue(dlg.FileName);
                else e.Cancel();
            }
            if (e.Mode == FileDialogMode.Open)
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog()
                {
                    Title = "打开",
                    Filter = e.Filter,
                    InitialDirectory = m_SaveFilePath
                };
                if (!string.IsNullOrWhiteSpace(path))
                {
                    dlg.InitialDirectory = Path.GetDirectoryName(path);
                    dlg.FileName = Path.GetFileName(path);
                    dlg.DefaultExt = Path.GetExtension(path);
                    dlg.Filter = "所有文件(*." + dlg.DefaultExt.TrimStart('.') + ")|*." + dlg.DefaultExt.TrimStart('.');
                }
                bool? result = dlg.ShowDialog(this);
                if (result.HasValue && result.Value) e.Continue(dlg.FileName);
                else e.Cancel();
            }
            //Mark the event as handled
            e.Handled = true;
        }
    }
}
