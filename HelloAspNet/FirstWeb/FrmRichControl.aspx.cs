using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWeb
{
    public partial class FrmRichControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CalMain_SelectionChanged(object sender, EventArgs e)
        {
            //선택한 날짜를 캘린더 위에 한줄을 넣어 표현해주는 것
            Response.Write(CalMain.SelectedDate.ToShortDateString() + "<hr />");
        }
    }
}