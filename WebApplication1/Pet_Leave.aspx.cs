using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Pet_Leave : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["Animal_HouseConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("Pet.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            //前面是發信email後面是顯示的名稱
            mail.From = new MailAddress("chaly904243@gmail.com", "信件名稱");

            

            string sql = "select a.*, b.ID, b.ADOPTERS_MAIL from PET_SIAZE a inner join ADOPTERS b on a.ADOPT = b.ID where a.IS_ADOPT = 0 AND a.LEAVE_DATE <> ''";
            DataTable dt = new DataTable();

            SqlConnection sqlconn = new SqlConnection();
            SqlCommand sqlCmd = new SqlCommand(sql, sqlconn);

            sqlconn.ConnectionString = strCon;
            sqlconn.Open();

            SqlDataReader Sqldr = sqlCmd.ExecuteReader();
            dt.Load(Sqldr);
            Sqldr.Close();

            //收信者email
            string s = string.Empty;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                s += "編號：" + dt.Rows[0]["PET_NUM"].ToString() + "已離所半年。";
                mail.To.Add(dt.Rows[i]["ADOPTERS_MAIL"].ToString());
            }
            mail.To.Add("chaly904243@gmail.com");

            //設定優先權
            mail.Priority = MailPriority.Normal;

            //標題
            mail.Subject = "測試";

            
            //內容
            mail.Body = "<h1>" + s + "</h1>";

            //內容使用html
            mail.IsBodyHtml = true;

            //設定gmail的smtp (這是google的)
            SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);

            //您在gmail的帳號密碼
            MySmtp.Credentials = new System.Net.NetworkCredential("chaly904243@gmail.com", "abcdef731017");

            //開啟ssl
            MySmtp.EnableSsl = true;

            //發送郵件
            MySmtp.Send(mail);

            //放掉宣告出來的MySmtp
            MySmtp = null;

            //放掉宣告出來的mail
            mail.Dispose();

            Response.Write("<script language='javascript'>alert('MAIL已寄送。')</script>");
        }
    }
}