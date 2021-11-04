using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace Common.Utility.CryptoApi
{
    /// <summary>
    /// AES加密/解密 例子
    /// </summary>
    public class Sample
    {
        /// <summary>
        /// 运行例子
        /// </summary>
        public static void Run()
        {
            //企业后台开发者设置的token, corpID, EncodingAESKey
            string sToken = "QDG6eK";
            string sCorpID = "wx5823bf96d3bd56c7";
            string sEncodingAESKey = "jWmYm7qr5nMoAUwZRjGtBxmz3KA1tkAj3ykkR6q2B2C";

            Console.WriteLine();
            Console.WriteLine("使用示例一：验证回调URL");
            /*
			------------使用示例一：验证回调URL---------------
			*企业开启回调模式时，企业会向验证url发送一个get请求 
			假设点击验证时，企业收到类似请求：
			* GET /cgi-bin/wxpush?msg_signature=5c45ff5e21c57e6ad56bac8758b79b1d9ac89fd3&timestamp=1409659589&nonce=263014780&echostr=P9nAzaqQ%3D%3D 
			* HTTP/1.1 Host: qy.weixin.qq.com

			* 接收到该请求时，企业应			1.解析出Get请求的参数，包括消息体签名(msg_signature)，时间戳(timestamp)，随机数字串(nonce)以及推送过来的随机加密字符串(echostr),
			这一步注意作URL解码。
			2.验证消息体签名的正确性 
			3.解密出echostr原文，将原文当作Get请求的response，返回给企业
			第2，3步可以用企业提供的库函数VerifyURL来实现。
			*/
            var wxcpt = new BizMsgCrypt(sToken, sEncodingAESKey, sCorpID);
            // string sVerifyMsgSig = HttpUtils.ParseUrl("msg_signature");
            string sVerifyMsgSig = "5c45ff5e21c57e6ad56bac8758b79b1d9ac89fd3";
            // string sVerifyTimeStamp = HttpUtils.ParseUrl("timestamp");
            string sVerifyTimeStamp = "1409659589";
            // string sVerifyNonce = HttpUtils.ParseUrl("nonce");
            string sVerifyNonce = "263014780";
            // 获得的加密字符串 string sVerifyEchoStr = HttpUtils.ParseUrl("echostr");
            string sVerifyEchoStr = "P9nAzCzyDtyTWESHep1vC5X9xho/qYX3Zpb4yKa9SKld1DsH3Iyt3tP3zNdtp+4RPcs8TgAE7OaBO+FZXvnaqQ==";
            // 解密得到消息内容明文
            string sEchoStr = "";
            int ret = wxcpt.VerifyURL(sVerifyMsgSig, sVerifyTimeStamp, sVerifyNonce, sVerifyEchoStr, ref sEchoStr);
            if (ret != 0)
            {
                Console.WriteLine("ERR: VerifyURL fail, ret: " + ret);
                return;
            }
            //ret==0表示验证成功，sEchoStr参数表示明文，用户需要将sEchoStr作为get请求的返回参数，返回给企业。
            // HttpUtils.SetResponse(sEchoStr);
            Console.WriteLine($"密文: {sVerifyEchoStr}");
            Console.WriteLine($"明文: {sEchoStr}");


            Console.WriteLine();
            Console.WriteLine("使用示例二：对用户回复的消息解密");
            /*
			------------使用示例二：对用户回复的消息解密---------------
			用户回复消息或者点击事件响应时，企业会收到回调消息，此消息是经过企业加密之后的密文以post形式发送给企业，密文格式请参考官方文档
			假设企业收到企业的回调消息如下：
			POST /cgi-bin/wxpush? msg_signature=477715d11cdb4164915debcba66cb864d751f3e6&timestamp=1409659813&nonce=1372623149 HTTP/1.1
			Host: qy.weixin.qq.com
			Content-Length: 613
			<xml>			<ToUserName><![CDATA[wx5823bf96d3bd56c7]]></ToUserName><Encrypt><![CDATA[RypEvHKD8QQKFhvQ6QleEB4J58tiPdvo+rtK1I9qca6aM/wvqnLSV5zEPeusUiX5L5X/QH03v+qN+E7Q==]]></Encrypt>
			<AgentID><![CDATA[218]]></AgentID>
			</xml>

			企业收到post请求之后应该			1.解析出url上的参数，包括消息体签名(msg_signature)，时间戳(timestamp)以及随机数字串(nonce)
			2.验证消息体签名的正确性。
			3.将post请求的数据进行xml解析，并将<Encrypt>标签的内容进行解密，解密出来的明文即是用户回复消息的明文，明文格式请参考官方文档
			第2，3步可以用企业提供的库函数DecryptMsg来实现。
			*/
            // string sReqMsgSig = HttpUtils.ParseUrl("msg_signature");
            string sReqMsgSig = "477715d11cdb4164915debcba66cb864d751f3e6";
            // string sReqTimeStamp = HttpUtils.ParseUrl("timestamp");
            string sReqTimeStamp = "1409659813";
            // string sReqNonce = HttpUtils.ParseUrl("nonce");
            string sReqNonce = "1372623149";
            // Post请求的密文数据
            // string sReqData = HttpUtils.PostData();
            string sReqData = "<xml><ToUserName><![CDATA[wx5823bf96d3bd56c7]]></ToUserName><Encrypt><![CDATA[RypEvHKD8QQKFhvQ6QleEB4J58tiPdvo+rtK1I9qca6aM/wvqnLSV5zEPeusUiX5L5X/0lWfrf0QADHHhGd3QczcdCUpj911L3vg3W/sYYvuJTs3TUUkSUXxaccAS0qhxchrRYt66wiSpGLYL42aM6A8dTT+6k4aSknmPj48kzJs8qLjvd4Xgpue06DOdnLxAUHzM6+kDZ+HMZfJYuR+LtwGc2hgf5gsijff0ekUNXZiqATP7PF5mZxZ3Izoun1s4zG4LUMnvw2r+KqCKIw+3IQH03v+BCA9nMELNqbSf6tiWSrXJB3LAVGUcallcrw8V2t9EL4EhzJWrQUax5wLVMNS0+rUPA3k22Ncx4XXZS9o0MBH27Bo6BpNelZpS+/uh9KsNlY6bHCmJU9p8g7m3fVKn28H3KDYA5Pl/T8Z1ptDAVe0lXdQ2YoyyH2uyPIGHBZZIs2pDBS8R07+qN+E7Q==]]></Encrypt><AgentID><![CDATA[218]]></AgentID></xml>";
            string sMsg = "";  // 解析之后的明文
            ret = wxcpt.DecryptMsg(sReqMsgSig, sReqTimeStamp, sReqNonce, sReqData, ref sMsg);
            if (ret != 0)
            {
                Console.WriteLine("ERR: Decrypt Fail, ret: " + ret);
                return;
            }
            // ret==0表示解密成功，sMsg表示解密之后的明文xml串
            // TODO: 对明文的处理
            // For example:
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sMsg);
            XmlNode root = doc.FirstChild;
            string content = root["Content"].InnerText;
            Console.WriteLine($"ToUser消息解密结果:\n {content}");


            Console.WriteLine();
            Console.WriteLine("使用示例三：企业回复用户消息的加密");
            /*
			------------使用示例三：企业回复用户消息的加密---------------
			企业被动回复用户的消息也需要进行加密，并且拼接成密文格式的xml串。
			假设企业需要回复用户的明文如下：
			<xml>
			<ToUserName><![CDATA[mycreate]]></ToUserName>
			<FromUserName><![CDATA[wx5823bf96d3bd56c7]]></FromUserName>
			<CreateTime>1348831860</CreateTime>
			<MsgType><![CDATA[text]]></MsgType>
			<Content><![CDATA[this is a test]]></Content>
			<MsgId>1234567890123456</MsgId>
			<AgentID>128</AgentID>
			</xml>

			为了将此段明文回复给用户，企业应：			1.自己生成时间时间戳(timestamp),随机数字串(nonce)以便生成消息体签名，也可以直接用从企业的post url上解析出的对应值。
			2.将明文加密得到密文。	3.用密文，步骤1生成的timestamp,nonce和企业在企业设定的token生成消息体签名。			4.将密文，消息体签名，时间戳，随机数字串拼接成xml格式的字符串，发送给企业。
			以上2，3，4步可以用企业提供的库函数EncryptMsg来实现。
			*/
            // 需要发送的明文
            string sRespData = "<xml><ToUserName><![CDATA[mycreate]]></ToUserName><FromUserName><![CDATA[wx582396d3bd56c7]]></FromUserName><CreateTime>1348831860</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[this is a test]]></Content><MsgId>1234567890123456</MsgId><AgentID>128</AgentID></xml>";
            string sEncryptMsg = ""; //xml格式的密文
            ret = wxcpt.EncryptMsg(sRespData, sReqTimeStamp, sReqNonce, ref sEncryptMsg);
            if (ret != 0)
            {
                Console.WriteLine("ERR: EncryptMsg Fail, ret: " + ret);
                return;
            }
            // TODO:
            // 加密成功，企业需要将加密之后的sEncryptMsg返回
            // HttpUtils.SetResponse(sEncryptMsg);
            Console.WriteLine($"ToUser消息加密结果:\n {sEncryptMsg}");
        }
    }


    /// <summary>
    /// 加密签名/验证签名/异常处理
    ///-40001 :  签名验证错误
    ///-40002 :  xml解析失败
    ///-40003 :  sha加密生成签名失败
    ///-40004 :  AESKey 非法
    ///-40005 :  corpid 校验错误
    ///-40006 :  AES 加密失败
    ///-40007 :  AES 解密失败
    ///-40008 :  解密后得到的buffer非法
    ///-40009 :  base64加密异常
    ///-40010 :  base64解密异常
    /// </summary>
    public class BizMsgCrypt
    {
        readonly string m_sToken;
        string m_sEncodingAESKey;
        readonly string m_sReceiveId;

        /// <summary>
        /// 异常处理
        /// </summary>
        enum BizMsgCryptErrorCode
        {
            BizMsgCrypt_OK = 0,
            BizMsgCrypt_ValidateSignature_Error = -40001,
            BizMsgCrypt_ParseXml_Error = -40002,
            BizMsgCrypt_ComputeSignature_Error = -40003,
            BizMsgCrypt_IllegalAesKey = -40004,
            BizMsgCrypt_ValidateCorpid_Error = -40005,
            BizMsgCrypt_EncryptAES_Error = -40006,
            BizMsgCrypt_DecryptAES_Error = -40007,
            BizMsgCrypt_IllegalBuffer = -40008,
            BizMsgCrypt_EncodeBase64_Error = -40009,
            BizMsgCrypt_DecodeBase64_Error = -40010
        };

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sToken">开发者设置的Token</param>
        /// <param name="sEncodingAESKey">开发者设置的EncodingAESKey</param>
        /// <param name="sReceiveId">不同场景含义不同，详见文档说明</param>
        public BizMsgCrypt(string sToken, string sEncodingAESKey, string sReceiveId)
        {
            m_sToken = sToken;
            m_sReceiveId = sReceiveId;
            m_sEncodingAESKey = sEncodingAESKey;
        }

        /// <summary>
        /// 验证URL
        /// </summary>
        /// <param name="sMsgSignature">签名串，对应URL参数的msg_signature</param>
        /// <param name="sTimeStamp">时间戳，对应URL参数的timestamp</param>
        /// <param name="sNonce">随机串，对应URL参数的nonce</param>
        /// <param name="sEchoStr">随机串，对应URL参数的echostr</param>
        /// <param name="sReplyEchoStr">解密之后的echostr，当return返回0时有效</param>
        /// <returns>成功0，失败返回对应的错误码</returns>
        public int VerifyURL(string sMsgSignature, string sTimeStamp, string sNonce, string sEchoStr, ref string sReplyEchoStr)
        {
            int ret = 0;
            if (m_sEncodingAESKey.Length != 43)
                return (int)BizMsgCryptErrorCode.BizMsgCrypt_IllegalAesKey;
            ret = VerifySignature(m_sToken, sTimeStamp, sNonce, sEchoStr, sMsgSignature);
            if (0 != ret)
                return ret;
            sReplyEchoStr = "";
            string sReceiveId = "";
            try
            {
                sReplyEchoStr = CryptoAES.Decrypt(sEchoStr, m_sEncodingAESKey, ref sReceiveId); //m_sReceiveId
            }
            catch (Exception)
            {
                sReplyEchoStr = "";
                ret = (int)BizMsgCryptErrorCode.BizMsgCrypt_DecryptAES_Error;
            }
            if (sReceiveId != m_sReceiveId)
            {
                sReplyEchoStr = "";
                ret = (int)BizMsgCryptErrorCode.BizMsgCrypt_ValidateCorpid_Error;
            }
            return ret;
        }

        /// <summary>
        /// 检验消息的真实性，并且获取解密后的明文
        /// </summary>
        /// <param name="sMsgSignature">签名串，对应URL参数的msg_signature</param>
        /// <param name="sTimeStamp">时间戳，对应URL参数的timestamp</param>
        /// <param name="sNonce">随机串，对应URL参数的nonce</param>
        /// <param name="sPostData">密文，对应POST请求的数据</param>
        /// <param name="sMsg">解密后的原文，当return返回0时有效</param>
        /// <returns>成功0，失败返回对应的错误码</returns>
        public int DecryptMsg(string sMsgSignature, string sTimeStamp, string sNonce, string sPostData, ref string sMsg)
        {
            if (m_sEncodingAESKey.Length != 43)
                return (int)BizMsgCryptErrorCode.BizMsgCrypt_IllegalAesKey;
            XmlDocument doc = new XmlDocument();
            XmlNode root;
            string sEncryptMsg;
            try
            {
                doc.LoadXml(sPostData);
                root = doc.FirstChild;
                sEncryptMsg = root["Encrypt"].InnerText;
            }
            catch (Exception)
            {
                return (int)BizMsgCryptErrorCode.BizMsgCrypt_ParseXml_Error;
            }
            //verify signature
            int ret = VerifySignature(m_sToken, sTimeStamp, sNonce, sEncryptMsg, sMsgSignature);
            if (ret != 0)
                return ret;
            //decrypt
            string sReceiveId = "";
            try
            {
                sMsg = CryptoAES.Decrypt(sEncryptMsg, m_sEncodingAESKey, ref sReceiveId);
            }
            catch (FormatException)
            {
                sMsg = "";
                ret = (int)BizMsgCryptErrorCode.BizMsgCrypt_DecodeBase64_Error;
            }
            catch (Exception)
            {
                sMsg = "";
                ret = (int)BizMsgCryptErrorCode.BizMsgCrypt_DecryptAES_Error;
            }
            return sReceiveId == m_sReceiveId ? ret : (int)BizMsgCryptErrorCode.BizMsgCrypt_ValidateCorpid_Error;
        }

        /// <summary>
        /// 将企业号回复用户的消息加密打包
        /// </summary>
        /// <param name="sReplyMsg">企业号待回复用户的消息，xml格式的字符串</param>
        /// <param name="sTimeStamp">时间戳，可以自己生成，也可以用URL参数的timestamp</param>
        /// <param name="sNonce">随机串，可以自己生成，也可以用URL参数的nonce</param>
        /// <param name="sEncryptMsg">加密后的可以直接回复用户的密文，包括msg_signature, timestamp, nonce, encrypt的xml格式的字符串,当return返回0时有效</param>
        /// <returns>成功0，失败返回对应的错误码</returns>
        public int EncryptMsg(string sReplyMsg, string sTimeStamp, string sNonce, ref string sEncryptMsg)
        {
            if (m_sEncodingAESKey.Length != 43)
                return (int)BizMsgCryptErrorCode.BizMsgCrypt_IllegalAesKey;
            string raw = "";
            try
            {
                raw = CryptoAES.Encrypt(sReplyMsg, m_sEncodingAESKey, m_sReceiveId);
            }
            catch (Exception)
            {
                return (int)BizMsgCryptErrorCode.BizMsgCrypt_EncryptAES_Error;
            }
            int ret = GenarateSinature(m_sToken, sTimeStamp, sNonce, raw, out string MsgSigature);
            if (0 != ret)
                return ret;
            sEncryptMsg = "";
            string EncryptLabelHead = "<Encrypt><![CDATA[";
            string EncryptLabelTail = "]]></Encrypt>";
            string MsgSigLabelHead = "<MsgSignature><![CDATA[";
            string MsgSigLabelTail = "]]></MsgSignature>";
            string TimeStampLabelHead = "<TimeStamp><![CDATA[";
            string TimeStampLabelTail = "]]></TimeStamp>";
            string NonceLabelHead = "<Nonce><![CDATA[";
            string NonceLabelTail = "]]></Nonce>";
            sEncryptMsg = sEncryptMsg + "<xml>" + EncryptLabelHead + raw + EncryptLabelTail;
            sEncryptMsg = sEncryptMsg + MsgSigLabelHead + MsgSigature + MsgSigLabelTail;
            sEncryptMsg = sEncryptMsg + TimeStampLabelHead + sTimeStamp + TimeStampLabelTail;
            sEncryptMsg = sEncryptMsg + NonceLabelHead + sNonce + NonceLabelTail;
            sEncryptMsg += "</xml>";
            return 0;
        }

        class ALComparer : IComparer<string>
        {
            public int Compare(string sLeft, string sRight)
            {
                int index = 0, iLeftLength = sLeft.Length, iRightLength = sRight.Length;
                while (index < iLeftLength && index < iRightLength)
                {
                    if (sLeft[index] < sRight[index])
                        return -1;
                    else if (sLeft[index] > sRight[index])
                        return 1;
                    else
                        index++;
                }
                return iLeftLength - iRightLength;
            }
        }

        private static int VerifySignature(string sToken, string sTimeStamp, string sNonce, string sMsgEncrypt, string sSigture)
        {
            int ret = GenarateSinature(sToken, sTimeStamp, sNonce, sMsgEncrypt, out string hash);
            return ret != 0 ? ret : hash == sSigture ? 0 : (int)BizMsgCryptErrorCode.BizMsgCrypt_ValidateSignature_Error;
        }

        public static int GenarateSinature(string sToken, string sTimeStamp, string sNonce, string sMsgEncrypt, out string sMsgSignature)
        {
            var AL = new List<string>
            {
                sToken,
                sTimeStamp,
                sNonce,
                sMsgEncrypt
            };
            AL.Sort(new ALComparer());
            string raw = "";
            for (int i = 0; i < AL.Count; ++i)
                raw += AL[i];
            string hash = "";
            try
            {
                SHA1 sha = new SHA1CryptoServiceProvider();
                ASCIIEncoding enc = new ASCIIEncoding();
                byte[] dataToHash = enc.GetBytes(raw);
                byte[] dataHashed = sha.ComputeHash(dataToHash);
                hash = BitConverter.ToString(dataHashed).Replace("-", "");
                hash = hash.ToLower();
            }
            catch (Exception)
            {
                sMsgSignature = hash;
                return (int)BizMsgCryptErrorCode.BizMsgCrypt_ComputeSignature_Error;
            }
            sMsgSignature = hash;
            return 0;
        }
    }


    /// <summary>
    /// 加密/解密 方法
    /// </summary>
    public class CryptoAES
    {
        public static UInt32 HostToNetworkOrder(UInt32 inval)
        {
            UInt32 outval = 0;
            for (int i = 0; i < 4; i++)
                outval = (outval << 8) + ((inval >> (i * 8)) & 255);
            return outval;
        }

        public static Int32 HostToNetworkOrder(Int32 inval)
        {
            Int32 outval = 0;
            for (int i = 0; i < 4; i++)
                outval = (outval << 8) + ((inval >> (i * 8)) & 255);
            return outval;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Input">密文</param>
        /// <param name="EncodingAESKey"></param>
        /// <returns></returns>
        public static string Decrypt(String Input, string EncodingAESKey, ref string corpid)
        {
            byte[] Key;
            Key = Convert.FromBase64String(EncodingAESKey + "=");
            byte[] Iv = new byte[16];
            Array.Copy(Key, Iv, 16);
            byte[] btmpMsg = AES_decrypt(Input, Iv, Key);

            int len = BitConverter.ToInt32(btmpMsg, 16);
            len = IPAddress.NetworkToHostOrder(len);


            byte[] bMsg = new byte[len];
            byte[] bCorpid = new byte[btmpMsg.Length - 20 - len];
            Array.Copy(btmpMsg, 20, bMsg, 0, len);
            Array.Copy(btmpMsg, 20 + len, bCorpid, 0, btmpMsg.Length - 20 - len);
            string oriMsg = Encoding.UTF8.GetString(bMsg);
            corpid = Encoding.UTF8.GetString(bCorpid);


            return oriMsg;
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Input">明文</param>
        /// <param name="EncodingAESKey"></param>
        /// <returns></returns>
        public static String Encrypt(String Input, string EncodingAESKey, string corpid)
        {
            byte[] Key;
            Key = Convert.FromBase64String(EncodingAESKey + "=");
            byte[] Iv = new byte[16];
            Array.Copy(Key, Iv, 16);
            string Randcode = CreateRandCode(16);
            byte[] bRand = Encoding.UTF8.GetBytes(Randcode);
            byte[] bCorpid = Encoding.UTF8.GetBytes(corpid);
            byte[] btmpMsg = Encoding.UTF8.GetBytes(Input);
            byte[] bMsgLen = BitConverter.GetBytes(HostToNetworkOrder(btmpMsg.Length));
            byte[] bMsg = new byte[bRand.Length + bMsgLen.Length + bCorpid.Length + btmpMsg.Length];

            Array.Copy(bRand, bMsg, bRand.Length);
            Array.Copy(bMsgLen, 0, bMsg, bRand.Length, bMsgLen.Length);
            Array.Copy(btmpMsg, 0, bMsg, bRand.Length + bMsgLen.Length, btmpMsg.Length);
            Array.Copy(bCorpid, 0, bMsg, bRand.Length + bMsgLen.Length + btmpMsg.Length, bCorpid.Length);

            return AES_encrypt(bMsg, Iv, Key);

        }

        private static string CreateRandCode(int codeLen)
        {
            string codeSerial = "2,3,4,5,6,7,a,c,d,e,f,h,i,j,k,m,n,p,r,s,t,A,C,D,E,F,G,H,J,K,M,N,P,Q,R,S,U,V,W,X,Y,Z";
            if (codeLen == 0)
            {
                codeLen = 16;
            }
            string[] arr = codeSerial.Split(',');
            string code = "";
            int randValue = -1;
            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
            for (int i = 0; i < codeLen; i++)
            {
                randValue = rand.Next(0, arr.Length - 1);
                code += arr[randValue];
            }
            return code;
        }

        private static String AES_encrypt(String Input, byte[] Iv, byte[] Key)
        {
            var aes = new RijndaelManaged();
            //秘钥的大小，以位为单位
            aes.KeySize = 256;
            //支持的块大小
            aes.BlockSize = 128;
            //填充模式
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.CBC;
            aes.Key = Key;
            aes.IV = Iv;
            var encrypt = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] xBuff = null;

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encrypt, CryptoStreamMode.Write))
                {
                    byte[] xXml = Encoding.UTF8.GetBytes(Input);
                    cs.Write(xXml, 0, xXml.Length);
                }
                xBuff = ms.ToArray();
            }
            String Output = Convert.ToBase64String(xBuff);
            return Output;
        }

        private static String AES_encrypt(byte[] Input, byte[] Iv, byte[] Key)
        {
            var aes = new RijndaelManaged();
            //秘钥的大小，以位为单位
            aes.KeySize = 256;
            //支持的块大小
            aes.BlockSize = 128;
            //填充模式
            //aes.Padding = PaddingMode.PKCS7;
            aes.Padding = PaddingMode.None;
            aes.Mode = CipherMode.CBC;
            aes.Key = Key;
            aes.IV = Iv;
            var encrypt = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] xBuff = null;

            #region 自己进行PKCS7补位，用系统自己带的不行
            byte[] msg = new byte[Input.Length + 32 - Input.Length % 32];
            Array.Copy(Input, msg, Input.Length);
            byte[] pad = KCS7Encoder(Input.Length);
            Array.Copy(pad, 0, msg, Input.Length, pad.Length);
            #endregion

            #region 注释的也是一种方法，效果一样
            //ICryptoTransform transform = aes.CreateEncryptor();
            //byte[] xBuff = transform.TransformFinalBlock(msg, 0, msg.Length);
            #endregion

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encrypt, CryptoStreamMode.Write))
                {
                    cs.Write(msg, 0, msg.Length);
                }
                xBuff = ms.ToArray();
            }

            String Output = Convert.ToBase64String(xBuff);
            return Output;
        }

        private static byte[] KCS7Encoder(int text_length)
        {
            int block_size = 32;
            // 计算需要填充的位数
            int amount_to_pad = block_size - (text_length % block_size);
            if (amount_to_pad == 0)
            {
                amount_to_pad = block_size;
            }
            // 获得补位所用的字符
            char pad_chr = Chr(amount_to_pad);
            string tmp = "";
            for (int index = 0; index < amount_to_pad; index++)
            {
                tmp += pad_chr;
            }
            return Encoding.UTF8.GetBytes(tmp);
        }
        /**
         * 将数字转化成ASCII码对应的字符，用于对明文进行补码
         * 
         * @param a 需要转化的数字
         * @return 转化得到的字符
         */
        static char Chr(int a)
        {

            byte target = (byte)(a & 0xFF);
            return (char)target;
        }
        private static byte[] AES_decrypt(String Input, byte[] Iv, byte[] Key)
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.None;
            aes.Key = Key;
            aes.IV = Iv;
            var decrypt = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] xBuff = null;
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, decrypt, CryptoStreamMode.Write))
                {
                    byte[] xXml = Convert.FromBase64String(Input);
                    byte[] msg = new byte[xXml.Length + 32 - xXml.Length % 32];
                    Array.Copy(xXml, msg, xXml.Length);
                    cs.Write(xXml, 0, xXml.Length);
                }
                xBuff = Decode2(ms.ToArray());
            }
            return xBuff;
        }
        private static byte[] Decode2(byte[] decrypted)
        {
            int pad = (int)decrypted[decrypted.Length - 1];
            if (pad < 1 || pad > 32)
            {
                pad = 0;
            }
            byte[] res = new byte[decrypted.Length - pad];
            Array.Copy(decrypted, 0, res, 0, decrypted.Length - pad);
            return res;
        }
    }
}
