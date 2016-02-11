<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Admin_Descriptions.aspx.cs" Inherits="JBPhotography.Admin_Descriptions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h3>Click edit below to change any of the descriptions</h3>
    <br />
    <br />
    <asp:table ID="descTable" runat="server" CssClass="Center" GridLines="Both" Width="1000px"></asp:table>
</asp:Content>
