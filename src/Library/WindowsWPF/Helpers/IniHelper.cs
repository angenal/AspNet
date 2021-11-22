using System;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowsWPF.Helpers
{
    public static class IniHelper
    {
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string sectionName, string key, string defaultValue, byte[] returnBuffer, int size, string filePath);
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string sectionName, string key, string value, string filePath);
        public static string GetValue(string sectionName, string key, string filePath, int index = 0)
        {
            byte[] bytes = new byte[2048];
            int count = GetPrivateProfileString(sectionName, key, string.Empty, bytes, 999, filePath);
            return Encoding.Default.GetString(bytes, index, count);
        }
        public static bool SetValue(string sectionName, string key, string value, string filePath)
        {
            try
            {
                return WritePrivateProfileString(sectionName, key, value, filePath) > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static bool RemoveSection(string sectionName, string filePath)
        {
            try
            {
                return WritePrivateProfileString(sectionName, null, string.Empty, filePath) > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static bool Removekey(string sectionName, string key, string filePath)
        {
            try
            {
                return WritePrivateProfileString(sectionName, key, null, filePath) > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
