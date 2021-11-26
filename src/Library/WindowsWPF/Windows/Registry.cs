using Microsoft.Win32;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

namespace System.Windows
{
    /// <summary>
    /// 注册表工具类
    /// </summary>
    public static class RegistryTool
    {
        const string DefaultName = "";
        const string PrefixShortcut = @"SOFTWARE\Classes\";
        const string CommandShortcut = @"shell\open\command";
        // whileSecurity: Loop together until the safety problem is solved
        const long LoopTimesForLabel = 30; // Loop times
        const int MillisecondsTimeoutForLabel = 500;

        /// <summary>
        /// 创建快捷方式(为当前应用程序)
        /// 前提：本地组策略编辑"gpedit.msc"：计算机配置/管理模板/系统/组策略："配置包含应用 URI 处理程序的 Web 到应用链接"
        /// 禁用此策略将会禁用 Web 到应用链接，并会在默认浏览器中打开 http(s) URI 而不是启动相关应用。
        /// </summary>
        /// <param name="protocol"></param>
        public static void RegistThisApp(string protocol)
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            object[] attributes = assembly.GetCustomAttributes(false);
            var a0 = attributes.FirstOrDefault(t => t is GuidAttribute);
            var a1 = attributes.FirstOrDefault(t => t is AssemblyProductAttribute);
            var a2 = attributes.FirstOrDefault(t => t is AssemblyDescriptionAttribute);
            //var programs = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
            string name = protocol, path = "\"" + assembly.Location + "\"" + " \"%1\"";
            string icon = Directory.GetFiles(Path.GetDirectoryName(assembly.Location), "*.ico").FirstOrDefault();
            if (icon == null) icon = assembly.Location + ",1";
            string description = a2 != null ? ((AssemblyDescriptionAttribute)a2).Description : null;
            RegistShortcut(name, path, protocol, icon, description);
        }

        /// <summary>
        /// 创建快捷方式 abc://api.abc.com/act
        /// </summary>
        /// <param name="name">App.abc</param>
        /// <param name="path">"C:\Users\Administrator\AppData\Roaming\abc\app.exe" "%1"</param>
        /// <param name="protocol">abc</param>
        /// <param name="icon">C:\Users\Administrator\AppData\Roaming\abc\app.ico</param>
        /// <param name="description">Application Description</param>
        /// <param name="whileSecurity">一起循环直到安全问题解决</param>
        public static void RegistShortcut(string name, string path, string protocol, string icon, string description = null, bool whileSecurity = true)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("You must provide the argument.", nameof(name));
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("You must provide the argument.", nameof(path));
            if (string.IsNullOrEmpty(protocol)) throw new ArgumentException("You must provide the argument.", nameof(protocol));

            long location = 0; // Loop seed
        IL_A1: // Loop start
            try
            {
                RegistryKey rk = Registry.CurrentUser.CreateSubKey(PrefixShortcut + name), k0 = null, k1 = null;
                rk.SetValue(DefaultName, "URL:" + protocol);
                rk.SetValue("URL Protocol", DefaultName);
                //rk.SetValue("", protocol + "Protocol");
                //rk.SetValue("URL Protocol", exePath);

                if (!string.IsNullOrEmpty(description))
                {
                    k0 = rk.CreateSubKey("Application");
                    k0.SetValue(DefaultName, description);
                }

                if (!string.IsNullOrEmpty(icon))
                {
                    k1 = rk.CreateSubKey("DefaultIcon");
                    k1.SetValue(DefaultName, icon);
                }

                RegistryKey k2 = rk.CreateSubKey(CommandShortcut);
                k2.SetValue(DefaultName, path);

                rk.Close();
                if (k0 != null) k0.Close();
                if (k1 != null) k1.Close();
                k2.Close();
            }
            catch (SecurityException)
            {
                while (whileSecurity && Interlocked.Increment(ref location) < LoopTimesForLabel)
                {
                    Thread.Sleep(MillisecondsTimeoutForLabel);
                    goto IL_A1; // Loop end
                }
            }
        }

        /// <summary>
        /// 检查注册表键值对是否存在
        /// </summary>
        /// <param name="name">注册表键名</param>
        /// <param name="whileSecurity">一起循环直到安全问题解决</param>
        /// <returns></returns>
        public static bool ExistsShortcut(string name, bool whileSecurity = true)
        {
            bool ok = false;
            long location = 0; // Loop seed
        IL_A1: // Loop start
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(PrefixShortcut + name);
                if (rk != null)
                {
                    string v = rk.GetValue(DefaultName)?.ToString();
                    ok = v != null && v.StartsWith("URL:");
                    rk.Close();
                }
            }
            catch (SecurityException)
            {
                while (whileSecurity && Interlocked.Increment(ref location) < LoopTimesForLabel)
                {
                    Thread.Sleep(MillisecondsTimeoutForLabel);
                    goto IL_A1; // Loop end
                }
            }
            return ok;
        }

        /// <summary>
        /// 获取打开快捷方式执行的命令
        /// </summary>
        /// <param name="name">注册表键名</param>
        /// <param name="whileSecurity">一起循环直到安全问题解决</param>
        /// <returns></returns>
        public static string GetShortcut(string name, bool whileSecurity = true)
        {
            string v = null;
            long location = 0; // Loop seed
        IL_A1: // Loop start
            try
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey(PrefixShortcut + name);
                if (rk != null)
                {
                    RegistryKey k2 = rk.OpenSubKey(CommandShortcut);
                    if (k2 != null) v = k2.GetValue(DefaultName)?.ToString();
                    rk.Close();
                    if (k2 != null) k2.Close();
                }
            }
            catch (SecurityException)
            {
                while (whileSecurity && Interlocked.Increment(ref location) < LoopTimesForLabel)
                {
                    Thread.Sleep(MillisecondsTimeoutForLabel);
                    goto IL_A1; // Loop end
                }
            }
            return v;
        }
    }
}
