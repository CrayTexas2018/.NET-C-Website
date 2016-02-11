<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="AddAddonProduct.aspx.cs" Inherits="JBPhotography.AddAddonProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <table>
        <tr><td><asp:Label ID="ProductNameLabel" runat="server" Text="Product Name"></asp:Label></td></tr>
        <tr><td><asp:TextBox ID="ProductNameTextBox" runat="server"></asp:TextBox></td></tr>

        <tr><td><asp:Label ID="ProductDisplayNameLabel" runat="server" Text="Product Display Name"></asp:Label></td></tr>
        <tr><td><asp:TextBox ID="ProductDisplayNameTextBox" runat="server"></asp:TextBox></td></tr>

        <tr><td><asp:Label ID="ProductPriceLabel" runat="server" Text="Product Price"></asp:Label></td></tr>
        <tr><td><asp:TextBox ID="ProductPriceTextBox" runat="server"></asp:TextBox></td></tr>

        <tr><td><asp:Label ID="ProductTypeLabel" runat="server" Text="Product Type"></asp:Label></td></tr>
        <tr><td><asp:TextBox ID="ProductTypeTextBox" runat="server"></asp:TextBox></td></tr>

        <tr><td><asp:Label ID="ProductActiveLabel" runat="server" Text="Is Active"></asp:Label></td></tr>
        <tr><td><asp:TextBox ID="ProductActiveTextBox" runat="server"></asp:TextBox></td></tr>

        <tr><td><asp:Button ID="SaveButton" runat="server" Text="Add Addon Product" OnClick="SaveButton_Click" /></td></tr>
    </table>
</asp:Content>
