using System;
using System.IO;
using System.IO.Compression;
using System.Util.Net.Web.Static;
using System.Util.Net.Web.Interfaces;
using System.Util.Net.Web.Protocol;
using System.Util.Text;

namespace System.Util.Net.Web.Message
{
    class FileResponse : HttpResponse
    {
        public override long ContentLength => Headers[HttpHeaders.ContentLength].ConvertToLong();

        public override Stream Content => content;

        public FileResponse(string path, IHttpRequest request) : base()
        {
            var file = new FileInfo(path);
            var fileStream = file.OpenRead();
            var time = file.LastWriteTime.ToUniversalTime().ToString("r");
            Headers[HttpHeaders.ContentType] = MIMEHelper.GetContentTypeByExtension(System.IO.Path.GetExtension(path));
            Headers.Add("Last-Modified", file.LastWriteTime.ToUniversalTime().ToString("r"));
            if (time == request.Headers[HttpHeaders.IfModifiedSince])
            {
                this.Write304();
            }
            else
            {
                bool is206 = false;
                (long start, long length) fileRange = (0, fileStream.Length);

                var range = request.Headers[HttpHeaders.Range]?.Trim();
                if (!range.IsNullOrEmpty())
                {
                    if (range.StartsWith("bytes="))
                    {
                        range = range.Substring(6);
                        var rangeSplit = range.Split(new char[] { '-' }, StringSplitOptions.None);
                        if (rangeSplit.Length == 2)
                        {
                            if (long.TryParse(rangeSplit[0], out var start))
                            {
                                if (!long.TryParse(rangeSplit[1], out var end))
                                {
                                    end = fileStream.Length - 1;
                                }
                                if (start >= 0 && end < fileStream.Length && start < end)
                                {
                                    fileRange = (start, end - start + 1);
                                    is206 = true;
                                }
                            }
                        }
                    }
                }

                fileStream.Seek(fileRange.start, SeekOrigin.Begin);

                this.ErrorCode = is206 ? 206 : 200;

                if (request.Headers[HttpHeaders.AcceptEncoding].Contains("gzip") && fileRange.length < 10 * 1024 * 1024)
                {
                    using (var compress = new GZipStream(content, CompressionMode.Compress, true))
                    {
                        fileStream.CopyToWithCount(compress, fileRange.length);
                    }
                    content.Seek(0, SeekOrigin.Begin);
                    Headers[HttpHeaders.ContentEncoding] = "gzip";
                    Headers[HttpHeaders.ContentLength] = content.Length.ToString();
                    File.WriteAllBytes("test.gz", (content as MemoryStream).ToArray());
                }
                else
                {
                    Headers[HttpHeaders.ContentRange] = $"bytes {fileRange.start}-{fileRange.start + fileRange.length - 1}/{fileStream.Length}";
                    Headers[HttpHeaders.ContentLength] = fileRange.length.ToString();
                    this.content = fileStream;
                }
            }
        }

        protected override void CleanUpUnmanagedResources()
        {
            content.Dispose();
        }
    }

}
