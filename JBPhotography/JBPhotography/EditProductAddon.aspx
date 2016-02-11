<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="EditProductAddon.aspx.cs" Inherits="JBPhotography.EditProductAddon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <table>
        <tr><td><asp:Label ID="ProductIDLabel" runat="server" Text="Product ID:"></asp:Label></td></tr>
        
        <tr><td><asp:Label ID="ProductNameLabel" runat="server" Text="Product Name"></asp:Label></td></tr>
        <tr><td><asp:TextBox ID="ProductNameTextBox" runat="server"></asp:TextBox></td></tr>

        <tr><td><asp:Label ID="ProductDisplayNameLabel" runat="server" Text="Product Display Name"></asp:Label></td></tr>
        <tr><td><asp:TextBox ID="ProductDisplayNameTextBox" runat="server"></asp:TextBox></td></tr>

        <tr><td><asp:Label ID="ProductPriceLabel" runat="server" Text="Product Price"></asp:Label></td></tr>
        <tr><td><asp:TextBox ID="ProductPriceTextBox" runat="server"></asp:TextBox></td></tr>

        <tr><td><asp:Label ID="ProductTypeLabel" runat="server" Text="Product Type"></asp:Label></td></tr>
        <tr><td><asp:TextBox ID="ProductTypeTextbox" runat="server"></asp:TextBox></td></tr>

        <tr><td><asp:Label ID="ProductActiveLabel" runat="server" Text="Product Active"></asp:Label></td></tr>
        <tr><td><asp:TextBox ID="ProductActiveTextBox" runat="server"></asp:TextBox></td></tr>

        <tr><td><asp:Button ID="SaveButton" runat="server" Text="Save Changes" OnClick="SaveButton_Click" /></td></tr>

    </table>

    <asp:Table ID="AddonTable" runat="server">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
            <asp:TableHeaderCell>Product Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Display Name</asp:TableHeaderCell>
            <asp:TableHeaderCell>Price</asp:TableHeaderCell>
            <asp:TableHeaderCell>Display Order</asp:TableHeaderCell>
            <asp:TableHeaderCell>Is Active</asp:TableHeaderCell>
            <asp:TableHeaderCell>Edit</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>

    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell><asp:Button ID="AddButton" runat="server" Text="Add Addon Value" OnClick="AddButton_Click" /></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
