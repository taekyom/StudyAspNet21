using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWeb
{
    public partial class FrmStandardControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblDateTme.Text = DateTime.Now.ToString();
        }

        protected void BtnServer_Click(object sender, EventArgs e)
        {
            var result = $"유저 아이디 : {TxtUserID.Text}" +
                         $"패스워드 : {TxtPassword.Text}" +
                         $"설명 : {TxtDesc.Text}";

            Response.Write(result);
        }
    }
}