﻿<%@ Page Title="" Language="C#" MasterPageFile="~/NhanVien.master" AutoEventWireup="true" CodeBehind="NV1.aspx.cs" Inherits="VD.NV1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging">
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
