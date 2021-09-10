using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["Animal_HouseConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "Select * From USER_ACC where ACCOUNT = '" + TextBox1.Text + "'";
            DataTable dt = new DataTable();

            SqlConnection sqlconn = new SqlConnection();
            SqlCommand sqlCmd = new SqlCommand(sql, sqlconn);

            sqlconn.ConnectionString = strCon;
            sqlconn.Open();

            SqlDataReader Sqldr = sqlCmd.ExecuteReader();
            dt.Load(Sqldr);
            Sqldr.Close();

            if(dt.Rows.Count > 0)
            {
                Response.Write("<script language='javascript'>alert('無此帳號，請重新輸入。')</script>");
            }

            if (dt.Rows[0]["PASSWORD"].ToString() != TextBox2.Text)
            {
                Response.Write("<script language='javascript'>alert('密碼錯誤，請重新輸入。')</script>");
            }
            else
            {
                Server.Transfer("Default.aspx");
            }

            if(string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                Response.Write("<script language='javascript'>alert('帳號或密碼不可為空白，請重新輸入。')</script>");
            }
        }
    }
}