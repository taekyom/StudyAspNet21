using DotNetNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.Board
{
    public partial class BoardList : System.Web.UI.Page
    {
        private DB_Repository _repo;

        public bool SearchMode { get; set; } = false; //검색모드면 true, 아니면(보통상태) false

        public int RecordCount = 0; //총 레코드 수
        public int PageIndex = 0; //페이징할 때 값, 현재 보여줄 페이지 번호

        public BoardList()
        {
            _repo = new DB_Repository(); //sqlconnection 생성
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SearchMode)
            {
                RecordCount = _repo.GetCountAll();
            }
            LblTotalRecord.Text = $"Total Record : {RecordCount}"; //상단에 총 글의 개수를 나타내기 위함

            if (Request["Page"] != null)
            {
                PageIndex = Convert.ToInt32(Request["Page"]) - 1;
            }
            else
            {
                PageIndex = 0; //1페이지
            }
            //TODO : 쿠키를 사용해서 리스트 페이지번호 유지
            //실제 페이징 처리 
            PagingControl.PageIndex = PageIndex;
            PagingControl.RecordCount = RecordCount;
            
            if (!Page.IsPostBack) //최초로드면~
            {
                DisplayData();
            }
        }
        private void DisplayData()
        {
            if (!SearchMode)
            {
                GrvNotes.DataSource = _repo.GetAll(PageIndex); //페이징을 위한 부분, 페이징은 0부터 시작
            }

            GrvNotes.DataBind(); //실제 데이터 바인드 완성
        }
    }
}