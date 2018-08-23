<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="trangChu.aspx.cs" Inherits="VD9.trangChu1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>VD9: DÙNG SESSION ĐỂ KIỂM SOÁT ĐĂNG NHẬP</h1><br />
    <h2>Chuẩn bị CSDL</h2>
    Tạo bảng NguoiDung(id, hoLot, ten, tenDangNhap, matKhau, vaiTro) và cấp quyền cho log1...
    <h2>Chú ý</h2>
    1. Có trang đăng nhập để người dùng đăng nhập<br />
    2. Kiểm tra Session["role"] ở mỗi nested master page để biết đã đăng nhập chưa, vai trò...<br />
    3. Có trang đăng xuất để xoá tất cả thông tin trong Session liên quan đăng nhập...<br />
    4. Thêm đăng nhập, đăng xuất vào menu
</asp:Content>
