using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Util.Net.Web.Protocol;
using System.Util.Text;

namespace System.Util.Net.Web.Message
{
    /// <summary>
    /// HttpResponse for client
    /// </summary>
    public class HttpResponseForClient : HttpResponse
    {

        /// <summary>
        /// ContentLength
        /// </summary>
        public override long ContentLength => Headers[Protocol.HttpHeaders.ContentLength].ConvertToLong();
    }
}
