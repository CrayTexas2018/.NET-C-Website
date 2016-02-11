<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="AddProductAddonValue.aspx.cs" Inherits="JBPhotography.AddProductAddonValue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <table>
        <tr><td>Product Name</td></tr>
        <tr><td><asp:TextBox ID="ProductNameTextBox" runat="server"></asp:TextBox></td></tr>

        <tr><td>Display Name</td></tr>
        <tr><td><asp:TextBox ID="ProductDisplayNameTextBox" runat="server"></asp:TextBox></td></tr>

        <tr><td>Price</td></tr>
        <tr><td><asp:TextBox ID="ProductPriceTextBox" runat="server"></asp:TextBox></td></tr>

        <tr><td>Order</td></tr>
        <tr><td><asp:TextBox ID="ProductOrderTextBox" runat="server"></asp:TextBox></td></tr>

        <tr><td>Is Active:</td></tr>
        <tr><td><asp:TextBox ID="ProductIsActive" runat="server"></asp:TextBox></td></tr>

        <tr><td><asp:Button ID="SaveButton" runat="server" Text="Add Product" OnClick="SaveButton_Click" /></td></tr>
    </table>
</asp:Content>
