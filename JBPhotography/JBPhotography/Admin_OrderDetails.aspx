<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Admin_OrderDetails.aspx.cs" Inherits="JBPhotography.Admin_OrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <table>
        <tr>
            <td><asp:Button ID="RescheduleButton" runat="server" Text="Reschedule" OnClick="RescheduleButton_Click" /></td>
        </tr>
    </table>

    <asp:Table ID="Table1" runat="server" GridLines="Both">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right" Font-Bold="true">Invoice Number: </asp:TableCell>
            <asp:TableCell><asp:Label ID="InvoiceLabel" runat="server" Text="Invoice Label"></asp:Label></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right" Font-Bold="true">Email: </asp:TableCell>
            <asp:TableCell><asp:Label ID="EmailLabel" runat="server" Text="Email Label"></asp:Label></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right" Font-Bold="true">Name: </asp:TableCell>
            <asp:TableCell><asp:Label ID="NameLabel" runat="server" Text="Name Label"></asp:Label></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right" Font-Bold="true">Phone Number</asp:TableCell>
            <asp:TableCell><asp:Label ID="PhoneNumberLabel" runat="server" Text="Phone Number Label"></asp:Label></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right" Font-Bold="true">Company: </asp:TableCell>
            <asp:TableCell><asp:Label ID="CompanyLabel" runat="server" Text="Company Label"></asp:Label></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right" Font-Bold="true">Date Ordered: </asp:TableCell>
            <asp:TableCell><asp:Label ID="CreatedLabel" runat="server" Text="Created Label"></asp:Label></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right" Font-Bold="true">Order Scheduled: </asp:TableCell>
            <asp:TableCell><asp:Label ID="ScheduledLabel" runat="server" Text="Scheduled Label"></asp:Label></asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table ID="Table2" runat="server">
        <asp:TableRow>
            <asp:TableCell><%Response.Write("<br/><br/>" + Session["InvoiceTable"] + "<br/><br/>"); %></asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
