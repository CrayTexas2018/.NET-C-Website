<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="EditProductAddonOption.aspx.cs" Inherits="JBPhotography.EditProductAddonOption" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:Table ID="ProductTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
            <asp:TableHeaderCell>Product Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Display Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Price</asp:TableHeaderCell>
            <asp:TableHeaderCell>Order</asp:TableHeaderCell>
            <asp:TableHeaderCell>Is Active</asp:TableHeaderCell>
            <asp:TableHeaderCell>Edit</asp:TableHeaderCell>
        </asp:TableHeaderRow>

        <asp:TableRow ID="Row">
            <asp:TableCell><asp:Label ID="ProductIDLabel" runat="server" Text="Label"></asp:Label></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="ProductNameTextBox" runat="server"></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="ProductDisplayNameTextBox" runat="server"></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="ProductPriceTextBox" runat="server"></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="ProductOrderTextBox" TextMode ="Number" runat="server"></asp:TextBox></asp:TableCell>
            <asp:TableCell><asp:TextBox ID="ProductActiveTextBox" TextMode="Number" runat="server"></asp:TextBox></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
