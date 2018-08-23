<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="trangChu.aspx.cs" Inherits="VD.trangChu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>VD5: ĐỌC DỮ LIỆU VÀ ĐƯA LÊN GRIDVIEW</h1><br />
         Các bước thực hiện:<br/><br />
        A. Trong SQL Server
    1. Tạo CSDL Sample<br />
    2. Tạo bảng HangHoa: ID - int, ten - nvarchar(50), maTheLoai - int.<br />
    3. Tạo bảng TheLoai: maTheLoai - int, tenTheLoai - nvarchar(50)<br />
        B. Trong QT1<br />
    4.     ....<br />
    <h2>Cấu hình cho gridview:</h2><br />
    1. Phân trang: Allow paging: True; Page size: Tuỳ ý<br />
    Nếu Allow paging = true thì phải cấu hình tối thiểu là sự kiện PageIndexChanging<br />
    2. Canh vị trí: HorizontallAlign: Center/Left...<br />
    3. Sắp xếp khi kích lên tiêu đề cột: AllowSorting=True<br />
    Nếu AllowSorting=True thì phải cấu hình tối thiểu là sự kiện Sorting<br />
    <h2>Chú ý</h2><br />
    1. Bây giờ sau khi thêm mới thành công, cần đọc lại dữ liệu và đưa lên gridview
    <p>
        &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/QT1.aspx">Chuyển sang chức năng QT1</asp:HyperLink>
        </p>
</asp:Content>
