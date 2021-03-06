#if NET40 || NET45
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.IO;
using System.Text;
using System.Util.IO;

namespace System.Util
{
    /// <summary>
    /// Cs Complier
    /// </summary>
    public class CsComplier
    {
        /// <summary>
        /// Target Dll
        /// </summary>
        public string target = "target.dll";
        /// <summary>
        /// Using DLL
        /// </summary>
        public string[] @using = { "" };
        /// <summary>
        /// Source Path
        /// </summary>
        public string path = Static.CurrentPath();
        ///<summary> 
        /// Error
        /// </summary>    
        public string Error => error;

        private string error = "";

        /// <summary>
        /// Complie
        /// </summary>
        public bool Complie() => Complie(ref error);

        /// <summary>
        /// Complie
        /// <param name="log">log</param>
        /// </summary>
        public bool Complie(ref string log)
        {
            var files = DirectoryHelper.GetAllFilesIncludeChild(new DirectoryInfo(path), "*.cs");
            bool result;
            if (files.Count == 0)
            {
                result = true;
            }
            else
            {
                if (File.Exists(target))
                {
                    File.Delete(target);
                }

                CodeDomProvider compiler = new CSharpCodeProvider();
                var param = new CompilerParameters(@using, target, false)
                {
                    GenerateExecutable = false,
                    GenerateInMemory = false,
                    WarningLevel = 2,
                    CompilerOptions = "/lib:."
                };
                string[] filepaths = new string[files.Count];
                for (int i = 0; i < files.Count; i++)
                {
                    filepaths[i] = files[i].FullName;
                }
                var res = compiler.CompileAssemblyFromFile(param, filepaths);
                if (res.Errors.HasErrors)
                {
                    var sb = new StringBuilder();
                    foreach (CompilerError err in res.Errors)
                    {
                        if (!err.IsWarning)
                        {
                            var builder = new StringBuilder();
                            builder.Append("   ");
                            builder.Append(err.FileName);
                            builder.Append(" Line:");
                            builder.Append(err.Line);
                            builder.Append(" Col:");
                            builder.Append(err.Column);
                            sb.Append("Script compilation failed because: " + err.ErrorText + builder.ToString());
                            sb.Append("\r\n");
                        }
                    }
                    log = sb.ToString();
                    error = log;
                    result = false;
                    return result;
                }
                result = true;
            }
            log = "Success!";
            return result;
        }
    }
}
#endif