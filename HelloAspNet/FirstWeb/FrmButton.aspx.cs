using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWeb
{
    public partial class FrmButton : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) TxtNum.Text = "0"; //처음에만 postback이 0으로 초기화, 그 후는 관여X
        }

        protected void BtnInc_Click(object sender, EventArgs e)
        {
            TxtNum.Text = $"{int.Parse(TxtNum.Text) + 1}";
        }

        protected void BtnDec_Click(object sender, EventArgs e)
        {
            TxtNum.Text = $"{int.Parse(TxtNum.Text) - 1}";
        }
        
        protected void BtnLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.naver.com");
        }

        protected void BtnImage_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}