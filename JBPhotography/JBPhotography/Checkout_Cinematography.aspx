<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Checkout_Cinematography.aspx.cs" Inherits="JBPhotography.Checkout_Cinematography" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
    <br />
    <br />
    <asp:Panel runat="server" ID="MyPanel">
        <asp:Table ID="ProductTable" runat="server"></asp:Table>
    </asp:Panel>

    <div class="NextButton"><asp:Button ID="ContinueButton" runat="server" Text="Continue To Next Step" OnClick="ContinueButton_Click" /></div>
</asp:Content>
