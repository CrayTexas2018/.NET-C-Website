<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="JBPhotography.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="Center">
        <ul>
            <li><asp:Label ID="ResponseLabel" runat="server" Text="Enter email below. If an account with this email exists, a reset link will be sent."></asp:Label></li>
            <li><asp:TextBox ID="EmailTextBox" TextMode="Email" placeholder ="Email Address" runat="server"></asp:TextBox></li>
            <li><asp:Button ID="ResetButton" runat="server" Text="Reset Password" OnClick="ResetButton_Click" /></li>
        </ul>
    </div>
</asp:Content>
