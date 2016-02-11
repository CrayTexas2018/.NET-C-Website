<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="JBPhotography.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <table>
        <tr><td><asp:Label ID="ProductNameLabel" runat="server" Text="Product Name:"></asp:Label></td></tr>
        <tr><td><asp:TextBox ID="ProductNameTextBox" runat="server"></asp:TextBox></td></tr>

         <tr><td><asp:Label ID="ProductDisplayNameLabel" runat="server" Text="Product Display Name:"></asp:Label></td></tr>
        <tr><td><asp:TextBox ID="ProductDisplayNameTextBox" runat="server"></asp:TextBox></td></tr>

         <tr><td><asp:Label ID="ProductPriceLabel" runat="server" Text="Product Price:"></asp:Label></td></tr>
        <tr><td><asp:TextBox ID="ProductPriceTextBox" runat="server"></asp:TextBox></td></tr>

         <tr><td><asp:Label ID="ProductDescriptionLabel" runat="server" Text="Product Description"></asp:Label></td></tr>
        <tr><td><asp:TextBox ID="ProductDescriptionTextBox" runat="server"></asp:TextBox></td></tr>

         <tr><td><asp:Label ID="IsActiveLabel" runat="server" Text="Is Active:"></asp:Label></td></tr>
        <tr><td><asp:TextBox ID="IsActiveTextBox" runat="server"></asp:TextBox></td></tr>\

        <tr><td><asp:Button ID="SaveButton" runat="server" Text="Add Product" OnClick="SaveButton_Click" /></td></tr>
    </table>
</asp:Content>
