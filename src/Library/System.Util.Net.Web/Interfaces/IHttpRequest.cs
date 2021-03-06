using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Util.Net.Web.Protocol;


namespace System.Util.Net.Web.Interfaces
{
    /// <summary>
    /// HttpRequest
    /// </summary>
    public interface IHttpRequest : IHttpMessage
    {
        /// <summary>
        /// Method
        /// </summary>
        HttpMethods Method
        {
            get;
        }

        /// <summary>
        /// Uri
        /// </summary>
        URI Uri
        {
            get;
        }

        /// <summary>
        /// ExtraErrorCode
        /// </summary>
        int ExtraErrorCode
        {
            get;
        }

        /// <summary>
        /// IsReadFinish
        /// </summary>
        bool IsReadFinish
        {
            get;
        }

        /// <summary>
        /// UserHostAddress
        /// </summary>
        string UserHostAddress
        {
            get;
        }

        /// <summary>
        /// ContentLength
        /// </summary>
        int ContentLength
        {
            get;
        }
    }
}
