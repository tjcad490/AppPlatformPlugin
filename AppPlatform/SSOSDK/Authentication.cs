using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Text;

public class Authentication
{
    static readonly string cookieName = "EACToken";
    static readonly string hashSplitter = "|";

    public Authentication()
    {
    }

    public static string GetAppKey(int appID)
    {
        //string cmdText = @"select * from ";
        return string.Empty;
    }

    public static string GetAppKey()
    {
        return "22362E7A9285DD53A0BBC2932F9733C505DC04EDBFE00D70";
    }

    public static string GetAppIV()
    {
        return "1E7FA9231E7FA923";
    }

    /// <summary>
    /// 取得加密服务
    /// </summary>
    /// <returns></returns>
    static CryptoService GetCryptoService()
    {
        string key = GetAppKey();
        string IV = GetAppIV();

        CryptoService cs = new CryptoService(key, IV);
        return cs;
    }

    /// <summary>
    /// 创建各分站发往认证中心的 Token
    /// </summary>
    /// <param name="ssoRequest"></param>
    /// <returns></returns>
    public static bool CreateAppToken(SSORequest ssoRequest)
    {
        string OriginalAuthenticator = ssoRequest.IASID + ssoRequest.TimeStamp + ssoRequest.AppUrl;
        string AuthenticatorDigest = CryptoHelper.ComputeHashString(OriginalAuthenticator);
        string sToEncrypt = OriginalAuthenticator + AuthenticatorDigest;
        byte[] bToEncrypt = CryptoHelper.ConvertStringToByteArray(sToEncrypt);

        CryptoService cs = GetCryptoService();

        byte[] encrypted;

        if (cs.Encrypt(bToEncrypt, out encrypted))
        {
            ssoRequest.Authenticator = CryptoHelper.ToBase64String(encrypted);

            return true;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// 验证从各分站发送过来的 Token
    /// </summary>
    /// <param name="ssoRequest"></param>
    /// <returns></returns>
    public static bool ValidateAppToken(SSORequest ssoRequest)
    {
        string Authenticator = ssoRequest.Authenticator;

        string OriginalAuthenticator = ssoRequest.IASID + ssoRequest.TimeStamp + ssoRequest.AppUrl;
        string AuthenticatorDigest = CryptoHelper.ComputeHashString(OriginalAuthenticator);
        string sToEncrypt = OriginalAuthenticator + AuthenticatorDigest;
        byte[] bToEncrypt = CryptoHelper.ConvertStringToByteArray(sToEncrypt);

        CryptoService cs = GetCryptoService();
        byte[] encrypted;

        if (cs.Encrypt(bToEncrypt, out encrypted))
        {
            return Authenticator == CryptoHelper.ToBase64String(encrypted);
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// 创建认证中心发往各分站的 Token
    /// </summary>
    /// <param name="ssoRequest"></param>
    /// <returns></returns>
    public static bool CreateEACToken(SSORequest ssoRequest)
    {
        string OriginalAuthenticator = ssoRequest.UserAccount+ssoRequest.EnterpriseId + ssoRequest.IASID + ssoRequest.TimeStamp + ssoRequest.AppUrl;
        string AuthenticatorDigest = CryptoHelper.ComputeHashString(OriginalAuthenticator);
        string sToEncrypt = OriginalAuthenticator + AuthenticatorDigest;
        byte[] bToEncrypt = CryptoHelper.ConvertStringToByteArray(sToEncrypt);

        CryptoService cs = GetCryptoService();
        byte[] encrypted;

        if (cs.Encrypt(bToEncrypt, out encrypted))
        {
            ssoRequest.Authenticator = CryptoHelper.ToBase64String(encrypted);

            return true;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// 验证从认证中心发送过来的 Token
    /// </summary>
    /// <param name="ssoRequest"></param>
    /// <returns></returns>
    public static bool ValidateEACToken(SSORequest ssoRequest)
    {
        string Authenticator = ssoRequest.Authenticator;

        string OriginalAuthenticator = ssoRequest.UserAccount +ssoRequest.EnterpriseId+ ssoRequest.IASID + ssoRequest.TimeStamp + ssoRequest.AppUrl;
        string AuthenticatorDigest = CryptoHelper.ComputeHashString(OriginalAuthenticator);
        string sToEncrypt = OriginalAuthenticator + AuthenticatorDigest;
        byte[] bToEncrypt = CryptoHelper.ConvertStringToByteArray(sToEncrypt);

        string EncryCurrentAuthenticator = string.Empty;
        CryptoService cs = GetCryptoService();
        byte[] encrypted;

        if (cs.Encrypt(bToEncrypt, out encrypted))
        {
            EncryCurrentAuthenticator = CryptoHelper.ToBase64String(encrypted);

            return Authenticator == EncryCurrentAuthenticator;
        }
        else
        {
            return false;
        }
    }


    /// <summary>
    /// 创建 EAC 认证中心的 Cookie
    /// </summary>
    /// <param name="userAccount"></param>
    /// <param name="timeStamp"></param>
    /// <param name="expireTime"></param>
    /// <param name="cookieValue"></param>
    /// <returns></returns>
    public static bool CreatEACCookie(string userAccount,string EnterpriseId, string timeStamp, string expireTime)
    {
        string plainText = "UserAccount=" + userAccount +";EnterpriseId="+EnterpriseId+ ";TimeStamp=" + timeStamp + ";ExpireTime=" + expireTime;
        plainText += hashSplitter + CryptoHelper.ComputeHashString(plainText);

        CryptoService cs = GetCryptoService();
        byte[] encrypted;

        if (cs.Encrypt(CryptoHelper.ConvertStringToByteArray(plainText), out encrypted))
        {
            string cookieValue = CryptoHelper.ToBase64String(encrypted);
            SetCookie(cookieValue);

            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 验证 EAC 认证中心的 Cookie，验证通过时获取用户登录账号
    /// </summary>
    /// <param name="userAccount">输出用户登录账号</param>
    /// <returns></returns>
    public static bool ValidateEACCookie(out string userAccount,out string EnterpriseId)
    {
        userAccount = string.Empty;
        EnterpriseId = string.Empty;
        try
        {

            string cookieValue = GetCookie().Value;
            byte[] toDecrypt = CryptoHelper.FromBase64String(cookieValue);
            CryptoService cs = GetCryptoService();

            string decrypted = string.Empty;
            if (cs.Decrypt(toDecrypt, out decrypted))
            {

                string[] arrTemp = decrypted.Split(Convert.ToChar(hashSplitter));
                string plainText = arrTemp[0];
                string hashedText = arrTemp[1];

                userAccount = plainText.Split(Convert.ToChar(";"))[0].Split(Convert.ToChar("="))[1];
                EnterpriseId = plainText.Split(Convert.ToChar(";"))[1].Split(Convert.ToChar("="))[1];
                return hashedText.Replace("\0", string.Empty) == CryptoHelper.ComputeHashString(plainText);

            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
    }


    public static void Logout()
    {
        HttpContext.Current.Response.Cookies[cookieName].Expires = DateTime.Parse("1900-1-1");
        HttpContext.Current.Response.Cookies[cookieName].Path = "/";
    }

    private static void SetCookie(string cookieValue)
    {
        HttpContext.Current.Response.Cookies[cookieName].Value = cookieValue;
        HttpContext.Current.Response.Cookies[cookieName].Expires = DateTime.Now.AddHours(24);
        HttpContext.Current.Response.Cookies[cookieName].Path = "/";
    }

    private static HttpCookie GetCookie()
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies["EACToken"];
        return cookie;
    }
}
