<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Pet_Leave.aspx.cs" Inherits="WebApplication1.Pet_Leave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="System.Data"%>
<%@ Import namespace="System.Configuration"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="height:100vh; background-color:#f8f0cc;">
        
        <div style="margin:auto auto; width:1125px;">
             <div class="row" style="width:500px; margin-left:60px;">
                <div style="float:left;">
                    <asp:Button ID="Button1" runat="server" Text="發送MAIL" CssClass="btn btn-primary" OnClick="Button1_Click1" />

                </div>
            </div>
                <%
                    string strCon = ConfigurationManager.ConnectionStrings["Animal_HouseConnectionString"].ConnectionString;
                    string sql = "Select * From PET_SIAZE where IS_ADOPT = 0";
                    DataTable dt = new DataTable();
                    SqlConnection sqlconn = new SqlConnection();
                    SqlCommand sqlCmd = new SqlCommand(sql, sqlconn);

                    sqlconn.ConnectionString = strCon;
                    sqlconn.Open();

                    SqlDataReader Sqldr = sqlCmd.ExecuteReader();
                    dt.Load(Sqldr);
                    Sqldr.Close();
                %>
                <%
                    if(dt.Rows.Count > 0)
                    {
                        for(int i = 0; i < dt.Rows.Count; i++)
                        {
                            string sType = dt.Rows[i]["PET_TYPE"].ToString();
                            string sPET_VARIETY = dt.Rows[i]["PET_VARIETY"].ToString();
                            string sLeaveDate = dt.Rows[i]["LEAVE_DATE"].ToString();
                            string sID = dt.Rows[i]["ID"].ToString();
                            string sIMG = dt.Rows[i]["PET_IMG"].ToString();
                            if(sType == "0")
                            {
                                sType = "狗";
                            }
                            else
                            {
                                sType = "貓";
                            }

                            string s = "Pet_Detail.aspx?ID=" + sID + "&Type=E";
                           
                            string sHtml = "<div style='width:280px;border:solid 1px black; float:left; margin:20px 0px 0px 60px;'>";
                            sHtml += "<div style='width:240px; margin:auto auto;'>";
                            sHtml += "<a href='" + s + "'>";
                            sHtml += "<img src='Pic2/" + sIMG + "' style='width:240px;height:180px;'/>";
                            sHtml += "</a>";
                            sHtml += "</div>";
                            sHtml += "<div>";
                            sHtml += "<div><lable>類別：" + sType + "</lable></div>";
                            sHtml += "<div><lable>品種：" + sPET_VARIETY + "</lable></div>";
                            sHtml += "<div><lable>離所日：" + sLeaveDate + "</lable></div>";
                            sHtml += "</div>";
                            sHtml += "</div>";

                            Response.Write(sHtml);
                        }
                    }
                %>

            
        </div>
    </div>
</asp:Content>
