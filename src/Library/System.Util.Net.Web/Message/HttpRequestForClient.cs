using System.IO;
using System.Util.Net.Web.Interfaces;
using System.Util.Net.Web.Protocol;

namespace System.Util.Net.Web.Message
{
    class HttpRequestForClient : HttpRequest, IHttpRequest
    {
        public HttpRequestForClient()
        {
            HttpVersion = new Version(1, 1);
            _content = new MemoryStream();
        }
        public void SetMethod(HttpMethods method)
        {
            Method = method;
        }
        public void SetURI(URI uri)
        {
            Uri = uri;
        }
        public override void Write(byte[] buffer)
        {
            _content.Write(buffer);
        }
        public override string GetHttpHeader()
        {
            Headers[HttpHeaders.Connection] = "close";
            Headers[HttpHeaders.ContentLength] = Content.Length.ToString();
            Headers[HttpHeaders.AcceptEncoding] = "identity";
            Headers[HttpHeaders.Host] = Uri.Host + (Uri.Port == 80 ? "" : ":" + Uri.Port.ToString());
            Headers[HttpHeaders.UserAgent] = "WebClient/1.0 (compatible)";
            return base.GetHttpHeader();
        }
    }
}
