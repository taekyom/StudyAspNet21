using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWeb
{
    public partial class FrmResponseBuffer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = -1; //현재페이지를 매번 새로 읽어옴
            Response.Buffer = true; //buffer : 값을 담아놨다가 한번에 출력하는 것, 버퍼사용
            Response.Write("[1] 현재 글이 보여짐");
            Response.Flush(); //버퍼에 있는 내용 출력
            Response.Write("[3] 현재 글은?");
            Response.Clear(); //버퍼에 있는 내용 삭제
            Response.Write("[4] 출력");
            Response.End();
            Response.Write("[5] 출력이 안됨");
        }
    }
}