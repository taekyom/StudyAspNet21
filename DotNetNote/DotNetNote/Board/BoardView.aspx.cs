using DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.Board
{
    public partial class BoardView : System.Web.UI.Page
    {
        private string _Id; //현재 게시글 번호
        protected void Page_Load(object sender, EventArgs e)
        {
            lnkDelete.NavigateUrl = $"BoardDelete.aspx?Id={Request["Id"]}";
            lnkModify.NavigateUrl = $"BoardWrite.aspx?Id={Request["Id"]}&Mode=Edit";
            lnkReply.NavigateUrl = $"BoardWrite.aspx?Id={Request["Id"]}&Mode=Reply";

            _Id = Request["Id"];
            if (_Id == null)
                Response.Redirect("BoardList.aspx");

            if (!Page.IsPostBack)
                DisplayData();
        }

        private void DisplayData()
        {
            var repo = new DB_Repository();
            Note note = repo.GetNoteById(Convert.ToInt32(_Id));

            lblNum.Text = _Id;
            lblName.Text = note.Name;
            lblEmail.Text = string.Format("<a href='mailto:{0}'>{0}</a>", note.Email); //email을 누르면 바로 작성할 수 있도록 해줌(outlook으로 바로 연동 등)
            lblTitle.Text = note.Title;

            string content = note.Content;

            //인코딩 방식 : text, html, mixed
            string encoding = note.Encoding;
            if(encoding == "Text")
            {
                lblContent.Text = Helpers.HtmlUtility.EncodeWithTabAndSpace(content); 
            }
            else if(encoding == "Mixed")
            {
                lblContent.Text = content.Replace("\r\n", "<br/>");
            }
            else //html
            {
                lblContent.Text = content; //html은 변환없이 출력
            }

            lblReadCount.Text = note.ReadCount.ToString();
            lblHomepage.Text = $"<a href='{note.Homepage}' target='_blank'>{note.Homepage}</a>";
            lblPostDate.Text = note.PostDate.ToString();
            lblPostIP.Text = note.PostIp;

            if(note.FileName.Length > 1)
            {
                lblFile.Text = $"{note.FileName} / 다운로드 {note.DownCount}";
            }
            else
            {
                lblFile.Text = "(None)";
            }
        }
    }
}