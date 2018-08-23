<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="VD10.DangNhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style="float:none; position:relative;color:red">
        <asp:Label ID="lThongBao" runat="server" Text="Nơi đưa thông báo"></asp:Label>
    </div>
    <div style="float:none; position:relative">Tên đăng nhập:<asp:TextBox ID="tbTenDangNhap" runat="server"></asp:TextBox>
    </div><div style="float:left; position:relative"></div>
    <div style="float:none; position:relative;width:100px">Mật khẩu:<asp:TextBox ID="tbMatKhau" runat="server"></asp:TextBox>
    </div><div style="float:left; position:relative"></div>
    <div style="float:none; position:relative">
        <asp:Button ID="bDangNhap" runat="server" Text="Đăng nhập" OnClick="bDangNhap_Click" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
