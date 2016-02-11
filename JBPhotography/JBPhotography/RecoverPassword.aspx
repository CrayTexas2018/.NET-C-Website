<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="JBPhotography.RecoverPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class ="Center">
    <%if (isValid == true)
    {%>
        <ul>
        <li><asp:Label ID="Label1" runat="server" Text="Enter Email And New Password Below"></asp:Label></li>
        <li><asp:Label ID="ErrorLabel" runat="server" Text="" ForeColor="Red"></asp:Label></li>
        <li><asp:TextBox ID="EmailAddressTextBox" textmode="Email" placeholder="Email Address" runat="server"></asp:TextBox></li>
        <li><asp:TextBox ID="PasswordTextBox1" textmode="Password" placeholder="New Password" runat="server"></asp:TextBox></li>
        <li><asp:TextBox ID="PasswordTextBox2" textmode="Password" placeholder="Confirm New Password" runat="server"></asp:TextBox></li>
        <li><asp:Button ID="ChangeButton" runat="server" Text="Change Password" OnClick="ChangeButton_Click" /></li>
        </ul>
    <%} %>
    </div>
</asp:Content>
