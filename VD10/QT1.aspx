<%@ Page Title="" Language="C#" MasterPageFile="~/QuanTri.master" AutoEventWireup="true" CodeBehind="QT1.aspx.cs" Inherits="VD10.QT1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <p>
    ---------Đây là phần chính của trang web QT1</p>
    <p>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
            
        </asp:PlaceHolder>
    </p>
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
    <asp:Label ID="lThongBao" runat="server" Text="Chỗ hiện thông báo!!!"></asp:Label>
    <br />
    <asp:Button ID="bThemMoi" runat="server" OnClick="bThemMoi_Click" Text="Thêm" />
    <br />
    <p>
        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" EmptyDataText="Không có bản ghi nào" HorizontalAlign="Center" EnableViewState="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting">
        </asp:GridView>
    </p>
</asp:Content>

