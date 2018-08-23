<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="trangChu.aspx.cs" Inherits="VD1.trangChu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>VD3: THÊM MỚI BẢN GHI</h1><br />
         Các bước thực hiện:<br/><br />
        A. Trong SQL Server
    1. Tạo CSDL Sample<br />
    2. Tạo bảng HangHoa: ID - int, ten - nvarchar(50), maTheLoai - int.<br />
    3. Tạo bảng TheLoai: maTheLoai - int, tenTheLoai - nvarchar(50)<br />
        B. Trong QT1<br />
    4.     ....<br />
    <h2>Một số tài liệu</h2><br />
    <p>
        &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/QT1.aspx">Chuyển sang chức năng QT1</asp:HyperLink>
        </p>
</asp:Content>
