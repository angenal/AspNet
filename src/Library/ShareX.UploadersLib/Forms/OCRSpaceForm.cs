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
using ShareX.UploadersLib.OtherServices;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareX.UploadersLib
{
    public partial class OCRSpaceForm : Form
    {
        public OCRSpaceLanguages Language { get; set; } = OCRSpaceLanguages.eng;
        public string Result { get; private set; }

        private Stream data;
        private string filename;

        public OCRSpaceForm()
        {
            InitializeComponent();
            Icon = ShareXResources.Icon;
            cbLanguages.Items.AddRange(Helpers.GetEnumDescriptions<OCRSpaceLanguages>());
            txtResult.SupportSelectAll();
        }

        public OCRSpaceForm(Stream data, string filename) : this()
        {
            this.data = data;
            this.filename = filename;
        }

        private async void OCRSpaceResultForm_Shown(object sender, EventArgs e)
        {
            UpdateControls();

            if (string.IsNullOrEmpty(Result))
            {
                await StartOCR(data, filename);
            }
        }

        private void UpdateControls()
        {
            cbLanguages.SelectedIndex = (int)Language;

            if (!string.IsNullOrEmpty(Result))
            {
                txtResult.Text = Result;
            }

            btnStartOCR.Visible = data != null && data.Length > 0 && !string.IsNullOrEmpty(filename);
        }

        private async Task StartOCR(Stream stream, string filename)
        {
            if (stream != null && stream.Length > 0 && !string.IsNullOrEmpty(filename))
            {
                cbLanguages.Enabled = btnStartOCR.Enabled = txtResult.Enabled = false;
                pbProgress.Visible = true;

                await Task.Run(() =>
                {
                    try
                    {
                        OCRSpace ocr = new OCRSpace(Language, false);
                        OCRSpaceResponse response = ocr.DoOCR(stream, filename);

                        if (response != null && !response.IsErroredOnProcessing && response.ParsedResults.Count > 0)
                        {
                            Result = response.ParsedResults[0].ParsedText;
                        }
                    }
                    catch (Exception e)
                    {
                        DebugHelper.WriteException(e);
                    }
                });

                if (!IsDisposed)
                {
                    UpdateControls();
                    cbLanguages.Enabled = btnStartOCR.Enabled = txtResult.Enabled = true;
                    pbProgress.Visible = false;
                    txtResult.Focus();
                    llGoogleTranslate.Enabled = true;
                }
            }
        }

        private void cbLanguages_SelectedIndexChanged(object sender, EventArgs e)
        {
            Language = (OCRSpaceLanguages)cbLanguages.SelectedIndex;
        }

        private async void btnStartOCR_Click(object sender, EventArgs e)
        {
            await StartOCR(data, filename);
        }

        private void llAttribution_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            URLHelpers.OpenURL("https://ocr.space");
        }

        private void llGoogleTranslate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            URLHelpers.OpenURL("https://translate.google.com/#auto/en/" + Uri.EscapeDataString(txtResult.Text));
            Close();
        }
    }
}