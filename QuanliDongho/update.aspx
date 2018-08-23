<%@ Page Title="" Language="C#" MasterPageFile="~/Quanli.master" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="QuanliDongho.update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="q" runat="server">



   
    <p>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        Nhap ID mau san pham ban muon update :</p>
    <p style="margin-left: 200px">

        ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="ID" runat="server" Width="135px"></asp:TextBox>
    </p>
    <p>

        &nbsp;</p>
    <p style="margin-left: 80px">

        &nbsp; Nhap thong tin moi cho san pham:&nbsp;</p>
    <p style="margin-left: 360px">
        ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="ID1" runat="server" Width="137px"></asp:TextBox>
    </p>
    <p style="margin-left: 360px">
        Hang&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="hang" runat="server" Width="138px"></asp:TextBox>
    </p>
    <p style="margin-left: 360px">
        Mau sac&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="mausac" runat="server" Width="135px"></asp:TextBox>
    </p>
    <p style="margin-left: 360px">
        Gia&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="gia" runat="server" style="margin-left: 0px" Width="135px"></asp:TextBox>
    </p>
    <p style="margin-left: 280px">
       
    </p>
     <div>
        <asp:Label ID="lThongBao" runat="server" Text=" "></asp:Label>
        </div>
        <asp:Button ID="bCapNhat" runat="server" OnClick="bCapNhat_Click" Text="Update" style="margin-left: 657px" />
    </br>
   
    <div>
    </div>



</asp:Content>
