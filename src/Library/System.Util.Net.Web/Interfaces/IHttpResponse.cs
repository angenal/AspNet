using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Util.Net.Web.Interfaces
{
    /// <summary>
    /// HttpResponse
    /// </summary>
    public interface IHttpResponse : IHttpMessage, IDisposable
    {
        /// <summary>
        /// ContentLength
        /// </summary>
        long ContentLength
        {
            get;
        }
    }
}
