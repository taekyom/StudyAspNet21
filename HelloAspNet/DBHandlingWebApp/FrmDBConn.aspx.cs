using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DBHandlingWebApp
{
    public partial class FrmDBConn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnConn_Click(object sender, EventArgs e)
        {
            var connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

            using(SqlConnection conn = new SqlConnection(connString))
            {
                if (conn.State == System.Data.ConnectionState.Closed) conn.Open();

                //LblResult.Text = conn.State.ToString(); //"DB 연결 성공";
                var query = @"Insert Memos 
                              Values
                              ('이태경', 'tkyoung1014@naver.com', '이태경입니다.', GetDate(), '127.0.0.1')";

                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                    LblResult.Text = "데이터 저장 완료";
                }
                catch (Exception ex)
                {
                    LblResult.Text = $"오류{ex}";
                }
                
            }
        }
    }
}