using Aspose.Email;
using Aspose.Email.Mail;
using System;
using System.Reflection;
using System.Text;

namespace Common.Utility
{
    /// <summary>
    /// 发送邮件 - 阿里云
    /// </summary>
    public class Mail_Aliyun
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <returns>【状态：0成功，1异常；返回信息】</returns>
        public Tuple<int, string> Send(string email, string subject, string content, string[] files, Mail_Account config)
        {
            Tuple<int, string> res = new Tuple<int, string>(1, "发送异常");
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(content)) return res;

            //string regionId = config["regionId"];
            //string accessKeyId = config["accessKeyId"];
            //string secret = config["secret"];

            //IClientProfile profile = DefaultProfile.GetProfile(regionId, accessKeyId, secret);
            //IAcsClient client = new DefaultAcsClient(profile);
            //SingleSendMailRequest request = new SingleSendMailRequest();
            try
            {
                //request.AccountName = config["AccountName"];
                //request.FromAlias = config["FromAlias"];
                //request.AddressType = 1;
                //request.TagName = config["TagName"];
                //request.ReplyToAddress = false;
                //request.ToAddress = email;
                //request.Subject = subject;
                //request.HtmlBody = content;
                //request.ContentType = Aliyun.Acs.Core.Http.FormatType.RAW;
                //SingleSendMailResponse httpResponse = client.GetAcsResponse(request);
                //res = new Tuple<int, string>(0, "发送成功，流水号为:" + httpResponse.RequestId);

                Aspose.Email.Mail.ClientLicense.RunOnce();
                using (SmtpClient client = new SmtpClient(config.Host, config.Post, config.AccountName, config.Password))
                {
                    client.SecurityOptions = SecurityOptions.Auto;
                    MailMessage message = new MailMessage();
                    message.Date = DateTime.Now;
                    message.Priority = MailPriority.High;
                    message.Sensitivity = MailSensitivity.Normal;
                    message.From = config.AccountName;
                    foreach (string reply in config.ReplyTo)
                    {
                        message.ReplyToList.Add(new MailAddress(reply));
                    }
                    message.To.Add(email);
                    message.Subject = subject;
                    message.HtmlBody = content;
                    foreach (string file in files)
                    {
                        message.AddAttachment(new Attachment(file));
                    }
                    client.Send(message);
                }
                res = new Tuple<int, string>(0, "发送成功");
            }
            //catch (ServerException e)
            //{
            //    res = new Tuple<int, string>(1, e.Message);
            //}
            //catch (ClientException e)
            //{
            //    res = new Tuple<int, string>(1, e.Message);
            //}
            catch (Exception e)
            {
                res = new Tuple<int, string>(1, e.Message);
            }
            return res;
        }
        
        
        /// <summary>
        /// 邮件发送
        /// </summary>
        /// <param name="EPSModel">参数</param>
        /// <returns></returns>
        public static bool Send(EmailParameterSet EPSModel)
        {
            try
            {
                // License For Aspose.Email
                ClientLicense.RunOnce();

                // 配置发送邮件的账号、服务器地址
                using (SmtpClient client = new SmtpClient(EPSModel.SendSetSmtp, 587, EPSModel.SendEmail, EPSModel.SendPwd))
                {
                    // 服务器认证
                    //client.AuthenticationMethod = SmtpAuthentication.Auto;
                    //client.UseDefaultCredentials = true;
                    client.SecurityOptions = SecurityOptions.Auto;

                    // 邮件信息
                    MailMessage message = new MailMessage();
                    Encoding encoding = Encoding.UTF8;
                    message.Date = DateTime.Now;
                    message.BodyEncoding = encoding;
                    message.SubjectEncoding = encoding;
                    message.Priority = MailPriority.High;
                    message.Sensitivity = MailSensitivity.Normal;

                    // 发件人
                    message.From = new MailAddress(EPSModel.SendEmail, "发件人姓名", encoding);
                    // 收件人
                    message.To.Add(new MailAddress(EPSModel.ConsigneeAddress, EPSModel.ConsigneeName, encoding));
                    // 回复列表
                    //message.ReplyToList.Add(new MailAddress(reply));

                    // 标题
                    message.Subject = EPSModel.ConsigneeTheme;
                    // 内容
                    message.IsBodyHtml = EPSModel.IsBodyHtml;
                    message.HtmlBody = EPSModel.SendContent;
                    //message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(EPSModel.SendContent, null, "text/html"));

                    // 附件
                    //message.AddAttachment(new Attachment(file));

                    client.Send(message);
                }
                return true;//发送成功
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        
    }
    
    public class EmailParameterSet
    {
        /// <summary>
        /// 收件人的邮件地址 
        /// </summary>
        public string ConsigneeAddress { get; set; }

        /// <summary>
        /// 收件人的名称
        /// </summary>
        public string ConsigneeName { get; set; }

        /// <summary>
        /// 收件人标题
        /// </summary>
        public string ConsigneeHand { get; set; }

        /// <summary>
        /// 收件人的主题
        /// </summary>
        public string ConsigneeTheme { get; set; }

        /// <summary>
        /// 发件邮件服务器的Smtp设置
        /// </summary>
        public string SendSetSmtp { get; set; }

        /// <summary>
        /// 发件人的邮件
        /// </summary>
        public string SendEmail { get; set; }

        /// <summary>
        /// 发件人的邮件密码
        /// </summary>
        public string SendPwd { get; set; }

        /// <summary>
        /// 发件内容
        /// </summary>
        public string SendContent { get; set; }

        /// <summary>
        /// 获取或者设置指定邮件正文是否为html
        /// </summary>
        public bool IsBodyHtml { get; set; }
    }
    
}

/// <summary>
/// 发送邮件 - 账户配置
/// </summary>
public class Mail_Account
{
    /// <summary>
    /// 主机IP
    /// </summary>
    public string Host { get; set; }
    /// <summary>
    /// 端口号
    /// </summary>
    public int Post { get; set; }
    /// <summary>
    /// 账户名
    /// </summary>
    public string AccountName { get; set; }
    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; }
    /// <summary>
    /// 回复列表
    /// </summary>
    public string[] ReplyTo { get; set; }
}

#region License For Aspose.Email -Version 6.1.0 
namespace Aspose.Email.Mail
{
    public sealed class ClientLicense
    {
        private static bool _licensed = false;
        private static object _lock = new object();
        /// <summary>
        /// License For Aspose.Email -Version 6.1.0 
        /// </summary>
        public static void RunOnce()
        {
            if (_licensed) return;

            lock (_lock)
            {
                if (_licensed) return;

                string name = Assembly.CreateQualifiedName(typeof(Aspose.Email.License).Assembly.FullName, "\u0008\u2002\u2005");
                Type licType = Type.GetType(name, false, false);
                if (licType == null)
                {
                    throw new NotSupportedException("Unsupported version of Aspose.Email");
                }
                object lic = Activator.CreateInstance(licType);
                int findCount = 0;
                foreach (FieldInfo field in licType.GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance))
                {
                    if (field.FieldType == typeof(int) && field.Name == "\u0002")
                    {
                        field.SetValue(lic, (int)256);
                        ++findCount;
                    }
                    else if (field.FieldType.Name == "\u0002\u2000" && field.Name == "\u0008")
                    {
                        field.SetValue(lic, (int)1);
                        ++findCount;
                    }
                    else if (field.FieldType.Name == "\u0006\u2002\u2005" && field.Name == "\u0002\u2000")
                    {
                        field.SetValue(lic, (int)1);
                        ++findCount;
                    }
                    else if (field.FieldType.Name == "\u0008\u2002\u2005" && field.Name == "\u0005\u2000")
                    {
                        field.SetValue(null, lic);
                        ++findCount;
                    }
                }
                if (findCount < 4)
                {
                    //throw new NotSupportedException("Unsupported version of Aspose.Email");
                }
                _licensed = true;
            }
        }
    }
}
#endregion
