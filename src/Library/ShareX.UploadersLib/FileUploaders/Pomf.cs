﻿#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (c) 2007-2017 ShareX Team

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

using Newtonsoft.Json;
using ShareX.HelpersLib;
using ShareX.UploadersLib.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ShareX.UploadersLib.FileUploaders
{
    public class PomfFileUploaderService : FileUploaderService
    {
        public override FileDestination EnumValue { get; } = FileDestination.Pomf;

        public override Icon ServiceIcon => Resources.Pomf;

        public override bool CheckConfig(UploadersConfig config)
        {
            return config.PomfUploader != null && !string.IsNullOrEmpty(config.PomfUploader.UploadURL);
        }

        public override GenericUploader CreateUploader(UploadersConfig config, TaskReferenceHelper taskInfo)
        {
            return new Pomf(config.PomfUploader);
        }

        public override TabPage GetUploadersConfigTabPage(UploadersConfigForm form) => form.tpPomf;
    }

    public class Pomf : FileUploader
    {
        // Pomf clones: https://docs.google.com/spreadsheets/d/1kh1TZdtyX7UlRd55OBxf7DB-JGj2rsfWckI0FPQRYhE
        // More clones: https://github.com/tsudoko/long-live-pomf/blob/master/long-live-pomf.md
        public static List<PomfUploader> Uploaders = new List<PomfUploader>()
        {
            //new PomfUploader("https://pomf.se/upload.php"),           
            new PomfUploader("https://comfy.moe/upload.php"),
            new PomfUploader("https://doko.moe/upload.php"),
            new PomfUploader("https://edfile.pro/upload/archive"),
            //new PomfUploader("https://filebox.moe/upload.php"),
            new PomfUploader("http://glop.me/upload.php", "http://gateway.glop.me/ipfs"),
            new PomfUploader("https://maro.xyz/upload.php", "https://a.maro.xyz/"),
            new PomfUploader("https://mixtape.moe/upload.php"),
            new PomfUploader("https://pomf.cat/upload.php", "https://a.pomf.cat"),
            new PomfUploader("https://pomf.space/upload.php"),
            new PomfUploader("https://pomf.pyonpyon.moe/upload.php"),
            new PomfUploader("https://pomfe.co/upload.php", "https://a.pomfe.co"),
            new PomfUploader("http://reich.io/upload.php"),
            new PomfUploader("https://safe.moe/api/upload"),
            //new PomfUploader("https://sugoi.vidyagam.es/upload.php"), - dangerous site
            new PomfUploader("https://up.asis.io/upload.php", "http://dl.asis.io"),
            new PomfUploader("https://void.cat/upload.php"),
            new PomfUploader("https://vidga.me/upload.php")
        };

        public PomfUploader Uploader { get; private set; }

        public Pomf(PomfUploader uploader)
        {
            Uploader = uploader;
        }

        public override UploadResult Upload(Stream stream, string fileName)
        {
            UploadResult result = SendRequestFile(Uploader.UploadURL, stream, fileName, "files[]");

            if (result.IsSuccess)
            {
                PomfResponse response = JsonConvert.DeserializeObject<PomfResponse>(result.Response);

                if (response.success && response.files != null && response.files.Count > 0)
                {
                    string url = response.files[0].url;

                    if (!URLHelpers.HasPrefix(url) && !string.IsNullOrEmpty(Uploader.ResultURL))
                    {
                        string resultURL = URLHelpers.FixPrefix(Uploader.ResultURL);
                        url = URLHelpers.CombineURL(resultURL, url);
                    }

                    result.URL = url;
                }
            }

            return result;
        }

        public static string TestUploaders()
        {
            List<PomfTest> successful = new List<PomfTest>();
            List<PomfTest> failed = new List<PomfTest>();

            using (MemoryStream ms = new MemoryStream())
            {
                using (Image logo = ShareXResources.Logo)
                {
                    logo.Save(ms, ImageFormat.Png);
                }

                foreach (PomfUploader uploader in Uploaders)
                {
                    try
                    {
                        Pomf pomf = new Pomf(uploader);
                        string filename = Helpers.GetRandomAlphanumeric(10) + ".png";

                        Stopwatch timer = Stopwatch.StartNew();
                        UploadResult result = pomf.Upload(ms, filename);
                        long uploadTime = timer.ElapsedMilliseconds;

                        if (result != null && result.IsSuccess && !string.IsNullOrEmpty(result.URL))
                        {
                            successful.Add(new PomfTest { Name = uploader.ToString(), URL = result.URL, UploadTime = uploadTime });
                        }
                        else
                        {
                            failed.Add(new PomfTest { Name = uploader.ToString() });
                        }
                    }
                    catch (Exception e)
                    {
                        DebugHelper.WriteException(e);
                        failed.Add(new PomfTest { Name = uploader.ToString() });
                    }
                }
            }

            return string.Format("Successful uploads ({0}):\r\n\r\n{1}\r\n\r\nFailed uploads ({2}):\r\n\r\n{3}",
                successful.Count, string.Join("\r\n", successful.OrderBy(x => x.UploadTime)), failed.Count, string.Join("\r\n", failed));
        }

        private class PomfResponse
        {
            public bool success { get; set; }
            public object error { get; set; }
            public List<PomfFile> files { get; set; }
        }

        private class PomfFile
        {
            public string hash { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public string size { get; set; }
        }

        private class PomfTest
        {
            public string Name { get; set; }
            public string URL { get; set; }
            public long UploadTime { get; set; } = -1;

            public override string ToString()
            {
                if (!string.IsNullOrEmpty(URL))
                {
                    return $"{Name} ({UploadTime}ms): {URL}";
                }

                return Name;
            }
        }
    }
}
