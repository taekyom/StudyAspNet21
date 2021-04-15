using DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.Board
{
    public partial class BoardWrite : System.Web.UI.Page
    {
        private string _ID; //리스트에서 넘겨주는 번호
        public BoardWriteFormType FormType { get; set; } = BoardWriteFormType.Write; //기본값 : 글쓰기
        protected void Page_Load(object sender, EventArgs e)
        {
            _ID = Request["Id"]; //GET/POST 모두 다 받음
            if (!Page.IsPostBack)
            {
                switch (FormType)
                {
                    case BoardWriteFormType.Write:
                        LblTitleDescription.Text = "글쓰기 - 다음 필드들을 입력하십시오.";
                        break;
                    case BoardWriteFormType.Modify:
                        LblTitleDescription.Text = "글수정 - 다음 필드들을 수정하십시오.";
                        DisplayDataForModify();
                        break;
                    case BoardWriteFormType.Reply:
                        LblTitleDescription.Text = "댓글 달기 - 다음 필드들을 입력하십시오.";
                        DisplayDataForReply();
                        break;
                }
            }
        }

        private void DisplayDataForReply()
        {
            throw new NotImplementedException();
        }

        private void DisplayDataForModify()
        {
            throw new NotImplementedException();
        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            if (IsImageTextCorrect())
            {
                //TODO : 파일업로드

                Note note = new Note();
                note.Id = Convert.ToInt32(_ID); //없으면 0
                note.Name = txtName.Text; //필수
                note.Email = txtEmail.Text;
                note.Title = txtTitle.Text; //필수
                note.Homepage = txtHomepage.Text;
                note.Content = txtContent.Text; //필수
                note.FileName = "";
                note.FileSize = 0;
                note.Password = txtPassword.Text;
                note.PostIp = Request.UserHostAddress;
                note.Encoding = rdoEncoding.SelectedValue; //필수 //text, html, mixed값이 들어감

                DB_Repository repo = new DB_Repository();
                switch (FormType)
                {
                    case BoardWriteFormType.Write:
                        repo.Add(note);
                        Response.Redirect("BoardList.aspx");
                        break;
                    case BoardWriteFormType.Modify:
                        break;
                    case BoardWriteFormType.Reply:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                lblError.Text = "보안코드가 틀립니다. 다시 입력하십시오.";
            }
        }

        private bool IsImageTextCorrect()
        {
            if (Page.User.Identity.IsAuthenticated) //이미 로그인된 상태
            {
                return true;
            }
            else
            {
                if (Session["ImageText"] != null)
                {
                    return (txtImageText.Text == Session["ImageText"].ToString());
                }
            }
            return false; //보안코드 불일치
        }

        protected void chkUpload_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}