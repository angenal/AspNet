using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Util.Net.Web.Interfaces;

namespace System.Util.Net.Web.Event
{
    /// <summary>
    /// RequestParsedEventArgs
    /// </summary>
    public class RequestParsedEventArgs :EventArgs
    {
        /// <summary>
        /// Request
        /// </summary>
        /// <value>The request.</value>
        public IHttpRequest Request
        {
            get;
            set;
        }
    }
}
