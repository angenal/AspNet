using System;
using System.IO;
using System.Reflection;

namespace EOPDFDemo
{
    //IDemoArgs provides access to demo arguments
    //entered by user through the HTML interface 
    //created by a Demo's GetInstructions method.
    //This interface is implemented by MainForm
    public interface IDemoArgs
    {
        //Get a string argument based on the input
        //element Id
        string GetString(string id);
    }

    public abstract class Demo
    {
        private string m_szPath;

        public Demo(string path)
        {
            m_szPath = path;
        }

        public string Path
        {
            get
            {
                return m_szPath;
            }
        }

        public virtual bool HasPdfResult()
        {
            return true;
        }

        public virtual string RunDemo(
            Stream result, IDemoArgs args)
        {
            return null;
        }

        public static string GetInputFilePath(string fileName)
        {
            string path = typeof(Demo).Assembly.Location;
            path = System.IO.Path.GetDirectoryName(path);
            path = System.IO.Path.Combine(path, "Input");
            path = System.IO.Path.Combine(path, fileName);
            return path;
        }

        public virtual string GetInstructions()
        {
            string resxName = this.GetType().FullName + ".htm";
            resxName = resxName.Replace(".HtmlToPdfDemos.", ".HtmlToPdf.");

            try
            {
                using (Stream stream = this.GetType().Assembly.GetManifestResourceStream(resxName))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch
            {
                return @"Please select a demo from the TreeView on the left side,
                then click ""Run"" on the toolbar to run the demo. The
                result PDF file will be displayed here.";
            }
        }

        public virtual string GetCSCode()
        {
            return "C# source code not available.";
        }

        public virtual string GetVBCode()
        {
            return "VB.NET source code not available.";
        }

        protected System.Drawing.Image LoadImage(string image)
        {
            Stream stream =
                typeof(Demo).Assembly.GetManifestResourceStream("EOPDFDemo.Images." + image);
            return System.Drawing.Image.FromStream(stream);
        }
    }
}