using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Util.Net.Web.Interfaces;
using System.Util.Logs;

namespace System.Util.Net.Web.Event
{
    /// <summary>
    /// ProcessEventArgs
    /// </summary>
    public class ProcessEventArgs : EventArgs
    {
        /// <summary>
        /// IsProcessed
        /// </summary>
        public bool IsProcessed
        {
            get;
            set;
        } = false;
        /// <summary>
        /// ServerName
        /// </summary>
        public string ServerName
        {
            get;
            internal set;
        }

        /// <summary>
        /// Request
        /// </summary>
        public IHttpRequest Request
        {
            get;
            internal set;
        }
        /// <summary>
        /// Response
        /// </summary>
        public IHttpResponse Response
        {
            get;
            set;
        }
        /// <summary>
        /// Log
        /// </summary>
        public LogProvider Log
        {
            get;
            set;
        }
    }
}
