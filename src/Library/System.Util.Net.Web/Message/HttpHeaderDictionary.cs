using System.Util.Collections;
using System.Util.Net.Web.Protocol;

namespace System.Util.Net.Web.Message
{
    /// <summary>
    /// HttpHeaders
    /// </summary>
    public class HttpHeaderDictionary : SafeStringToStringDictionary
    {
        /// <summary>
        /// GetHttpHeader
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public string this[HttpHeaders x]
        {
            get
            {
                return this[HttpHeadersHelper.GetNameByHeader(x)];
            }
            set
            {
                this[HttpHeadersHelper.GetNameByHeader(x)] = value;
            }
        }

        internal void Add(HttpHeaders x, string content)
        {
            Add(HttpHeadersHelper.GetNameByHeader(x), content);
        }
    }
}
