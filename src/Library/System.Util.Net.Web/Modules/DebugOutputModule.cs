using System.Util.Logs;
using System.Util.Net.Web.Event;
using System.Util.Net.Web.Interfaces;
using System.Util.Text;

namespace System.Util.Net.Web.Modules
{
    /// <summary>
    /// Debug output request message Module 
    /// </summary>
    public class DebugOutputModule : IModule
    {
        private readonly LogProvider _logProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugOutputModule"/> class.
        /// </summary>
        /// <param name="logProvider">The logger to output</param>
        public DebugOutputModule(LogProvider logProvider)
        {
            _logProvider = logProvider;
        }

        /// <inheritdoc/>
        public void Process(object website, ProcessEventArgs args)
        {
            var request = args.Request;
            _logProvider.Debug(request.GetHttpHeader());
            if (request.ContentLength > 0)
            {
                _logProvider.Debug(request.Content.ReadAll().ConvertFromBytes());
            }
        }
    }
}
