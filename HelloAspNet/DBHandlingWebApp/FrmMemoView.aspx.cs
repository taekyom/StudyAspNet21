﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBHandlingWebApp
{
    public partial class FrmMemoView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request["Num"]))
            {
                Response.Write("잘못된 요청입니다.");
                Response.End();
            }
            else
            {
                var connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString; //항상 똑같음
                using (var conn = new SqlConnection(connString))
                {
                    if (conn.State == System.Data.ConnectionState.Closed) conn.Open(); //항상 똑같음

                    SqlCommand cmd = new SqlCommand("ViewMemo", conn); //항상 똑같음(파라미터만 변경)
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Num", Convert.ToInt32(Request["Num"]));

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        LblNum.Text = Request["Num"];
                        LblName.Text = reader["Name"].ToString();
                        LblEmail.Text = reader["Email"].ToString();
                        LblTitle.Text = reader["Title"].ToString();
                        LblPostDate.Text = reader["PostDate"].ToString();
                        LblPostIP.Text = reader["PostIP"].ToString();
                    }
                    reader.Close();
                }
            }
        }
    }
}