﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Adopt.aspx.cs" Inherits="WebApplication1.Adopt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="System.Data"%>
<%@ Import namespace="System.Configuration"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="height:100vh; background-color:#f8f0cc;">
       
        <div style="margin:auto auto; width:1125px; ">
            <div class="row" style="width:80px; margin-left:60px;">
                <asp:Button ID="Button1" runat="server" Text="新增" CssClass="btn btn-primary" OnClick="Button1_Click"/>
            </div>
            <%
                 
                    string strCon = ConfigurationManager.ConnectionStrings["Animal_HouseConnectionString"].ConnectionString;
                    string sql = "Select * From ADOPTERS";
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
                            string sName = dt.Rows[i]["ADOPTERS_NAME"].ToString();
                            string sMail = dt.Rows[i]["ADOPTERS_MAIL"].ToString();
                            string sTel = dt.Rows[i]["ADOPTERS_TEL"].ToString();
                            string sID = dt.Rows[i]["ID"].ToString();

                            //Label1.Text = "姓名：" + sName;
                            //Label1.Text = "EMAIL：" + sMail;
                            //Label1.Text = "電話：" + sTel;
                            string s = "Adopt_Detail.aspx?ID=" + sID + "&Type=E";
                            
                            string sHtml = "<div style='width:280px;border:solid 1px black; float:left; margin:20px 0px 0px 60px;'>";
                            sHtml += "<div style='width:160px; margin:auto auto;'>";
                            sHtml += "<a href='" + s + "'>";
                            sHtml += "<img src='Image/04.jpg' />";
                            sHtml += "</a>";
                            sHtml += "</div>";
                            sHtml += "<div>";
                            sHtml += "<div><lable>姓名：" + sName + "</lable></div>";
                            sHtml += "<div><lable>EMAIL：" + sMail + "</lable></div>";
                            sHtml += "<div><lable>電話：" + sTel + "</lable></div>";
                            sHtml += "</div>";
                            sHtml += "</div>";

                            Response.Write(sHtml);
                        }
                    }
                %>
            
        </div>
    </div>
</asp:Content>
