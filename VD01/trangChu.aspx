<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="trangChu.aspx.cs" Inherits="VD1.trangChu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Các bước thực hiện:<br/><br />
    1. Tạo master page có tên Site.Master<br />
    Thêm 3 section sẽ tạo thành 3 phần đầu, thân, cuối của website. Phần thân sẽ <br />
    chứa các nội dung thuộc các trang thừa kế Site.Master<br />
    2. Tạo NESTED master page có tên Quantri.Master cho nhóm chức năng quản trị, thừa kế Site.Master<br />
    Thêm 3 contentPlaceHolder có id lần lượt là: header, maincontent và footer. Tương tự, maincontent <br />
        sau này sẽ chứa nội dung riêng của trang web sẽ thừa kế Quantri.Master.<br />
    3. Tạo NESTED master page có tên Nhanvien.Master cho nhóm chức năng nhân viên, thừa kế Site.Master<br />
    Tương tự như với Quantri.Master.<br />
    4. Thêm các webform QT1, QT2 dùng master page Quantri.Master.<br />
        Chú ý ở các trang này, chọn "Default to Master's content".<br />
    5. Thêm menu (kéo từ Toolbox và thả) vào phần contentPlaceHolder có id header của Quantri.Master<br />
        Thêm các item và liên kết đến QT1, Qt2...<br />
    ....</p>
    <h2>Một số tài liệu</h2><br />
    http://www.asp.net/web-forms/overview/older-versions-getting-started/master-pages/nested-master-pages-cs <br />
    https://msdn.microsoft.com/en-us/library/bb547109(v=vs.100).aspx <br />
    https://www.asp.net/web-forms/overview/older-versions-getting-started/master-pages/creating-a-site-wide-layout-using-master-pages-cs <br />
    <br /><br />
    <p>
        &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/QT1.aspx">Chuyển sang chức năng QT1</asp:HyperLink>
        </p>
</asp:Content>
