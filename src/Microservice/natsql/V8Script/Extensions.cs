using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using LazyCache;
using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;
using NATS.Client;
using natsql.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace natsql.V8Script
{
    /// <summary>
    /// 
    /// </summary>
    public static class Extensions
    {
        public static readonly JsonConverter[] JsonConverters = new JsonConverter[] { new IsoDateTimeConverter { DateTimeFormat = NewtonsoftJson.DateTimeFormat } };

        public static string ToJson<T>(this T obj) => JsonConvert.SerializeObject(obj, JsonConverters);

        public static T ToObject<T>(this string s) => JsonConvert.DeserializeObject<T>(s);

        public static List<int> ToListInt(this ScriptObject obj)
        {
            var p = new List<int>();
            foreach (string attr in obj.GetDynamicMemberNames())
            {
                var v = obj.GetProperty(attr);
                if (v is int i) p.Add(i);
            }
            return p;
        }

        public static List<string> ToListString(this ScriptObject obj)
        {
            var p = new List<string>();
            foreach (string attr in obj.GetDynamicMemberNames())
            {
                var v = obj.GetProperty(attr);
                if (v is string i && !string.IsNullOrWhiteSpace(i)) p.Add(i);
            }
            return p;
        }

        public static Dictionary<string, object> ToDictionary(this ScriptObject obj)
        {
            var p = new Dictionary<string, object>();
            if (obj == null) return p;
            foreach (var key in obj.PropertyNames) p.Add(key, obj.GetProperty(key));
            return p;
        }

        public static string ToStr(this Dictionary<string, object> p)
        {
            var s = new StringBuilder();
            if (p != null) foreach (var k in p.Keys) { s.Append(k); s.Append(p[k]); }
            return s.ToString();
        }

        public static int Crc32(this string text)
        {
            if (string.IsNullOrEmpty(text)) return 0;
            var c = new Force.Crc32.Crc32Algorithm();
            var b = Encoding.ASCII.GetBytes(text);
            return Math.Abs(BitConverter.ToInt32(c.ComputeHash(b), 0));
        }

        public static string Md5(this string text)
        {
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
            return BitConverter.ToString(s).ToLower().Replace("-", "");
        }

        public static int ToInt(this Guid guid, byte shift = 8)
        {
            var res = 0;
            var bytes = guid.ToByteArray();

            for (var i = 0; i < shift; i++)
                res += bytes[i] << i * 8;

            return Math.Abs(res);
        }

        public static T DeepClone<T>(this T obj) where T : class
        {
            if (obj == null) return null;
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                return (T)bf.Deserialize(ms);
            }
        }

        public static Tuple<bool, string> DownloadFile(this Uri address, string dirName, string fileName = null, TimeSpan? timeout = null, bool checkFileExists = true, bool checkFileTypesExists = true)
        {
            if (dirName == null || !Directory.Exists(dirName)) return new Tuple<bool, string>(false, fileName);
            if (string.IsNullOrEmpty(fileName))
            {
                fileName = Md5((address.Authority + address.AbsolutePath).ToLower());
            }
            if (fileName.Length > 0 && checkFileExists)
            {
                if (File.Exists(Path.Combine(dirName, fileName))) return new Tuple<bool, string>(true, fileName);
                if (checkFileTypesExists)
                {
                    foreach (string extName in ImageFileTypes.Values)
                    {
                        if (File.Exists(Path.Combine(dirName, fileName + extName))) return new Tuple<bool, string>(true, fileName + extName);
                    }
                }
            }

            var ok = false;
            if (timeout == null || timeout == TimeSpan.Zero) timeout = TimeSpan.FromMinutes(2);
            Task.Factory.StartNew(() =>
            {
                try
                {
                    string src = address.AbsolutePath;
                    int index = src.LastIndexOf('.'), cup = 5;
                    var hasExt = index > 0 && index > src.Length - cup;
                    string extName = hasExt ? src.Substring(index) : null;
                    index = fileName.LastIndexOf('.');
                    hasExt = index > 0 && index > fileName.Length - cup;
                    if (hasExt)
                    {
                        extName = fileName.Substring(index);
                        fileName = fileName.Substring(0, fileName.Length - extName.Length);
                    }

                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.82 Safari/537.36");

                        byte[] fileBytes = wc.DownloadData(address);
                        string fileType = wc.ResponseHeaders[HttpResponseHeader.ContentType];

                        if (string.IsNullOrEmpty(fileType) && string.IsNullOrEmpty(extName))
                            return;

                        if (fileType.ToLower().StartsWith("image"))
                        {
                            string tpy = fileType.ToLower();
                            foreach (string k in ImageFileTypes.Keys)
                            {
                                if (tpy != k) continue;
                                extName = ImageFileTypes[k];
                                break;
                            }
                        }

                        fileName += extName;
                        var path = Path.Combine(dirName, fileName);
                        File.WriteAllBytes(path, fileBytes);
                        ok = true;
                    }
                }
                catch (Exception) { }
            }).Wait(timeout.Value);
            return new Tuple<bool, string>(ok, fileName);
        }

        public static Tuple<string, string> MapPath(this Uri address) => new Tuple<string, string>(HttpContext.Current?.Server.MapPath(address.AbsolutePath.Substring(0, 1 + address.AbsolutePath.LastIndexOf('/'))) ?? Environment.CurrentDirectory.Replace('\\', '/').TrimEnd('/') + '/', address.AbsoluteUri.Substring(0, 1 + address.AbsoluteUri.LastIndexOf('/')));

        public static Dictionary<string, string> ImageFileTypes = new Dictionary<string, string>
        {
            { "image/bmp", ".bmp" },
            { "image/gif", ".gif" },
            { "image/jpeg", ".jpg" },
            { "image/png", ".png" },
            { "image/pjpeg", ".jfif" },
            { "image/svg+xml", ".svg" },
            { "image/tiff", ".tiff" },
            { "image/x-icon", ".ico" },
            { "image/x-jg", ".art" },
        };
    }

    /// <summary>
    /// 
    /// </summary>
    public static class ScriptExtensions
    {
        /// <summary>
        /// DateTime.Now.js() => new Date()
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static object js(this DateTime dt)
        {
            var t = dt.Add(TimeZone.CurrentTimeZone.GetUtcOffset(dt));
            object createDate = ScriptEngine.Current.Script.__createDate;
            if (createDate is Undefined)
                createDate = ScriptEngine.Current.Evaluate(@"__createDate=function(yr,mo,day,hr,min,sec,ms){return new Date(yr,mo,day,hr,min,sec,ms)}");
            //createDate = ScriptEngine.Current.Evaluate(@"__createDate=function(yr,mo,day,hr,min,sec,ms){return new Date(Date.UTC(yr,mo,day,hr,min,sec,ms)).toLocaleString('zh-CN',{timeZone:'Asia/Shanghai'})}");
            return ((dynamic)createDate)(t.Year, t.Month - 1, t.Day, t.Hour, t.Minute, t.Second, t.Millisecond);
        }

        #region Html Document Parser

        /// <summary>
        /// query HtmlNode[] selectors
        /// https://www.w3.org/TR/selectors-3/
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<HtmlNode> query(this HtmlDocument doc, string selector, string separator = "\n")
        {
            var nodes = new List<HtmlNode>();
            foreach (string i in selector.Split(separator.ToCharArray()).Where(i => !string.IsNullOrWhiteSpace(i)))
                nodes.AddRange(doc.DocumentNode.QuerySelectorAll(i));
            return nodes;
        }

        /// <summary>
        /// query HtmlNode[] selectors is List String ScriptObject
        /// https://www.w3.org/TR/selectors-3/
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<HtmlNode> query(this HtmlDocument doc, ScriptObject selector)
        {
            var nodes = new List<HtmlNode>();
            foreach (string i in selector.ToListString())
                nodes.AddRange(doc.DocumentNode.QuerySelectorAll(i));
            return nodes;
        }

        /// <summary>
        /// query HtmlNode[] selectors is params string[]
        /// https://www.w3.org/TR/selectors-3/
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<HtmlNode> query(this HtmlDocument doc, params string[] selector)
        {
            var nodes = new List<HtmlNode>();
            foreach (string i in selector.Where(i => !string.IsNullOrWhiteSpace(i)))
                nodes.AddRange(doc.DocumentNode.QuerySelectorAll(i));
            return nodes;
        }

        /// <summary>
        /// query Html selectors
        /// https://www.w3.org/TR/selectors-3/
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static string html(this HtmlDocument doc, string selector, bool innerHtml = false) => html(query(doc, selector), innerHtml);

        /// <summary>
        /// query Html selectors is List String ScriptObject
        /// https://www.w3.org/TR/selectors-3/
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="selector"></param>
        /// <param name="innerHtml"></param>
        /// <returns></returns>
        public static string html(this HtmlDocument doc, ScriptObject selector, bool innerHtml = false) => html(query(doc, selector), innerHtml);

        /// <summary>
        /// query Html selectors is params string[]
        /// https://www.w3.org/TR/selectors-3/
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static string html(this HtmlDocument doc, params string[] selector) => html(query(doc, selector), false);

        /// <summary>
        /// query object[] selectors
        /// https://www.w3.org/TR/selectors-3/
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static object[] json(this HtmlDocument doc, string selector) => json(query(doc, selector));

        /// <summary>
        /// query object[] selectors is List String ScriptObject
        /// https://www.w3.org/TR/selectors-3/
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static object[] json(this HtmlDocument doc, ScriptObject selector) => json(query(doc, selector));

        /// <summary>
        /// query object[] selectors is params string[]
        /// https://www.w3.org/TR/selectors-3/
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static object[] json(this HtmlDocument doc, params string[] selector) => json(query(doc, selector));

        /// <summary>
        /// json object[] nodes.json()
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static object[] json(this IEnumerable<HtmlNode> nodes)
        {
            var items = new object[nodes.Count()];
            for (var i = 0; i < items.Length; i++) items[i] = json(nodes.ElementAt(i));
            return items;
        }

        /// <summary>
        /// json object node.json()
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static object json(this HtmlNode node)
        {
            dynamic item = new System.Dynamic.ExpandoObject();
            item.html = node.InnerHtml?.Trim();
            item.text = node.InnerText?.Trim();
            item.tagName = node.Name;
            foreach (HtmlAttribute attr in node.Attributes)
            {
                switch (attr.Name)
                {
                    case "id": item.id = attr.Value; break;
                    case "alt": item.alt = attr.Value; break;
                    case "class": item.className = attr.Value; break;
                    case "content": item.content = attr.Value; break;
                    case "name": item.name = attr.Value; break;
                    case "href": item.href = attr.Value; break;
                    case "src": item.src = attr.Value; break;
                    case "style": item.style = attr.Value; break;
                    case "target": item.target = attr.Value; break;
                    case "type": item.type = attr.Value; break;
                    case "title": item.title = attr.Value; break;
                    case "value": item.value = attr.Value; break;
                    default: break;
                }
            }
            return item;
        }

        /// <summary>
        /// html string nodes.html()
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static string html(this IEnumerable<HtmlNode> nodes, bool innerHtml = false)
        {
            var s = new StringBuilder();
            foreach (HtmlNode node in nodes) s.Append(html(node, innerHtml));
            return s.ToString();
        }

        /// <summary>
        /// html string node.html()
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static string html(this HtmlNode node, bool innerHtml = false)
        {
            if (innerHtml) return node.InnerHtml?.Trim();

            var s = new StringBuilder();
            s.AppendFormat("<{0}", node.Name);
            foreach (HtmlAttribute attr in node.Attributes) s.AppendFormat(" {0}=\"{1}\"", attr.Name, attr.Value?.Replace("\"", "'"));
            s.Append(">");
            s.Append(node.InnerHtml?.Trim());
            s.AppendFormat("</{0}>", node.Name);
            return s.ToString();
        }

        /// <summary>
        /// doc.save(path)
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="path"></param>
        public static void save(this HtmlDocument doc, string path) => File.WriteAllText(path, doc.DocumentNode.OuterHtml);

        #endregion

        /// <summary>
        /// Init Add Host Extensions
        /// </summary>
        /// <param name="engine"></param>
        public static void AddHostExtensions(this V8ScriptEngine engine)
        {
            #region function setTimeout(func, delay)

            engine.Script._setTimeout = new Action<ScriptObject, int>((func, delay) =>
            {
                var timer = new Timer(_ => func.Invoke(false));
                timer.Change(delay, Timeout.Infinite);
            });

            engine.Execute(@"
function setTimeout(func, delay) {
    let args = Array.prototype.slice.call(arguments, 2);
    _setTimeout(func.bind(undefined, ...args), delay || 0);
}
            ");

            #endregion

            #region function $.loadxml(text) return XmlDocument

            //            engine.Execute(@"
            //$.loadxml = function (text) {
            //    var doc = new XmlDocument();
            //    doc.LoadXml(text);
            //    return doc;
            //};
            //            ");

            #endregion

            #region function $.loadhtml(text), $.loadurl(url) return HtmlDocument

            //            engine.Execute(@"
            //$.loadhtml = function (text) {
            //    var doc = new HtmlDocument();
            //    if (!text) return doc;
            //    let c = text[0]; if (c == 'A' || c == 'B' || c == 'C' || c == 'D' || c == 'E' || c == 'F') text = $.loadfile(text);
            //    doc.LoadHtml(text);
            //    return doc;
            //};
            //            ");

            //            engine.Execute(@"
            //$.loadurl = function (url) {
            //    let duration = arguments.length > 1 ? arguments[1] : $.timeout();
            //    let userAgent = arguments.length > 2 ? arguments[2] : 'Mozilla /5.0 (Macintosh; Intel Mac OS X 10_14_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.105 Safari/537.36';
            //    let web = new HtmlWeb();
            //    web.AutoDetectEncoding = true;
            //    web.UsingCache = false;
            //    web.BrowserTimeout = TimeSpan.FromSeconds(duration);
            //    web.UserAgent = userAgent;
            //    var doc = web.Load(url);
            //    return doc;
            //};
            //            ");

            #endregion
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class TimeExt
    {
        /// <summary>
        /// 时间戳 DateTime 转化十六进制
        /// </summary>
        public static string ToTimestampHex(this DateTime dateTime, bool toSeconds = true)
        {
            return ToTimestampHex(toSeconds ? ToTimestamp(dateTime) / 1000 : ToTimestamp(dateTime));
        }

        /// <summary>
        /// 时间戳 Seconds 转化十六进制
        /// </summary>
        public static string ToTimestampHex(this long t) => t.ToString("x8").ToUpper();

        /// <summary>
        /// 时间戳 Seconds 转化时间值
        /// </summary>
        public static DateTime ToDateTime(this long t, bool toSeconds = true)
        {
            return toSeconds ? _epoch_local.AddSeconds(t) : _epoch_local.AddMilliseconds(t);
        }

        /// <summary>
        /// 时间戳 Seconds 即自1970年1月1日UTC以来经过的秒数 (等价于ToTimestampSeconds)
        /// </summary>
        public static long Unix(this DateTime dateTime) => (long)(dateTime.ToUniversalTime() - _epoch_utc).TotalSeconds;

        /// <summary>
        /// 时间戳 Seconds 即自1970年1月1日UTC以来经过的秒数 (等价于Unix)
        /// </summary>
        public static long ToTimestampSeconds(this DateTime dateTime) => ToTimestamp(dateTime) / 1000;

        /// <summary>
        /// 时间戳 Milliseconds 即自1970年1月1日UTC以来经过的毫秒数
        /// </summary>
        public static long ToTimestamp(this DateTime dateTime)
        {
#if NS2 || NETSTANDARD2_0
            return (dateTime < _epoch_local ? DateTimeOffset.Now : new DateTimeOffset(dateTime)).ToUnixTimeMilliseconds();
#else
            return (long)Math.Round(((dateTime < _epoch_local ? DateTime.Now : dateTime) - _epoch_local).TotalMilliseconds, MidpointRounding.AwayFromZero);
#endif
        }

        /// <summary>
        /// 时间戳 Nanoseconds 即自1970年1月1日UTC以来经过的纳秒数
        /// </summary>
        public static long UnixNano(this DateTime dateTime) => (dateTime.ToUniversalTime() - _epoch_utc).Ticks * 100;

        /// <summary>
        /// 时间范围值
        /// </summary>
        public static string ToDurationString(this TimeSpan duration)
        {
            var a = duration.ToString().Split(':', '.');
            int h = int.Parse(a[0]), m = int.Parse(a[1]), s = int.Parse(a[2]), ms = int.Parse(a[3].Substring(0, 3));
            return $"{(h > 0 ? h + "h" : "")}{(m > 0 ? m + "m" : "")}{(s > 0 ? s + "s" : "")}{(ms > 0 ? ms + "ms" : "")}";
        }

        private static readonly DateTime _epoch_utc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static readonly DateTime _epoch_local = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
    }

    /// <summary>
    /// 
    /// </summary>
    public static class ConsoleFunctions
    {
        /// <summary>
        /// console.log(args)
        /// console.log('{0:G}',new Date)
        /// </summary>
        /// <param name="args"></param>
        public static void log(params object[] args)
        {
            Console.Write("console.log > ");
            foreach (var arg in args)
            {
                if (arg == null || arg == DBNull.Value)
                {
                    Console.Write("null ");
                    continue;
                }

                if (arg is Undefined)
                {
                    Console.Write("undefined ");
                    continue;
                }

                if (arg is string && Regex.IsMatch(arg.ToString(), @"\{\d+:?\w*\}"))
                {
                    Console.Write(arg.ToString(), args.Skip(1).ToArray());
                    Console.Write(" ");
                    break;
                }

                if (arg is string || arg is char || arg is ulong || arg is long || arg is int || arg is uint || arg is bool || arg is decimal || arg is float || arg is double)
                {
                    Console.Write(arg);
                    Console.Write(" ");
                    continue;
                }

                if (arg is DateTime)
                {
                    Console.Write(((DateTime)arg).ToString(NewtonsoftJson.DateTimeFormat));
                    Console.Write(" ");
                    continue;
                }

                #region HtmlNode

                if (arg is HtmlNode node0)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(node0.html());
                    continue;
                }

                if (arg is IEnumerable<HtmlNode> nodes1)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    foreach (HtmlNode node1 in nodes1) Console.WriteLine(node1.html());
                    continue;
                }

                if (arg is HtmlNodeCollection nodes2)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    foreach (HtmlNode node1 in nodes2) Console.WriteLine(node1.html());
                    continue;
                }

                #endregion

                var s = JsonConvert.SerializeObject(arg, Extensions.JsonConverters);
                Console.Write(s);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class DatabaseObject
    {
        public readonly SqlSugarClient Db;

        readonly V8ScriptEngine Engine;

        readonly string Prefix;
        readonly string Subject;

        public string prefix => Prefix;
        public string subject => Subject;

        public DatabaseObject(DbConfig config, V8ScriptEngine engine, string prefix, string subject)
        {
            if (config == null || string.IsNullOrWhiteSpace(config.Conn))
                return;

            //Create SqlSugarClient
            Db = new SqlSugarClient(new ConnectionConfig
            {
                ConnectionString = config.Conn,
                DbType = config.Type == "mysql" ? DbType.MySql : DbType.SqlServer,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true,
            });
            Db.Ado.CommandTimeOut = 120;
            //Print sql
            if (config.Debug) Db.Aop.OnLogExecuting = (sql, pars) => Console.WriteLine(@"[{0:T}] {1} > {2}: {3} < {4}", DateTime.Now, Subject, Db.CurrentConnectionConfig.DbType, sql, Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            Engine = engine;
            Prefix = prefix;
            Subject = subject;
        }

        /// <summary>
        /// var uuid = $db.uuid()
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object uuid(params object[] args)
        {
            if (args.Length > 0)
                return Guid.NewGuid().ToString(args[0].ToString());
            return Guid.NewGuid().ToString().ToLower();
        }

        /// <summary>
        /// var guid = $db.guid("N")
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object guid(params object[] args)
        {
            if (args.Length > 0)
                return Guid.NewGuid().ToString(args[0].ToString());
            return Guid.NewGuid().ToString().ToLower();
        }

        /// <summary>
        /// var seconds = $db.timeout()
        /// $db.timeout(60)
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object timeout(params object[] args)
        {
            if (args.Length > 0)
            {
                if (int.TryParse(args[0].ToString(), out int i) && i > 0)
                    Db.Ado.CommandTimeOut = i;
            }
            return Db.Ado.CommandTimeOut;
        }

        /// <summary>
        /// $db.q: return ResultObject or Array of all rows
        /// $db.q('select * from table1 where id=@id',{id:1})
        /// </summary>
        /// <param name="args"></param>
        public object q(params object[] args)
        {
            if (Db == null || args.Length == 0)
                return null;

            string sql = args[0].ToString();
            if (string.IsNullOrWhiteSpace(sql))
                return null;

            Dictionary<string, object> p = args.Length > 1 ? (args[1] as ScriptObject)?.ToDictionary() : null;

            string code = null;

            var cacheType = CacheObject.Types.Default;
            var cacheEnabled = args.Length > 2 && Enum.TryParse(args[2].ToString(), out cacheType);
            var cacheKey = cacheEnabled ? (sql + p.ToStr()).Md5() : null;
            if (cacheEnabled) code = CacheObject.Get(cacheType, cacheKey);

            if (string.IsNullOrEmpty(code))
            {
                var dt = Db.Ado.GetDataTable(sql, p);
                if (dt == null || dt.Rows.Count == 0)
                    return null;

                code = JsonConvert.SerializeObject(dt, Extensions.JsonConverters);
                if (cacheEnabled) CacheObject.Set(cacheType, cacheKey, code);
            }

            var obj = Engine.Evaluate(JS.SecurityCode(code));
            return obj;
        }

        /// <summary>
        /// $db.q2: return Cache{ Memory = 0, Redis, Default } ResultObject or Array of all rows
        /// $db.q2(0,'select * from table1 where id=@id',{id:1})
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object q2(params object[] args)
        {
            if (Db == null || args.Length <= 1)
                return null;

            string sql = args[1].ToString();
            if (string.IsNullOrWhiteSpace(sql))
                return null;

            Dictionary<string, object> p = args.Length > 2 ? (args[2] as ScriptObject)?.ToDictionary() : null;

            Enum.TryParse(args[0].ToString(), out CacheObject.Types cacheType);
            var cacheKey = (sql + p.ToStr()).Md5();
            var code = CacheObject.Get(cacheType, cacheKey);

            if (string.IsNullOrEmpty(code))
            {
                var dt = Db.Ado.GetDataTable(sql, p);
                if (dt == null || dt.Rows.Count == 0)
                    return null;

                code = JsonConvert.SerializeObject(dt, Extensions.JsonConverters);
                CacheObject.Set(cacheType, cacheKey, code);
            }

            var obj = Engine.Evaluate(JS.SecurityCode(code));
            return obj;
        }

        /// <summary>
        /// $db.g: return ResultValue of first column in first row
        /// $db.g('select name from table1 where id=@id',{id:1})
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object g(params object[] args)
        {
            if (Db == null || args.Length == 0)
                return null;

            string sql = args[0].ToString();
            if (string.IsNullOrWhiteSpace(sql))
                return null;

            Dictionary<string, object> p = args.Length > 1 ? (args[1] as ScriptObject)?.ToDictionary() : null;

            object obj = null;

            var cacheType = CacheObject.Types.Default;
            var cacheEnabled = args.Length > 2 && Enum.TryParse(args[2].ToString(), out cacheType);
            var cacheKey = cacheEnabled ? (sql + p.ToStr()).Md5() : null;
            if (cacheEnabled)
            {
                var code = CacheObject.Get(cacheType, cacheKey);
                if (!string.IsNullOrEmpty(code)) obj = JsonConvert.DeserializeObject(code);
            }

            if (obj == null)
            {
                obj = Db.Ado.GetScalar(sql, p);

                if (obj == null || obj == DBNull.Value)
                    return null;

                if (cacheEnabled) CacheObject.Set(cacheType, cacheKey, JsonConvert.SerializeObject(obj, Extensions.JsonConverters));
            }
            return obj;
        }

        /// <summary>
        /// $db.g2: return Cache{ Memory = 0, Redis, Default } ResultValue of first column in first row
        /// $db.g2(0,'select name from table1 where id=@id',{id:1})
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object g2(params object[] args)
        {
            if (Db == null || args.Length <= 1)
                return null;

            string sql = args[1].ToString();
            if (string.IsNullOrWhiteSpace(sql))
                return null;

            Dictionary<string, object> p = args.Length > 2 ? (args[2] as ScriptObject)?.ToDictionary() : null;

            object obj = null;

            Enum.TryParse(args[0].ToString(), out CacheObject.Types cacheType);
            var cacheKey = (sql + p.ToStr()).Md5();
            var code = CacheObject.Get(cacheType, cacheKey);
            if (!string.IsNullOrEmpty(code)) obj = JsonConvert.DeserializeObject(code);

            if (obj == null)
            {
                obj = Db.Ado.GetScalar(sql, p);

                if (obj == null || obj == DBNull.Value)
                    return null;

                CacheObject.Set(cacheType, cacheKey, JsonConvert.SerializeObject(obj, Extensions.JsonConverters));
            }
            return obj;
        }

        /// <summary>
        /// $db.i: return LastInsertId must int in number-id-column
        /// $db.i('insert into table1 values(@id,@name)',{id:1,name:'test'})
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object i(params object[] args)
        {
            if (Db == null || args.Length == 0)
                return 0;

            if (args.Length > 1 && args[0].GetType().Name.EndsWith("Array"))
            {
                if (Db.CurrentConnectionConfig.DbType != DbType.SqlServer)
                    return 0;

                var dt = new System.Data.DataTable(args[1].ToString());
                var idc = args.Length > 2 ? args[2].ToString() : "Id";

                var list = (dynamic)args[0];
                var leng = list.length;
                var count = 0;
                for (var i = 0; i < leng; i++)
                {
                    var obj = list[i] as ScriptObject;
                    if (obj == null || obj.PropertyNames.Count() == 0) continue;
                    if (dt.Columns.Count == 0)
                    {
                        dt.Columns.Add(idc);
                        foreach (var key in obj.PropertyNames) if (key != idc) dt.Columns.Add(key);
                    }
                    if (dt.Columns.Count > 0)
                    {
                        var row = dt.NewRow();
                        foreach (var key in obj.PropertyNames) if (key != idc) row[key] = obj.GetProperty(key);
                        dt.Rows.Add(row);

                        if (i % 201 == 200 || i + 1 == leng)
                        {
                            count += SQLServer.BatchInsert(dt, Db.Ado.CommandTimeOut, Db.CurrentConnectionConfig.ConnectionString);
                            dt.Clear();
                        }
                    }
                }
                return count;
            }
            else
            {
                string sql = args[0].ToString();
                if (string.IsNullOrWhiteSpace(sql))
                    return 0;

                Dictionary<string, object> p = args.Length > 1 ? (args[1] as ScriptObject)?.ToDictionary() : null;

                var sql0 = sql.ToUpper();
                sql = sql.Trim().TrimEnd(';') + (Db.CurrentConnectionConfig.DbType == DbType.MySql
                ? (sql0.Contains("LAST_INSERT_ID()") ? "" : ";SELECT LAST_INSERT_ID();") : Db.CurrentConnectionConfig.DbType == DbType.SqlServer
                ? (sql0.Contains("SCOPE_IDENTITY()") ? "" : ";SELECT SCOPE_IDENTITY();") : "");
                return Db.Ado.GetScalar(sql, p);
            }
        }

        /// <summary>
        /// $db.x: return RowsAffected all inserted,updated,deleted
        /// $db.x('update table1 set name=@name where id=@id',{id:1,name:'test'})
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object x(params object[] args)
        {
            if (Db == null || args.Length == 0)
                return null;

            string sql = args[0].ToString();
            if (string.IsNullOrWhiteSpace(sql))
                return null;

            Dictionary<string, object> p = args.Length > 1 ? (args[1] as ScriptObject)?.ToDictionary() : null;
            var obj = Db.Ado.ExecuteCommand(sql, p);
            return obj;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class NatsObject
    {
        private IConnection Connection { get; set; }

        readonly string Prefix;
        readonly string Subject;

        public string prefix => Prefix;
        public string subject => Subject;

        public string name => Connection?.Opts.Name ?? null;

        public NatsObject(IConnection connection, string prefix, string subject)
        {
            Connection = connection;
            Prefix = prefix;
            Subject = subject;
        }

        /// <summary>
        /// $nats.pub('data'); $nats.pub('subj','data')
        /// </summary>
        /// <param name="args"></param>
        public void pub(params object[] args)
        {
            var length = args.Length;
            if (length == 0)
                return;

            if (length == 1)
            {
                Connection?.Publish(Subject, Encoding.UTF8.GetBytes((args[0] as ScriptObject)?.ToJson() ?? args[0].ToString()));
                Connection?.Flush();
            }
            else if (length == 2)
            {
                Connection?.Publish(args[0].ToString(), Encoding.UTF8.GetBytes((args[1] as ScriptObject)?.ToJson() ?? args[1].ToString()));
                Connection?.Flush();
            }
        }

        /// <summary>
        /// $nats.req('data'); $nats.req('data',3); $nats.req('subj','data',3) // timeout:3s
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object req(params object[] args)
        {
            var length = args.Length;
            if (length == 0)
                return null;

            byte[] p = null;
            if (length == 1)
            {
                p = Connection?.Request(Subject, Encoding.UTF8.GetBytes((args[0] as ScriptObject)?.ToJson() ?? args[0].ToString())).Data;
                Connection?.Flush();
            }
            else if (length == 2)
            {
                p = int.TryParse(args[1].ToString(), out int timeout)
                    ? Connection?.Request(Subject, Encoding.UTF8.GetBytes((args[0] as ScriptObject)?.ToJson() ?? args[0].ToString()), timeout).Data
                    : Connection?.Request(args[0].ToString(), Encoding.UTF8.GetBytes((args[1] as ScriptObject)?.ToJson() ?? args[1].ToString())).Data;
                Connection?.Flush();
            }
            else if (length == 3)
            {
                p = int.TryParse(args[2].ToString(), out int timeout)
                    ? Connection?.Request(args[0].ToString(), Encoding.UTF8.GetBytes((args[1] as ScriptObject)?.ToJson() ?? args[1].ToString()), timeout).Data
                    : Connection?.Request(args[0].ToString(), Encoding.UTF8.GetBytes((args[1] as ScriptObject)?.ToJson() ?? args[1].ToString())).Data;
                Connection?.Flush();
            }

            return p == null && p.Length == 0 ? null : Encoding.UTF8.GetString(p);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class AjaxFunctions
    {
        readonly Dictionary<string, object> Values = new Dictionary<string, object>();
        readonly V8ScriptEngine Engine;
        readonly RestClient client;

        public AjaxFunctions(V8ScriptEngine engine)
        {
            Engine = engine;
            client = new RestClient();
            client.AddDefaultHeader("Accept", "*/*");
            client.AddDefaultHeader("Accept-Language", "zh-CN,zh;q=0.9,en;q=0.8");
            client.UserAgent = "Mozilla /5.0 (Macintosh; Intel Mac OS X 10_14_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.105 Safari/537.36";
            client.FailOnDeserializationError = false;
            client.ThrowOnDeserializationError = false;
            client.FollowRedirects = true;
            client.MaxRedirects = 2;
            client.ReadWriteTimeout = 60 * 1000;
            client.Timeout = 60 * 1000; // default timeout 60s
            //client.ThrowOnAnyError = true;
            // Override with Custom Newtonsoft JSON Handler
            //client.AddJsonHandler();
        }

        /// <summary>
        /// var uuid = $.uuid()
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object uuid(params object[] args)
        {
            if (args.Length > 0)
                return Guid.NewGuid().ToString(args[0].ToString());
            return Guid.NewGuid().ToString().ToLower();
        }

        /// <summary>
        /// var guid = $.guid("N")
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object guid(params object[] args)
        {
            if (args.Length > 0)
                return Guid.NewGuid().ToString(args[0].ToString());
            return Guid.NewGuid().ToString().ToLower();
        }

        /// <summary>
        /// var i = $.crc("text")
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public object crc(params object[] args) => args.Length == 0 ? 0 : string.Join("", args).Crc32();

        /// <summary>
        /// var i = $.md5("text")
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public object md5(params object[] args) => args.Length == 0 ? "" : string.Join("", args).Md5();

        /// <summary>
        /// var ok = $.v("n",1)
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object v(params object[] args)
        {
            if (args.Length == 0) return false;

            string k = args[0].ToString();
            if (string.IsNullOrEmpty(k)) return false;

            if (args.Length == 1)
            {
                return Values.Keys.Contains(k) ? Values[k] : false;
            }

            if (args.Length == 2)
            {
                Values[k] = args[1];
                return true;
            }

            Values[k] = args.Skip(1).ToArray();
            return true;
        }

        /// <summary>
        /// var res = $.q("get",url)
        /// var res = $.q("get",url,param)
        /// var res = $.q("post",url,param,"json")
        /// </summary>
        /// <param name="args"></param>
        public object q(params object[] args) => args.Length < 2 ? null : Request(args[0].ToString(), args.Skip(1).ToArray());

        /// <summary>
        /// var res = $.get(url)
        /// var res = $.get(url,param)
        /// </summary>
        /// <param name="args"></param>
        public object get(params object[] args) => Request("get", args);

        /// <summary>
        /// var res = $.post(url,param,"json")
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object post(params object[] args) => Request("post", args);

        /// <summary>
        /// var seconds = $.timeout()
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object timeout(params object[] args)
        {
            if (args.Length == 1)
            {
                if (int.TryParse(args[0].ToString(), out int i) && i > 0)
                    client.Timeout = client.ReadWriteTimeout = i * 1000;
            }
            if (args.Length >= 2)
            {
                if (int.TryParse(args[0].ToString(), out int i) && i > 0)
                    client.Timeout = i * 1000;
                if (int.TryParse(args[1].ToString(), out int j) && j > 0)
                    client.ReadWriteTimeout = j * 1000;
            }
            return client.Timeout / 1000;
        }

        Tuple<Method, Uri, RestRequest> GetRequestMethodAndUrl(object[] args)
        {
            string methodArg = args[0].ToString(), url = args[1].ToString();
            if (methodArg.StartsWith("http")) { var str = methodArg; methodArg = url; url = str; }
            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri resource))
                return null;

            var baseUrl = new Uri($"{resource.Scheme}://{resource.Authority}/");
            var method = Enum.TryParse(methodArg.ToUpper(), out Method method1) ? method1 : Method.GET;

            var request = new RestRequest(resource.PathAndQuery.TrimStart('/'));
            request.RequestFormat = DataFormat.None;
            request.ReadWriteTimeout = client.ReadWriteTimeout;
            request.Timeout = client.Timeout;

            return new Tuple<Method, Uri, RestRequest>(method, baseUrl, request);
        }

        public object Request(string method, params object[] args)
        {
            var length = args.Length;
            if (length == 0)
                return null;

            var param = GetRequestMethodAndUrl(new object[] { method }.Concat(args).ToArray());
            if (param == null)
                return null;

            client.BaseUrl = param.Item2;
            var request = param.Item3;

            var jsonEncoding = length > 2 && args[2].ToString() == "json";
            if (jsonEncoding) request.RequestFormat = DataFormat.Json;
            var xmlEncoding = length > 2 && args[2].ToString() == "xml";
            if (xmlEncoding) request.RequestFormat = DataFormat.Xml;

            if (length > 1 && args[1] != null)
            {
                var obj = args[1] as ScriptObject;

                if (jsonEncoding)
                {
                    request.AddHeader("Content-Type", "application/json;charset=utf-8");
                    if (obj != null) request.AddCustomJsonBody(obj.ToDictionary());
                    else request.AddJsonBody(args[1]);
                }
                else if (xmlEncoding)
                {
                    request.AddParameter("", args[1].ToString(), "text/xml", ParameterType.RequestBody); // request.AddXmlBody();
                }
                else
                {
                    if (param.Item1 == Method.GET)
                    {
                        if (obj != null) foreach (var key in obj.PropertyNames) request.AddQueryParameter(key, Convert.ToString(obj.GetProperty(key)), true);
                        else request.AddQueryParameter("", args[1].ToString(), false);
                    }
                    else if (param.Item1 == Method.POST || param.Item1 == Method.PUT || param.Item1 == Method.PATCH || param.Item1 == Method.DELETE)
                    {
                        if (obj != null) foreach (var key in obj.PropertyNames) request.AddParameter(key, obj.GetProperty(key), "application/x-www-form-urlencoded", ParameterType.GetOrPost);
                        else request.AddParameter("", args[1].ToString(), "application/x-www-form-urlencoded", ParameterType.GetOrPost);
                    }
                    else
                    {
                        if (obj != null) request.AddCustomJsonBody(obj.ToDictionary());
                        else request.AddJsonBody(args[1]);
                    }
                }
            }

            var res = client.Execute(request, param.Item1);
            if (res.ResponseStatus != ResponseStatus.Completed)
                return new { code = -1, error = res.ErrorException.Message };
            if (res.StatusCode != System.Net.HttpStatusCode.OK)
                return new { code = res.StatusCode.GetHashCode(), error = res.StatusDescription };

            if (string.IsNullOrWhiteSpace(res.Content))
                return null;

            var content = res.Content.Trim();

            jsonEncoding = content.StartsWith("{") && content.EndsWith("}");

            return jsonEncoding ? Engine.Evaluate(JS.SecurityCode(content)) : content;
        }

        /// <summary>
        /// var fileName = $.download('https://www.baidu.com/favicon.ico')
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object download(params object[] args)
        {
            var length = args.Length;
            if (length == 0 || !Uri.TryCreate(args[0].ToString(), UriKind.Absolute, out Uri address))
                return null;

            string dir = "", name = "";
            TimeSpan timeout = TimeSpan.FromMilliseconds(client.Timeout);

            if (length > 1 && args[1] != null)
                parseArgs(args[1].ToString(), ref dir, ref name, ref timeout);
            if (length > 2 && args[2] != null)
                parseArgs(args[2].ToString(), ref dir, ref name, ref timeout);
            if (length > 3 && args[3] != null)
                parseArgs(args[3].ToString(), ref dir, ref name, ref timeout);

            if (string.IsNullOrEmpty(dir)) dir = tempdir().ToString();
            if (string.IsNullOrEmpty(name))
            {
                var arg1 = address.AbsolutePath;
                int index = arg1.LastIndexOf('.'), cup = 5;
                var hasExt = index > arg1.Length - cup;
                if (hasExt) name = arg1.Substring(1 + arg1.LastIndexOf('/'));
            }

            var file = address.DownloadFile(dir, name, timeout, name != null && name.Length > 0 && !name.EndsWith(".tmp"));
            if (!file.Item1)
                return null;

            return Path.Combine(dir, file.Item2);

            void parseArgs(string arg1, ref string dir1, ref string name1, ref TimeSpan timeout1)
            {
                if (arg1.Contains(Path.DirectorySeparatorChar) || arg1.Contains('/'))
                {
                    dir1 = arg1;
                    int index = arg1.LastIndexOf('.'), cup = 5;
                    var hasExt = index > arg1.Length - cup;
                    if (hasExt)
                    {
                        index = arg1.Contains('/') ? arg1.LastIndexOf('/') : arg1.LastIndexOf(Path.DirectorySeparatorChar);
                        dir1 = arg1.Substring(0, index);
                        name1 = arg1.Substring(index + 1);
                    }
                }
                else if (arg1.Contains('.'))
                {
                    name1 = arg1;
                }
                else if (int.TryParse(arg1, out int s))
                {
                    timeout1 = TimeSpan.FromSeconds(s);
                }
                else
                {
                    name1 = arg1;
                }
            }
        }

        /// <summary>
        /// var tempdir = $.tempdir()
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object tempdir(params object[] args)
        {
            var dir = Environment.GetEnvironmentVariable("TEMP");
            if (string.IsNullOrEmpty(dir)) dir = Environment.GetEnvironmentVariable("TMP");
            if (string.IsNullOrEmpty(dir)) dir = Path.GetTempPath();
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            return dir;
        }

        /// <summary>
        /// var tmpfile = $.tempfile(), randomfile = $.tempfile("random")
        /// var tmpfile = $.tempfile('https://www.baidu.com/', '.html')
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object tempfile(params object[] args)
        {
            var extension = Path.GetExtension(args.Length > 1 ? "0." + args[1].ToString() : "0.tmp");
            if (args.Length > 0 && Uri.TryCreate(args[0].ToString(), UriKind.Absolute, out Uri address))
                return Path.Combine(tempdir().ToString(), (address.Authority + address.AbsolutePath).ToLower().Md5() + extension);
            return Path.ChangeExtension(args.Length > 0 && "random" == args[0].ToString() ? Path.Combine(tempdir().ToString(), Path.GetRandomFileName()) : Path.GetTempFileName(), extension);
        }

        /// <summary>
        /// var fs = $.loaddir(path)
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object loaddir(params object[] args)
        {
            if (args.Length == 0)
                return null;

            var path = args[0].ToString();
            var s = new List<string>();
            s.AddRange(Directory.GetFiles(path));
            s.AddRange(Directory.GetDirectories(path));
            return Engine.Evaluate(JsonConvert.SerializeObject(s));
        }

        /// <summary>
        /// var text = $.loadfile(path)
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object loadfile(params object[] args)
        {
            if (args.Length == 0)
                return null;

            var path = args[0].ToString();
            if (!File.Exists(path))
                return null;

            return File.ReadAllText(path);
        }

        /// <summary>
        /// var ok = $.existsdir(path)
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object existsdir(params object[] args)
        {
            if (args.Length == 0)
                return null;

            var path = args[0].ToString();
            return Directory.Exists(path);
        }

        /// <summary>
        /// var ok = $.existsfile(path)
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object existsfile(params object[] args)
        {
            if (args.Length == 0)
                return null;

            var path = args[0].ToString();
            return File.Exists(path);
        }

        /// <summary>
        /// var ok = $.deletefile(path)
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object deletefile(params object[] args)
        {
            if (args.Length == 0)
                return null;

            var path = args[0].ToString();
            File.Delete(path);
            return !File.Exists(path);
        }

        /// <summary>
        /// var doc = $.loadxml(path)
        /// var doc = $.loadxml(text)
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object loadxml(params object[] args)
        {
            if (args.Length == 0)
                return null;

            var doc = new XmlDocument();

            var text = args[0].ToString();
            if (!text.TrimStart().StartsWith("<") && Uri.IsWellFormedUriString(text, UriKind.RelativeOrAbsolute) || File.Exists(text))
                doc.Load(text);
            else
                doc.LoadXml(text);
            return doc;
        }

        /// <summary>
        /// var doc = $.loadhtml(path)
        /// var doc = $.loadhtml(text)
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object loadhtml(params object[] args)
        {
            if (args.Length == 0)
                return null;

            var doc = new HtmlDocument();

            var text = args[0].ToString();
            if (!text.TrimStart().StartsWith("<") && Uri.IsWellFormedUriString(text, UriKind.RelativeOrAbsolute) || File.Exists(text))
                doc.Load(text, true);
            else
                doc.LoadHtml(text);
            return doc;
        }

        /// <summary>
        /// var doc = $.loadurl(url)
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object loadurl(params object[] args)
        {
            if (args.Length == 0)
                return null;

            var url = args[0].ToString();
            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri _))
                return null;

            var duration = args.Length > 1 && args[1].GetType().Name.StartsWith("Int") ? int.Parse(args[1].ToString()) : client.Timeout / 1000;
            var userAgent = args.Length > 2 ? args[2].ToString() : client.UserAgent;

            var web = new HtmlWeb
            {
                AutoDetectEncoding = true,
                BrowserTimeout = TimeSpan.FromSeconds(duration),
                UserAgent = userAgent
            };

            var doc = web.Load(url);
            return doc;
        }

        /// <summary>
        /// 压缩图片文件(文件路径,命令行参数,有损压缩模式=true,覆盖文件=true)
        /// var res = $.compressimage('D:/Temp/01.png', 'pingo -s9 -pngpalette=50 -strip -q')
        /// var res = $.compressimage('D:/Temp/02.jpg', 'cjpeg -quality 60,40 -optimize -dct float -smooth 5')
        /// var res = $.compressimage('D:/Temp/03.gif', 'gifsicle -O3')
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object compressimage(params object[] args)
        {
            var length = args.Length;
            if (length == 0)
                return null;

            string fileName = args[0].ToString(), cmdArguments = length > 1 && "String" == args[1].GetType().Name ? args[1].ToString() : null;
            if (fileName.Contains(" -") && !cmdArguments.Contains(" -"))
            {
                string temp = fileName; fileName = cmdArguments; cmdArguments = temp;
            }

            bool lossy = length > 2 && "Boolean" == args[2].GetType().Name ? (bool)args[2] : true;
            bool overwrite = length > 3 && "Boolean" == args[3].GetType().Name ? (bool)args[3] : true;

            var result = ImageCompress.CompressFile(fileName, cmdArguments, lossy, overwrite);
            return result != null ? Engine.Evaluate(JS.SecurityCode(JsonConvert.SerializeObject(result))) : null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class CacheObject
    {
        /// <summary>
        /// 缓存方式
        /// </summary>
        public enum Types { Memory = 0, Redis, Default }
        /// <summary>
        /// 缓存方式从参数获取
        /// </summary>
        /// <param name="index"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Types ArgTypes(int index, params object[] args) => args.Length > index && int.TryParse(args[index].ToString(), out int t) ? t == 1 ? Types.Redis : t == 2 ? Types.Default : Types.Memory : Types.Default;

        readonly V8ScriptEngine Engine;

        readonly string Prefix;
        readonly string Subject;

        public string prefix => Prefix;
        public string subject => Subject;

        public CacheObject(RedisConfig config, V8ScriptEngine engine, string prefix, string subject)
        {
            Memory2RedisCache.Init(new RedisConfiguration(config.Addr) { Password = config.Password, DefaultDatabase = config.Db });
            Engine = engine;
            Prefix = prefix;
            Subject = subject;
        }

        /// <summary>
        /// $cache.get("key",0) // Memory:0, Cache{ Memory = 0, Redis, Default }
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object get(params object[] args)
        {
            var length = args.Length;
            if (length == 0)
                return null;

            string k = args[0].ToString();
            if (string.IsNullOrEmpty(k)) return null;

            string code = Get(ArgTypes(1), k);
            if (string.IsNullOrEmpty(code)) return null;

            return Engine.Evaluate(JS.SecurityCode(code));
        }

        /// <summary>
        /// Get Cache
        /// </summary>
        /// <param name="types"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static string Get(Types types, string k)
        {
            string v = null;
            if (string.IsNullOrEmpty(k)) return v;
            switch (types)
            {
                case Types.Memory:
                    v = Memory2RedisCache.Memory.Get<string>(k);
                    break;
                case Types.Redis:
                    v = Memory2RedisCache.Redis.Get<string>(k);
                    break;
                default:
                    v = Memory2RedisCache.Default.Get<string>(k);
                    break;
            }
            return v;
        }

        /// <summary>
        /// $cache.set("key",123,60,1) // Expire 60 seconds, Redis:1, Cache{ Memory = 0, Redis, Default }
        /// </summary>
        /// <param name="args"></param>
        public void set(params object[] args)
        {
            var length = args.Length;
            if (length < 2)
                return;

            string k = args[0].ToString();
            if (string.IsNullOrEmpty(k)) return;

            string v = (args[1] as ScriptObject != null) ? JsonConvert.SerializeObject(args[1], Extensions.JsonConverters) : args[1].ToString();

            int expire = 0, index = 2;
            if (length > 2 && int.TryParse(args[2].ToString(), out int s) && s >= 0)
            {
                expire = s;
                index = 3;
            }

            Set(ArgTypes(index), k, v, expire);
        }

        /// <summary>
        /// Add Cache
        /// </summary>
        /// <param name="types"></param>
        /// <param name="k"></param>
        /// <param name="v"></param>
        /// <param name="expire"></param>
        public static void Set(Types types, string k, string v, int expire = 3600 * 24)
        {
            if (string.IsNullOrEmpty(k)) return;
            switch (types)
            {
                case Types.Memory:
                    Memory2RedisCache.Memory.Add(k, v, expire <= 1 ? TimeSpan.Zero : TimeSpan.FromSeconds(expire));
                    break;
                case Types.Redis:
                    Memory2RedisCache.Redis.Add(k, v, expire <= 1 ? TimeSpan.Zero : TimeSpan.FromSeconds(expire));
                    break;
                default:
                    Memory2RedisCache.Default.Add(k, v, expire <= 1 ? TimeSpan.Zero : TimeSpan.FromSeconds(expire));
                    break;
            }
        }

        /// <summary>
        /// $cache.del("key",2) // Default:2, Cache{ Memory = 0, Redis, Default }
        /// </summary>
        /// <param name="args"></param>
        public void del(params object[] args)
        {
            var length = args.Length;
            if (length == 0)
                return;

            string k = args[0].ToString();
            if (string.IsNullOrEmpty(k)) return;

            Del(ArgTypes(1), k);
        }

        /// <summary>
        /// Delete Cache
        /// </summary>
        /// <param name="types"></param>
        /// <param name="k"></param>
        public static void Del(Types types, string k)
        {
            if (string.IsNullOrEmpty(k)) return;
            switch (types)
            {
                case Types.Memory:
                    Memory2RedisCache.Memory.Remove(k);
                    break;
                case Types.Redis:
                    Memory2RedisCache.Redis.Remove(k);
                    break;
                default:
                    Memory2RedisCache.Default.Remove(k);
                    break;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class RedisObject
    {
        readonly Redis.List RedisList;

        readonly V8ScriptEngine Engine;

        readonly string Prefix;
        readonly string Subject;

        public string prefix => Prefix;
        public string subject => Subject;

        public RedisObject(RedisConfig config, V8ScriptEngine engine, string prefix, string subject)
        {
            RedisList = new Redis.List(new RedisConfiguration(config.Addr) { Password = config.Password, DefaultDatabase = config.Db }.ToString());
            Engine = engine;
            Prefix = prefix;
            Subject = subject;
        }

        /// <summary>
        /// $redis.get("key")
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object get(params object[] args)
        {
            var length = args.Length;
            if (length == 0)
                return null;

            string k = args[0].ToString();
            if (string.IsNullOrEmpty(k)) return null;

            string code = RedisList.Get(k);
            if (string.IsNullOrEmpty(code)) return null;

            return Engine.Evaluate(JS.SecurityCode(code));
        }

        /// <summary>
        /// $redis.set("key",123,60)
        /// </summary>
        /// <param name="args"></param>
        public bool set(params object[] args)
        {
            var length = args.Length;
            if (length < 2)
                return false;

            string k = args[0].ToString();
            if (string.IsNullOrEmpty(k)) return false;

            string v = (args[1] as ScriptObject != null) ? JsonConvert.SerializeObject(args[1], Extensions.JsonConverters) : args[1].ToString();

            int expire = 0;
            if (length > 2 && int.TryParse(args[2].ToString(), out int s) && s >= 0)
            {
                expire = s;
            }

            return RedisList.Set(k, v, expire);
        }

        /// <summary>
        /// $redis.push("key",123,60)
        /// </summary>
        /// <param name="args"></param>
        public void push(params object[] args)
        {
            var length = args.Length;
            if (length < 2)
                return;

            string k = args[0].ToString();
            if (string.IsNullOrEmpty(k)) return;

            string v = (args[1] as ScriptObject != null) ? JsonConvert.SerializeObject(args[1], Extensions.JsonConverters) : args[1].ToString();

            int expire = 0; // 3600 * 24
            if (length > 2 && int.TryParse(args[2].ToString(), out int s) && s >= 0)
            {
                expire = s;
            }

            RedisList.Push(k, v, expire);
        }

        /// <summary>
        /// var list = $redis.pop("key",10)
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object pop(params object[] args)
        {
            var length = args.Length;
            if (length == 0)
                return null;

            string k = args[0].ToString();
            if (string.IsNullOrEmpty(k)) return null;

            int size = 1;
            if (length > 1 && int.TryParse(args[1].ToString(), out int s) && s >= 0)
            {
                size = s;
            }

            var list = RedisList.Pop(k, size);
            if (list.Count == 0) return null;

            var code = "[" + string.Join(",", list) + "]";

            return Engine.Evaluate(JS.SecurityCode(code));
        }

        /// <summary>
        /// var seconds = $redis.expire("key")
        /// var ok = $redis.expire("key", 60)
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object expire(params object[] args)
        {
            var length = args.Length;
            if (length == 0)
                return false;

            string k = args[0].ToString();
            if (string.IsNullOrEmpty(k)) return false;

            if (length > 1 && int.TryParse(args[1].ToString(), out int s) && s >= 0)
            {
                return RedisList.Expire(k, s);
            }
            else
            {
                var t = RedisList.Expire(k);
                return t.HasValue ? (int)t.Value.TotalSeconds : -2;
            }
        }

        /// <summary>
        /// var seconds = $redis.idle("key")
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object idle(params object[] args)
        {
            var length = args.Length;
            if (length == 0)
                return -1;

            string k = args[0].ToString();
            if (string.IsNullOrEmpty(k)) return -2;

            var t = RedisList.Idle(k);
            return t.HasValue ? (int)t.Value.TotalSeconds : -2;
        }

        /// <summary>
        /// var ok = $redis.del("key")
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public object del(params object[] args)
        {
            var length = args.Length;
            if (length == 0)
                return false;

            string k = args[0].ToString();
            if (string.IsNullOrEmpty(k)) return false;

            return RedisList.Delete(k);
        }
    }
}
