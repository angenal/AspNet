using System.IO;

namespace System.Util.Binary
{
    /// <summary>
    /// Binary File
    /// </summary>
    public class BaseBinaryFile : DisposableClass ,IDisposable
    {
        /// <summary>
        /// File Stream
        /// </summary>
        protected FileStream _file;
        /// <summary>
        /// Initializes a new instance of the <see cref="System.Util.Binary.BaseBinaryFile"/> class.
        /// </summary>
        /// <param name="path">File Path</param>
        public BaseBinaryFile(string path)
        {
            _file = new FileStream(path, FileMode.Open, FileAccess.Read);
        }

        /// <summary>
        /// Read
        /// </summary>
        protected virtual bool Read()
        {
            return true;
        }

        /// <summary>
        /// Clean Up Managed Resources
        /// </summary>
        protected override void CleanUpManagedResources()
        {
            _file.Dispose();
            base.CleanUpManagedResources();
        }
    }
}
