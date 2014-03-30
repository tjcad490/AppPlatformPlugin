using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

[Serializable]
public class SSORequest : MarshalByRefObject
{
    public string IASID;         //各独立站点标识ID
    public string TimeStamp;     //时间戳
    public string AppUrl;        //各独立站点的访问地址
    public string Authenticator; //各独立站点的 Token

    public string UserAccount;   //账号
    public string EnterpriseId;
    public string Password;      //密码

    public string IPAddress;     //IP地址

    //为ssresponse对象做准备
    public string ErrorDescription = "认证失败";   //用户认证通过,认证失败,包数据格式不正确,数据校验不正确
    public int Result = -1;

    public SSORequest()
    {

    }


    /// <summary>
    /// 获取当前页面上的SSORequest对象
    /// </summary>
    /// <param name="CurrentPage"></param>
    /// <returns></returns>
    public static SSORequest GetRequest(Page CurrentPage)
    {
        SSORequest request = new SSORequest();
        request.IPAddress = CurrentPage.Request.UserHostAddress;
        request.IASID = CurrentPage.Request["IASID"].ToString();// Request本身会Decode
        request.UserAccount = CurrentPage.Request["UserAccount"].ToString();//this.Text
        request.EnterpriseId = CurrentPage.Request["EnterpriseId"].ToString();
        request.Password = CurrentPage.Request["Password"].ToString();
        request.AppUrl = CurrentPage.Request["AppUrl"].ToString();
        request.Authenticator = CurrentPage.Request["Authenticator"].ToString();
        request.TimeStamp = CurrentPage.Request["TimeStamp"].ToString();
        return request;
    }
}
