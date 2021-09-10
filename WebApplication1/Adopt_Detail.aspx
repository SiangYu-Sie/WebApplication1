<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Adopt_Detail.aspx.cs" Inherits="WebApplication1.Adopt_Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <div class="container" style="background-color:#f8f0cc; height:100vh;" >
        <div style="width:1120px; height:auto; float:left; margin:auto 20%;">
            <div style="width:450px; float:left;">
                <div>
                    <table>
                        <tr>
                            <td>姓名</td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>性別</td>
                            <td>
                                <asp:RadioButton ID="RadioButton1" runat="server" Text="男" AutoPostBack="True" OnCheckedChanged="RadioButton1_CheckedChanged" />
                                <asp:RadioButton ID="RadioButton2" runat="server" Text="女" AutoPostBack="True" OnCheckedChanged="RadioButton2_CheckedChanged" />
                            </td>
                        </tr>
                        <tr>
                            <td>EMAIL</td>
                            <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>地址</td>
                            <td><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>電話</td>
                            <td><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>上傳圖片</td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                <asp:Button ID="Button4" runat="server" Text="上傳" CssClass="btn btn-primary" OnClick="Button4_Click"/>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="margin:20px auto;">
                    <table>
                        <tr>
                            <td>家庭環境</td>
                            <td><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>飼養經驗</td>
                            <td>
                                <asp:RadioButton ID="RadioButton3" runat="server" AutoPostBack="True" OnCheckedChanged="RadioButton3_CheckedChanged" Text="有" />
                                <asp:RadioButton ID="RadioButton4" runat="server" AutoPostBack="True" OnCheckedChanged="RadioButton4_CheckedChanged" Text="無" />
                            </td>
                        </tr>
                        <tr>
                            <td>年收入</td>
                            <td><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></td>
                        </tr>
                    </table>
                </div>
            </div>
            <div style="width:400px; float:left; margin:auto 20px;">
                <div>
                    <div style="margin:auto 60px; width:330px;"><asp:Image ID="Image1" runat="server" ImageUrl="Image/01.png" Width="240px" height="180px"/></div>
                </div>
                <div style="width:auto; height:auto; margin-top:">
                    <div style="margin:auto auto; width:230px;">
                        <div style="margin-right:3px; width:65px; float:left;"><asp:Button ID="Button1" runat="server" Text="刪除" OnClick="Button1_Click" CssClass="btn btn-warning" /></div>
                        <div style="margin-right:3px; width:65px; float:left;"><asp:Button ID="Button2" runat="server" Text="編輯" OnClick="Button2_Click" CssClass="btn btn-primary"/></div>
                        <div style="margin-right:3px; width:65px; float:left;"><asp:Button ID="Button3" runat="server" Text="儲存" OnClick="Button3_Click" CssClass="btn btn-primary"/></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
