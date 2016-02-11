<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Admin_Products.aspx.cs" Inherits="JBPhotography.Admin_Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="text-align:center; margin-top:10px;">
        <div style="margin:auto; text-align:left;">
            <div class="Center" style="margin:0 auto;"><asp:Table ID="ProductTable" CssClass="ProductTable" Width="1000px" runat="server"></asp:Table></div>
            <asp:Button ID="AddProductButton" runat="server" Text="Add Product" OnClick="AddProductButton_Click" />
        </div>
    </div>
</asp:Content>
