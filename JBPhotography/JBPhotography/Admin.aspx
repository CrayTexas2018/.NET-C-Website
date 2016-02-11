<%@ Page Title="Test" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="JBPhotography.AdminPages.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h1>Admin Page</h1>
    <ul>
        <li>Front Facing:</li>
            <ul>
                <li><a href="Admin_Products.aspx">Products</a></li>
                <li><a href="Admin_Descriptions.aspx">Descriptions</a></li>
            </ul>
        <li>Orders:</li>
            <ul>
                <li><a href="Admin_Orders.aspx">Upcoming Orders</a></li>
                <li><a href="Admin_searchinvoice.aspx">Search By Invoice</a></li>
            </ul>
        <li>Schedule:</li>
            <ul>
                <li><a href="Admin_searchinvoice.aspx">Today's Schedule</a></li>
                <li><a href="Admin_searchinvoice.aspx">Tomorrow's Schedule</a></li>
                <li><a href="Admin_searchinvoice.aspx">View Schedule</a></li>
            </ul>
        <li>Revenue:</li>
            <ul>
                <li><a href="Admin_searchinvoice.aspx">Today's Revenue</a></li>
                <li><a href="Admin_searchinvoice.aspx">Tomorrow's Revenue</a></li>
                <li><a href="Admin_searchinvoice.aspx">Weekly Revenue</a></li>
                <li><a href="Admin_searchinvoice.aspx">Monthly Revenue</a></li>
                <li><a href="Admin_searchinvoice.aspx">Quarterly Revenue</a></li>
                <li><a href="Admin_searchinvoice.aspx">Annual Revenue</a></li>
            </ul>
        <li>Expenses:</li>
            <ul>
                <li><a href="Admin_searchinvoice.aspx">Weekly Expense</a></li>
                <li><a href="Admin_searchinvoice.aspx">Monthly Expense</a></li>
                <li><a href="Admin_searchinvoice.aspx">Quarterly Expense</a></li>
                <li><a href="Admin_searchinvoice.aspx">Yearly Expense</a></li>
            </ul>
    </ul>
    
</asp:Content>
