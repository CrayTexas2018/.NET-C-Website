<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="NewUser.aspx.cs" Inherits="JBPhotography.NewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="Center"><h1>Complete Form Below To Create Account</h1></div>
        <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red"></asp:Label>
        <div class="NewUserForm">
            <ul>
                <li><p>Email Address:</p></li>
                <li><asp:TextBox ID="EmailTextBox" placeholder="Email Address" TextMode="Email" Columns="26" runat="server"></asp:TextBox></li>
                <li><p>Password:</p></li>
                <li><asp:TextBox ID="PasswordTextBox1" placeholder="Password" TextMode="Password" Columns="26" runat="server"></asp:TextBox></li>
                <li><p>Password Again:</p></li>
                <li><asp:TextBox ID="PasswordTextBox2" placeholder="Password" TextMode="Password" Columns="26" runat="server"></asp:TextBox></li>
                <li><p>First Name:</p></li>
                <li><asp:TextBox ID="FirstNameTextBox" placeholder="First Name" Columns="26" runat="server"></asp:TextBox></li>
                <li><p>Last Name:</p></li>
                <li><asp:TextBox ID="LastNameTextBox" placeholder="Last Name" Columns="26" runat="server"></asp:TextBox></li>
                <li><p>Phone Number:</p></li>
                <li><asp:TextBox ID="PhoneNumberTextBox" placeholder="Phone Number" TextMode="Phone" Columns="26" runat="server"></asp:TextBox></li>
                <li><p>Company:</p></li>
                <li><asp:TextBox ID="CompanyTextBox" placeholder="Company Name" Columns="26" runat="server"></asp:TextBox></li>
            </ul>
        </div>
    <div class="Center" style="padding-top:10px;"><asp:Button ID="CreateAccountButton" runat="server" Text="Create Account" OnClick="CreateAccountButton_Click" /></div>
</asp:Content>
