<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Pet_Detail.aspx.cs" Inherits="WebApplication1.Pet_Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <div class="container" style="background-color:#f8f0cc; height:100vh;" >
        <div>
            <div style="width:510px; float:left; margin:auto 20px;">
                <div>
                    <%--<div style="margin:auto auto; width:100px;"><asp:Label ID="Label1" runat="server" Text="002"></asp:Label></div>--%>
                    <div style="margin:auto auto; width:200px;">
                        <asp:Image ID="Image1" runat="server" ImageUrl="Image/01.png" Width="200px" Height="150" />

                    </div>
                </div>
                <div style="margin:20px auto; width:450px;">
                    <table>
                        <tr>
                            <td>個性行為：</td>
                            <td><asp:TextBox ID="TextBox10" runat="server"></asp:TextBox></td>
                        
                        </tr>
                        <tr>
                            <td>結扎與否：</td>
                            <td>
                                <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                            </td>
                        
                        </tr>
                        <tr>
                            <td>疫苗施打：</td>
                            <td><asp:TextBox ID="TextBox12" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>驅蟲與否：</td>
                            <td><asp:TextBox ID="TextBox13" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>領養與否：</td>
                            <td>
                                <asp:RadioButton ID="RadioButton1" runat="server" Text="是" OnCheckedChanged="RadioButton1_CheckedChanged" AutoPostBack="True" />
                                <asp:RadioButton ID="RadioButton2" runat="server" Text="否" OnCheckedChanged="RadioButton2_CheckedChanged" AutoPostBack="True" />
                            </td>
                        
                        </tr>
                        <tr runat="server" id="Adopt">
                            <td>離所日期：</td>
                            <td>
                                <%--<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>--%>
                                <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged"></asp:Calendar>
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            </td>
                        
                        </tr>
                        <tr runat="server" id="Adopt2">
                            <td>領養人：</td>
                            <td>
                                <%--<asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>--%>
                                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>

            </div>
            <div style="width:510px; float:left; margin:auto 20px;">
                <div>
                    <table>
                        <tr>
                            <td>品種：</td>
                            <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>類別：</td>
                            <td>
                                <asp:RadioButton ID="RadioButton3" runat="server" Text="狗" OnCheckedChanged="RadioButton3_CheckedChanged" AutoPostBack="True" />
                                <asp:RadioButton ID="RadioButton4" runat="server" Text="貓" OnCheckedChanged="RadioButton4_CheckedChanged" AutoPostBack="True" />
                            </td>
                        
                        </tr>
                        <tr>
                            <td>體重：</td>
                            <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                        
                        </tr>
                        <tr>
                            <td>性別：</td>
                            <td>
                                <asp:RadioButton ID="RadioButton5" runat="server" OnCheckedChanged="RadioButton5_CheckedChanged" Text="公" AutoPostBack="True" />
                                <asp:RadioButton ID="RadioButton6" runat="server" OnCheckedChanged="RadioButton6_CheckedChanged" Text="母" AutoPostBack="True" />
                            </td>
                        
                        </tr>
                        <tr>
                            <td>毛色：</td>
                            <td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>年齡：</td>
                            <td><asp:TextBox ID="TextBox6" runat="server" Height="23px"></asp:TextBox></td>
                        
                        </tr>
                        <tr>
                            <td>編號：</td>
                            <td><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td>
                        
                        </tr>
                        <tr>
                            <td>上傳圖片</td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <asp:Button ID="Button5" runat="server" Text="上傳" CssClass="btn btn-primary" OnClick="Button5_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>進所日期：</td>
                            <td><%--<asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>--%>
                                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        
                    </table>
                </div>
                <div style="padding-left:160px; margin-top:30px;">
                    <div style="margin:auto auto; width:100px; float:left;">
                        <asp:Button ID="Button1" runat="server" Text="編輯" CssClass="btn btn-primary" OnClick="Button1_Click" />
                        <asp:Button ID="Button4" runat="server" Text="儲存" CssClass="btn btn-primary" OnClick="Button4_Click" />
                    </div>
                    <div style="margin:auto auto; width:100px; float:left;"><asp:Button ID="Button2" runat="server" Text="刪除" CssClass="btn btn-danger" OnClick="Button2_Click" /></div>
                </div>
                <div style="padding-left:160px; margin-top:30px;">
                    <asp:Button ID="Button3" runat="server" Text="返回列表頁" CssClass="btn btn-warning" OnClick="Button3_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
