using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Util.Logs;
using System.Util.Collections;

namespace System.Util.Net.Web.Cookie
{
    /// <summary>
    /// HttpCookies
    /// </summary>
    public class HttpCookies : IEnumerable<HttpCookie>
    {
        SafeDictionary<string, HttpCookie> cookies;
        /// <summary>
        /// Initializes a new instance of the <see cref="System.Util.Net.Web.Cookie.HttpCookies"/> class.
        /// </summary>
        public HttpCookies()
        {
            this.cookies = new SafeDictionary<string, HttpCookie>();
        }
        /// <summary>
        /// Get the cookie with the specified key.
        /// </summary>
        /// <param name="key">Key</param>
        public HttpCookie this[string key]
        {
            get
            {
                return cookies.ContainsKey(key) ? cookies[key] : new HttpCookie { Name = key };
            }
        }
        /// <summary>
        /// Get enumerator
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<HttpCookie> GetEnumerator()
        {
            return cookies.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="cookie"></param>
        public void Add(HttpCookie cookie)
        {
            cookies[cookie.Name] = cookie;
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="str"></param>
        public void Add(string str)
        {
            try
            {
                var cookiestrings = str.Split(';');
                foreach (string cookiestring in cookiestrings)
                {
                    var cookie = cookiestring.Split('=');
                    if (cookie.Length >= 2)
                    {
                        var name = cookie[0].Trim();
                        var content = cookie[1].Trim();
                        this.Add(new HttpCookie { Name = name, Content = content });
                    }
                }
            }
            catch (Exception e)
            {
                LogProvider.Default.Warn("Error Cookies \r\n");
                LogProvider.Default.Warn(e);
            }
        }
    }
}
