<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Admin_EditDescription.aspx.cs" ValidateRequest="false" Inherits="JBPhotography.Admin_EditDescription" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="//cdn.tinymce.com/4/tinymce.min.js"></script>
  <script>tinymce.init({ selector:'textarea' });</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div id="Product" runat="server">
        <ul>
            <li><asp:Label ID="DescIDLabel" runat="server" Text="Description ID: "></asp:Label></li>
            <li><asp:Label ID="DescNameLabel" runat="server" Text="Product: Error"></asp:Label></li>
            <li><asp:TextBox ID="DescNameTextBox" width="200px" placeholder ="New description Name" runat="server"></asp:TextBox></li>

            <li><asp:Label ID="DescriptionLabel" runat="server" Text="Product: Error"></asp:Label></li>
            <li><asp:TextBox ID="DescriptionTextBox" columns="75" textmode="MultiLine" height="120px" placeholder ="New Product Description" runat="server"></asp:TextBox></li>

            <li><asp:Label ID="DescActiveLabel" runat="server" Text="Product Active: "></asp:Label></li>
            <asp:RadioButtonList ID="DescActiveList" runat="server">
                <asp:ListItem Text="True" Value ="1"></asp:ListItem>
                <asp:ListItem Text="False" Value ="0"></asp:ListItem>
            </asp:RadioButtonList>    

            <br /><br />

            <asp:Button ID="SaveButton" runat="server" Text="Save Changes" OnClick="SaveButton_Click" />        
    </div>
</asp:Content>
