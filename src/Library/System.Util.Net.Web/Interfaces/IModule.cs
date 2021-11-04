using System.Util.Net.Web.Event;

namespace System.Util.Net.Web.Interfaces
{
    /// <summary>
    /// Module
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Process
        /// </summary>
        /// <param name="website"></param>
        /// <param name="args"></param>
        void Process(object website, ProcessEventArgs args);
    }
}
