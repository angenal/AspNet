using System.Collections.Generic;
using System.Util.Collections;
using System.Util.Logs;
using System.Util.Net.Web.Error;
using System.Util.Net.Web.Event;
using System.Util.Net.Web.Interfaces;
using System.Util.Net.Web.Protocol;

namespace System.Util.Net.Web
{
    /// <summary>
    /// WebServer
    /// </summary>
    public class WebServer
    {
        /// <summary>
        /// Name
        /// </summary>
        /// <value></value>
        public string Name
        {
            get;
            internal set;
        } = $"WebServer({typeof(WebServer).Assembly.GetName().Version})";

        readonly List<IListener> _listeners = new List<IListener>();

        /// <summary>
        /// Log
        /// </summary>
        public LogProvider Log
        {
            get;
            set;
        } = LogProvider.Default;

        /// <summary>
        /// IsStarted
        /// </summary>
        /// <value><c>true</c> if is started; otherwise, <c>false</c>.</value>
        public bool IsStarted
        {
            get;
            private set;
        }

        /// <summary>
        /// Websites
        /// </summary>
        public SafeDictionary<string, Website> Websites
        {
            get;
        } = new SafeDictionary<string, Website>();

        /// <summary>
        /// Start
        /// </summary>
        public void Start()
        {
            if (IsStarted)
                return;
            if (Websites.Keys.Count == 0)
            {
                Websites.Add("", new Website(""));
            }
            foreach (var x in Websites)
            {
                x.Value.Start(this);
            }
            foreach (var listener in _listeners)
            {
                if (listener.Server != this)
                {
                    listener.Server = this;
                }
                listener.Start();
            }
            IsStarted = true;
        }

        /// <summary>
        /// Stop
        /// </summary>
        public void Stop()
        {
            if (!IsStarted)
                return;
            foreach (var listener in _listeners)
            {
                listener.Stop();
            }
            IsStarted = true;
        }

        /// <summary>
        /// Add Website
        /// </summary>
        /// <param name="website">The website.</param>
        public void AddWebsite(Website website) => Websites.Add(website.HostName, website);

        /// <summary>
        /// Add listener
        /// </summary>
        /// <param name="listener">Listener</param>
        public void AddListener(IListener listener)
        {
            if (IsStarted)
            {
                listener.Start();
            }
            _listeners.Add(listener);
        }

        /// <summary>
        /// Removes listener
        /// </summary>
        /// <param name="listener">Listener</param>
        public void RemoveListener(IListener listener)
        {
            if (!_listeners.Contains(listener))
            {
                Log.Warn("Try to remove a listener which hasn't been added");
                return;
            }
            if (IsStarted)
            {
                listener.Stop();
            }
            _listeners.Remove(listener);
        }

        /// <summary>
        /// RequestParsed EventHandler
        /// </summary>
        public event EventHandler<RequestParsedEventArgs> RequestParsed;

        internal void OnParsed(HttpContext x)
        {
            if (this.RequestParsed != null)
            {
                var args = new RequestParsedEventArgs
                {
                    Request = x.Request
                };
                this.RequestParsed(this, args);
            }
        }

        internal IHttpResponse OnProcess(HttpContext x)
        {
            try
            {
                var host = x.Request.Headers[HttpHeaders.Host];
                var website = Websites[host] ?? Websites[""];
                if (website == null)
                {
                    return ErrorHelper.Build(400, 0, Name, "Invaild Hostname");
                }
                return website.OnProcess(x);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return ErrorHelper.Build(500, 0, Name);
            }
        }
    }
}
