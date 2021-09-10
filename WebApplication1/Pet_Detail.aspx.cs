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
    public partial class Pet_Detail : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["Animal_HouseConnectionString"].ConnectionString;
        string sID = string.Empty;
        string sType = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            sType = Request.QueryString["Type"];
            sID = Request.QueryString["ID"];
            Adopt.Visible = false;
            Adopt2.Visible = false;
            SetDrList();

            if (RadioButton1.Checked == true)
            {
                Adopt.Visible = true;
                Adopt2.Visible = true;
            }

            if (!IsPostBack)//如果不是用PostBack回來的話
            {
                if(sType == "A")
                {

                    SetControl_ADD();
                }
                else
                {
                    SetControl_Edit();
                    string sql = "Select * From PET_SIAZE where ID = " + sID;
                    DataTable dt = new DataTable();

                    SqlConnection sqlconn = new SqlConnection();
                    SqlCommand sqlCmd = new SqlCommand(sql, sqlconn);

                    sqlconn.ConnectionString = strCon;
                    sqlconn.Open();

                    SqlDataReader Sqldr = sqlCmd.ExecuteReader();
                    dt.Load(Sqldr);
                    Sqldr.Close();

                    string sType = dt.Rows[0]["PET_TYPE"].ToString();
                    string sSex = dt.Rows[0]["PET_SEX"].ToString();
                    string sAdopt = dt.Rows[0]["IS_ADOPT"].ToString();

                    TextBox1.Text = dt.Rows[0]["PET_VARIETY"].ToString();
                    //TextBox2.Text = dt.Rows[0]["PET_VARIETY"].ToString();
                    TextBox3.Text = dt.Rows[0]["PET_WEIGHT"].ToString();
                    //TextBox4.Text = dt.Rows[0]["PET_WEIGHT"].ToString();
                    TextBox5.Text = dt.Rows[0]["PET_COLOR"].ToString();
                    TextBox6.Text = dt.Rows[0]["PET_OLD"].ToString();
                    //TextBox7.Text = "";
                    TextBox8.Text = dt.Rows[0]["PET_NUM"].ToString();
                    //TextBox9.Text = dt.Rows[0]["ENTER_DATE"].ToString();
                    Calendar1.SelectedDate = Convert.ToDateTime(dt.Rows[0]["ENTER_DATE"].ToString());
                    TextBox10.Text = dt.Rows[0]["PERSONALITY"].ToString();
                    TextBox11.Text = dt.Rows[0]["LIGATION"].ToString();
                    TextBox12.Text = dt.Rows[0]["VACCINE"].ToString();
                    TextBox13.Text = dt.Rows[0]["DEWORMING"].ToString();
                    if(!string.IsNullOrWhiteSpace(dt.Rows[0]["LEAVE_DATE"].ToString()))
                    {
                        Calendar2.SelectedDate = Convert.ToDateTime(dt.Rows[0]["LEAVE_DATE"].ToString());
                    }
                    DropDownList1.SelectedValue = dt.Rows[0]["ADOPT"].ToString();
                    Image1.ImageUrl = "Pic2/" + dt.Rows[0]["PET_IMG"].ToString().Trim();
                    HiddenField1.Value = dt.Rows[0]["PET_IMG"].ToString();

                    if (sType == "0")
                    {
                        RadioButton3.Checked = true;
                    }
                    else
                    {
                        RadioButton4.Checked = true;
                    }

                    if (sSex == "0")
                    {
                        RadioButton5.Checked = true;
                    }
                    else
                    {
                        RadioButton6.Checked = true;
                    }

                    if (sAdopt == "0")
                    {
                        RadioButton1.Checked = true;
                    }
                    else
                    {
                        RadioButton2.Checked = true;
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.ReadOnly = false;
            //TextBox2.ReadOnly = false;
            TextBox3.ReadOnly = false;
            //TextBox4.ReadOnly = false;
            TextBox5.ReadOnly = false;
            TextBox6.ReadOnly = false;
            //TextBox7.ReadOnly = false;
            TextBox8.ReadOnly = false;
            //TextBox9.ReadOnly = false;
            TextBox10.ReadOnly = false;
            TextBox11.ReadOnly = false;
            TextBox12.ReadOnly = false;
            TextBox13.ReadOnly = false;

            Button1.Visible = false;
            Button2.Visible = true;
            Button4.Visible = true;
        }

        private void SetControl_ADD()
        {
            TextBox1.Text = "";
            //TextBox2.Text = "";
            TextBox3.Text = "";
            //TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            //TextBox7.Text = "";
            TextBox8.Text = "";
            //TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox13.Text = "";

            Button1.Visible = false;
            Button2.Visible = false;
            Button4.Visible = true;
        }

        private void SetControl_Edit()
        {
            TextBox1.ReadOnly = true;
            //TextBox2.ReadOnly = true;
            TextBox3.ReadOnly = true;
            //TextBox4.ReadOnly = true;
            TextBox5.ReadOnly = true;
            TextBox6.ReadOnly = true;
            //TextBox7.ReadOnly = true;
            TextBox8.ReadOnly = true;
            //TextBox9.ReadOnly = true;
            TextBox10.ReadOnly = true;
            TextBox11.ReadOnly = true;
            TextBox12.ReadOnly = true;
            TextBox13.ReadOnly = true;

            Button1.Visible = true;
            Button2.Visible = true;
            Button4.Visible = false;
        }

        private void SetDrList()
        {
            string sql = "Select ID,ADOPTERS_NAME from ADOPTERS";
            DataTable dt = new DataTable();

            SqlConnection sqlconn = new SqlConnection();
            SqlCommand sqlCmd = new SqlCommand(sql, sqlconn);

            sqlconn.ConnectionString = strCon;
            sqlconn.Open();

            SqlDataReader Sqldr = sqlCmd.ExecuteReader();
            dt.Load(Sqldr);
            Sqldr.Close();

            DropDownList1.DataValueField = "ID";
            DropDownList1.DataTextField = "ADOPTERS_NAME";
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (sType == "A")
            {
                string strIns = @"Insert into PET_SIAZE(PET_TYPE, PET_VARIETY, PET_SEX, PET_WEIGHT,PET_COLOR,PET_OLD,PET_NUM,ENTER_DATE,PERSONALITY,LIGATION,VACCINE,DEWORMING, LEAVE_DATE,IS_ADOPT,ADOPT,PET_IMG,CREATE_DATE) values(@PET_TYPE, @PET_VARIETY, @PET_SEX, @PET_WEIGHT,@PET_COLOR,@PET_OLD,@PET_NUM,@ENTER_DATE,@PERSONALITY,@LIGATION,@VACCINE,@DEWORMING, @LEAVE_DATE,@IS_ADOPT,@ADOPT,@PET_IMG,getdate())";
                SqlConnection sqlconn = new SqlConnection();
                SqlCommand sqlCmd = new SqlCommand(strIns, sqlconn);
                sqlconn.ConnectionString = strCon;
                sqlconn.Open();
                int iType = 0;
                int iSex = 0;
                int iAdopt = 0;

                if (RadioButton4.Checked == true)
                {
                    iType = 1;
                }

                if (RadioButton6.Checked == true)
                {
                    iSex = 1;
                }

                if (RadioButton2.Checked == true)
                {
                    iAdopt = 1;
                }

                sqlCmd.Parameters.AddWithValue("@PET_VARIETY", TextBox1.Text);
                sqlCmd.Parameters.AddWithValue("@PET_TYPE", iType);
                sqlCmd.Parameters.AddWithValue("@PET_SEX", iSex);
                sqlCmd.Parameters.AddWithValue("@PET_WEIGHT", Convert.ToDecimal(TextBox3.Text));
                sqlCmd.Parameters.AddWithValue("@PET_COLOR", TextBox5.Text);
                sqlCmd.Parameters.AddWithValue("@PET_OLD", TextBox6.Text);
                sqlCmd.Parameters.AddWithValue("@PET_NUM", TextBox8.Text);
                sqlCmd.Parameters.AddWithValue("@ENTER_DATE", Calendar1.SelectedDate.ToString("yyyy/MM/dd"));
                sqlCmd.Parameters.AddWithValue("@PERSONALITY", TextBox10.Text);
                sqlCmd.Parameters.AddWithValue("@LIGATION", TextBox11.Text);
                sqlCmd.Parameters.AddWithValue("@VACCINE", TextBox12.Text);
                sqlCmd.Parameters.AddWithValue("@DEWORMING", TextBox13.Text);
                sqlCmd.Parameters.AddWithValue("@LEAVE_DATE", Calendar2.SelectedDate.ToString("yyyy/MM/dd"));
                sqlCmd.Parameters.AddWithValue("@IS_ADOPT", iAdopt);
                sqlCmd.Parameters.AddWithValue("@ADOPT", DropDownList1.SelectedValue.ToString());
                sqlCmd.Parameters.AddWithValue("@PET_IMG", HiddenField1.Value);

                //PET_TYPE, PET_VARIETY, PET_SEX, PET_WEIGHT,PET_COLOR,PET_OLD,PET_NUM,ENTER_DATE,PERSONALITY,LIGATION,VACCINE,DEWORMING, LEAVE_DATE,IS_ADOPT,ADOPT,CREATE_DATE
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Cancel();
                sqlconn.Close();
                sqlconn.Dispose();

                Server.Transfer("Pet.aspx");
            }
            else
            {
                string strUp = @"Update PET_SIAZE SET PET_TYPE = @PET_TYPE, PET_VARIETY = @PET_VARIETY, PET_SEX = @PET_SEX, PET_WEIGHT = @PET_WEIGHT, PET_COLOR = @PET_COLOR, PET_OLD = @PET_OLD, PET_NUM = @PET_NUM, ENTER_DATE = @ENTER_DATE, PERSONALITY = @PERSONALITY, LIGATION = @LIGATION, VACCINE = @VACCINE, DEWORMING = @DEWORMING, LEAVE_DATE = @LEAVE_DATE, IS_ADOPT = @IS_ADOPT, ADOPT = @ADOPT, PET_IMG = @PET_IMG where ID = @ID";
                SqlConnection sqlconn = new SqlConnection();
                SqlCommand sqlCmd = new SqlCommand(strUp, sqlconn);
                sqlconn.ConnectionString = strCon;
                sqlconn.Open();

                int iType = 0;
                int iSex = 0;
                int iAdopt = 0;
                string sAdopt = string.Empty;
                string sLeaveDate = string.Empty;

                if (RadioButton4.Checked == true)
                {
                    iType = 1;
                }

                if (RadioButton6.Checked == true)
                {
                    iSex = 1;
                }

                if (RadioButton2.Checked == true)
                {
                    iAdopt = 1;
                }

                if(iAdopt == 1)
                {
                    sAdopt = "";
                    sLeaveDate = "";
                }
                else
                {
                    sAdopt = DropDownList1.SelectedValue.ToString();
                    sLeaveDate = Calendar2.SelectedDate.ToString("yyyy/MM/dd");
                }

                sqlCmd.Parameters.AddWithValue("@PET_VARIETY", TextBox1.Text);
                sqlCmd.Parameters.AddWithValue("@PET_TYPE", iType);
                sqlCmd.Parameters.AddWithValue("@PET_SEX", iSex);
                sqlCmd.Parameters.AddWithValue("@PET_WEIGHT", TextBox3.Text);
                sqlCmd.Parameters.AddWithValue("@PET_COLOR", TextBox5.Text);
                sqlCmd.Parameters.AddWithValue("@PET_OLD", TextBox6.Text);
                sqlCmd.Parameters.AddWithValue("@PET_NUM", TextBox8.Text);
                sqlCmd.Parameters.AddWithValue("@ENTER_DATE", Calendar1.SelectedDate.ToString("yyyy/MM/dd"));
                sqlCmd.Parameters.AddWithValue("@PERSONALITY", TextBox10.Text);
                sqlCmd.Parameters.AddWithValue("@LIGATION", TextBox11.Text);
                sqlCmd.Parameters.AddWithValue("@VACCINE", TextBox12.Text);
                sqlCmd.Parameters.AddWithValue("@DEWORMING", TextBox13.Text);
                sqlCmd.Parameters.AddWithValue("@LEAVE_DATE", sLeaveDate);
                sqlCmd.Parameters.AddWithValue("@IS_ADOPT", iAdopt);
                sqlCmd.Parameters.AddWithValue("@ADOPT", sAdopt);
                sqlCmd.Parameters.AddWithValue("@PET_IMG", HiddenField1.Value);
                sqlCmd.Parameters.AddWithValue("@ID", sID);

                sqlCmd.ExecuteNonQuery();
                sqlCmd.Cancel();
                sqlconn.Close();
                sqlconn.Dispose();

                Server.Transfer("Pet.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string strDel = @"Delete PET_SIAZE where ID = @ID";
            SqlConnection sqlconn = new SqlConnection();
            SqlCommand sqlCmd = new SqlCommand(strDel, sqlconn);
            sqlconn.ConnectionString = strCon;
            sqlconn.Open();

            sqlCmd.Parameters.AddWithValue("@ID", sID);

            sqlCmd.ExecuteNonQuery();
            sqlCmd.Cancel();
            sqlconn.Close();
            sqlconn.Dispose();

            Server.Transfer("Pet.aspx");
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Adopt.Visible = true;
            Adopt2.Visible = true;
            if(RadioButton1.Checked == true)
            {
                RadioButton2.Checked = false;
            }
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Adopt.Visible = false;
            Adopt2.Visible = false;
            if (RadioButton2.Checked == true)
            {
                RadioButton1.Checked = false;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pet.aspx");
        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton3.Checked == true)
            {
                RadioButton4.Checked = false;
            }
        }

        protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton4.Checked == true)
            {
                RadioButton3.Checked = false;
            }
        }

        protected void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton5.Checked == true)
            {
                RadioButton6.Checked = false;
            }
        }

        protected void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton6.Checked == true)
            {
                RadioButton5.Checked = false;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                //if (FileUpload1.PostedFile.FileName == "")
                //if (FileUpload1.FileName == "") 
                //if (!FileUpload1.HasFile)  //獲取一個值，該值指示 System.Web.UI.WebControls.FileUpload 控制元件是否包含檔案。包含檔案，則為 true；否則為 false。 
                //{
                //    this.Upload_info.Text = "請選擇上傳檔案！";
                //}
                //else
                //{
                //string filepath = FileUpload1.PostedFile.FileName; //得到的是檔案的完整路徑,包括檔名，如：C:\Documents and Settings\Administrator\My Documents\My Pictures\20022775_m.jpg 
                //string filepath = FileUpload1.FileName;    //得到上傳的檔名20022775_m.jpg 
                string filename = FileUpload1.PostedFile.FileName;//20022775_m.jpg 
                string serverpath = Server.MapPath("~/Pic2/") + filename;//取得檔案在伺服器上儲存的位置C:\Inetpub\wwwroot\WebSite1\images\20022775_m.jpg 
                FileUpload1.PostedFile.SaveAs(serverpath);//將上傳的檔案另存為 
                HiddenField1.Value = filename;
                Image1.ImageUrl = "Pic2/" + filename;
                //this.Upload_info.Text = "上傳成功！";
                //}
            }
            catch (Exception ex)
            {
                //this.Upload_info.Text = "上傳發生錯誤！原因是："   ex.ToString();
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox2.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            TextBox4.Text = Calendar2.SelectedDate.ToString("yyyy/MM/dd");
        }
    }
}