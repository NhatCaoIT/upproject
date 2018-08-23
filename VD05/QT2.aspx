<%@ Page Title="" Language="C#" MasterPageFile="~/QuanTri.master" AutoEventWireup="true" CodeBehind="QT2.aspx.cs" Inherits="VD.QT2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <p>
    ---------Đây là phần chính của trang web QT2</p>
    <p>Nhập ID và các giá trị mới để cập nhật!</p>
    <table>
        <tr>
            <td>ID:</td><td>
            <asp:TextBox ID="tbID" runat="server" Width="83px"></asp:TextBox>
            </td>
            <td>Tên:</td><td>
            <asp:TextBox ID="tbTen" runat="server"></asp:TextBox>
            </td>
            <td>Thể loại:</td><td>
            <asp:DropDownList ID="ddlTheLoai" runat="server">
            </asp:DropDownList>
            </td>
        </tr>
    </table>
    <div>
        <asp:Label ID="lThongBao" runat="server" Text="Chỗ hiện thông báo"></asp:Label>
        !</div>
    <div>
        <asp:Button ID="bCapNhat" runat="server" OnClick="bCapNhat_Click" Text="Cập nhật" />
    </div>
</asp:Content>

