using System.Text;

namespace System.Windows
{
    public static class Commands
    {
        public static string GetExtraCommandLineArgs(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string arg in args)
            {
                if (!arg.StartsWith("--")) continue;
                if (sb.Length > 0) sb.Append(" ");
                sb.Append(arg);
            }
            return sb.ToString();
        }
    }
}
