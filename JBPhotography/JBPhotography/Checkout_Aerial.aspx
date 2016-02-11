<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Checkout_Aerial.aspx.cs" Inherits="JBPhotography.Checkout_Aerial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
    <br />
    <asp:Panel runat="server" ID="MyPanel">
        <asp:Label ID="TopLabel" runat="server" Text=""></asp:Label>
        <asp:Table ID="ProductTable" runat="server"></asp:Table>
    </asp:Panel>

    <div class="NextButton"><asp:Button ID="ContinueButton" runat="server" Text="Continue To Next Step" OnClick="ContinueButton_Click" /></div>
</asp:Content>
