using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace StateMngWebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["Now"] = DateTime.Now;
            Application["Visit"] = 0; //페이지 접속자 수 확인
        }
        protected void Application_End(object sender, EventArgs e)
        {
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            Session["Now"] = DateTime.Now;
            Application.Lock();
            Application["Visit"] = Convert.ToInt32(Application["Visit"]) + 1;
            Application.UnLock();
            //한명 들어올 때마다 lock걸고 +1해서 카운트하고 unlock
        }
        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["Visit"] = Convert.ToInt32(Application["Visit"]) - 1;
            Application.UnLock();
            //한명 나갈 때마다 lock걸고 -1해서 카운트하고 unlock
        }
    }
}