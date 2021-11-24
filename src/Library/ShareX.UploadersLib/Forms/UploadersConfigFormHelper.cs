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
using ShareX.UploadersLib.FileUploaders;
using ShareX.UploadersLib.ImageUploaders;
using ShareX.UploadersLib.Properties;
using ShareX.UploadersLib.SharingServices;
using ShareX.UploadersLib.TextUploaders;
using ShareX.UploadersLib.URLShorteners;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareX.UploadersLib
{
    public partial class UploadersConfigForm
    {
        #region Imgur

        private void ImgurRefreshAlbumList()
        {
            try
            {
                lvImgurAlbumList.Items.Clear();

                if (OAuth2Info.CheckOAuth(Config.ImgurOAuth2Info))
                {
                    Config.ImgurAlbumList = new Imgur(Config.ImgurOAuth2Info).GetAlbums();
                    ImgurFillAlbumList();
                    lvImgurAlbumList.Focus();
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        private void ImgurFillAlbumList()
        {
            if (Config.ImgurAlbumList != null)
            {
                foreach (ImgurAlbumData album in Config.ImgurAlbumList)
                {
                    ListViewItem lvi = new ListViewItem(album.id ?? "");
                    lvi.SubItems.Add(album.title ?? "");
                    lvi.SubItems.Add(album.description ?? "");
                    lvi.Selected = Config.ImgurSelectedAlbum != null && !string.IsNullOrEmpty(Config.ImgurSelectedAlbum.id) &&
                        album.id.Equals(Config.ImgurSelectedAlbum.id, StringComparison.InvariantCultureIgnoreCase);
                    lvi.Tag = album;
                    lvImgurAlbumList.Items.Add(lvi);
                }
            }
        }

        #endregion Imgur

        #region Flickr

        private void FlickrAuthOpen()
        {
            try
            {
                OAuthInfo oauth = new OAuthInfo(APIKeys.FlickrKey, APIKeys.FlickrSecret);

                string url = new FlickrUploader(oauth).GetAuthorizationURL();

                if (!string.IsNullOrEmpty(url))
                {
                    Config.FlickrOAuthInfo = oauth;
                    URLHelpers.OpenURL(url);
                    DebugHelper.WriteLine("FlickrAuthOpen - Authorization URL is opened: " + url);
                }
                else
                {
                    DebugHelper.WriteLine("FlickrAuthOpen - Authorization URL is empty.");
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        private void FlickrAuthComplete(string code)
        {
            try
            {
                if (!string.IsNullOrEmpty(code) && Config.FlickrOAuthInfo != null)
                {
                    bool result = new FlickrUploader(Config.FlickrOAuthInfo).GetAccessToken(code);

                    if (result)
                    {
                        oauthFlickr.Status = OAuthLoginStatus.LoginSuccessful;
                        MessageBox.Show(Resources.UploadersConfigForm_Login_successful, "ShareX", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        oauthFlickr.Status = OAuthLoginStatus.LoginFailed;
                        MessageBox.Show(Resources.UploadersConfigForm_Login_failed, "ShareX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        #endregion Flickr

        #region Photobucket

        public void PhotobucketAuthOpen()
        {
            try
            {
                OAuthInfo oauth = new OAuthInfo(APIKeys.PhotobucketConsumerKey, APIKeys.PhotobucketConsumerSecret);

                string url = new Photobucket(oauth).GetAuthorizationURL();

                if (!string.IsNullOrEmpty(url))
                {
                    Config.PhotobucketOAuthInfo = oauth;
                    URLHelpers.OpenURL(url);
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        public void PhotobucketAuthComplete()
        {
            try
            {
                string verification = txtPhotobucketVerificationCode.Text;

                if (!string.IsNullOrEmpty(verification) && Config.PhotobucketOAuthInfo != null &&
                    !string.IsNullOrEmpty(Config.PhotobucketOAuthInfo.AuthToken) && !string.IsNullOrEmpty(Config.PhotobucketOAuthInfo.AuthSecret))
                {
                    Photobucket pb = new Photobucket(Config.PhotobucketOAuthInfo);
                    bool result = pb.GetAccessToken(verification);

                    if (result)
                    {
                        Config.PhotobucketAccountInfo = pb.GetAccountInfo();
                        lblPhotobucketAccountStatus.Text = Resources.UploadersConfigForm_Login_successful;
                        txtPhotobucketDefaultAlbumName.Text = Config.PhotobucketAccountInfo.AlbumID;
                        Config.PhotobucketAccountInfo.AlbumList.Add(Config.PhotobucketAccountInfo.AlbumID);
                        cboPhotobucketAlbumPaths.Items.Add(Config.PhotobucketAccountInfo.AlbumID);
                        cboPhotobucketAlbumPaths.SelectedIndex = 0;
                        MessageBox.Show(Resources.UploadersConfigForm_Login_successful, "ShareX", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        lblPhotobucketAccountStatus.Text = Resources.UploadersConfigForm_Login_failed;
                        MessageBox.Show(Resources.UploadersConfigForm_Login_failed, "ShareX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        public void PhotobucketCreateAlbum()
        {
            Photobucket pb = new Photobucket(Config.PhotobucketOAuthInfo, Config.PhotobucketAccountInfo);
            if (pb.CreateAlbum(txtPhotobucketParentAlbumPath.Text, txtPhotobucketNewAlbumName.Text))
            {
                string albumPath = txtPhotobucketParentAlbumPath.Text + "/" + txtPhotobucketNewAlbumName.Text;
                Config.PhotobucketAccountInfo.AlbumList.Add(albumPath);
                cboPhotobucketAlbumPaths.Items.Add(albumPath);
                MessageBox.Show(string.Format(Resources.UploadersConfigForm_PhotobucketCreateAlbum__0__successfully_created_, albumPath), "ShareX",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion Photobucket

        #region Google Photos

        public void GooglePhotosRefreshAlbumList()
        {
            try
            {
                lvPicasaAlbumList.Items.Clear();

                if (OAuth2Info.CheckOAuth(Config.PicasaOAuth2Info))
                {
                    List<GooglePhotosAlbumInfo> albums = new GooglePhotos(Config.PicasaOAuth2Info).GetAlbumList();

                    if (albums != null && albums.Count > 0)
                    {
                        foreach (GooglePhotosAlbumInfo album in albums)
                        {
                            ListViewItem lvi = new ListViewItem(album.ID);
                            lvi.SubItems.Add(album.Name ?? "");
                            lvi.SubItems.Add(album.Summary ?? "");
                            lvi.Tag = album;
                            lvPicasaAlbumList.Items.Add(lvi);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        #endregion Google Photos

        #region Amazon S3

        private void UpdateAmazonS3Status()
        {
            AmazonS3 s3 = new AmazonS3(Config.AmazonS3Settings);

            lblAmazonS3PathPreview.Text = s3.GetPreviewURL();
        }

        #endregion Amazon S3

        #region Google Cloud Storage

        private void UpdateGoogleCloudStorageStatus()
        {
            GoogleCloudStorage gcs = new GoogleCloudStorage(Config.GoogleCloudStorageOAuth2Info)
            {
                Bucket = Config.GoogleCloudStorageBucket,
                Domain = Config.GoogleCloudStorageDomain,
                Prefix = Config.GoogleCloudStorageObjectPrefix
            };

            lblGoogleCloudStoragePathPreview.Text = gcs.GetPreviewURL();
        }

        #endregion Google Cloud Storage

        #region Azure Storage

        private void UpdateAzureStorageStatus()
        {
            AzureStorage azure = new AzureStorage(Config.AzureStorageAccountName, Config.AzureStorageAccountAccessKey, Config.AzureStorageContainer,
                Config.AzureStorageEnvironment, Config.AzureStorageCustomDomain, Config.AzureStorageUploadPath);

            lblAzureStorageURLPreview.Text = azure.GetPreviewURL();
        }

        #endregion Azure Storage

        #region Backblaze B2

        private void B2UpdateCustomDomainPreview()
        {
            string uploadPath = NameParser.Parse(NameParserType.FolderPath, Config.B2UploadPath);

            if (cbB2CustomUrl.Checked)
            {
                string customUrl = NameParser.Parse(NameParserType.FolderPath, Config.B2CustomUrl);
                if (URLHelpers.IsValidURL(customUrl))
                {
                    txtB2UrlPreview.Text = customUrl + uploadPath + "example.png";
                }
                else
                {
                    txtB2UrlPreview.Text = "invalid custom URL";
                }
            }
            else
            {
                string bucket = string.IsNullOrEmpty(Config.B2BucketName) ?
                    "[bucket]" :
                    URLHelpers.URLEncode(Config.B2BucketName);
                string url = $"https://f001.backblazeb2.com/file/{bucket}/{uploadPath}example.png";
                txtB2UrlPreview.Text = url;
            }
        }

        #endregion Backblaze B2

        #region Google Drive

        private void GoogleDriveRefreshFolders()
        {
            try
            {
                lvGoogleDriveFoldersList.Items.Clear();

                if (OAuth2Info.CheckOAuth(Config.GoogleDriveOAuth2Info))
                {
                    List<GoogleDriveFile> folders = new GoogleDrive(Config.GoogleDriveOAuth2Info).GetFolders();

                    if (folders != null)
                    {
                        foreach (GoogleDriveFile folder in folders)
                        {
                            ListViewItem lvi = new ListViewItem(folder.name);
                            lvi.SubItems.Add(folder.description);
                            lvi.Tag = folder;
                            lvGoogleDriveFoldersList.Items.Add(lvi);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        #endregion Google Drive

        #region Box

        public void BoxListFolders()
        {
            lvBoxFolders.Items.Clear();
            BoxAddFolder(Box.RootFolder);
            BoxListFolders(Box.RootFolder);
        }

        public void BoxListFolders(BoxFileEntry fileEntry)
        {
            if (!OAuth2Info.CheckOAuth(Config.BoxOAuth2Info))
            {
                MessageBox.Show(Resources.UploadersConfigForm_ListFolders_Authentication_required_, Resources.UploadersConfigForm_BoxListFolders_Box_refresh_folders_list_failed,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Box box = new Box(Config.BoxOAuth2Info);
                BoxFileInfo files = box.GetFiles(fileEntry);
                if (files != null && files.entries != null && files.entries.Length > 0)
                {
                    foreach (BoxFileEntry folder in files.entries.Where(x => x.type == "folder"))
                    {
                        BoxAddFolder(folder);
                    }
                }
            }
        }

        private void BoxAddFolder(BoxFileEntry folder)
        {
            ListViewItem lvi = new ListViewItem(folder.name);
            lvi.Tag = folder;
            lvBoxFolders.Items.Add(lvi);
        }

        #endregion Box

        #region OneDrive

        public void OneDriveListFolders(OneDriveFileInfo fileEntry, TreeNode tnParent)
        {
            Application.DoEvents();
            OneDrive oneDrive = new OneDrive(Config.OneDriveV2OAuth2Info);
            OneDriveFileList oneDrivePathInfo = oneDrive.GetPathInfo(fileEntry.id);
            tnParent.Nodes.Clear();
            foreach (OneDriveFileInfo folder in oneDrivePathInfo.value)
            {
                OneDriveAddFolder(folder, tnParent);
            }
        }

        private void OneDriveAddFolder(OneDriveFileInfo folder, TreeNode tnParent)
        {
            TreeNode tn = new TreeNode(folder.name);
            tn.Tag = folder;
            tn.Nodes.Add(new TreeNode(Resources.UploadersConfigForm_OneDriveAddFolder_Querying_folders___));

            if (tnParent != null)
            {
                tnParent.Nodes.Add(tn);
            }
            else
            {
                tvOneDrive.Nodes.Add(tn);
            }
        }

        #endregion OneDrive

        #region FTP

        private bool FTPCheckAccount(int index)
        {
            return Config.FTPAccountList.IsValidIndex(index);
        }

        private FTPAccount FTPGetSelectedAccount()
        {
            int index = cbFTPAccounts.SelectedIndex;

            if (FTPCheckAccount(index))
            {
                return Config.FTPAccountList[index];
            }

            return null;
        }

        private void FTPAddAccount(FTPAccount account)
        {
            if (account != null)
            {
                Config.FTPAccountList.Add(account);
                cbFTPAccounts.Items.Add(account);
                FTPUpdateControls();
            }
        }

        private void FTPUpdateControls()
        {
            int selected = cbFTPAccounts.SelectedIndex;

            cbFTPAccounts.Items.Clear();
            cbFTPImage.Items.Clear();
            cbFTPText.Items.Clear();
            cbFTPFile.Items.Clear();

            if (Config.FTPAccountList.Count > 0)
            {
                foreach (FTPAccount account in Config.FTPAccountList)
                {
                    cbFTPAccounts.Items.Add(account);
                    cbFTPImage.Items.Add(account);
                    cbFTPText.Items.Add(account);
                    cbFTPFile.Items.Add(account);
                }

                cbFTPAccounts.SelectedIndex = selected.Between(0, Config.FTPAccountList.Count - 1);
                cbFTPImage.SelectedIndex = Config.FTPSelectedImage.Between(0, Config.FTPAccountList.Count - 1);
                cbFTPText.SelectedIndex = Config.FTPSelectedText.Between(0, Config.FTPAccountList.Count - 1);
                cbFTPFile.SelectedIndex = Config.FTPSelectedFile.Between(0, Config.FTPAccountList.Count - 1);
            }

            FTPUpdateEnabledStates();
        }

        private void FTPUpdateEnabledStates()
        {
            cbFTPImage.Enabled = cbFTPText.Enabled = cbFTPFile.Enabled = cbFTPAccounts.Enabled = cbFTPAccounts.Items.Count > 0;
            btnFTPRemove.Enabled = btnFTPDuplicate.Enabled = gbFTPAccount.Enabled = cbFTPAccounts.SelectedIndex > -1;

            FTPAccount account = FTPGetSelectedAccount();

            if (account != null)
            {
                gbFTPS.Visible = account.Protocol == FTPProtocol.FTPS;
                gbSFTP.Visible = account.Protocol == FTPProtocol.SFTP;
                pFTPTransferMode.Enabled = account.Protocol == FTPProtocol.FTP || account.Protocol == FTPProtocol.FTPS;
            }
            else
            {
                gbFTPS.Visible = gbSFTP.Visible = false;
            }
        }

        private void FTPRefreshNames()
        {
            cbFTPAccounts.RefreshItems();
            cbFTPImage.RefreshItems();
            cbFTPText.RefreshItems();
            cbFTPFile.RefreshItems();
        }

        private void FTPLoadSelectedAccount()
        {
            FTPAccount account = FTPGetSelectedAccount();

            if (account != null)
            {
                FTPLoadAccount(account);
            }
        }

        private void FTPLoadAccount(FTPAccount account)
        {
            txtFTPName.Text = account.Name;

            switch (account.Protocol)
            {
                case FTPProtocol.FTP:
                    rbFTPProtocolFTP.Checked = true;
                    break;
                case FTPProtocol.FTPS:
                    rbFTPProtocolFTPS.Checked = true;
                    break;
                case FTPProtocol.SFTP:
                    rbFTPProtocolSFTP.Checked = true;
                    break;
            }

            txtFTPHost.Text = account.Host;
            nudFTPPort.Value = account.Port;
            txtFTPUsername.Text = account.Username;
            txtFTPPassword.Text = account.Password;

            if (account.IsActive)
            {
                rbFTPTransferModeActive.Checked = true;
            }
            else
            {
                rbFTPTransferModePassive.Checked = true;
            }

            txtFTPRemoteDirectory.Text = account.SubFolderPath;
            cbFTPURLPathProtocol.SelectedIndex = (int)account.BrowserProtocol;
            txtFTPURLPath.Text = account.HttpHomePath;
            cbFTPAppendRemoteDirectory.Checked = account.HttpHomePathAutoAddSubFolderPath;
            cbFTPRemoveFileExtension.Checked = account.HttpHomePathNoExtension;
            lblFTPURLPreviewValue.Text = account.PreviewHttpPath;

            cbFTPSEncryption.SelectedIndex = (int)account.FTPSEncryption;
            txtFTPSCertificateLocation.Text = account.FTPSCertificateLocation;

            txtSFTPKeyLocation.Text = account.Keypath;
            txtSFTPKeyPassphrase.Text = account.Passphrase;

            FTPUpdateEnabledStates();
        }

        private void FTPClearFields()
        {
            FTPAccount account = new FTPAccount()
            {
                Name = "",
                HttpHomePathAutoAddSubFolderPath = false
            };

            FTPLoadAccount(account);
        }

        private void FTPUpdateURLPreview()
        {
            FTPAccount account = FTPGetSelectedAccount();

            if (account != null)
            {
                lblFTPURLPreviewValue.Text = account.PreviewHttpPath;
            }
        }

        private async Task FTPTestAccountAsync(FTPAccount account)
        {
            if (account != null)
            {
                btnFTPTest.Enabled = false;

                await Task.Run(() =>
                {
                    FTPTestAccount(account);
                });

                btnFTPTest.Enabled = true;
            }
        }

        private void FTPTestAccount(FTPAccount account)
        {
            string msg = "";
            string remotePath = account.GetSubFolderPath();
            List<string> directories = new List<string>();

            try
            {
                if (account.Protocol == FTPProtocol.FTP || account.Protocol == FTPProtocol.FTPS)
                {
                    using (FTP ftp = new FTP(account))
                    {
                        if (ftp.Connect())
                        {
                            if (!ftp.DirectoryExists(remotePath))
                            {
                                directories = ftp.CreateMultiDirectory(remotePath);
                            }

                            if (ftp.IsConnected)
                            {
                                if (directories.Count > 0)
                                {
                                    msg = Resources.UploadersConfigForm_TestFTPAccount_Connected_Created_folders + "\r\n" + string.Join("\r\n", directories);
                                }
                                else
                                {
                                    msg = Resources.UploadersConfigForm_TestFTPAccount_Connected_;
                                }
                            }
                        }
                    }
                }
                else if (account.Protocol == FTPProtocol.SFTP)
                {
                    using (SFTP sftp = new SFTP(account))
                    {
                        if (sftp.Connect())
                        {
                            if (!sftp.DirectoryExists(remotePath))
                            {
                                directories = sftp.CreateMultiDirectory(remotePath);
                            }

                            if (sftp.IsConnected)
                            {
                                if (directories.Count > 0)
                                {
                                    msg = Resources.UploadersConfigForm_TestFTPAccount_Connected_Created_folders + "\r\n" + string.Join("\r\n", directories);
                                }
                                else
                                {
                                    msg = Resources.UploadersConfigForm_TestFTPAccount_Connected_;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
            }

            MessageBox.Show(msg, "ShareX", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FTPOpenClient(FTPAccount account)
        {
            if (account.Protocol == FTPProtocol.FTP || account.Protocol == FTPProtocol.FTPS)
            {
                new FTPClientForm(account).Show();
            }
            else
            {
                MessageBox.Show(Resources.UploadersConfigForm_FTPOpenClient_FTP_client_only_supports_FTP_or_FTPS_, "ShareX", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion FTP

        #region SendSpace

        public UserPassBox SendSpaceRegister()
        {
            UserPassBox upb = new UserPassBox(Resources.UploadersConfigForm_SendSpaceRegister_SendSpace_Registration___, "John Doe", "john.doe@gmail.com", "JohnDoe", "");
            upb.ShowDialog();
            if (upb.DialogResult == DialogResult.OK)
            {
                SendSpace sendSpace = new SendSpace(APIKeys.SendSpaceKey);
                upb.Success = sendSpace.AuthRegister(upb.UserName, upb.FullName, upb.Email, upb.Password);
                if (!upb.Success && sendSpace.Errors.Count > 0)
                {
                    MessageBox.Show(sendSpace.ToErrorString(), Resources.UploadersConfigForm_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return upb;
        }

        #endregion SendSpace

        #region Ge.tt

        public void Ge_ttLogin()
        {
            try
            {
                Ge_tt gett = new Ge_tt(APIKeys.Ge_ttKey);
                Ge_ttLogin login = gett.Login(txtGe_ttEmail.Text, txtGe_ttPassword.Text);
                Config.Ge_ttLogin = login;
                lblGe_ttStatus.Text = Resources.UploadersConfigForm_Login_successful;
            }
            catch (Exception ex)
            {
                Config.Ge_ttLogin = null;
                lblGe_ttStatus.Text = Resources.UploadersConfigForm_Login_failed;
                ex.ShowError();
            }
        }

        #endregion Ge.tt

        #region Pastebin

        public void PastebinLogin()
        {
            if (Config.PastebinSettings != null)
            {
                try
                {
                    Pastebin pastebin = new Pastebin(APIKeys.PastebinKey, Config.PastebinSettings);

                    if (pastebin.Login())
                    {
                        UpdatePastebinStatus();
                        MessageBox.Show(Resources.UploadersConfigForm_Login_successful, "ShareX", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        UpdatePastebinStatus();
                        MessageBox.Show(Resources.UploadersConfigForm_Login_failed, "ShareX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    ex.ShowError();
                }
            }
        }

        public void UpdatePastebinStatus()
        {
            if (Config.PastebinSettings == null || string.IsNullOrEmpty(Config.PastebinSettings.UserKey))
            {
                lblPastebinLoginStatus.Text = Resources.UploadersConfigForm_UpdatePastebinStatus_NotLoggedIn;
            }
            else
            {
                lblPastebinLoginStatus.Text = Resources.UploadersConfigForm_UpdatePastebinStatus_LoggedIn;
            }
        }

        #endregion Pastebin

        #region Pushbullet

        public void PushbulletGetDevices()
        {
            cboPushbulletDevices.Items.Clear();
            cboPushbulletDevices.ResetText();

            Pushbullet pushbullet = new Pushbullet(Config.PushbulletSettings);
            Config.PushbulletSettings.DeviceList = pushbullet.GetDeviceList();

            if (Config.PushbulletSettings.DeviceList.Count > 0)
            {
                Config.PushbulletSettings.SelectedDevice = 0;

                cboPushbulletDevices.Enabled = true;

                Config.PushbulletSettings.DeviceList.ForEach(pbDevice =>
                {
                    cboPushbulletDevices.Items.Add(pbDevice.Name ?? Resources.UploadersConfigForm_LoadSettings_Invalid_device_name);
                });

                cboPushbulletDevices.SelectedIndex = 0;
            }
        }

        #endregion Pushbullet

        #region Twitter

        private OAuthInfo GetSelectedTwitterAccount()
        {
            return Config.TwitterOAuthInfoList.ReturnIfValidIndex(Config.TwitterSelectedAccount);
        }

        private bool CheckTwitterAccounts()
        {
            return Config.TwitterOAuthInfoList.IsValidIndex(Config.TwitterSelectedAccount);
        }

        private bool TwitterUpdateSelected()
        {
            Config.TwitterSelectedAccount = lbTwitterAccounts.SelectedIndex;

            if (Config.TwitterSelectedAccount > -1)
            {
                OAuthInfo oauth = Config.TwitterOAuthInfoList[Config.TwitterSelectedAccount];

                if (oauth != null)
                {
                    txtTwitterDescription.Enabled = true;
                    txtTwitterDescription.Text = oauth.Description;
                    oauthTwitter.Enabled = true;

                    if (OAuthInfo.CheckOAuth(oauth))
                    {
                        oauthTwitter.Status = OAuthLoginStatus.LoginSuccessful;
                    }
                    else
                    {
                        oauthTwitter.Status = OAuthLoginStatus.LoginRequired;
                    }

                    return true;
                }
            }

            txtTwitterDescription.Enabled = false;
            txtTwitterDescription.Text = "";
            oauthTwitter.Enabled = false;
            return false;
        }

        private void TwitterAuthOpen()
        {
            if (CheckTwitterAccounts())
            {
                try
                {
                    OAuthInfo oauth = new OAuthInfo(APIKeys.TwitterConsumerKey, APIKeys.TwitterConsumerSecret);

                    string url = new Twitter(oauth).GetAuthorizationURL();

                    if (!string.IsNullOrEmpty(url))
                    {
                        oauth.Description = Config.TwitterOAuthInfoList[Config.TwitterSelectedAccount].Description;
                        Config.TwitterOAuthInfoList[Config.TwitterSelectedAccount] = oauth;
                        URLHelpers.OpenURL(url);
                        DebugHelper.WriteLine("TwitterAuthOpen - Authorization URL is opened: " + url);
                    }
                    else
                    {
                        DebugHelper.WriteLine("TwitterAuthOpen - Authorization URL is empty.");
                    }
                }
                catch (Exception ex)
                {
                    ex.ShowError();
                }
            }
        }

        private void TwitterAuthComplete(string code)
        {
            if (CheckTwitterAccounts())
            {
                try
                {
                    OAuthInfo oauth = GetSelectedTwitterAccount();

                    if (oauth != null && !string.IsNullOrEmpty(oauth.AuthToken) && !string.IsNullOrEmpty(oauth.AuthSecret))
                    {
                        bool result = new Twitter(oauth).GetAccessToken(code);

                        if (result)
                        {
                            oauth.AuthVerifier = "";
                            oauthTwitter.Status = OAuthLoginStatus.LoginSuccessful;
                            MessageBox.Show(Resources.UploadersConfigForm_Login_successful, "ShareX", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            oauthTwitter.Status = OAuthLoginStatus.LoginFailed;
                            MessageBox.Show(Resources.UploadersConfigForm_Login_failed, "ShareX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.ShowError();
                }
            }
        }

        private void TwitterAuthClear()
        {
            if (CheckTwitterAccounts())
            {
                OAuthInfo oauth = new OAuthInfo();

                OAuthInfo oauth2 = GetSelectedTwitterAccount();

                if (oauth2 != null)
                {
                    oauth.Description = oauth2.Description;
                }

                Config.TwitterOAuthInfoList[Config.TwitterSelectedAccount] = oauth;
            }
        }

        #endregion Twitter

        #region Custom uploader

        private bool CustomUploaderCheck(int index)
        {
            return Config.CustomUploadersList.IsValidIndex(index);
        }

        private CustomUploaderItem CustomUploaderGetSelected()
        {
            int index = lbCustomUploaderList.SelectedIndex;

            if (CustomUploaderCheck(index))
            {
                return Config.CustomUploadersList[index];
            }

            return null;
        }

        private void CustomUploaderAdd()
        {
            CustomUploaderAdd(new CustomUploaderItem());
        }

        private void CustomUploaderAdd(CustomUploaderItem uploader)
        {
            if (uploader != null)
            {
                Config.CustomUploadersList.Add(uploader);
                lbCustomUploaderList.Items.Add(uploader);
                CustomUploaderUpdateList();
            }
        }

        private void CustomUploaderLoadSelected()
        {
            CustomUploaderItem uploader = CustomUploaderGetSelected();
            if (uploader != null)
            {
                CustomUploaderLoad(uploader);
            }
        }

        private void CustomUploaderLoad(CustomUploaderItem uploader)
        {
            txtCustomUploaderName.Text = uploader.Name ?? "";
            CustomUploaderSetDestinationType(uploader.DestinationType);

            cbCustomUploaderRequestType.SelectedIndex = (int)uploader.RequestType;
            txtCustomUploaderRequestURL.Text = uploader.RequestURL ?? "";
            txtCustomUploaderFileForm.Text = uploader.FileFormName ?? "";
            txtCustomUploaderFileForm.Enabled = uploader.RequestType == CustomUploaderRequestMethod.POST;

            txtCustomUploaderArgName.Text = "";
            txtCustomUploaderArgValue.Text = "";
            lvCustomUploaderArguments.Items.Clear();
            if (uploader.Arguments != null)
            {
                foreach (KeyValuePair<string, string> arg in uploader.Arguments)
                {
                    lvCustomUploaderArguments.Items.Add(arg.Key).SubItems.Add(arg.Value);
                }
            }

            txtCustomUploaderHeaderName.Text = "";
            txtCustomUploaderHeaderValue.Text = "";
            lvCustomUploaderHeaders.Items.Clear();
            if (uploader.Headers != null)
            {
                foreach (KeyValuePair<string, string> arg in uploader.Headers)
                {
                    lvCustomUploaderHeaders.Items.Add(arg.Key).SubItems.Add(arg.Value);
                }
            }

            cbCustomUploaderResponseType.SelectedIndex = (int)uploader.ResponseType;
            txtCustomUploaderJsonPath.Text = "";
            txtCustomUploaderXPath.Text = "";
            txtCustomUploaderRegexp.Text = "";
            lvCustomUploaderRegexps.Items.Clear();
            if (uploader.RegexList != null)
            {
                foreach (string regexp in uploader.RegexList)
                {
                    lvCustomUploaderRegexps.Items.Add(regexp);
                }
            }

            txtCustomUploaderURL.Text = uploader.URL ?? "";
            txtCustomUploaderThumbnailURL.Text = uploader.ThumbnailURL ?? "";
            txtCustomUploaderDeletionURL.Text = uploader.DeletionURL ?? "";

            CustomUploaderUpdateStates();
        }

        private void CustomUploaderUpdateStates()
        {
            bool isSelected = CustomUploaderCheck(lbCustomUploaderList.SelectedIndex);

            txtCustomUploaderName.Enabled = btnCustomUploaderRemove.Enabled = btnCustomUploaderDuplicate.Enabled = pCustomUploader.Enabled =
                mbCustomUploaderDestinationType.Enabled = isSelected;

            if (isSelected)
            {
                CustomUploaderUpdateRequestState();
                CustomUploaderUpdateArgumentsState();
                CustomUploaderUpdateHeadersState();
                CustomUploaderUpdateResponseState();
            }

            btnCustomUploaderClearUploaders.Enabled = btnCustomUploadersExportAll.Enabled = cbCustomUploaderImageUploader.Enabled =
                btnCustomUploaderImageUploaderTest.Enabled = cbCustomUploaderTextUploader.Enabled = btnCustomUploaderTextUploaderTest.Enabled =
                cbCustomUploaderFileUploader.Enabled = btnCustomUploaderFileUploaderTest.Enabled = cbCustomUploaderURLShortener.Enabled =
                btnCustomUploaderURLShortenerTest.Enabled = cbCustomUploaderURLSharingService.Enabled = btnCustomUploaderURLSharingServiceTest.Enabled =
                lbCustomUploaderList.Items.Count > 0;
        }

        private void CustomUploaderUpdateRequestState()
        {
            txtCustomUploaderFileForm.Enabled = (CustomUploaderRequestMethod)cbCustomUploaderRequestType.SelectedIndex == CustomUploaderRequestMethod.POST;
        }

        private void CustomUploaderUpdateArgumentsState()
        {
            btnCustomUploaderArgAdd.Enabled = !string.IsNullOrEmpty(txtCustomUploaderArgName.Text);
            btnCustomUploaderArgRemove.Enabled = btnCustomUploaderArgUpdate.Enabled = lvCustomUploaderArguments.SelectedItems.Count > 0;
        }

        private void CustomUploaderUpdateHeadersState()
        {
            btnCustomUploaderHeaderAdd.Enabled = !string.IsNullOrEmpty(txtCustomUploaderHeaderName.Text);
            btnCustomUploaderHeaderRemove.Enabled = btnCustomUploaderHeaderUpdate.Enabled = lvCustomUploaderHeaders.SelectedItems.Count > 0;
        }

        private void CustomUploaderUpdateResponseState()
        {
            btnCustomUploaderJsonAddSyntax.Enabled = !string.IsNullOrEmpty(txtCustomUploaderJsonPath.Text);
            btnCustomUploaderXmlSyntaxAdd.Enabled = !string.IsNullOrEmpty(txtCustomUploaderXPath.Text);
            btnCustomUploaderRegexpAdd.Enabled = !string.IsNullOrEmpty(txtCustomUploaderRegexp.Text);
            btnCustomUploaderRegexpRemove.Enabled = btnCustomUploaderRegexpUpdate.Enabled = btnCustomUploaderRegexAddSyntax.Enabled =
                lvCustomUploaderRegexps.SelectedItems.Count > 0;
        }

        private void CustomUploaderRefreshNames()
        {
            lbCustomUploaderList.RefreshSelectedItem();
            cbCustomUploaderImageUploader.RefreshItems();
            cbCustomUploaderTextUploader.RefreshItems();
            cbCustomUploaderFileUploader.RefreshItems();
            cbCustomUploaderURLShortener.RefreshItems();
            cbCustomUploaderURLSharingService.RefreshItems();
        }

        private void CustomUploaderClearUploaders()
        {
            Config.CustomUploadersList.Clear();
            lbCustomUploaderList.Items.Clear();
            CustomUploaderClearFields();
            Config.CustomImageUploaderSelected = Config.CustomTextUploaderSelected = Config.CustomFileUploaderSelected = Config.CustomURLShortenerSelected =
                Config.CustomURLSharingServiceSelected = 0;
            CustomUploaderUpdateList();
            CustomUploaderUpdateStates();
            btnCustomUploaderAdd.Focus();
        }

        private void CustomUploaderClearFields()
        {
            CustomUploaderLoad(new CustomUploaderItem());
        }

        private void CustomUploaderExportAll()
        {
            if (Config.CustomUploadersList != null && Config.CustomUploadersList.Count > 0)
            {
                using (FolderSelectDialog fsd = new FolderSelectDialog())
                {
                    if (fsd.ShowDialog())
                    {
                        foreach (CustomUploaderItem uploader in Config.CustomUploadersList)
                        {
                            string json = eiCustomUploaders.Serialize(uploader);
                            string filepath = Path.Combine(fsd.FileName, uploader.GetFileName());
                            File.WriteAllText(filepath, json, Encoding.UTF8);
                        }
                    }
                }
            }
        }

        private void CustomUploaderLoadTab(bool selectLastItem = false)
        {
            lbCustomUploaderList.Items.Clear();

            if (Config.CustomUploadersList == null)
            {
                Config.CustomUploadersList = new List<CustomUploaderItem>();
            }
            else
            {
                foreach (CustomUploaderItem customUploader in Config.CustomUploadersList)
                {
                    lbCustomUploaderList.Items.Add(customUploader);
                }

                CustomUploaderUpdateList();
            }

#if DEBUG
            btnCustomUploadersExportAll.Visible = true;
#endif

            CustomUploaderClearFields();

            if (lbCustomUploaderList.Items.Count > 0)
            {
                if (selectLastItem)
                {
                    lbCustomUploaderList.SelectedIndex = lbCustomUploaderList.Items.Count - 1;
                }
                else if (Config.CustomUploadersList.IsValidIndex(Config.CustomImageUploaderSelected))
                {
                    lbCustomUploaderList.SelectedIndex = Config.CustomImageUploaderSelected;
                }
            }

            CustomUploaderUpdateStates();
        }

        public static void CustomUploaderUpdateTab()
        {
            if (IsInstanceActive)
            {
                UploadersConfigForm form = GetFormInstance(null);
                form.CustomUploaderLoadTab(true);
                form.ForceActivate();
            }
        }

        private void CustomUploaderAddDestinationTypes()
        {
            string[] enums = Helpers.GetLocalizedEnumDescriptions<CustomUploaderDestinationType>().Skip(1).Select(x => x.Replace("&", "&&")).ToArray();

            for (int i = 0; i < enums.Length; i++)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem(enums[i]);

                int index = i;

                tsmi.Click += (sender, e) =>
                {
                    ToolStripMenuItem tsmi2 = (ToolStripMenuItem)cmsCustomUploaderDestinationType.Items[index];
                    tsmi2.Checked = !tsmi2.Checked;

                    CustomUploaderItem uploader = CustomUploaderGetSelected();
                    if (uploader != null)
                    {
                        uploader.DestinationType = CustomUploaderGetDestinationType();
                    }
                };

                cmsCustomUploaderDestinationType.Items.Add(tsmi);
            }

            cmsCustomUploaderDestinationType.Closing += (sender, e) => e.Cancel = e.CloseReason == ToolStripDropDownCloseReason.ItemClicked;
        }

        private void CustomUploaderSetDestinationType(CustomUploaderDestinationType destinationType)
        {
            for (int i = 0; i < cmsCustomUploaderDestinationType.Items.Count; i++)
            {
                ToolStripMenuItem tsmi = (ToolStripMenuItem)cmsCustomUploaderDestinationType.Items[i];
                tsmi.Checked = destinationType.HasFlag(1 << i);
            }
        }

        private CustomUploaderDestinationType CustomUploaderGetDestinationType()
        {
            CustomUploaderDestinationType destinationType = CustomUploaderDestinationType.None;

            for (int i = 0; i < cmsCustomUploaderDestinationType.Items.Count; i++)
            {
                ToolStripMenuItem tsmi = (ToolStripMenuItem)cmsCustomUploaderDestinationType.Items[i];

                if (tsmi.Checked)
                {
                    destinationType |= (CustomUploaderDestinationType)(1 << i);
                }
            }

            return destinationType;
        }

        private void CustomUploaderFixSelectedUploader(int removedIndex)
        {
            int resetIndex = Config.CustomUploadersList.Count - 1;

            if (Config.CustomImageUploaderSelected == removedIndex)
            {
                Config.CustomImageUploaderSelected = resetIndex;
            }
            else if (Config.CustomImageUploaderSelected > removedIndex)
            {
                Config.CustomImageUploaderSelected--;
            }

            if (Config.CustomTextUploaderSelected == removedIndex)
            {
                Config.CustomTextUploaderSelected = resetIndex;
            }
            else if (Config.CustomTextUploaderSelected > removedIndex)
            {
                Config.CustomTextUploaderSelected--;
            }

            if (Config.CustomFileUploaderSelected == removedIndex)
            {
                Config.CustomFileUploaderSelected = resetIndex;
            }
            else if (Config.CustomFileUploaderSelected > removedIndex)
            {
                Config.CustomFileUploaderSelected--;
            }

            if (Config.CustomURLShortenerSelected == removedIndex)
            {
                Config.CustomURLShortenerSelected = resetIndex;
            }
            else if (Config.CustomURLShortenerSelected > removedIndex)
            {
                Config.CustomURLShortenerSelected--;
            }

            if (Config.CustomURLSharingServiceSelected == removedIndex)
            {
                Config.CustomURLSharingServiceSelected = resetIndex;
            }
            else if (Config.CustomURLSharingServiceSelected > removedIndex)
            {
                Config.CustomURLSharingServiceSelected--;
            }
        }

        private void CustomUploaderUpdateList()
        {
            cbCustomUploaderImageUploader.Items.Clear();
            cbCustomUploaderTextUploader.Items.Clear();
            cbCustomUploaderFileUploader.Items.Clear();
            cbCustomUploaderURLShortener.Items.Clear();
            cbCustomUploaderURLSharingService.Items.Clear();

            if (Config.CustomUploadersList.Count > 0)
            {
                foreach (CustomUploaderItem item in Config.CustomUploadersList)
                {
                    cbCustomUploaderImageUploader.Items.Add(item);
                    cbCustomUploaderTextUploader.Items.Add(item);
                    cbCustomUploaderFileUploader.Items.Add(item);
                    cbCustomUploaderURLShortener.Items.Add(item);
                    cbCustomUploaderURLSharingService.Items.Add(item);
                }

                cbCustomUploaderImageUploader.SelectedIndex = Config.CustomImageUploaderSelected.Between(0, Config.CustomUploadersList.Count - 1);
                cbCustomUploaderTextUploader.SelectedIndex = Config.CustomTextUploaderSelected.Between(0, Config.CustomUploadersList.Count - 1);
                cbCustomUploaderFileUploader.SelectedIndex = Config.CustomFileUploaderSelected.Between(0, Config.CustomUploadersList.Count - 1);
                cbCustomUploaderURLShortener.SelectedIndex = Config.CustomURLShortenerSelected.Between(0, Config.CustomUploadersList.Count - 1);
                cbCustomUploaderURLSharingService.SelectedIndex = Config.CustomURLSharingServiceSelected.Between(0, Config.CustomUploadersList.Count - 1);
            }
        }

        private async Task TestCustomUploader(CustomUploaderDestinationType type, CustomUploaderItem item)
        {
            btnCustomUploaderImageUploaderTest.Enabled = btnCustomUploaderTextUploaderTest.Enabled = btnCustomUploaderFileUploaderTest.Enabled =
                btnCustomUploaderURLShortenerTest.Enabled = btnCustomUploaderURLSharingServiceTest.Enabled = false;

            UploadResult result = null;

            txtCustomUploaderLog.ResetText();

            await Task.Run(() =>
            {
                try
                {
                    switch (type)
                    {
                        case CustomUploaderDestinationType.ImageUploader:
                            using (Stream stream = ShareXResources.Logo.GetStream())
                            {
                                CustomImageUploader imageUploader = new CustomImageUploader(item);
                                result = imageUploader.Upload(stream, "Test.png");
                                result.Errors = imageUploader.Errors;
                            }
                            break;
                        case CustomUploaderDestinationType.TextUploader:
                            CustomTextUploader textUploader = new CustomTextUploader(item);
                            result = textUploader.UploadText("ShareX text upload test", "Test.txt");
                            result.Errors = textUploader.Errors;
                            break;
                        case CustomUploaderDestinationType.FileUploader:
                            using (Stream stream = ShareXResources.Logo.GetStream())
                            {
                                CustomFileUploader fileUploader = new CustomFileUploader(item);
                                result = fileUploader.Upload(stream, "Test.png");
                                result.Errors = fileUploader.Errors;
                            }
                            break;
                        case CustomUploaderDestinationType.URLShortener:
                            CustomURLShortener urlShortener = new CustomURLShortener(item);
                            result = urlShortener.ShortenURL(Links.URL_WEBSITE);
                            result.Errors = urlShortener.Errors;
                            break;
                        case CustomUploaderDestinationType.URLSharingService:
                            CustomURLSharer urlSharer = new CustomURLSharer(item);
                            result = urlSharer.ShareURL(Links.URL_WEBSITE);
                            result.Errors = urlSharer.Errors;
                            break;
                    }
                }
                catch (Exception e)
                {
                    result = new UploadResult();
                    result.Errors.Add(e.Message);
                }
            });

            if (!IsDisposed)
            {
                if (result != null)
                {
                    if (((type == CustomUploaderDestinationType.ImageUploader || type == CustomUploaderDestinationType.TextUploader ||
                        type == CustomUploaderDestinationType.FileUploader) && !string.IsNullOrEmpty(result.URL)) ||
                        (type == CustomUploaderDestinationType.URLShortener && !string.IsNullOrEmpty(result.ShortenedURL)) ||
                        (type == CustomUploaderDestinationType.URLSharingService && !result.IsError && !string.IsNullOrEmpty(result.URL)))
                    {
                        txtCustomUploaderLog.AppendText("URL: " + result + Environment.NewLine);

                        if (!string.IsNullOrEmpty(result.ThumbnailURL))
                        {
                            txtCustomUploaderLog.AppendText("Thumbnail URL: " + result.ThumbnailURL + Environment.NewLine);
                        }

                        if (!string.IsNullOrEmpty(result.DeletionURL))
                        {
                            txtCustomUploaderLog.AppendText("Deletion URL: " + result.DeletionURL + Environment.NewLine);
                        }
                    }
                    else if (result.IsError)
                    {
                        txtCustomUploaderLog.AppendText(Resources.UploadersConfigForm_Error + ": " + result.ErrorsToString() + Environment.NewLine);
                    }
                    else
                    {
                        txtCustomUploaderLog.AppendText(Resources.UploadersConfigForm_TestCustomUploader_Error__Result_is_empty_ + Environment.NewLine);
                    }

                    txtCustomUploaderLog.ScrollToCaret();

                    btnCustomUploaderShowLastResponse.Tag = result.Response;
                    btnCustomUploaderShowLastResponse.Enabled = !string.IsNullOrEmpty(result.Response);
                }

                btnCustomUploaderImageUploaderTest.Enabled = btnCustomUploaderTextUploaderTest.Enabled = btnCustomUploaderFileUploaderTest.Enabled =
                    btnCustomUploaderURLShortenerTest.Enabled = btnCustomUploaderURLSharingServiceTest.Enabled = true;
            }
        }

        #endregion Custom uploader

        #region Jira

        public void JiraAuthOpen()
        {
            try
            {
                OAuthInfo oauth = new OAuthInfo(APIKeys.JiraConsumerKey);
                oauth.SignatureMethod = OAuthInfo.OAuthInfoSignatureMethod.RSA_SHA1;
                oauth.ConsumerPrivateKey = Jira.PrivateKey;

                string url = new Jira(Config.JiraHost, oauth).GetAuthorizationURL();

                if (!string.IsNullOrEmpty(url))
                {
                    Config.JiraOAuthInfo = oauth;
                    URLHelpers.OpenURL(url);
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        public void JiraAuthComplete(string code)
        {
            try
            {
                if (!string.IsNullOrEmpty(code) && Config.JiraOAuthInfo != null && !string.IsNullOrEmpty(Config.JiraOAuthInfo.AuthToken) && !string.IsNullOrEmpty(Config.JiraOAuthInfo.AuthSecret))
                {
                    Jira jira = new Jira(Config.JiraHost, Config.JiraOAuthInfo);
                    bool result = jira.GetAccessToken(code);

                    if (result)
                    {
                        oAuthJira.Status = OAuthLoginStatus.LoginSuccessful;
                        MessageBox.Show(Resources.UploadersConfigForm_Login_successful, "ShareX", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        oAuthJira.Status = OAuthLoginStatus.LoginFailed;
                        MessageBox.Show(Resources.UploadersConfigForm_Login_failed, "ShareX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }

        #endregion Jira

        #region Shared folder

        private void SharedFolderUpdateControls()
        {
            int selected = lbSharedFolderAccounts.SelectedIndex;

            lbSharedFolderAccounts.Items.Clear();
            cboSharedFolderImages.Items.Clear();
            cboSharedFolderText.Items.Clear();
            cboSharedFolderFiles.Items.Clear();

            if (Config.LocalhostAccountList.Count > 0)
            {
                foreach (LocalhostAccount account in Config.LocalhostAccountList)
                {
                    lbSharedFolderAccounts.Items.Add(account);
                    cboSharedFolderImages.Items.Add(account);
                    cboSharedFolderText.Items.Add(account);
                    cboSharedFolderFiles.Items.Add(account);
                }

                lbSharedFolderAccounts.SelectedIndex = selected.Between(0, Config.LocalhostAccountList.Count - 1);
                cboSharedFolderImages.SelectedIndex = Config.LocalhostSelectedImages.Between(0, Config.LocalhostAccountList.Count - 1);
                cboSharedFolderText.SelectedIndex = Config.LocalhostSelectedText.Between(0, Config.LocalhostAccountList.Count - 1);
                cboSharedFolderFiles.SelectedIndex = Config.LocalhostSelectedFiles.Between(0, Config.LocalhostAccountList.Count - 1);
            }

            SharedFolderUpdateEnabledStates();
        }

        private void SharedFolderUpdateEnabledStates()
        {
            cboSharedFolderImages.Enabled = cboSharedFolderText.Enabled = cboSharedFolderFiles.Enabled = Config.LocalhostAccountList.Count > 0;
            btnSharedFolderRemove.Enabled = btnSharedFolderDuplicate.Enabled = lbSharedFolderAccounts.SelectedIndex > -1;
        }

        private void SharedFolderAddItem(LocalhostAccount account)
        {
            Config.LocalhostAccountList.Add(account);
            lbSharedFolderAccounts.Items.Add(account);
            lbSharedFolderAccounts.SelectedIndex = lbSharedFolderAccounts.Items.Count - 1;
            SharedFolderUpdateControls();
        }

        private bool SharedFolderRemoveItem(int index)
        {
            if (index.IsBetween(0, lbSharedFolderAccounts.Items.Count - 1))
            {
                Config.LocalhostAccountList.RemoveAt(index);
                lbSharedFolderAccounts.Items.RemoveAt(index);

                if (lbSharedFolderAccounts.Items.Count > 0)
                {
                    lbSharedFolderAccounts.SelectedIndex = index == lbSharedFolderAccounts.Items.Count ? lbSharedFolderAccounts.Items.Count - 1 : index;
                    pgSharedFolderAccount.SelectedObject = lbSharedFolderAccounts.Items[lbSharedFolderAccounts.SelectedIndex];
                }
                else
                {
                    pgSharedFolderAccount.SelectedObject = null;
                }

                SharedFolderUpdateControls();

                return true;
            }

            return false;
        }

        #endregion Shared folder

        #region Generic OAuth2

        private OAuth2Info OAuth2Open(IOAuth2Basic uploader)
        {
            try
            {
                string url = uploader.GetAuthorizationURL();

                if (!string.IsNullOrEmpty(url))
                {
                    URLHelpers.OpenURL(url);
                    DebugHelper.WriteLine(uploader.ToString() + " - Authorization URL is opened: " + url);
                    return uploader.AuthInfo;
                }
                else
                {
                    DebugHelper.WriteLine(uploader.ToString() + " - Authorization URL is empty.");
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }

            return null;
        }

        private bool OAuth2Complete(IOAuth2Basic uploader, string code, OAuthControl control)
        {
            try
            {
                if (!string.IsNullOrEmpty(code) && uploader.AuthInfo != null)
                {
                    bool result = uploader.GetAccessToken(code);
                    ConfigureOAuthStatus(control, result);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }

            return false;
        }

        private bool OAuth2Refresh(IOAuth2 uploader, OAuthControl oauth2)
        {
            try
            {
                if (OAuth2Info.CheckOAuth(uploader.AuthInfo))
                {
                    bool result = uploader.RefreshAccessToken();
                    ConfigureOAuthStatus(oauth2, result);
                    return result;
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }

            return false;
        }

        private void ConfigureOAuthStatus(OAuthControl oauth2, bool result)
        {
            if (result)
            {
                oauth2.Status = OAuthLoginStatus.LoginSuccessful;
                MessageBox.Show(Resources.UploadersConfigForm_Login_successful, "ShareX", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                oauth2.Status = OAuthLoginStatus.LoginFailed;
                MessageBox.Show(Resources.UploadersConfigForm_Login_failed, "ShareX", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion Generic OAuth2
    }
}