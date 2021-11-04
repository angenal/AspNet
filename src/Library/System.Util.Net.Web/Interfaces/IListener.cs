
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Util.Logs;
using System.Util.Net.Sockets.Event;
using System.Util.Net.Web.Event;


namespace System.Util.Net.Web.Interfaces
{
    /// <summary>
    /// Listener
    /// </summary>
    public interface IListener
    {
        /// <summary>
        /// Start
        /// </summary>
        void Start();

        /// <summary>
        /// Stop
        /// </summary>
        void Stop();

        /// <summary>
        /// Log
        /// </summary>
        LogProvider Log
        {
            get;
            set;
        }

        /// <summary>
        /// Server
        /// </summary>
        WebServer Server
        {
            get;
            set;
        }

        /// <summary>
        /// SocketAccepted
        /// </summary>
        event EventHandler<SocketAcceptedArgs> SocketAccepted;
    }
}
