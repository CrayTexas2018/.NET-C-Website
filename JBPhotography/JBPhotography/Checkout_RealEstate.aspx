<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Checkout_RealEstate.aspx.cs" Inherits="JBPhotography.Checkout_RealEstate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!--<h1><object type="image/svg+xml" data="\Images\CheckoutPath\selectday.svg" width="700">Your browser does not support SVG</object></h1>-->
    <br />
    <asp:Panel runat="server" ID="MyPanel">
        <asp:Label ID="TopLabel" runat="server" Text=""></asp:Label>
        <h4></h4>
        <asp:Table ID="ProductTable" runat="server"></asp:Table>
    </asp:Panel>

    <div class="NextButton"><asp:Button ID="ContinueButton" runat="server" Text="Continue To Next Step" OnClick="ContinueButton_Click" /></div>
</asp:Content>
