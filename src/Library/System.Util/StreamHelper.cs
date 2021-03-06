using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace System.Util
{
    /// <summary>
    /// StreamHelper
    /// </summary>
    public static class StreamHelper
    {
        /// <summary>
        /// CopyTo with Count
        /// </summary>
        /// <param name="src">Source Stream.</param>
        /// <param name="des">Destination Stream.</param>
        /// <param name="count">Copy Count.</param>
        public static long CopyToWithCount(this Stream src, Stream des, long count)
        {
            var bufferSize = 81920;
            var buffer = new byte[bufferSize];
            var copied = 0L;

            while (count != 0)
            {
                var bytesRead = src.Read(buffer, 0, bufferSize);
                if (bytesRead == 0)
                {
                    break;
                }
                copied += bytesRead;
                des.Write(buffer, 0, bytesRead);
                count -= bytesRead;
            }
            return copied;
        }

        /// <summary>
        /// CopyToAsync with Count 
        /// </summary>
        /// <param name="src">Source Stream.</param>
        /// <param name="des">Destination Stream.</param>
        /// <param name="count">Copy Count.</param>
        public static async Task<long> CopyToAsyncWithCount(this Stream src, Stream des, long count)
        {
            var bufferSize = 81920;
            var buffer = new byte[bufferSize];
            var copied = 0L;

            while (count != 0)
            {
                var bytesRead = await src.ReadAsync(buffer, 0, bufferSize);
                if (bytesRead == 0)
                {
                    break;
                }
                copied += bytesRead;
                await des.WriteAsync(buffer, 0, bytesRead);
                count -= bytesRead;
            }
            return copied;
        }

        /// <summary>
        /// ReadAll (Seek Before Read)
        /// </summary>
        /// <param name="stream"></param>
        /// <exception cref="ArgumentException">The stream cannot seek or read</exception>
        /// <returns></returns>
        public static byte[] ReadAll(this Stream stream)
        {
            if (!stream.CanSeek)
            {
                throw new ArgumentException("Stream must be able to seek.");
            }
            stream.Seek(0, SeekOrigin.Begin);
            byte[] result = new byte[stream.Length];
            if (!stream.CanRead)
            {
                throw new ArgumentException("Stream must be able to read.");
            }
            stream.Read(result, 0, result.Length);
            return result;
        }

        /// <summary>
        /// ReadAll Without Seek
        /// </summary>
        /// <param name="stream"></param>
        /// <exception cref="ArgumentException">The stream cannot read</exception>
        /// <returns></returns>
        public static byte[] ReadAllWithoutSeek(this Stream stream)
        {
            if (!stream.CanRead)
            {
                throw new ArgumentException("Stream must be able to read.");
            }
            var result = new List<byte>();
            var x = stream.ReadByte();
            while (x != -1)
            {
                result.Add((byte)x);
                x = stream.ReadByte();
            }
            return result.ToArray();
        }

#if NET40
        /// <summary>
        /// ReadAsync
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static Task<int> ReadAsync(this Stream stream, byte[] buffer, int offset, int length) =>
            Task<int>.Factory.FromAsync(stream.BeginRead, stream.EndRead, buffer, offset, length, null);
#endif

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        public static void Write(this Stream stream, byte[] buffer) => stream.Write(buffer, 0, buffer.Length);

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        public static void Write(this Stream stream, byte[] buffer, int offset) => stream.Write(buffer, offset, buffer.Length - offset);

#if NET45 || NETSTANDARD2_0
        /// <summary>
        /// WriteAsync
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Task WriteAsync(this Stream stream, byte[] buffer) => stream.WriteAsync(buffer, 0, buffer.Length);
#endif

#if NET40
        /// <summary>
        /// WriteAsync
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Task WriteAsync(this Stream stream, byte[] buffer) =>
            Task.Factory.FromAsync(stream.BeginWrite, stream.EndWrite, buffer, 0, buffer.Length, null);
#endif

        /// <summary>
        /// BeginRead
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IAsyncResult BeginRead(this Stream stream, byte[] buffer, AsyncCallback callback) => stream.BeginRead(buffer, 0, callback);
        /// <summary>
        /// BeginRead
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IAsyncResult BeginRead(this Stream stream, byte[] buffer, int offset, AsyncCallback callback) => stream.BeginRead(buffer, offset, buffer.Length - offset, callback, null);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public static IAsyncResult BeginWrite(this Stream stream, byte[] buffer, AsyncCallback callback) => stream.BeginWrite(buffer, 0, buffer.Length, callback, null);
    }
}
