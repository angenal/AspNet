using System.Util.Net.Web.Error;
using System.Util.Net.Web.Event;
using System.Util.Net.Web.Interfaces;
using System.Util.Net.Web.Modules;
using System;
using System.Collections.Generic;

namespace System.Util.Net.Web
{
    /// <summary>
    /// Website
    /// </summary>
    public class Website
    {
        private WebServer _server;

        /// <summary>
        /// HostName
        /// </summary>
        public string HostName
        {
            get;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Website"/> class.
        /// </summary>
        /// <param name="hostname"></param>
        public Website(string hostname)
        {
            HostName = hostname;
        }

        /// <summary>
        /// Path
        /// </summary>
        public string Path
        {
            get;
            set;
        } = Environment.CurrentDirectory;

        /// <summary>
        /// Modules
        /// </summary>
        public List<IModule> Modules
        {
            get;
        } = new List<IModule>();

        /// <summary>
        /// Start
        /// </summary>
        public void Start(WebServer server)
        {
            _server = server;
            if (Modules.Count == 0)
            {
                Modules.Insert(0, new FileModule());
            }
            Modules.ForEach((x) =>
            {
                Process += x.Process;
            });
        }

        /// <summary>
        /// Process
        /// </summary>
        public event EventHandler<ProcessEventArgs> Process;
        internal IHttpResponse OnProcess(HttpContext x)
        {
            try
            {
                if (Process != null)
                {
                    var args = new ProcessEventArgs
                    {
                        Request = x.Request,
                        ServerName = _server.Name,
                        Log = x.Log
                    };
                    Process(this, args);
                    if (args.IsProcessed)
                    {
                        return args.Response;
                    }
                }
                return ErrorHelper.Build(501, 0, _server.Name);
            }
            catch (Exception e)
            {
                _server.Log.Error(e);
                return ErrorHelper.Build(500, 0, _server.Name);
            }
        }
    }
}
