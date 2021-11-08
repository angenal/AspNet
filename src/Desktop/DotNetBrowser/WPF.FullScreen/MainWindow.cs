using DotNetBrowser;
using DotNetBrowser.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WindowsWPF.Controls;

namespace WPF.FullScreen
{
    /// <summary></summary>
    public partial class MainWindow
    {
        // 浏览器事件
        protected void InitializeWebBrowser()
        {
            var browser = WebBrowser1.Browser;
            // Enable SpellChecker service.
            //browser.Context.SpellCheckerService.Enabled = true;
            // Configure SpellChecker's language.
            //browser.Context.SpellCheckerService.Language = "en-US";
            // Set default accept/reject SSL certificates using custom SSL certificate verifier.
            browser.Context.NetworkService.CertificateVerifier = new MainCertificateVerifier();
            BrowserContext.DefaultContext.NetworkService.NetworkDelegate = new MainNetworkDelegate();
            // Set default handle SSL certificate errors.
            browser.LoadHandler = new MainLoadHandler();
            // Set default media stream device using custom default device.
            MediaStreamDeviceManager deviceManager = browser.MediaStreamDeviceManager;
            // Get list of all available audio capture devices (microphones).
            List<MediaStreamDevice> audioCaptureDevices = deviceManager.GetMediaStreamDevices(MediaStreamType.AUDIO_CAPTURE);
            // Get list of all available video capture devices (webcams).
            List<MediaStreamDevice> videoCaptureDevices = deviceManager.GetMediaStreamDevices(MediaStreamType.VIDEO_CAPTURE);
            // Register own provider to provide Chromium with default device.
            deviceManager.Provider = new MainMediaStreamDeviceProvider();
            // Handles various events.
            WebBrowser1.KeyDown += WebBrowser_KeyDown;
            WebBrowser1.StatusChangedEvent += WebBrowser_StatusChangedEvent;
            browser.TitleChangedEvent += Browser_TitleChangedEvent;
            browser.StartLoadingFrameEvent += Browser_StartLoadingFrameEvent;
            browser.FinishLoadingFrameEvent += Browser_FinishLoadingFrameEvent;
            browser.RenderUnresponsiveEvent += Browser_RenderUnresponsiveEvent;
            browser.UserAgent = Properties.Resources.UserAgent;
            browser.LoadURL(Properties.Resources.URL);
            System.Diagnostics.Debug.WriteLine(">> Main window:URL: " + Properties.Resources.URL);
            System.Diagnostics.Debug.WriteLine(">> Main window:UserAgent: " + Properties.Resources.UserAgent);
            //browser.LoadHTML();
        }

        private void WebBrowser_KeyDown(object sender, KeyEventArgs e)
        {
            //提示快捷键功能
            if (e.Key == Key.F1) MessageBox.Show(HotkeyMessageBoxText, "提示", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void WebBrowser_StatusChangedEvent(object sender, StatusEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($">> WebView: {e.Text} {e.Browser.URL}");
        }

        private void WebBrowser_GestureEvent(object sender, GestureEventArgs e)
        {
            if (e.IsCtrlDown && e.IsAltDown && e.GestureType == GestureType.LONG_PRESS) MessageBox.Show("Gesture event: `Ctrl+Alt+LONG_PRESS`");
        }


        private void Browser_TitleChangedEvent(object sender, TitleEventArgs e)
        {
            TransparentSplash.EndDisplay();
        }

        private void Browser_StartLoadingFrameEvent(object sender, StartLoadingArgs e)
        {
            //TransparentSplash.EndDisplay(3);//关闭启动图(延迟3秒)
        }

        private void Browser_FinishLoadingFrameEvent(object sender, FinishLoadingEventArgs e)
        {
            if (!e.IsMainFrame) return;
            System.Diagnostics.Debug.WriteLine(">> WebView: finish loading");
            JSValue value = e.Browser.ExecuteJavaScriptAndReturnValue("window");
            value.AsObject().SetProperty("browser", new MainBrowser(this));
            System.Diagnostics.Debug.WriteLine($">> WebView: window.browser => new {nameof(MainBrowser)}");
        }

        private void Browser_RenderUnresponsiveEvent(object sender, RenderEventArgs e)
        {
            e.TerminationStatus = TerminationStatus.StillRunning;
        }


        // 窗口事件
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //自动更新 https://github.com/ravibpatel/AutoUpdater.NET
            AutoUpdaterDotNET.AutoUpdater.CheckForUpdateEvent += AutoUpdater_CheckForUpdateEvent;
            AutoUpdaterDotNET.AutoUpdater.Start(Properties.Resources.AutoUpdaterURL);
            //彻底去除关闭按钮
            RemoveCloseButton();
            //窗体一直置顶
            //SetTopMost();
        }

        private void AutoUpdater_CheckForUpdateEvent(AutoUpdaterDotNET.UpdateInfoEventArgs args)
        {
            if (args.IsUpdateAvailable) TransparentSplash.EndDisplay();//关闭启动图
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            //添加快捷键功能
            RegisterHotkey();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true; //取消关闭事件(Alt+F4)
        }

        /// <summary>
        /// 询问关闭该应用程序
        /// </summary>
        public void Window_ComfirmExit()
        {
            if (m_Window_ComfirmExit) return;
            m_Window_ComfirmExit = true;
            MessageBoxResult result = MessageBox.Show(this, "是否退出该应用程序？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
            m_Window_ComfirmExit = false;
            if (result == MessageBoxResult.Yes) Window_Exit();
        }
        private bool m_Window_ComfirmExit = false;

        /// <summary>
        /// 退出该应用程序时，释放系统资源。
        /// </summary>
        public void Window_Exit()
        {
            //注销快捷键
            f5Hotkey.Dispose();
            ctrlF5.Dispose();
            altA.Dispose();
            altQ.Dispose();
            //释放资源
            TransparentSplash.Instance.Dispose();
            WebBrowser1.Browser.Dispose();
            WebBrowser1.Dispose();
            Close();
            //退出应用程序
            Environment.Exit(0);
        }
    }
}
