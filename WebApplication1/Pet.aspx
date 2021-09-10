<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Pet.aspx.cs" Inherits="WebApplication1.Pet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%@ Import namespace="System.Data.SqlClient"%>
<%@ Import namespace="System.Data"%>
<%@ Import namespace="System.Configuration"%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="height:100vh; background-color:#f8f0cc;">
        
        <div style="margin:auto auto; width:1125px;">
                <div class="row" style="width:600px; margin-left:60px;">
                    <div style="width:100px; float:left;"><asp:Button ID="Button1" runat="server" Text="新增" CssClass="btn btn-primary" OnClick="Button1_Click" /></div>
                    <div style="width:150px; float:left;"><asp:Button ID="Button2" runat="server" Text="已領養" CssClass="btn btn-primary" OnClick="Button2_Click" /></div>
                    <div style="width:300px; float:left;"><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><asp:Button ID="Button3" runat="server" Text="搜尋" CssClass="btn btn-primary" OnClick="Button3_Click" /></div>
                </div>

                <%
                    string strCon = ConfigurationManager.ConnectionStrings["Animal_HouseConnectionString"].ConnectionString;
                    string sql = "Select * From PET_SIAZE where IS_ADOPT = 1 ";
                    string sWhere = string.Empty;
                    string sText = Request.QueryString["Text"];
                    if(!string.IsNullOrWhiteSpace(sText))
                    {
                        sWhere += "And (PET_VARIETY like '%" + sText + "%' OR PERSONALITY like '%" + sText + "%' OR PET_WEIGHT = " + sText + " OR PET_COLOR = '%" + sText + "%' OR PET_NUM = '%" + sText + "%')";
                    }

                    sql = sql + sWhere;
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
                            string sSEX = dt.Rows[i]["PET_SEX"].ToString();
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

                            if(sSEX == "0")
                            {
                                sSEX = "公";
                            }
                            else
                            {
                                sSEX = "母";
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
                            sHtml += "<div><lable>性別：" + sSEX + "</lable></div>";
                            sHtml += "</div>";
                            sHtml += "</div>";

                            Response.Write(sHtml);
                        }
                    }
                %>

            
        </div>
    </div>
</asp:Content>
