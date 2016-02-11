<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="ConfirmPasswordSent.aspx.cs" Inherits="JBPhotography.ConfirmPasswordSent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="refresh" content="5; url=Default.aspx" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="Center">
        <ul>
            <li><p>Email Sending. Please allow up to 5 minutes for the email to send.</p></li>
            <li><p>This Page Will Automatically Redirect In 5 Seconds</p></li>
            <li><a href="Default.aspx">Click Here If Page Does Not Refresh</a></li>
        </ul>
    </div>
</asp:Content>
