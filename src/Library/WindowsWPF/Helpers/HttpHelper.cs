using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;

namespace WindowsWPF.Helpers
{
    #region Http用例
    //class TestHttpHelper
    //{
    //    void TestGet()
    //    {
    //        //网址中存在中文编码
    //        string url = HttpHelper.URLEncode("https://postman-echo.com/get?test=一点点");
    //        HttpItem item = new HttpItem()
    //        {
    //            URL = url,                //必填
    //            Method = "get",           //可选
    //            ContentType = "text/html",//可选(有默认值)
    //        };
    //        item.ClentCertificates = new X509CertificateCollection();
    //        item.ClentCertificates.Add(new X509Certificate("C:\\1.cer", "123456"));
    //        item.ClentCertificates.Add(new X509Certificate("C:\\2.cer"));//配置多个证书
    //        HttpHelper http = new HttpHelper();
    //        HttpResult result = http.GetHtml(item);
    //        string html = result.Html;
    //        string cookie = result.Cookie;
    //        string title = HttpHelper.GetHtmlTitle(html);
    //        List<ImgItem> imgs = HttpHelper.GetImgList(html);
    //        //string ip = HttpHelper.GetUrlIp("http://www.sufeinet.com");
    //    }
    //    void TestPost()
    //    {
    //        //得到一个参数集合
    //        string parameters = "a=123&strange=boom";
    //        //NameValueCollection parameterList = HttpHelper.GetNameValueCollection(parameters);
    //        HttpItem item = new HttpItem()
    //        {
    //            URL = "https://postman-echo.com/post",  //必填
    //            Method = "post",                        //可选
    //            ContentType = "application/x-www-form-urlencoded",
    //            PostDataType = PostDataType.String,
    //            PostEncoding = Encoding.UTF8,
    //            Postdata = parameters
    //        };
    //        HttpHelper http = new HttpHelper();
    //        HttpResult result = http.GetHtml(item);
    //        //提交JSON格式的请求
    //        string post = HttpHelper.ObjectToJson(new { a = 123 });
    //        byte[] bytes = Encoding.UTF8.GetBytes(post);
    //        http = new HttpHelper();
    //        item = new HttpItem()
    //        {
    //            URL = "https://postman-echo.com/post",//必填
    //            Method = "post",                //可选
    //            ContentType = "application/x-www-form-urlencoded",
    //            PostDataType = PostDataType.Byte,
    //            PostdataByte = bytes
    //        };
    //        result = http.GetHtml(item);
    //        //上传文件的请求
    //        string file = @"D:\data.txt";
    //        item = new HttpItem()
    //        {
    //            URL = "https://postman-echo.com/post",//必填
    //            Method = "post",                //可选
    //            ContentType = "application/x-www-form-urlencoded",
    //            PostDataType = PostDataType.FilePath,
    //            Postdata = file
    //        };
    //        result = http.GetHtml(item);
    //    }
    //    void TestProxy()
    //    {
    //        HttpItem item = new HttpItem()
    //        {
    //            URL = "https://postman-echo.com/ip",//必填
    //            ProxyIp = "127.0.0.1:1021"
    //        };
    //        HttpHelper http = new HttpHelper();
    //        HttpResult result = http.GetHtml(item);

    //        item = new HttpItem()
    //        {
    //            URL = "https://postman-echo.com/ip",//必填
    //            ProxyIp = "127.0.0.1:1022",
    //            ProxyUserName = "admin",
    //            ProxyPwd = "123456"
    //        };
    //        result = http.GetHtml(item);

    //        item = new HttpItem()
    //        {
    //            URL = "https://postman-echo.com/ip",//必填
    //            WebProxy = new WebProxy("127.0.0.1", 1023) { Credentials = new NetworkCredential("admin", "123456") }
    //        };
    //        result = http.GetHtml(item);
    //    }
    //    void Test302()
    //    {
    //        HttpItem item = new HttpItem()
    //        {
    //            URL = "https://postman-echo.com/ip",//必填
    //            Allowautoredirect = false//默认为False就是不根据重定向自动跳转
    //        };
    //        HttpHelper http = new HttpHelper();
    //        HttpResult result = http.GetHtml(item);
    //        string cookie = result.Cookie;
    //        // 获取302跳转URl
    //        string redirectUrl = result.RedirectUrl;
    //        item = new HttpItem()
    //        {
    //            URL = redirectUrl,
    //            Cookie = cookie
    //        };
    //        result = http.GetHtml(item);
    //        string html = result.Html;
    //    }
    //    void TestCookie()
    //    {
    //        HttpItem item = new HttpItem()
    //        {
    //            URL = "https://postman-echo.com/get",//必填
    //            ResultCookieType = ResultCookieType.String,//默认值可以不写
    //        };
    //        HttpHelper http = new HttpHelper();
    //        HttpResult result = http.GetHtml(item);
    //        string cookie = result.Cookie;
    //        // 第二次使用Cookie
    //        item = new HttpItem()
    //        {
    //            URL = "https://postman-echo.com/post/thread-1-1.html",
    //            Method = "get",
    //            ContentType = "text/html",
    //            ResultCookieType = ResultCookieType.String,//默认值可以不写
    //            Cookie = cookie,//把Cookie写入请求中
    //        };
    //        result = http.GetHtml(item);
    //        cookie = result.Cookie;
    //        // 字符串Cookie转为CookieCollection类型
    //        CookieCollection cookies = HttpHelper.StrCookieToCookieCollection(cookie);
    //        // 直接获取返回的CookieCollection类型
    //        item = new HttpItem()
    //        {
    //            URL = "https://postman-echo.com/get",//必填
    //            ResultCookieType = ResultCookieType.CookieCollection
    //        };
    //        http = new HttpHelper();
    //        result = http.GetHtml(item);
    //        cookies = result.CookieCollection;
    //        // 第二次使用Cookie
    //        item = new HttpItem()
    //        {
    //            URL = "https://postman-echo.com/news/thread-1-1.html",
    //            Method = "get",
    //            ContentType = "text/html",
    //            CookieCollection = cookies,
    //            ResultCookieType = ResultCookieType.CookieCollection
    //        };
    //        result = http.GetHtml(item);
    //    }
    //    void TestHeader()
    //    {
    //        HttpItem item = new HttpItem()
    //        {
    //            URL = "https://echo.getpostman.com/headers",//必填
    //            Method = "get",                 //可选
    //            ContentType = "text/html",      //可选(有默认值)
    //            //ContentType = "application/x-www-form-urlencoded",  
    //        };
    //        HttpHelper http = new HttpHelper();
    //        HttpResult result = http.GetHtml(item);
    //        WebHeaderCollection header = result.Header;
    //    }
    //    void TestImage()
    //    {
    //        HttpItem item = new HttpItem()
    //        {
    //            URL = "https://fanyi-cdn.cdn.bcebos.com/static/translation/img/header/logo_e835568.png",
    //            Method = "get",
    //            ResultType = ResultType.Byte
    //        };
    //        HttpHelper http = new HttpHelper();
    //        HttpResult result = http.GetHtml(item);
    //        Image img = HttpHelper.GetImage(result.ResultByte);
    //    }
    //    void TestTls()
    //    {
    //        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
    //        HttpItem item = new HttpItem()
    //        {
    //            URL = "https://www.ct10649.com/ecportal/login/logout.action",
    //            SecurityProtocol = (SecurityProtocolType)3072
    //        };
    //        HttpHelper http = new HttpHelper();
    //        HttpResult result = http.GetHtml(item);
    //        string html = result.Html;
    //    }
    //    void TestJavaScript()
    //    {
    //        string strjs = @"function main1() { return 1 + 1;} function main2(n) { return 1 + n;}";
    //        //调用不带参数的方法
    //        string main1 = HttpHelper.JavaScriptEval(strjs, "main1()");
    //        //调用带参数的方法
    //        string main2 = HttpHelper.JavaScriptEval(strjs, "main2(25)");
    //        //直接执行JS代码
    //        string jiafa = HttpHelper.JavaScriptEval(string.Empty, "25+1+4");
    //        //直接执行JS代码
    //        string time = HttpHelper.JavaScriptEval(string.Empty, " new Date().toString()");
    //    }
    //}
    #endregion

    /// <summary>
    /// Http帮助类
    /// </summary>
    public class HttpHelper
    {
        #region Private Obj

        /// <summary>
        /// HttpHelperBLL
        /// </summary>
        private HttpHelperBll bll = new HttpHelperBll();
        /// <summary>
        /// gethtml方法异步调用的委托
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private delegate HttpResult GethtmlHandler(HttpItem item);
        /// <summary>
        /// 异步调用方法委托
        /// </summary>
        private ResultHandler resultheadler;
        #endregion

        #region HttpHelper
        /// <summary>
        /// 根据相传入的数据，得到相应页面数据
        /// </summary>
        /// <param name="item">参数类对象</param>
        /// <returns>返回HttpResult类型</returns>
        public HttpResult GetHtml(HttpItem item)
        {
            return bll.GetHtml(item);
        }
        /// <summary>
        /// GetHtml方法的异步调用方式，根据相传入的数据，得到相应页面数据
        /// </summary>
        /// <param name="item">参数类对象</param>
        /// <param name="resultMainName">回调的方法名</param>
        public void BeginInvokeGetHtml(HttpItem item, ResultHandler resultMainName)
        {
            resultheadler = resultMainName;
            GethtmlHandler handler = new GethtmlHandler(GetHtml);
            handler.BeginInvoke(item, new AsyncCallback(CallbackFunc), "AsycState:OK");
        }
        /// <summary>
        /// 内部回调方法
        /// </summary>
        /// <param name="resultType">返回值</param>
        private void CallbackFunc(IAsyncResult resultType)
        {
            //result 是“加法类.Add()方法”的返回值             
            //AsyncResult 是IAsyncResult接口的一个实现类，引用空间：System.Runtime.Remoting.Messaging             
            //AsyncDelegate 属性可以强制转换为用户定义的委托的实际类。
            GethtmlHandler handler = (GethtmlHandler)((AsyncResult)resultType).AsyncDelegate;
            HttpResult result = handler.EndInvoke(resultType);
            //回调方法传回执行结果
            resultheadler.Invoke(result);
        }
        /// <summary>
        /// 根据Url获取图片
        /// </summary>
        /// <param name="item">HttpItem参数</param>
        /// <returns>返回图片，错误为NULL</returns>
        public Image GetImage(HttpItem item)
        {
            return bll.GetImage(item);
        }
        /// <summary>
        /// 快速请求方法FastRequest（极速请求不接收数据,只做提交）不返回Header、Cookie、Html
        /// </summary>
        /// <param name="item">参数类对象</param>
        /// <returns>返回HttpResult类型</returns>
        public HttpResult FastRequest(HttpItem item)
        {

            return bll.FastRequest(item);
        }
        #endregion

        #region Cookie
        /// <summary>
        /// 根据字符生成Cookie和精简串，将排除path,expires,domain以及重复项
        /// </summary>
        /// <param name="strcookie">Cookie字符串</param>
        /// <returns>精简串</returns>
        public static string GetSmallCookie(string strcookie)
        {
            return HttpCookieHelper.GetSmallCookie(strcookie);
        }
        /// <summary>
        /// 将字符串Cookie转为CookieCollection
        /// </summary>
        /// <param name="strcookie">Cookie字符串</param>
        /// <returns>List-CookieItem</returns>
        public static CookieCollection StrCookieToCookieCollection(string strcookie)
        {
            return HttpCookieHelper.StrCookieToCookieCollection(strcookie);
        }
        /// <summary>
        /// 将CookieCollection转为字符串Cookie
        /// </summary>
        /// <param name="cookie">Cookie字符串</param>
        /// <returns>strcookie</returns>
        public static string CookieCollectionToStrCookie(CookieCollection cookie)
        {
            return HttpCookieHelper.CookieCollectionToStrCookie(cookie);
        }
        /// <summary>
        /// 自动合并两个Cookie的值返回更新后结果 
        /// </summary>
        /// <param name="oldCookkie">oldCookkie</param>
        /// <param name="newCookie">newCookie</param>
        /// <returns>返回更新后的Cookie</returns>
        public static string GetMergeCookie(string oldCookkie, string newCookie)
        {
            return HttpCookieHelper.GetMergeCookie(oldCookkie, newCookie);
        }
        #endregion

        #region URL

        /// <summary>
        /// 使用指定的编码对象将 URL 编码的字符串转换为已解码的字符串。
        /// </summary>
        /// <param name="text">指定的字符串</param>
        /// <param name="encoding">指定编码默认为Default</param>
        /// <returns>解码后字符串</returns>
        public static string URLDecode(string text, Encoding encoding = null)
        {
            return HttpUrlHelper.URLDecode(text, encoding);
        }
        /// <summary>
        /// 使用指定的编码对象对 URL 字符串进行编码。
        /// </summary>
        /// <param name="text">指定的字符串</param>
        /// <param name="encoding">指定编码默认为Default</param>
        /// <returns>转码后字符串</returns>
        public static string URLEncode(string text, Encoding encoding = null)
        {
            return HttpUrlHelper.URLEncode(text, encoding);
        }
        /// <summary>
        /// 将Url参数字符串转为一个Key和Value的集合
        /// </summary>
        /// <param name="str">要转为集合的字符串</param>
        /// <returns>NameValueCollection</returns>
        public static NameValueCollection GetNameValueCollection(string str)
        {
            return HttpUrlHelper.GetNameValueCollection(str);
        }
        /// <summary>
        /// 提取网站主机部分就是host
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>host</returns>
        public static string GetUrlHost(string url)
        {
            return HttpUrlHelper.GetUrlHost(url);
        }
        /// <summary>
        /// 提取网址对应的IP地址
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>返回Url对应的IP地址</returns>
        public static string GetUrlIp(string url)
        {
            return HttpUrlHelper.GetUrlIp(url);
        }
        #endregion

        #region MD5
        /// <summary>
        /// 传入明文，返回用MD%加密后的字符串32位长度
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>用MD5加密后的字符串</returns>
        public static string ToMD5(string str)
        {
            return MD5Helper.ToMD5_32(str);
        }
        /// <summary>
        /// 传入明文，返回用SHA1密后的字符串
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>SHA1加密后的字符串</returns>
        public static string ToSHA1(string str)
        {
            return MD5Helper.ToSHA1(str);
        }
        #endregion

        #region Json
        /// <summary>
        /// 将指定的Json字符串转为指定的T类型对象 
        /// </summary>
        /// <param name="jsonstr">字符串</param>
        /// <returns>转换后的对象，失败为Null</returns>
        public static object JsonToObject<T>(string jsonstr)
        {
            return JsonHelper.JsonToObject<T>(jsonstr);
        }
        /// <summary>
        /// 将指定的对象转为Json字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>转换后的字符串失败为空字符串</returns>
        public static string ObjectToJson(object obj)
        {
            return JsonHelper.ObjectToJson(obj);
        }
        #endregion

        #region HTML
        /// <summary>
        /// 获取所有的A链接
        /// </summary>
        /// <param name="html">要分析的Html代码</param>
        /// <returns>返回一个List存储所有的A标签</returns>
        public static List<AItem> GetAList(string html)
        {
            return HtmlHelper.GetAList(html);
        }
        /// <summary>
        /// 获取所有的Img标签
        /// </summary>
        /// <param name="html">要分析的Html代码</param>
        /// <returns>返回一个List存储所有的Img标签</returns>
        public static List<ImgItem> GetImgList(string html)
        {
            return HtmlHelper.GetImgList(html);
        }
        /// <summary>
        /// 过滤html标签
        /// </summary>
        /// <param name="html">html的内容</param>
        /// <returns>处理后的文本</returns>
        public static string StripHTML(string html)
        {
            return HtmlHelper.StripHTML(html);
        }
        /// <summary>
        /// 过滤html中所有的换行符号
        /// </summary>
        /// <param name="html">html的内容</param>
        /// <returns>处理后的文本</returns>
        public static string ReplaceNewLine(string html)
        {
            return HtmlHelper.ReplaceNewLine(html);
        }

        /// <summary>
        /// 提取Html字符串中两字符之间的数据
        /// </summary>
        /// <param name="html">源Html</param>
        /// <param name="s">开始字符串</param>
        /// <param name="e">结束字符串</param>
        /// <returns></returns>
        public static string GetBetweenHtml(string html, string s, string e)
        {
            return HtmlHelper.GetBetweenHtml(html, s, e);
        }
        /// <summary>
        /// 提取网页Title
        /// </summary>
        /// <param name="html">Html</param>
        /// <returns>返回Title</returns>
        public static string GetHtmlTitle(string html)
        {
            return HtmlHelper.GetHtmlTitle(html);
        }
        #endregion

        #region JavaScript
        /// <summary>
        /// 直接调用JS方法并获取返回的值
        /// </summary>
        /// <param name="strJs">要执行的JS代码</param>
        /// <param name="main">要调用的方法名</param>
        /// <returns>执行结果</returns>
        public static string JavaScriptEval(string strJs, string main)
        {
            return ExecJsHelper.JavaScriptEval(strJs, main);
        }

        #endregion

        #region Image
        /// <summary>
        /// 将字节数组转为图片
        /// </summary>
        /// <param name=" b">字节数组</param>
        /// <returns>返回图片</returns>
        public static System.Drawing.Image GetImage(byte[] b)
        {
            return ImageHelper.ByteToImage(b);
        }
        #endregion

        #region Encoding
        /// <summary>
        /// 将字节数组转为字符串
        /// </summary>
        /// <param name="b">字节数组</param>
        /// <param name="e">编码，默认为Default</param>
        /// <returns>字符串</returns>
        public static string ByteToString(byte[] b, Encoding e = null)
        {
            return EncodingHelper.ByteToString(b, e);
        }
        /// <summary>
        /// 将字符串转为字节数组
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="e">编码，默认为Default</param>
        /// <returns>字节数组</returns>
        public static byte[] StringToByte(string s, Encoding e = null)
        {
            return EncodingHelper.StringToByte(s, e);
        }
        #endregion

        #region Base64

        /// <summary>
        /// 将Base64编码解析成字符串
        /// </summary>
        /// <param name="strbase">要解码的string字符</param>
        /// <param name="encoding">字符编码方案</param>
        /// <returns>字符串</returns>
        public static string Base64ToString(string strbase, Encoding encoding)
        {
            return Base64Helper.Base64ToString(strbase, encoding);
        }
        /// <summary>
        /// 将字节数组为Base64编码
        /// </summary>
        /// <param name="bytebase">要编码的byte[]</param>
        /// <returns>base字符串</returns>
        public static string ByteToBase64(byte[] bytebase)
        {
            return Base64Helper.StringToBase64(bytebase);
        }
        /// <summary>
        /// 将字符串转为Base64编码
        /// </summary>
        /// <param name="str">要编码的string字符</param>
        /// <param name="encoding">字符编码方案</param>
        /// <returns>base字符串</returns>
        public static string StringToBase64(string str, Encoding encoding)
        {
            return Base64Helper.StringToBase64(str, encoding);
        }
        #endregion
    }

    /// <summary>
    /// 正则表达式静态类
    /// </summary>
    internal class RegexString
    {
        /// <summary>
        /// 获取所有的A链接
        /// </summary>
        internal static readonly string Alist = "<a[\\s\\S]+?href[=\"\']([\\s\\S]+?)[\"\'\\s+][\\s\\S]+?>([\\s\\S]+?)</a>";
        /// <summary>
        /// 获取所有的Img标签
        /// </summary>
        internal static readonly string ImgList = "<img[\\s\\S]*?src=[\"\']([\\s\\S]*?)[\"\'][\\s\\S]*?>([\\s\\S]*?)>";
        /// <summary>
        /// 所有的Nscript
        /// </summary>
        internal static readonly string Nscript = "<nscript[\\s\\S]*?>[\\s\\S]*?</nscript>";
        /// <summary>
        /// 所有的Style
        /// </summary>
        internal static readonly string Style = "<style[\\s\\S]*?>[\\s\\S]*?</style>";
        /// <summary>
        /// 所有的Script
        /// </summary>
        internal static readonly string Script = "<script[\\s\\S]*?>[\\s\\S]*?</script>";
        /// <summary>
        /// 所有的Html
        /// </summary>
        internal static readonly string Html = "<[\\s\\S]*?>";
        /// <summary>
        /// 换行符号
        /// </summary>
        internal static readonly string NewLine = Environment.NewLine;
        /// <summary>
        ///获取网页编码
        /// </summary>
        internal static readonly string Enconding = "<meta[^<]*charset=([^<]*)[\"']";
        /// <summary>
        /// 所有Html
        /// </summary>
        internal static readonly string AllHtml = "([\\s\\S]*?)";
        /// <summary>
        /// title
        /// </summary>
        internal static readonly string HtmlTitle = "<title>([\\s\\S]*?)</title>";
    }

    /// <summary>
    /// Base64帮助类
    /// </summary>
    public class Base64Helper
    {
        /// <summary>
        /// 将Base64编码解析成字符串
        /// </summary>
        /// <param name="strbase">要解码的string字符</param>
        /// <param name="encoding">字符编码方案</param>
        /// <returns></returns>
        public static string Base64ToString(string strbase, Encoding encoding)
        {
            byte[] buff = Convert.FromBase64String(strbase);
            return encoding.GetString(buff);
        }
        /// <summary>
        /// 将字节数组为Base64编码
        /// </summary>
        /// <param name="bytebase">要编码的byte[]</param>
        /// <returns></returns>
        public static string StringToBase64(byte[] bytebase)
        {
            return Convert.ToBase64String(bytebase);
        }
        /// <summary>
        /// 将字符串转为Base64编码
        /// </summary>
        /// <param name="str">要编码的string字符</param>
        /// <param name="encoding">字符编码方案</param>
        /// <returns></returns>
        public static string StringToBase64(string str, Encoding encoding)
        {
            byte[] buff = encoding.GetBytes(str);
            return Convert.ToBase64String(buff);
        }
    }

    internal class EncodingHelper
    {
        /// <summary>
        /// 将字节数组转为字符串
        /// </summary>
        /// <param name="b">字节数组</param>
        /// <param name="e">编码，默认为Default</param>
        /// <returns></returns>
        internal static string ByteToString(byte[] b, Encoding e = null)
        {
            if (e == null)
            {
                e = Encoding.Default;
            }
            string result = e.GetString(b);
            return result;
        }

        /// <summary>
        /// 将字符串转为字节数组
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="e">编码，默认为Default</param>
        /// <returns></returns>
        internal static byte[] StringToByte(string s, Encoding e = null)
        {
            if (e == null)
            {
                e = Encoding.Default;
            }
            byte[] b = e.GetBytes(s);
            return b;
        }
    }
    internal class ExecJsHelper
    {
        #region 私有
        private static Type type = Type.GetTypeFromProgID("ScriptControl");
        #endregion

        #region Internal
        /// <summary>
        /// 直接调用JS方法并获取返回的值
        /// </summary>
        /// <param name="strJs">要执行的JS代码</param>
        /// <param name="main">要调用的方法名</param>
        /// <returns>执行结果</returns>
        internal static string JavaScriptEval(string strJs, string main)
        {
            //Type
            object obj = GetScriptControl();
            //设置JS代码
            SetScriptControlType(strJs, obj);
            //执行JS
            return type.InvokeMember("Eval", BindingFlags.InvokeMethod, null, obj, new object[] { main }).ToString();
        }
        #endregion

        #region Private Main
        /// <summary>
        /// 获取ScriptControl接口类
        /// </summary>
        /// <param name="strJs">JS</param>
        /// <param name="obj">对象</param>
        /// <returns>Type</returns>
        private static Type SetScriptControlType(string strJs, object obj)
        {
            //设置语言类型
            type.InvokeMember("Language", BindingFlags.SetProperty, null, obj, new object[] { "JScript" });
            //添加JS代码
            type.InvokeMember("AddCode", BindingFlags.InvokeMethod, null, obj, new object[] { strJs });
            return type;
        }
        /// <summary>
        /// 获取ScriptControl接口对象
        /// </summary>
        /// <returns>ScriptControl对象</returns>
        private static object GetScriptControl()
        {
            return Activator.CreateInstance(type);
        }
        #endregion
    }
    internal static class HttpCookieHelper
    {
        /// <summary>
        /// 根据字符生成Cookie和精简串，将排除path,expires,domain以及重复项
        /// </summary>
        /// <param name="strcookie">Cookie字符串</param>
        /// <returns>精简串</returns>
        internal static string GetSmallCookie(string strcookie)
        {
            if (string.IsNullOrWhiteSpace(strcookie))
            {
                return string.Empty;
            }
            List<string> cookielist = new List<string>();
            //将Cookie字符串以,;分开，生成一个字符数组，并删除里面的空项
            string[] list = strcookie.ToString().Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in list)
            {
                string itemcookie = item.ToLower().Trim().Replace("\r\n", string.Empty).Replace("\n", string.Empty);
                //排除空字符串
                if (string.IsNullOrWhiteSpace(itemcookie)) continue;
                //排除不存在=号的Cookie项
                if (!itemcookie.Contains("=")) continue;
                //排除path项
                if (itemcookie.Contains("path=")) continue;
                //排除expires项
                if (itemcookie.Contains("expires=")) continue;
                //排除domain项
                if (itemcookie.Contains("domain=")) continue;
                //排除重复项
                if (cookielist.Contains(item)) continue;

                //对接Cookie基本的Key和Value串
                cookielist.Add(string.Format("{0};", item));
            }
            return string.Join(";", cookielist);
        }

        /// <summary>
        /// 将字符串Cookie转为CookieCollection
        /// </summary>
        /// <param name="strcookie">Cookie字符串</param>
        /// <returns>List-CookieItem</returns>
        internal static CookieCollection StrCookieToCookieCollection(string strcookie)
        {
            //排除空字符串
            if (string.IsNullOrWhiteSpace(strcookie))
            {
                return null;
            }
            CookieCollection cookielist = new CookieCollection();
            //先简化Cookie
            strcookie = GetSmallCookie(strcookie);
            //将Cookie字符串以,;分开，生成一个字符数组，并删除里面的空项
            string[] list = strcookie.ToString().Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in list)
            {
                string[] cookie = item.ToString().Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                if (cookie.Length == 2)
                {
                    cookielist.Add(new Cookie() { Name = cookie[0].Trim(), Value = cookie[1].Trim() });
                }
            }
            return cookielist;
        }

        /// <summary>
        /// 将CookieCollection转为字符串Cookie
        /// </summary>
        /// <param name="cookie">Cookie字符串</param>
        /// <returns>strcookie</returns>
        internal static string CookieCollectionToStrCookie(CookieCollection cookie)
        {
            if (cookie == null)
            {
                return string.Empty;
            }
            string resultcookie = string.Empty;
            foreach (Cookie item in cookie)
            {
                resultcookie += string.Format("{0}={1};", item.Name, item.Value);
            }
            return resultcookie;
        }

        /// <summary>
        /// 自动合并两个Cookie的值返回更新后结果 
        /// </summary>
        /// <param name="oldCookie">Cookie1</param>
        /// <param name="newCookie">Cookie2</param>
        /// <returns>返回更新后的Cookie</returns>
        internal static string GetMergeCookie(string oldCookie, string newCookie)
        {
            if (!string.IsNullOrEmpty(oldCookie) && !string.IsNullOrEmpty(newCookie))
            {
                if (oldCookie == newCookie)
                    return oldCookie;
                else
                {
                    List<string> Old = new List<string>(oldCookie.Split(';'));
                    List<string> New = new List<string>(newCookie.Split(';'));
                    foreach (string n in New)
                    {
                        foreach (string o in Old)
                        {
                            if (o == n || o.Split('=')[0] == n.Split('=')[0])
                            {
                                Old.Remove(o);
                                break;
                            }
                        }
                    }
                    List<string> list = new List<string>(Old);
                    list.AddRange(New);

                    StringBuilder sb = new StringBuilder();
                    foreach (var s in list)
                    {
                        if (s != "")
                        {
                            sb.Append(s).Append(";");
                        }
                    }
                    return sb.ToString();
                }
            }
            else if (!string.IsNullOrEmpty(oldCookie))
            {
                return oldCookie;
            }
            else if (!string.IsNullOrEmpty(newCookie))
            {
                return newCookie;
            }
            else
            {
                return "";
            }
        }
    }
    internal class HttpUrlHelper
    {
        /// <summary>
        /// 使用指定的编码对象将 URL 编码的字符串转换为已解码的字符串。
        /// </summary>
        /// <param name="text">指定的字符串</param>
        /// <param name="encoding">指定编码默认为Default</param>
        /// <returns></returns>
        internal static string URLDecode(string text, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.Default;
            }
            return HttpUtility.UrlDecode(text, encoding);
        }
        /// <summary>
        /// 使用指定的编码对象对 URL 字符串进行编码。
        /// </summary>
        /// <param name="text">指定的字符串</param>
        /// <param name="encoding">指定编码默认为Default</param>
        /// <returns></returns>
        internal static string URLEncode(string text, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.Default;
            }
            return HttpUtility.UrlEncode(text, encoding);
        }

        /// <summary>
        /// 将Url参数字符串转为一个Key和Value的集合
        /// </summary>
        /// <param name="str">要转为集合的字符串</param>
        /// <returns>NameValueCollection</returns>
        internal static NameValueCollection GetNameValueCollection(string str)
        {
            NameValueCollection coll = null;
            try
            {
                coll = HttpUtility.ParseQueryString(str);
            }
            catch { }
            return coll;
        }
        /// <summary>
        /// 提取网站主机部分就是host
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>host</returns>
        internal static string GetUrlHost(string url)
        {
            try
            {
                return new Uri(url).Host;
            }
            catch { return string.Empty; }
        }
        /// <summary>
        /// 提取网址对应的IP地址
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>返回Url对应的IP地址</returns>
        internal static string GetUrlIp(string url)
        {
            try
            {
                IPHostEntry hostInfo = Dns.GetHostEntry(GetUrlHost(url));
                return hostInfo.AddressList[0].ToString();
            }
            catch { return string.Empty; }
        }

        /// <summary>
        /// 获取当前页面的URL（五个数字可选 1~5 ）
        /// </summary>
        /// <param name="selectNO">1完整url,2域名之后,3域名之后不含参数,4只有域名,5获取参数</param>
        /// <returns></returns>
        public string getNowURL(int selectNO)
        {
            string strURL = "";
            switch (selectNO)
            {
                case 1:
                    strURL = HttpContext.Current.Request.Url.ToString();
                    break;
                case 2:
                    strURL = HttpContext.Current.Request.RawUrl;
                    break;
                case 3:
                    strURL = HttpContext.Current.Request.Url.AbsolutePath;
                    break;
                case 4:
                    strURL = HttpContext.Current.Request.Url.Host;
                    break;
                case 5:
                    strURL = HttpContext.Current.Request.Url.Query;
                    break;
                default:
                    strURL = HttpContext.Current.Request.Url.ToString();
                    break;
            }
            return strURL;
        }
    }
    internal class ImageHelper
    {
        /// <summary>
        /// 将字节数组转为图片
        /// </summary>
        /// <param name=" b">字节数组</param>
        /// <returns>返回图片</returns>
        internal static System.Drawing.Image ByteToImage(byte[] b)
        {
            try
            {
                MemoryStream ms = new MemoryStream(b);
                return Bitmap.FromStream(ms, true);
            }
            catch { return null; }
        }
    }
    internal class MD5Helper
    {
        /// <summary>
        /// 传入明文，返回用MD5加密后的字符串
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>MD5加密后的字符串</returns>
        internal static string ToMD5_32(string str)
        {
            string passwordFormat = System.Web.Configuration.FormsAuthPasswordFormat.MD5.ToString();
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, passwordFormat);
        }
        /// <summary>
        /// 传入明文，返回用SHA1密后的字符串
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns>SHA1加密后的字符串</returns>
        internal static string ToSHA1(string str)
        {
            string passwordFormat = System.Web.Configuration.FormsAuthPasswordFormat.SHA1.ToString();
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, passwordFormat);
        }
    }

    /// <summary>
    /// Json操作对象
    /// </summary>
    internal class JsonHelper
    {
        /// <summary>
        /// 将指定的Json字符串转为指定的T类型对象 
        /// </summary>
        /// <param name="jsonstr">字符串</param>
        /// <returns>转换后的对象，失败为Null</returns>
        internal static object JsonToObject<T>(string jsonstr)
        {
            try
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                return jss.Deserialize<T>(jsonstr);
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 将指定的对象转为Json字符串
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>转换后的字符串失败为空字符串</returns>
        internal static string ObjectToJson(object obj)
        {
            try
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                return jss.Serialize(obj);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }

    /// <summary>
    /// Html操作相关
    /// </summary>
    internal class HtmlHelper
    {
        /// <summary>
        /// 获取所有的A链接
        /// </summary>
        /// <param name="html">要分析的Html代码</param>
        /// <returns>返回一个List存储所有的A标签</returns>
        internal static List<AItem> GetAList(string html)
        {
            List<AItem> list = null;
            string ra = RegexString.Alist;
            if (Regex.IsMatch(html, ra, RegexOptions.IgnoreCase))
            {
                list = new List<AItem>();
                foreach (Match item in Regex.Matches(html, ra, RegexOptions.IgnoreCase))
                {
                    AItem a = null;
                    try
                    {
                        a = new AItem()
                        {
                            Href = item.Groups[1].Value,
                            Text = item.Groups[2].Value,
                            Html = item.Value,
                            Type = AType.Text
                        };
                        List<ImgItem> imglist = GetImgList(a.Text);
                        if (imglist != null && imglist.Count > 0)
                        {
                            a.Type = AType.Img;
                            a.Img = imglist[0];
                        }
                    }
                    catch { a = null; }
                    if (a != null)
                    {
                        list.Add(a);
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// 获取所有的Img标签
        /// </summary>
        /// <param name="html">要分析的Html代码</param>
        /// <returns>返回一个List存储所有的Img标签</returns>
        internal static List<ImgItem> GetImgList(string html)
        {
            List<ImgItem> list = null;
            string ra = RegexString.ImgList;
            if (Regex.IsMatch(html, ra, RegexOptions.IgnoreCase))
            {
                list = new List<ImgItem>();
                foreach (Match item in Regex.Matches(html, ra, RegexOptions.IgnoreCase))
                {
                    ImgItem a = null;
                    try
                    {
                        a = new ImgItem()
                        {
                            Src = item.Groups[1].Value,
                            Html = item.Value
                        };
                    }
                    catch { a = null; }
                    if (a != null)
                    {
                        list.Add(a);
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// 过滤html标签
        /// </summary>
        /// <param name="html">html的内容</param>
        /// <returns>处理后的文本</returns>
        internal static string StripHTML(string html)
        {
            html = Regex.Replace(html, RegexString.Nscript, string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            html = Regex.Replace(html, RegexString.Style, string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            html = Regex.Replace(html, RegexString.Script, string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            html = Regex.Replace(html, RegexString.Html, string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            return html;
        }
        /// <summary>
        /// 过滤html中所有的换行符号
        /// </summary>
        /// <param name="html">html的内容</param>
        /// <returns>处理后的文本</returns>
        internal static string ReplaceNewLine(string html)
        {
            return Regex.Replace(html, RegexString.NewLine, string.Empty, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }
        /// <summary>
        /// 提取Html字符串中两字符之间的数据
        /// </summary>
        /// <param name="html">源Html</param>
        /// <param name="s">开始字符串</param>
        /// <param name="e">结束字符串</param>
        /// <returns></returns>
        internal static string GetBetweenHtml(string html, string s, string e)
        {
            string rx = string.Format("{0}{1}{2}", s, RegexString.AllHtml, e);
            if (Regex.IsMatch(html, rx, RegexOptions.IgnoreCase))
            {
                Match match = Regex.Match(html, rx, RegexOptions.IgnoreCase);
                if (match != null && match.Groups.Count > 0)
                {
                    return match.Groups[1].Value.Trim();
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// 提取网页Title
        /// </summary>
        /// <param name="html">Html</param>
        /// <returns>返回Title</returns>
        internal static string GetHtmlTitle(string html)
        {
            if (Regex.IsMatch(html, RegexString.HtmlTitle))
            {
                return Regex.Match(html, RegexString.HtmlTitle).Groups[1].Value.Trim();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    /// <summary>
    /// Http返回参数类
    /// </summary>
    public class HttpResult
    {
        /// <summary>
        /// Http请求返回的Cookie
        /// </summary>
        public string Cookie { get; set; }
        /// <summary>
        /// Cookie对象集合
        /// </summary>
        public CookieCollection CookieCollection { get; set; }
        /// <summary>
        /// 返回的String类型数据 只有ResultType.String时才返回数据，其它情况为空
        /// </summary>
        public string Html { get; set; }
        /// <summary>
        /// 返回的Byte数组 只有ResultType.Byte时才返回数据，其它情况为空
        /// </summary>
        public byte[] ResultByte { get; set; }
        /// <summary>
        /// header对象
        /// </summary>
        public WebHeaderCollection Header { get; set; }
        /// <summary>
        /// 返回状态说明
        /// </summary>
        public string StatusDescription { get; set; }
        /// <summary>
        /// 返回状态码,默认为OK
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
        /// <summary>
        /// 最后访问的URl
        /// </summary>
        public string ResponseUri { get; set; }
        /// <summary>
        /// 获取重定向的URl
        /// </summary>
        public string RedirectUrl
        {
            get
            {
                try
                {
                    if (Header != null && Header.Count > 0)
                    {
                        if (Header.AllKeys.Any(k => k.ToLower().Contains("location")))
                        {
                            string baseurl = Header["location"].ToString().Trim();
                            string locationurl = baseurl.ToLower();
                            if (!string.IsNullOrWhiteSpace(locationurl))
                            {
                                bool b = locationurl.StartsWith("http://") || locationurl.StartsWith("https://");
                                if (!b)
                                {
                                    baseurl = new Uri(new Uri(ResponseUri), baseurl).AbsoluteUri;
                                }
                            }
                            return baseurl;
                        }
                    }
                }
                catch { }
                return string.Empty;
            }
        }
        /// <summary>
        /// HttpItem类，用于存储实际执行所用到的HttpItem对象
        /// </summary>
        public HttpItem item { get; set; }
    }

    /// <summary>
    /// 具体实现方法
    /// </summary>
    internal class HttpHelperBll
    {
        /// <summary>
        /// Httphelper原始访问类对象
        /// </summary>
        private HttphelperBase httpbase = new HttphelperBase();
        /// <summary>
        /// 根据相传入的数据，得到相应页面数据
        /// </summary>
        /// <param name="item">参数类对象</param>
        /// <returns>返回HttpResult类型</returns>
        internal HttpResult GetHtml(HttpItem item)
        {
            if (item.Allowautoredirect && item.AutoRedirectCookie)
            {
                HttpResult result = null;
                for (int i = 0; i < 100; i++)
                {
                    item.Allowautoredirect = false;
                    result = httpbase.GetHtml(item);
                    if (string.IsNullOrWhiteSpace(result.RedirectUrl))
                    {
                        break;
                    }
                    else
                    {
                        item.URL = result.RedirectUrl;
                        item.Method = "GET";
                        if (item.ResultCookieType == ResultCookieType.String)
                        {
                            item.Cookie += result.Cookie;
                        }
                        else
                        {
                            item.CookieCollection.Add(result.CookieCollection);
                        }
                    }
                }
                return result;
            }
            return httpbase.GetHtml(item);
        }
        /// <summary>
        /// 根据Url获取图片
        /// </summary>
        /// <param name="item">参数类对象</param>
        /// <returns>返回图片</returns>
        internal Image GetImage(HttpItem item)
        {
            item.ResultType = ResultType.Byte;
            return ImageHelper.ByteToImage(GetHtml(item).ResultByte);
        }
        /// <summary>
        /// 快速Post数据这个访求与GetHtml一样，只是不接收返回数据，只做提交。
        /// </summary>
        /// <param name="item">参数类对象</param>
        /// <returns>返回HttpResult类型</returns>
        internal HttpResult FastRequest(HttpItem item)
        {
            return httpbase.FastRequest(item);
        }
    }

    /// <summary>
    /// Http连接操作帮助类
    /// </summary>
    internal class HttphelperBase
    {
        #region 预定义方变量
        //默认的编码
        private Encoding encoding = Encoding.Default;
        //Post数据编码
        private Encoding postencoding = Encoding.Default;
        //HttpWebRequest对象用来发起请求
        private HttpWebRequest request = null;
        //获取影响流的数据对象
        private HttpWebResponse response = null;
        //设置本地的出口ip和端口
        private IPEndPoint _IPEndPoint = null;
        #endregion
        #region internal

        /// <summary>
        /// 根据相传入的数据，得到相应页面数据
        /// </summary>
        /// <param name="item">参数类对象</param>
        /// <returns>返回HttpResult类型</returns>
        internal HttpResult GetHtml(HttpItem item)
        {
            //返回参数
            HttpResult result = new HttpResult();
            result.item = item;
            try
            {
                //准备参数
                SetRequest(item);
            }
            catch (Exception ex)
            {
                //配置参数时出错
                return new HttpResult() { Cookie = string.Empty, Header = null, Html = ex.Message, StatusDescription = "配置参数时出错：" + ex.Message };
            }
            try
            {
                //请求数据
                using (response = (HttpWebResponse)request.GetResponse())
                {
                    GetData(item, result);
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (response = (HttpWebResponse)ex.Response)
                    {
                        GetData(item, result);
                    }
                }
                else
                {
                    result.Html = ex.Message;
                }
            }
            catch (Exception ex)
            {
                result.Html = ex.Message;
            }
            if (item.IsToLower) result.Html = result.Html.ToLower();
            //重置request，response为空
            if (item.IsReset)
            {
                request = null;
                response = null;
            }
            return result;
        }
        /// <summary>
        /// 快速Post数据这个访求与GetHtml一样，只是不接收返回数据，只做提交。
        /// </summary>
        /// <param name="item">参数类对象</param>
        /// <returns>返回HttpResult类型</returns>
        internal HttpResult FastRequest(HttpItem item)
        {
            //返回参数
            HttpResult result = new HttpResult();
            result.item = item;
            try
            {
                //准备参数
                SetRequest(item);
            }
            catch (Exception ex)
            {
                //配置参数时出错
                return new HttpResult() { Cookie = response.Headers["set-cookie"] != null ? response.Headers["set-cookie"] : string.Empty, Header = null, Html = ex.Message, StatusDescription = "配置参数时出错：" + ex.Message };
            }
            try
            {
                //请求数据
                using (response = (HttpWebResponse)request.GetResponse())
                {
                    //成功 不做处理只回成功状态
                    return new HttpResult() { Cookie = response.Headers["set-cookie"] != null ? response.Headers["set-cookie"] : string.Empty, Header = response.Headers, StatusCode = response.StatusCode, StatusDescription = response.StatusDescription };
                }
            }
            catch (WebException ex)
            {
                using (response = (HttpWebResponse)ex.Response)
                {
                    //不做处理只回成功状态
                    return new HttpResult() { Cookie = response.Headers["set-cookie"] != null ? response.Headers["set-cookie"] : string.Empty, Header = response.Headers, StatusCode = response.StatusCode, StatusDescription = response.StatusDescription };
                }
            }
            catch (Exception ex)
            {
                result.Html = ex.Message;
            }
            if (item.IsToLower) result.Html = result.Html.ToLower();
            return result;
        }
        #endregion

        #region GetData

        /// <summary>
        /// 获取数据的并解析的方法
        /// </summary>
        /// <param name="item"></param>
        /// <param name="result"></param>
        private void GetData(HttpItem item, HttpResult result)
        {
            if (response == null)
            {
                return;
            }
            #region base
            //获取StatusCode
            result.StatusCode = response.StatusCode;
            //获取最后访问的URl
            result.ResponseUri = response.ResponseUri.ToString();
            //获取StatusDescription
            result.StatusDescription = response.StatusDescription;
            //获取Headers
            result.Header = response.Headers;
            //获取CookieCollection
            if (response.Cookies != null) result.CookieCollection = response.Cookies;
            //获取set-cookie
            if (response.Headers["set-cookie"] != null) result.Cookie = response.Headers["set-cookie"];
            //Cookie是否自动更新为请求所获取的新Cookie值 
            if (item.IsUpdateCookie)
            {
                item.Cookie = result.Cookie;
                item.CookieCollection = result.CookieCollection;
            }
            #endregion

            #region 用户设置用编码
            //处理网页Byte
            byte[] ResponseByte = GetByte(item);

            if (ResponseByte != null && ResponseByte.Length > 0)
            {
                //设置编码
                SetEncoding(item, result, ResponseByte);

                //设置返回的Byte
                SetResultByte(item, result, ResponseByte);
            }
            else
            {
                //没有返回任何Html代码
                result.Html = string.Empty;
            }

            #endregion
        }
        /// <summary>
        /// 设置返回的Byte
        /// </summary>
        /// <param name="item">HttpItem</param>
        /// <param name="result">result</param>
        /// <param name="enByte">byte</param>
        private void SetResultByte(HttpItem item, HttpResult result, byte[] enByte)
        {
            //是否返回Byte类型数据
            if (item.ResultType == ResultType.Byte)
            {
                //Byte数据
                result.ResultByte = enByte;
            }
            else if (item.ResultType == ResultType.String)
            {
                //得到返回的HTML
                result.Html = encoding.GetString(enByte);
            }
            else if (item.ResultType == ResultType.StringByte)
            {
                //Byte数据
                result.ResultByte = enByte;
                //得到返回的HTML
                result.Html = encoding.GetString(enByte);
            }
        }
        /// <summary>
        /// 设置编码
        /// </summary>
        /// <param name="item">HttpItem</param>
        /// <param name="result">HttpResult</param>
        /// <param name="ResponseByte">byte[]</param>
        private void SetEncoding(HttpItem item, HttpResult result, byte[] ResponseByte)
        {
            //从这里开始我们要无视编码了
            if (encoding == null)
            {
                Match meta = Regex.Match(Encoding.Default.GetString(ResponseByte), RegexString.Enconding, RegexOptions.IgnoreCase);
                string c = string.Empty;
                if (meta != null && meta.Groups.Count > 0)
                {
                    c = meta.Groups[1].Value.ToLower().Trim();
                }
                string cs = string.Empty;
                if (!string.IsNullOrWhiteSpace(response.CharacterSet))
                {
                    cs = response.CharacterSet.Trim().Replace("\"", "").Replace("\'", "");
                }

                if (c.Length > 2)
                {
                    try
                    {
                        encoding = Encoding.GetEncoding(c.Replace("\"", string.Empty).Replace("'", "").Replace(";", "").Replace("iso-8859-1", "gbk").Trim());
                    }
                    catch
                    {
                        if (string.IsNullOrEmpty(cs))
                        {
                            encoding = Encoding.UTF8;
                        }
                        else
                        {
                            encoding = Encoding.GetEncoding(cs);
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(cs))
                    {
                        encoding = Encoding.UTF8;
                    }
                    else
                    {
                        encoding = Encoding.GetEncoding(cs);
                    }
                }
            }
        }
        /// <summary>
        /// 提取网页Byte
        /// </summary>
        /// <returns></returns>
        private byte[] GetByte(HttpItem item)
        {
            byte[] ResponseByte = null;
            using (MemoryStream _stream = new MemoryStream())
            {
                if (item.IsGzip)
                {
                    //开始读取流并设置编码方式
                    new GZipStream(response.GetResponseStream(), CompressionMode.Decompress).CopyTo(_stream, 10240);
                }
                else
                {
                    //GZIIP处理
                    if (response.ContentEncoding.Equals("gzip", StringComparison.InvariantCultureIgnoreCase))
                    {
                        //开始读取流并设置编码方式
                        new GZipStream(response.GetResponseStream(), CompressionMode.Decompress).CopyTo(_stream, 10240);
                    }
                    else
                    {
                        //开始读取流并设置编码方式
                        response.GetResponseStream().CopyTo(_stream, 10240);
                    }
                }
                //获取Byte
                ResponseByte = _stream.ToArray();
            }
            return ResponseByte;
        }
        #endregion

        #region SetRequest

        /// <summary>
        /// 为请求准备参数
        /// </summary>
        ///<param name="item">参数列表</param>
        private void SetRequest(HttpItem item)
        {
            if (!string.IsNullOrWhiteSpace(item.CerPath))
            {
                //这一句一定要写在创建连接的前面。使用回调的方法进行证书验证。
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Ssl3 | (SecurityProtocolType)3072 | (SecurityProtocolType)192 | (SecurityProtocolType)768;
            }
            //初始化对像，并设置请求的URL地址
            request = (HttpWebRequest)WebRequest.Create(item.URL);
            if (item.IPEndPoint != null)
            {
                _IPEndPoint = item.IPEndPoint;
                //设置本地的出口ip和端口
                request.ServicePoint.BindIPEndPointDelegate = new BindIPEndPoint(BindIPEndPointCallback);
            }
            request.AutomaticDecompression = item.AutomaticDecompression;
            // 验证证书
            SetCer(item);
            SetCerList(item);
            //设置Header参数
            if (item.Header != null && item.Header.Count > 0) foreach (string key in item.Header.AllKeys)
                {
                    request.Headers.Add(key, item.Header[key]);
                }
            // 设置代理
            SetProxy(item);
            if (item.ProtocolVersion != null) request.ProtocolVersion = item.ProtocolVersion;
            request.ServicePoint.Expect100Continue = item.Expect100Continue;
            //请求方式Get或者Post
            request.Method = item.Method;
            request.Timeout = item.Timeout;
            request.KeepAlive = item.KeepAlive;
            request.ReadWriteTimeout = item.ReadWriteTimeout;
            if (!string.IsNullOrWhiteSpace(item.Host))
            {
                request.Host = item.Host;
            }
            if (item.IfModifiedSince != null) request.IfModifiedSince = Convert.ToDateTime(item.IfModifiedSince);
            //Accept
            request.Accept = item.Accept;
            //ContentType返回类型
            request.ContentType = item.ContentType;
            //UserAgent客户端的访问类型，包括浏览器版本和操作系统信息
            request.UserAgent = item.UserAgent;
            // 编码
            encoding = item.Encoding;
            //设置安全凭证
            request.Credentials = item.ICredentials;
            //设置Cookie
            SetCookie(item);
            //来源地址
            request.Referer = item.Referer;
            //是否执行跳转功能
            request.AllowAutoRedirect = item.Allowautoredirect;
            if (item.MaximumAutomaticRedirections > 0)
            {
                request.MaximumAutomaticRedirections = item.MaximumAutomaticRedirections;
            }
            //设置最大连接
            if (item.Connectionlimit > 0) request.ServicePoint.ConnectionLimit = item.Connectionlimit;
            //当出现“请求被中止: 未能创建 SSL/TLS 安全通道”时需要配置此属性 
            if (item.SecurityProtocol > 0)
            {
                ServicePointManager.SecurityProtocol = item.SecurityProtocol;
            }
            //设置Post数据
            SetPostData(item);
        }
        /// <summary>
        /// 设置证书
        /// </summary>
        /// <param name="item"></param>
        private void SetCer(HttpItem item)
        {
            if (!string.IsNullOrWhiteSpace(item.CerPath))
            {
                //将证书添加到请求里
                if (!string.IsNullOrWhiteSpace(item.CerPwd))
                {
                    request.ClientCertificates.Add(new X509Certificate(item.CerPath, item.CerPwd));
                }
                else
                {
                    request.ClientCertificates.Add(new X509Certificate(item.CerPath));
                }
            }
        }
        /// <summary>
        /// 设置多个证书
        /// </summary>
        /// <param name="item"></param>
        private void SetCerList(HttpItem item)
        {
            if (item.ClentCertificates != null && item.ClentCertificates.Count > 0)
            {
                foreach (X509Certificate c in item.ClentCertificates)
                {
                    request.ClientCertificates.Add(c);
                }
            }
        }
        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="item">Http参数</param>
        private void SetCookie(HttpItem item)
        {
            if (!string.IsNullOrEmpty(item.Cookie)) request.Headers[HttpRequestHeader.Cookie] = item.Cookie;
            //设置CookieCollection
            if (item.ResultCookieType == ResultCookieType.CookieCollection)
            {
                request.CookieContainer = new CookieContainer();
                if (item.CookieCollection != null && item.CookieCollection.Count > 0)
                    request.CookieContainer.Add(item.CookieCollection);
            }
            else if (item.ResultCookieType == ResultCookieType.CookieContainer)
            {
                request.CookieContainer = item.CookieContainer;
            }
        }
        /// <summary>
        /// 设置Post数据
        /// </summary>
        /// <param name="item">Http参数</param>
        private void SetPostData(HttpItem item)
        {
            //验证在得到结果时是否有传入数据
            if (!request.Method.Trim().ToLower().Contains("get"))
            {
                if (item.PostEncoding != null)
                {
                    postencoding = item.PostEncoding;
                }
                byte[] buffer = null;
                //写入Byte类型
                if (item.PostDataType == PostDataType.Byte && item.PostdataByte != null && item.PostdataByte.Length > 0)
                {
                    //验证在得到结果时是否有传入数据
                    buffer = item.PostdataByte;
                }//写入文件
                else if (item.PostDataType == PostDataType.FilePath && !string.IsNullOrWhiteSpace(item.Postdata))
                {
                    StreamReader r = new StreamReader(item.Postdata, postencoding);
                    buffer = postencoding.GetBytes(r.ReadToEnd());
                    r.Close();
                } //写入字符串
                else if (!string.IsNullOrWhiteSpace(item.Postdata))
                {
                    buffer = postencoding.GetBytes(item.Postdata);
                }
                if (buffer != null)
                {
                    request.ContentLength = buffer.Length;
                    request.GetRequestStream().Write(buffer, 0, buffer.Length);
                }
                else
                {
                    request.ContentLength = 0;
                }
            }
        }
        /// <summary>
        /// 设置代理
        /// </summary>
        /// <param name="item">参数对象</param>
        private void SetProxy(HttpItem item)
        {
            bool isIeProxy = false;
            if (!string.IsNullOrWhiteSpace(item.ProxyIp))
            {
                isIeProxy = item.ProxyIp.ToLower().Contains("ieproxy");
            }
            if (!string.IsNullOrWhiteSpace(item.ProxyIp) && !isIeProxy)
            {
                //设置代理服务器
                if (item.ProxyIp.Contains(":"))
                {
                    string[] plist = item.ProxyIp.Split(':');
                    WebProxy myProxy = new WebProxy(plist[0].Trim(), Convert.ToInt32(plist[1].Trim()));
                    //建议连接
                    myProxy.Credentials = new NetworkCredential(item.ProxyUserName, item.ProxyPwd);
                    //给当前请求对象
                    request.Proxy = myProxy;
                }
                else
                {
                    WebProxy myProxy = new WebProxy(item.ProxyIp, false);
                    //建议连接
                    myProxy.Credentials = new NetworkCredential(item.ProxyUserName, item.ProxyPwd);
                    //给当前请求对象
                    request.Proxy = myProxy;
                }
            }
            else if (isIeProxy)
            {
                //设置为IE代理
            }
            else
            {
                request.Proxy = item.WebProxy;
            }
        }
        #endregion

        #region private main
        /// <summary>
        /// 回调验证证书问题
        /// </summary>
        /// <param name="sender">流对象</param>
        /// <param name="certificate">证书</param>
        /// <param name="chain">X509Chain</param>
        /// <param name="errors">SslPolicyErrors</param>
        /// <returns>bool</returns>
        private bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors) { return true; }

        /// <summary>
        /// 通过设置这个属性，可以在发出连接的时候绑定客户端发出连接所使用的IP地址。 
        /// </summary>
        /// <param name="servicePoint"></param>
        /// <param name="remoteEndPoint"></param>
        /// <param name="retryCount"></param>
        /// <returns></returns>
        public IPEndPoint BindIPEndPointCallback(ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount)
        {
            return _IPEndPoint;//端口号
        }

        #endregion
    }


    /// <summary>
    /// A链接的类型
    /// </summary>
    public enum AType
    {
        /// <summary>
        /// 文本链接(默认)
        /// </summary>
        Text,
        /// <summary>
        /// 图片链接
        /// </summary>
        Img
    }

    /// <summary>
    /// Post的数据格式(默认为string)
    /// </summary>
    public enum PostDataType
    {
        /// <summary>
        /// 字符串类型，这时编码Encoding可不设置
        /// </summary>
        String,
        /// <summary>
        /// Byte类型，需要设置PostdataByte参数的值编码Encoding可设置为空
        /// </summary>
        Byte,
        /// <summary>
        /// 传文件，Postdata必须设置为文件的绝对路径，必须设置Encoding的值
        /// </summary>
        FilePath
    }

    /// <summary>
    /// Cookie返回类型
    /// </summary>
    public enum ResultCookieType
    {
        /// <summary>
        /// 只返回字符串类型的Cookie
        /// </summary>
        String,
        /// <summary>
        /// CookieCollection格式的Cookie集合同时也返回String类型的cookie
        /// </summary>
        CookieCollection,
        /// <summary>
        /// CookieContainer 多纬度Cookie
        /// </summary>
        CookieContainer
    }

    /// <summary>
    /// 返回类型
    /// </summary>
    public enum ResultType
    {
        /// <summary>
        /// 表示只返回字符串 只有Html有数据,ResultByte为空
        /// </summary>
        String,
        /// <summary>
        /// 表示只返回字符串 只有ResultByte有数据,Html为空
        /// </summary>
        Byte,
        /// <summary>
        /// 表示返回字符串和字节流 ResultByte和Html都有数据返回
        /// </summary>
        StringByte
    }

    /// <summary>
    /// A连接对象
    /// </summary>
    public class AItem
    {
        /// <summary>
        /// 链接地址
        /// </summary>
        public string Href { get; set; }
        /// <summary>
        /// 链接文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 链接的图片，如果是文本链接则为空
        /// </summary>
        public ImgItem Img { get; set; }
        /// <summary>
        /// 整个连接Html
        /// </summary>
        public string Html { get; set; }
        /// <summary>
        /// A链接的类型
        /// </summary>
        public AType Type { get; set; }
    }

    /// <summary>
    /// 图片对象
    /// </summary>
    public class ImgItem
    {
        /// <summary>
        /// 图片网址
        /// </summary>
        public string Src { get; set; }
        /// <summary>
        /// 图片标签Html
        /// </summary>
        public string Html { get; set; }
    }

    /// <summary>
    /// Http请求参考类
    /// </summary>
    public class HttpItem
    {
        #region base
        /// <summary>
        /// 请求URL必须填写
        /// </summary>
        public string URL { get; set; }
        string _Method = "GET";
        /// <summary>
        /// 请求方式默认为GET方式,当为POST方式时必须设置Postdata的值
        /// </summary>
        public string Method
        {
            get { return _Method; }
            set { _Method = value; }
        }
        int _Timeout = 100000;
        /// <summary>
        /// 默认请求超时时间
        /// </summary>
        public int Timeout
        {
            get { return _Timeout; }
            set { _Timeout = value; }
        }
        int _ReadWriteTimeout = 30000;
        /// <summary>
        /// 默认写入和读取Post数据超时间
        /// </summary>
        public int ReadWriteTimeout
        {
            get { return _ReadWriteTimeout; }
            set { _ReadWriteTimeout = value; }
        }
        /// <summary>
        /// 设置Host的标头信息
        /// </summary>
        public string Host { get; set; }
        Boolean _KeepAlive = true;
        /// <summary>
        ///  获取或设置一个值，该值指示是否与 Internet 资源建立持久性连接默认为true。
        /// </summary>
        public Boolean KeepAlive
        {
            get { return _KeepAlive; }
            set { _KeepAlive = value; }
        }
        string _Accept = "text/html, application/xhtml+xml, */*";
        /// <summary>
        /// 请求标头值 默认为text/html, application/xhtml+xml, */*
        /// </summary>
        public string Accept
        {
            get { return _Accept; }
            set { _Accept = value; }
        }
        string _ContentType = "text/html";
        /// <summary>
        /// 请求返回类型默认 text/html
        /// </summary>
        public string ContentType
        {
            get { return _ContentType; }
            set { _ContentType = value; }
        }
        string _UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
        /// <summary>
        /// 客户端访问信息默认Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)
        /// </summary>
        public string UserAgent
        {
            get { return _UserAgent; }
            set { _UserAgent = value; }
        }
        /// <summary>
        /// 来源地址，上次访问地址
        /// </summary>
        public string Referer { get; set; }
        /// <summary>
        ///   获取或设置用于请求的 HTTP 版本。返回结果:用于请求的 HTTP 版本。默认为 System.Net.HttpVersion.Version11。
        /// </summary>
        public Version ProtocolVersion { get; set; }
        private Boolean _expect100continue = false;
        /// <summary>
        ///  获取或设置一个 System.Boolean 值，该值确定是否使用 100-Continue 行为。如果 POST 请求需要 100-Continue 响应，则为 true；否则为 false。默认值为 true。
        /// </summary>
        public Boolean Expect100Continue
        {
            get { return _expect100continue; }
            set { _expect100continue = value; }
        }
        /// <summary>
        /// 设置请求将跟随的重定向的最大数目
        /// </summary>
        public int MaximumAutomaticRedirections { get; set; }
        private DateTime? _IfModifiedSince = null;
        /// <summary>
        /// 获取和设置IfModifiedSince，默认为当前日期和时间
        /// </summary>
        public DateTime? IfModifiedSince
        {
            get { return _IfModifiedSince; }
            set { _IfModifiedSince = value; }
        }
        private Boolean _isGzip = false;
        /// <summary>
        ///  是否执行Gzip解压 默认为否
        /// </summary>
        public Boolean IsGzip
        {
            get { return _isGzip; }
            set { _isGzip = value; }
        }

        #endregion

        #region encoding
        /// <summary>
        /// 返回数据编码默认为NUll,可以自动识别,一般为utf-8,gbk,gb2312
        /// </summary>
        public Encoding Encoding { get; set; }
        /// <summary>
        /// 设置或获取Post参数编码,默认的为Default编码
        /// </summary>
        public Encoding PostEncoding { get; set; }

        //设置所使用的解压缩类型。
        private DecompressionMethods _AutomaticDecompression = DecompressionMethods.None;

        public DecompressionMethods AutomaticDecompression
        {
            get { return _AutomaticDecompression; }
            set { _AutomaticDecompression = value; }
        }

        #endregion

        #region post
        private PostDataType _PostDataType = PostDataType.String;
        /// <summary>
        /// Post的数据类型
        /// </summary>
        public PostDataType PostDataType
        {
            get { return _PostDataType; }
            set { _PostDataType = value; }
        }
        /// <summary>
        /// Post请求时要发送的字符串Post数据
        /// </summary>
        public string Postdata { get; set; }
        /// <summary>
        /// Post请求时要发送的Byte类型的Post数据
        /// </summary>
        public byte[] PostdataByte { get; set; }
        #endregion

        #region cookie
        /// <summary>
        /// Cookie对象集合
        /// </summary>
        public CookieCollection CookieCollection { get; set; }
        /// <summary>
        /// 请求时的Cookie
        /// </summary>
        public string Cookie { get; set; }
        private Boolean _AutoRedirectCookie = false;
        /// <summary>
        /// 请求时当设置allowautoredirect=true时是否自动处理Cookie
        /// </summary>
        public Boolean AutoRedirectCookie
        {
            get { return _AutoRedirectCookie; }
            set { _AutoRedirectCookie = value; }
        }
        private ResultCookieType _ResultCookieType = ResultCookieType.String;
        /// <summary>
        /// 设置返回/输入Cookie类型,默认的是只返回/输入字符串类型Cookie
        /// </summary>
        public ResultCookieType ResultCookieType
        {
            get { return _ResultCookieType; }
            set { _ResultCookieType = value; }
        }
        private Boolean _isUpdateCookie = false;
        /// <summary>
        /// 是否自动将Cookie自动更新为请求所获取的新Cookie值  默认为False
        /// </summary>
        public Boolean IsUpdateCookie
        {
            get { return _isUpdateCookie; }
            set { _isUpdateCookie = value; }
        }

        private CookieContainer _CookieContainer = new CookieContainer();
        /// <summary>
        /// Cookie对象的集合容器 模式Cookie，可容纳N个CookieCollection对象
        /// </summary>
        public CookieContainer CookieContainer
        {
            get { return _CookieContainer; }
            set { _CookieContainer = value; }
        }

        #endregion

        #region cer
        /// <summary>
        /// 证书绝对路径
        /// </summary>
        public string CerPath { get; set; }
        /// <summary>
        /// 证书密码
        /// </summary>
        public string CerPwd { get; set; }
        /// <summary>
        /// 设置509证书集合
        /// </summary>
        public X509CertificateCollection ClentCertificates { get; set; }
        private ICredentials _ICredentials = CredentialCache.DefaultCredentials;
        /// <summary>
        /// 获取或设置请求的身份验证信息。
        /// </summary>
        public ICredentials ICredentials
        {
            get { return _ICredentials; }
            set { _ICredentials = value; }
        }
        #endregion

        #region to
        private Boolean isToLower = false;
        /// <summary>
        /// 是否设置为全文小写，默认为不转化
        /// </summary>
        public Boolean IsToLower
        {
            get { return isToLower; }
            set { isToLower = value; }
        }
        #endregion

        #region link
        private Boolean allowautoredirect = false;
        /// <summary>
        /// 支持跳转页面，查询结果将是跳转后的页面，默认是不跳转
        /// </summary>
        public Boolean Allowautoredirect
        {
            get { return allowautoredirect; }
            set { allowautoredirect = value; }
        }
        private int connectionlimit = 1024;
        /// <summary>
        /// 最大连接数
        /// </summary>
        public int Connectionlimit
        {
            get { return connectionlimit; }
            set { connectionlimit = value; }
        }
        #endregion

        #region proxy
        /// <summary>
        /// 设置代理对象，不想使用IE默认配置就设置为Null，而且不要设置ProxyIp
        /// </summary>
        public WebProxy WebProxy { get; set; }
        /// <summary>
        /// 代理Proxy 服务器用户名
        /// </summary>
        public string ProxyUserName { get; set; }
        /// <summary>
        /// 代理 服务器密码
        /// </summary>
        public string ProxyPwd { get; set; }
        /// <summary>
        /// 代理 服务IP,如果要使用IE代理就设置为ieproxy
        /// </summary>
        public string ProxyIp { get; set; }
        #endregion

        #region result
        private ResultType resulttype = ResultType.String;
        /// <summary>
        /// 设置返回类型String和Byte
        /// </summary>
        public ResultType ResultType
        {
            get { return resulttype; }
            set { resulttype = value; }
        }
        private WebHeaderCollection header = new WebHeaderCollection();
        /// <summary>
        /// header对象
        /// </summary>
        public WebHeaderCollection Header
        {
            get { return header; }
            set { header = value; }
        }
        #endregion

        #region ip-port
        private IPEndPoint _IPEndPoint = null;
        /// <summary>
        /// 设置本地的出口ip和端口
        /// </summary>]
        /// <example>
        ///item.IPEndPoint = new IPEndPoint(IPAddress.Parse("192.168.1.1"),80);
        /// </example>
        public IPEndPoint IPEndPoint
        {
            get { return _IPEndPoint; }
            set { _IPEndPoint = value; }
        }
        #endregion

        #region config

        /// <summary>
        /// 当出现“请求被中止: 未能创建 SSL/TLS 安全通道”时需要配置此属性 
        /// </summary>
        public SecurityProtocolType SecurityProtocol { get; set; }

        private bool _isReset = false;
        /// <summary>
        /// 是否重置request,response的值，默认不重置，当设置为True时request,response将被设置为Null
        /// </summary>
        public bool IsReset
        {
            get { return _isReset; }
            set { _isReset = value; }
        }
        #endregion
    }

    /// <summary>
    /// gethtml方法异步调用的委托
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public delegate void ResultHandler(HttpResult item);
}
