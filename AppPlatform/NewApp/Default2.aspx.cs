using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["username"] = Request["username"];
        //Session["entername"] = Request["entername"];
        //Session["password"] = Request["password"];

        if (!IsPostBack)
        {
            #region SSO 部分代码
            SSORequest ssoRequest = new SSORequest();

            if (string.IsNullOrEmpty(Request["IASID"]))
            {
                ssoRequest.IASID = "1";
                ssoRequest.TimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                ssoRequest.AppUrl = Request.Url.ToString();
                Authentication.CreateAppToken(ssoRequest);

                Post(ssoRequest);
            }
            else if (!string.IsNullOrEmpty(Request["IASID"])
                && !string.IsNullOrEmpty(Request["TimeStamp"])
                && !string.IsNullOrEmpty(Request["AppUrl"])
                && !string.IsNullOrEmpty(Request["UserAccount"])
                && !string.IsNullOrEmpty(Request["EnterpriseId"])
                && !string.IsNullOrEmpty(Request["Authenticator"]))
            {
                ssoRequest.IASID = Request["IASID"];
                ssoRequest.TimeStamp = Request["TimeStamp"];
                ssoRequest.AppUrl = Request["AppUrl"];
                ssoRequest.UserAccount = Request["UserAccount"];
                ssoRequest.EnterpriseId = Request["EnterpriseId"];
                ssoRequest.Authenticator = Request["Authenticator"];

                if (Authentication.ValidateEACToken(ssoRequest))
                {
                    Session["CurrUserId"] = Request["UserAccount"];
                    Session["CurrEnterId"] = Request["EnterpriseId"];
                    Session.Timeout = 1;
                    FormsAuthentication.SetAuthCookie(Request["UserAccount"], false);
                    FormsAuthentication.SetAuthCookie(Request["EnterpriseId"], false);
                }
            }

            ViewState["SSORequest"] = ssoRequest;

            #endregion
        }
    }
    void Post(SSORequest ssoRequest)
    {
        PostService ps = new PostService();
        //认证中心(主站)地址
        string EACUrl = "http://localhost:25057/Account/Login";
        ps.Url = EACUrl;
        //ps.Add("UserAccount", ssoRequest.UserAccount);
        ps.Add("IASID", ssoRequest.IASID);
        ps.Add("TimeStamp", ssoRequest.TimeStamp);
        ps.Add("AppUrl", ssoRequest.AppUrl);
        ps.Add("Authenticator", ssoRequest.Authenticator);

        ps.Post();
    }
}