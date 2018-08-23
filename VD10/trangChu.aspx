<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="trangChu.aspx.cs" Inherits="VD10.trangChu1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>VD10: DÙNG MÃ CHUNG ĐỂ THAO TÁC DỮ LIỆU...</h1><br />
    <h2>Mã chung trong CommonCodes</h2><br />
    1. Class MD5Hash - dùng để lấy MD5 và kiểm tra mật khẩu. Trên thực tế, để quản lý mật khẩu chỉ dùng MD5 thì chưa đủ, cần kết hợp...<br />
    2. NameSpace DataClasses - Bao gồm các class dùng chung để thao tác dữ liệu. Thay vì mỗi khi thực hiện một lệnh SQL ta phải viết các đoạn code C# lặp lại...<br />
    <h2>Chú ý</h2><br />
    1. Áp dụng điển hình cho 3 trường hợp trong QT1.aspx.cs: thay mã nguồn cũ bằng mã sử dụng mã dùng chung...
</asp:Content>
