<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Admin_SearchInvoice.aspx.cs" Inherits="JBPhotography.Admin_SearchInvoice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <table class =" Center">
        <tr><td><h3>Search Invoices:</h3></td></tr>
        <tr>
            <td>Type In Invoice Number Below To Search Invoices:</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="InvoiceTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="InvoiceButton" runat="server" Text="Search" OnClick="InvoiceButton_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
