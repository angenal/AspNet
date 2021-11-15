using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace System.Windows
{
    // 摘要:表示将处理事件的方法。泛型类型参数指定事件所生成的事件数据的类型。
    [Serializable]
    public delegate void RequestHandler(HttpRequest req, HttpResponse resp);

    public class RequestDoc
    {
        public string Description { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
    }

    public class RequestMethod
    {
        public const string GET = "GET";
        public const string POST = "POST";
    }

    public class RequestRouter
    {
        public RequestRouteAttribute Attribute { get; set; }
        public RequestHandler Handler { get; set; }
    }

    public class RequestRouteAttribute : Attribute
    {
        public string Path { get; set; }
        public string Method { get; set; }
        public string Description { get; set; }
        public RequestRouteAttribute()
        {
        }
        public RequestRouteAttribute(string path)
        {
            Path = path;
        }
        public RequestRouteAttribute(string method, string path, string description = null)
        {
            Path = path;
            Method = method;
            Description = description;
        }
    }

    public static class RequestRouteHelper
    {
        public static List<RequestRouter> GetRequestHandlers(Type type)
        {
            var list = new List<RequestRouter>();
            Type handler = typeof(RequestHandler);
            MethodInfo method1 = handler.GetMethod("Invoke");
            var param1 = method1.GetParameters();
            int check1 = param1.Length;
            foreach (var method2 in type.GetMethods(BindingFlags.Public | BindingFlags.Static))
            {
                if (method1.ReturnType != method2.ReturnType) continue;
                var param2 = method2.GetParameters();
                int check2 = param2.Length;
                if (check1 != check2) continue;
                for (int i = 0; i < check1; i++) if (param1[i].ParameterType != param2[i].ParameterType) check2--;
                if (check1 != check2) continue;
                var attrs = method2.GetCustomAttributes(true);
                if (attrs == null) continue;
                var route = attrs.FirstOrDefault(t => t is RequestRouteAttribute);
                if (route == null) continue;
                var attr = (RequestRouteAttribute)route;
                if (string.IsNullOrEmpty(attr.Method)) attr.Method = RequestMethod.GET;
                if (string.IsNullOrEmpty(attr.Path)) attr.Path = "/api/" + method2.Name;
                list.Add(new RequestRouter { Attribute = attr, Handler = Delegate.CreateDelegate(handler, method2) as RequestHandler });
            }
            return list;
        }

        public static RequestDoc AsRequestDoc(RequestRouteAttribute a)
        {
            return new RequestDoc { Description = a.Description, Method = a.Method, Path = a.Path };
        }
    }

    public class HttpServer
    {
        private int _listenPort = 8080;
        private int _numOfProcessThread = 1;
        private List<HttpHandler> _handlers;
        private HttpListener listener;

        public HttpServer(int listenPort) : this(1, listenPort) { }
        public HttpServer(int numOfProcessThread, int listenPort)
        {
            _listenPort = listenPort;
            _numOfProcessThread = numOfProcessThread;
            _handlers = new List<HttpHandler>();
            listener = new HttpListener();
            listener.Prefixes.Add($"http://*:{_listenPort}/");
        }

        public void Start()
        {
            if (!HttpListener.IsSupported) throw new NotSupportedException("Windows XP SP2 or Server 2003 is required to use the HttpListener.");
            listener.Start();
            for (int i = 0; i < _numOfProcessThread; i++)
            {
                ThreadPool.QueueUserWorkItem(WorkerThread, listener);
            }
        }

        public void Stop()
        {
            listener.Stop();
        }

        public void Route(string urlPattern, string httpMethod, RequestHandler handler)
        {
            Regex pattern = new Regex(urlPattern);
            HttpHandler registeredHandler = new HttpHandler(pattern, httpMethod, handler);
            _handlers.Add(registeredHandler);
        }

        private void WorkerThread(object objListener)
        {
            HttpListener listener = objListener as HttpListener;
            while (listener.IsListening)
            {
                try
                {
                    HttpListenerContext context = listener.GetContext();
                    ProcessRequest(context);
                }
                catch (HttpListenerException)
                {
                    //catch exception when stop listener 
                }
            }
        }

        private void ProcessRequest(HttpListenerContext context)
        {
            bool isHandled = false;
            HttpListenerRequest request = context.Request;
            foreach (var handler in _handlers)
            {
                if (handler.UrlPattern.IsMatch(request.RawUrl) && handler.HttpMethod == context.Request.HttpMethod)
                {
                    HttpRequest req = new HttpRequest(context.Request);
                    HttpResponse resp = new HttpResponse(context.Response);
                    handler.RequestHandler(req, resp);
                    resp.Finish();
                    isHandled = true;
                    break; //it's been handled, stop propagation
                }
            }
            if (!isHandled)
            {
                DefaultHander(context);
            }
        }

        private void DefaultHander(HttpListenerContext context)
        {
            string html = string.Format("Not Handled:[{0}] {1} at {2}", context.Request.HttpMethod, context.Request.RawUrl, DateTime.Now);
            byte[] buffer = Encoding.UTF8.GetBytes(html);
            HttpListenerResponse response = context.Response;
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }
    }

    public static class HttpUtility
    {
        public static NameValueCollection GetFormValues(this HttpListenerRequest request)
        {
            NameValueCollection formValues = new NameValueCollection();
            using (StreamReader sr = new StreamReader(request.InputStream, request.ContentEncoding))
            {
                string formdata = sr.ReadToEnd();
                formdata = formdata.Replace('+', ' ');
                string[] fileds = formdata.Split('&');
                for (int i = 0; i < fileds.Length; i++)
                {
                    string[] keyValues = fileds[i].Split('=');
                    formValues.Add(Uri.UnescapeDataString(keyValues[0]), Uri.UnescapeDataString(keyValues[1]));
                }
            }
            return formValues;
        }

        public static void Write(this HttpListenerResponse response, string content)
        {
            response.Headers.Add(HttpRequestHeader.ContentType, "text/plain; charset=utf-8");
            using (StreamWriter sw = new StreamWriter(response.OutputStream))
            {
                sw.Write(content);
            }
        }
        public static void WriteJson(this HttpListenerResponse response, string content)
        {
            response.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
            using (StreamWriter sw = new StreamWriter(response.OutputStream))
            {
                sw.Write(content);
            }
        }

        public static void End(this HttpListenerResponse response)
        {
            response.OutputStream.Close();
        }
    }

    public class HttpRequest
    {
        private string requestBody = null;
        public HttpListenerRequest Request = null;
        public HttpRequest(HttpListenerRequest request)
        {
            Request = request;
        }

        public string GetBody()
        {
            if (requestBody == null)
            {
                using (StreamReader readStream = new StreamReader(Request.InputStream, Encoding.UTF8))
                {
                    requestBody = readStream.ReadToEnd();
                }
            }
            return requestBody;
        }

        public static string Get(string url, string queryString = "")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + (string.IsNullOrWhiteSpace(queryString) ? "" : "?") + queryString);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
            string result = streamReader.ReadToEnd();
            streamReader.Close();
            stream.Close();
            return result;
        }

        public static string Post(string url, string data = "")
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            if (!string.IsNullOrWhiteSpace(data))
            {
                byte[] postData = encoding.GetBytes(data);
                request.ContentLength = postData.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(postData, 0, postData.Length);
                requestStream.Close();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream, encoding);
            string result = streamReader.ReadToEnd();
            streamReader.Close();
            stream.Close();
            return result;
        }
    }

    public class HttpResponse
    {
        public HttpListenerResponse Response = null;
        public HttpResponse(HttpListenerResponse resp)
        {
            Response = resp;
        }

        public void SetBody(string body)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(body);
            Response.ContentLength64 = buffer.Length;
            Stream output = Response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
        }

        internal void Finish()
        {
            Response.OutputStream.Close();
        }
    }

    public class HttpHandler
    {
        public Regex UrlPattern = null;
        public RequestHandler RequestHandler = null;
        public string HttpMethod = string.Empty;

        public HttpHandler(Regex urlPattern, string httpMethod, RequestHandler handler)
        {
            HttpMethod = httpMethod;
            UrlPattern = urlPattern;
            RequestHandler = handler;
        }
    }
}
