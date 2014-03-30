using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSOSDK
{
   public class Post
    {
      public void post(SSORequest ssoRequest)
        {
            PostService ps = new PostService();

            ps.Url = ssoRequest.AppUrl;

            ps.Add("UserAccount", ssoRequest.UserAccount);
            ps.Add("EnterpriseId", ssoRequest.EnterpriseId);
            ps.Add("IASID", ssoRequest.IASID);
            ps.Add("TimeStamp", ssoRequest.TimeStamp);
            ps.Add("AppUrl", ssoRequest.AppUrl);
            ps.Add("Authenticator", ssoRequest.Authenticator);

            ps.Post();
        }
    }
}
