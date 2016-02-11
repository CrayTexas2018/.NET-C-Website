<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JBPhotography.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        li
        {
            margin-bottom:10px;
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:Panel ID="LoginPanel" runat="server" DefaultButton="LoginButton">
        <li><h2>Please Login, Create An Account, Or Continue As A Guest To Continue</h2></li>
            <p1><asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label></p1>
            <ul style="text-align:center;">
                <h3>Email Address:</h3>
                <li><asp:TextBox ID="EmailTextBox" Width="250px" placeholder ="Email Address" TextMode="Email" runat="server"></asp:TextBox></li>
                <h3>Password:</h3>
                <li><asp:TextBox ID="PasswordTextBox" Width="250px" placeholder ="Password" TextMode="Password" runat="server"></asp:TextBox></li>
                <li style ="text-align:center;"><asp:Button ID="LoginButton" runat="server" Width="200px" Text="Login" OnClick="LoginButton_Click" /></li>
                <li style ="text-align:center;"><asp:Button ID="CreateAccountButton" width="200px" runat="server" Text="Create Account" OnClick="CreateAccountButton_Click" /></li>
                <li><a href="ForgotPassword.aspx">Forgot Password</a></li>

                <li><h2>Or Continue As A Guest:</h2></li>

                <li style ="text-align:center;"><asp:Button ID="GuestButton" Width="200px" runat="server" Text="Continue As Guest" OnClick="GuestButton_Click"/></li>
            </ul>
    </asp:Panel>
</asp:Content>
