using System.Util.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace System.Util.Data.LDB
{



    /// <summary>
    /// LDB File
    /// </summary>
    public class LDBFile : DisposableClass, IDisposable
    {
        /// <summary>
        /// NEW FILE
        /// </summary>
        public static readonly byte[] NEWFILE = { ASCIIChar.L,ASCIIChar.D,ASCIIChar.B,          0,          0,
                                                            0,          0,          0,          0,          0,//10
                                                            1,          0,          0,          0,          0,
                                                            0,          0,          0,          0,          0,//20
                                                            0,          0,          0,          0,          0,
                                                            0,          0,          0,          0,          0,//30
                                                            0,          0,          0,          0,          0,
                                                            0,          0,          0,          0,          0,//40
                                                            0,          0,          0,          0,          0,
                                                            0,          0,          0,          0,          0,//50
                                                            0,          0,          0,          0,          0,
                                                            0,          0,          0,          0,          0,//60
                                                            0,          0,          0,          0,          0,
                                                            0,          0,          0,          0,          0,//70
                                                            0,          0,          0,          0,          0,
                                                            0,          0,          0,          0,          0,//80
                                                            0,          0,          0,          0,          0,
                                                            0,          0,          0,          0,          0,//90
                                                            0,          0,          0,          0,          0,
                                                            0,          0,          0,          0,        255,//100
                                                 };
        /// <summary>
        /// Inital a new instance of <see cref="System.Util.Data.LDB.LDBFile"/> class
        /// </summary>
        public LDBFile()
        {
            this.Initial();
        }

        /// <summary>
        /// Initialize a new instance of <see cref="System.Util.Data.LDB.LDBFile"/> class from a file
        /// </summary>
        /// <param name="Filename"></param>
        /// <param name="CanWrite"></param>
        public LDBFile(string Filename, bool CanWrite)
        {
            this.FileName = Filename;
            if (!File.Exists(Filename))
            {
                CreateFile(Filename);
            }
            if (CanWrite)
            {
                this.file = new FileStream(Filename, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
            }
            else
            {
                this.file = new FileStream(Filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            this.IsOpenFile = true;
            this.file.Seek(0, SeekOrigin.Begin);
            if (file.ReadByte() == ASCIIChar.L && file.ReadByte() == ASCIIChar.D && file.ReadByte() == ASCIIChar.B)
            {
                this.InitialFromFile();
            }
            else
            {
                throw new InvalidDataException("Error LDB File");
            }
        }

        private void CreateFile(string Filename)
        {
            File.WriteAllBytes(Filename, NEWFILE);
        }

        private void Initial()
        {
            this.Config = new LDBFileConfig();
        }
        private void InitialFromFile()
        {
            Initial();
            this.file.Seek(10, SeekOrigin.Begin);
            var major = file.ReadByte();
            var minor = file.ReadByte();
            if (major > 0 && minor > 0)
            {
                this.Config.Version = new Version(major, minor);
            }
            var buffer = new byte[28];
            file.Read(buffer, 0, 28);
            this.Config.DBName = buffer.ConvertFromBytes(Encoding.UTF8);

            this.file.Seek(99, SeekOrigin.Begin);
            if (file.ReadByte() != 255)
            {
                throw new InvalidDataException("Error LDB File");
            }
            else
            {
                if (file.Length == 100)
                {
                    this.Tables = new LDBTables(this);//Null Table
                }
                else
                {
                    if (file.Length < 300)
                    {
                        throw new InvalidDataException("Error LDB File");
                    }
                    else
                    {
                        buffer = new byte[200];
                        file.Read(buffer, 0, 100);
                        this.Tables = new LDBTables(this, buffer);
                    }
                }
            }

        }

        /// <summary>
        /// CloseFile
        /// </summary>
        public void Close()
        {
            this.file.Close();
            this.IsOpenFile = false;
        }

        /// <summary>
        /// Save
        /// </summary>
        public void Save()
        {
            if (FileName == null)
            {
                throw new InvalidOperationException("filename not set");
            }
            if (!IsOpenFile || !file.CanWrite)
            {
                throw new IOException("file cannot be written");
            }
            this.Config.Save(file);
            this.Tables.Save(file);
        }




        /// <summary>
        /// Config
        /// </summary>
        public LDBFileConfig Config
        {
            get;
            private set;
        }
        /// <summary>
        /// FileName
        /// </summary>
        public string FileName
        {
            get
            {
                return filename;
            }
            set
            {
                if (IsOpenFile)
                {
                    throw new InvalidOperationException("File is opening");
                }
                else
                {
                    this.filename = value;
                }
            }
        }
        /// <summary>
        /// Tables
        /// </summary>
        public LDBTables Tables
        {
            get;
            private set;
        }

        private string filename;
        FileStream file;




        private bool IsOpenFile = false;



        /// <summary>
        /// Cleans up managed resources
        /// </summary>
        protected override void CleanUpManagedResources()
        {
            if (IsOpenFile)
            {
                this.Close();
            }
            base.CleanUpManagedResources();
        }
    }
}
