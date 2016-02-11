<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="JBPhotography.EditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="Product" runat="server">
        <ul>
            <li><asp:Label ID="ProductIDLabel" runat="server" Text="Product: Error"></asp:Label></li>
            <li><asp:Label ID="ProductNameLabel" runat="server" Text="Product: Error"></asp:Label></li>
            <li><asp:TextBox ID="ProductNameTextBox" placeholder ="New Product Name" runat="server"></asp:TextBox></li>

            <li><asp:Label ID="ProductPriceLabel" runat="server" Text="Product: Error"></asp:Label></li>
            <li><asp:TextBox ID="ProductPriceTextBox" TextMode="Number" placeholder ="New Product Price" runat="server"></asp:TextBox></li>

            <li><asp:Label ID="ProductDescriptionLabel" runat="server" Text="Product: Error"></asp:Label></li>
            <li><asp:TextBox ID="ProductDescriptionTextBox" columns="75" textmode="MultiLine" height="120px" placeholder ="New Product Description" runat="server"></asp:TextBox></li>

            <li><asp:Label ID="ProductActiveLabel" runat="server" Text="Product: Error"></asp:Label></li>
            <asp:RadioButtonList ID="ProductActiveList" runat="server">
                <asp:ListItem Text="True" Value ="1"></asp:ListItem>
                <asp:ListItem Text="False" Value ="0"></asp:ListItem>
            </asp:RadioButtonList>
            <li><asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click" /></li>
            <br />
            <li><asp:CheckBox ID="DeleteCheckBox" Text="Confirm Delete" runat="server" OnCheckedChanged="DeleteCheckBox_CheckedChanged" /></li>
            <li><asp:Button ID="DeleteButton" runat="server" Text="Delete" OnClick="DeleteButton_Click"/></li>
        </ul>
        <br /><br />
        <asp:Table ID="AddonTable" runat="server" CssClass="CenterMargin">
            <asp:TableRow>
                <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>Display Name</asp:TableHeaderCell>
                <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                <asp:TableHeaderCell>Type</asp:TableHeaderCell>
                <asp:TableHeaderCell>Is Active</asp:TableHeaderCell>
                <asp:TableHeaderCell>Edit</asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
        <br /><br />
        <table>
            <tr><td><asp:Button ID="AddAddonButton" runat="server" Text="Add AddonProduct" OnClick="AddAddonButton_Click" /></td></tr>
        </table>
    </div>
</asp:Content>
