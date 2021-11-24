﻿#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (c) 2007-2018 ShareX Team

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

using ShareX.HelpersLib;
using ShareX.Properties;
using ShareX.ScreenCaptureLib;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;

namespace ShareX
{
    public partial class QRCodeForm : Form
    {
        private bool isReady;

        public QRCodeForm(string text = null)
        {
            InitializeComponent();
            Icon = ShareXResources.Icon;

            if (!string.IsNullOrEmpty(text))
            {
                txtQRCode.Text = text;
            }
        }

        public static QRCodeForm EncodeClipboard()
        {
            if (Clipboard.ContainsText())
            {
                string text = Clipboard.GetText();

                if (TaskHelpers.CheckQRCodeContent(text))
                {
                    return new QRCodeForm(text);
                }
            }

            return new QRCodeForm();
        }

        public static QRCodeForm DecodeFile(string filePath)
        {
            QRCodeForm form = new QRCodeForm();
            form.tcMain.SelectedTab = form.tpDecode;
            form.DecodeFromFile(filePath);
            return form;
        }

        private void QRCodeForm_Shown(object sender, EventArgs e)
        {
            isReady = true;

            txtQRCode.SetWatermark(Resources.QRCodeForm_InputTextToEncode);

            EncodeText(txtQRCode.Text);
        }

        private void ClearQRCode()
        {
            if (pbQRCode.Image != null)
            {
                Image temp = pbQRCode.Image;
                pbQRCode.Image = null;
                temp.Dispose();
            }
        }

        private void EncodeText(string text)
        {
            if (isReady)
            {
                ClearQRCode();

                int size = Math.Min(pbQRCode.Width, pbQRCode.Height);
                pbQRCode.Image = TaskHelpers.QRCodeEncode(text, size);
            }
        }

        private void DecodeImage(Bitmap bmp)
        {
            string output = "";

            string[] results = TaskHelpers.QRCodeDecode(bmp);

            if (results != null)
            {
                output = string.Join(Environment.NewLine + Environment.NewLine, results.Where(x => !string.IsNullOrEmpty(x)));
            }

            txtDecodeResult.Text = output;
        }

        private void DecodeFromFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                using (Image img = ImageHelpers.LoadImage(filePath))
                {
                    if (img != null)
                    {
                        DecodeImage((Bitmap)img);
                    }
                }
            }
        }

        private void QRCodeForm_Resize(object sender, EventArgs e)
        {
            EncodeText(txtQRCode.Text);
        }

        private void txtQRCode_TextChanged(object sender, EventArgs e)
        {
            EncodeText(txtQRCode.Text);
        }

        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            if (pbQRCode.Image != null)
            {
                ClipboardHelpers.CopyImage(pbQRCode.Image);
            }
        }

        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQRCode.Text))
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = @"PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp|SVG (*.svg)|*.svg";
                    saveFileDialog.FileName = txtQRCode.Text;
                    saveFileDialog.DefaultExt = "png";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        if (filePath.EndsWith("svg", StringComparison.InvariantCultureIgnoreCase))
                        {
                            BarcodeWriterSvg writer = new BarcodeWriterSvg
                            {
                                Format = BarcodeFormat.QR_CODE,
                                Options = new EncodingOptions
                                {
                                    Width = pbQRCode.Width,
                                    Height = pbQRCode.Height
                                }
                            };
                            SvgRenderer.SvgImage svgImage = writer.Write(txtQRCode.Text);
                            File.WriteAllText(filePath, svgImage.Content, Encoding.UTF8);
                        }
                        else
                        {
                            if (pbQRCode.Image != null)
                            {
                                ImageHelpers.SaveImage(pbQRCode.Image, filePath);
                            }
                        }
                    }
                }
            }
        }

        private void tsmiUpload_Click(object sender, EventArgs e)
        {
            if (pbQRCode.Image != null)
            {
                Image img = (Image)pbQRCode.Image.Clone();
                UploadManager.UploadImage(img);
            }
        }

        private void tsmiDecode_Click(object sender, EventArgs e)
        {
            if (pbQRCode.Image != null)
            {
                tcMain.SelectedTab = tpDecode;

                DecodeImage((Bitmap)pbQRCode.Image);
            }
        }

        private void btnDecodeFromScreen_Click(object sender, EventArgs e)
        {
            try
            {
                Hide();
                Thread.Sleep(250);

                using (Image img = RegionCaptureTasks.GetRegionImage(null))
                {
                    if (img != null)
                    {
                        DecodeImage((Bitmap)img);
                    }
                }
            }
            finally
            {
                this.ForceActivate();
            }
        }

        private void btnDecodeFromFile_Click(object sender, EventArgs e)
        {
            string filePath = ImageHelpers.OpenImageFileDialog();

            DecodeFromFile(filePath);
        }
    }
}