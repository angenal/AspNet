using System.Util.Net.Web.Cookie;
using System.Util.Net.Web.Interfaces;
using System.Util.Net.Web.Protocol;
using System.Util.Net.Web.Static;
using System.Util.Text;
using System;
using System.IO;
using System.Text;

namespace System.Util.Net.Web.Message
{
    /// <summary>
    /// HttpMessage Base
    /// </summary>
    public abstract class HttpMessageBase : DisposableClass, IHttpMessage
    {
        /// <summary>
        /// Headers
        /// </summary>
        public HttpHeaderDictionary Headers
        {
            get;
        } = new HttpHeaderDictionary();

        /// <summary>
        /// ErrorCode
        /// </summary>
        public int ErrorCode
        {
            get;
            set;
        } = 200;

        /// <summary>
        /// Content
        /// </summary>
        public virtual Stream Content => Stream.Null;

        /// <summary>
        /// Cookies
        /// </summary>
        public HttpCookies Cookies
        {
            get;
        } = new HttpCookies();

        /// <summary>
        /// HttpVersion
        /// </summary>
        public Version HttpVersion
        {
            get;
            protected set;
        }

        /// <summary>
        /// IsError
        /// </summary>
        public bool IsError => ErrorCode >= 400;

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        public bool Read(byte[] buffer, ref int read) => Read(buffer, 0, ref read);

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        public bool Read(byte[] buffer, int offset, ref int read) => InternalRead(buffer, offset, buffer.Length - offset, ref read);

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        public bool Read(byte[] buffer, int offset, int length, ref int read) => InternalRead(buffer, offset, length, ref read);

        /// <summary>
        /// InternalRead
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        unsafe protected bool InternalRead(byte[] buffer, int offset, int length, ref int read)
        {
            fixed (byte* pts = buffer)
            {
                return InternalRead(pts, offset, length, ref read);
            }
        }

        /// <summary>
        /// InternalRead
        /// </summary>
        /// <param name="pts"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        unsafe protected virtual bool InternalRead(byte* pts, int offset, int count, ref int read)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Parse Line
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="errorcode"></param>
        /// <returns></returns>
        protected unsafe bool ParseLine(byte* start, int length, out int errorcode)
        {
            byte* ptr = start;
            for (int i = 0; i < length; i++, ptr++)
            {
                if (*ptr == ASCIIChar.Colon)
                {
                    var name = StringHelper.ReadStringFromBytePoint(start, i);
                    if (*(++ptr) == ASCIIChar.SPACE)
                    {
                        var content = StringHelper.ReadStringFromBytePoint((++ptr), length - i - 2);
                        if (ValidateHeader(name, content, out errorcode))
                        {
                            if (name != HttpHeadersHelper.GetNameByHeader(Protocol.HttpHeaders.Cookie))
                            {
                                Headers.Add(name, content);
                            }
                            else
                            {
                                Cookies.Add(content);
                            }
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            errorcode = 400;
            return false;
        }

        /// <summary>
        /// Validate Header
        /// </summary>
        /// <param name="name"></param>
        /// <param name="content"></param>
        /// <param name="errorcode"></param>
        /// <returns></returns>
        protected virtual bool ValidateHeader(string name, string content, out int errorcode)
        {
            errorcode = 200;
            return true;
        }

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="str"></param>
        public virtual void Write(string str)
        {
            Write(str.ConvertToBytes(Encoding.UTF8));
        }

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="buffer"></param>
        public virtual void Write(byte[] buffer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GetHttpHeader
        /// </summary>
        /// <returns></returns>
        public virtual string GetHttpHeader()
        {
            throw new NotImplementedException();
        }

    }
}
