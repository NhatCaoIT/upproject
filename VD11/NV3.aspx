<%@ Page Title="" Language="C#" MasterPageFile="~/NhanVien.master" AutoEventWireup="true" CodeBehind="NV3.aspx.cs" Inherits="VD11.NV3" %>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <p>
    ---------Đây là phần chính của trang web NV3</p>
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
            <td>Hình ảnh:</td><td>
            
            <asp:FileUpload ID="FileUploadControl" runat="server" OnLoad="FileUploadControl_Load" />
                <!--Đoạn này giúp chọn file hình ảnh có đuôi JPG -->
<asp:RegularExpressionValidator ID="regexValidator" runat="server"
     ControlToValidate="FileUploadControl"
     ErrorMessage="Only JPEG images are allowed" 
     ValidationExpression="(.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])$)">
</asp:RegularExpressionValidator>
                <!--End: Đoạn này giúp chọn file hình ảnh có đuôi JPG -->
            </td>
        </tr>
    </table>
    <asp:Label ID="lThongBao" runat="server" Text="Chỗ hiện thông báo!!!"></asp:Label>
    <br />
    <asp:Button ID="bThemMoi" runat="server" OnClick="bThemMoi_Click" Text="Thêm" />
    <br />
    <p>
        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
        
        <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" Width="4px" RepeatColumns="3">
            <ItemTemplate>
                <asp:Table ID="Table1" runat="server">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">
                    ID: <asp:Label ID="lId" runat="server" Text='<%# Eval("ID") %>'></asp:Label><br />
                    Tên:        <asp:Label ID="lTenHang" runat="server" Text='<%# Eval("ten") %>'></asp:Label><br />
                    Loại:        <asp:Label ID="lLoaiHang" runat="server" Text='<%# Eval("maTheLoai") %>'></asp:Label>

                        </asp:TableCell>
                        <asp:TableCell runat="server">
                            <asp:Image ID="hinhAnh" runat="server" Height="90" Width="60" ImageUrl='<%#Bind("hinhAnh","~/files/img/{0}")%>' />

                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </ItemTemplate>
        </asp:DataList>
    </p>
</asp:Content>

