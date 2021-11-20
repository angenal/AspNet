using Microsoft.Win32;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace System.Windows
{
    public static class RegistryTool
    {
        /// <summary>
        /// 创建快捷方式(为当前应用程序)
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

        private const string PrefixShortcut = @"SOFTWARE\Classes\";
        private const string CommandShortcut = @"shell\open\command";

        /// <summary>
        /// 创建快捷方式 abc://api.abc.com/act
        /// </summary>
        /// <param name="name">App.abc</param>
        /// <param name="path">"C:\Users\Administrator\AppData\Roaming\abc\app.exe" "%1"</param>
        /// <param name="protocol">abc</param>
        /// <param name="icon">C:\Users\Administrator\AppData\Roaming\abc\app.ico</param>
        /// <param name="description">Application Description</param>
        public static void RegistShortcut(string name, string path, string protocol, string icon, string description = null)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("You must provide the argument.", nameof(name));
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("You must provide the argument.", nameof(path));
            if (string.IsNullOrEmpty(protocol)) throw new ArgumentException("You must provide the argument.", nameof(protocol));

            RegistryKey rk = Registry.CurrentUser.CreateSubKey(PrefixShortcut + name), k0 = null, k1 = null;
            rk.SetValue("", "URL:" + protocol);
            rk.SetValue("URL Protocol", "");
            //rk.SetValue("", protocol + "Protocol");
            //rk.SetValue("URL Protocol", exePath);

            if (!string.IsNullOrEmpty(description))
            {
                k0 = rk.CreateSubKey("Application");
                k0.SetValue("", description);
            }

            if (!string.IsNullOrEmpty(icon))
            {
                k1 = rk.CreateSubKey("DefaultIcon");
                k1.SetValue("", icon);
            }

            RegistryKey k2 = rk.CreateSubKey(CommandShortcut);
            k2.SetValue("", path);

            rk.Close();
            if (k0 != null) k0.Close();
            if (k1 != null) k1.Close();
            k2.Close();
        }

        public static bool ExistsShortcut(string name)
        {
            bool ok = false;
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(PrefixShortcut + name);
            if (rk != null)
            {
                string v = rk.GetValue("")?.ToString();
                ok = v != null && v.StartsWith("URL:") && rk.GetValue(CommandShortcut) != null;
                rk.Close();
            }
            return ok;
        }

        public static string GetShortcut(string name)
        {
            string v = null;
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(PrefixShortcut + name);
            if (rk != null)
            {
                v = rk.GetValue(CommandShortcut)?.ToString();
                rk.Close();
            }
            return v;
        }
    }
}
