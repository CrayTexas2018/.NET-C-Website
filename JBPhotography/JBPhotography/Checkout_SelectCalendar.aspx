<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Checkout_SelectCalendar.aspx.cs" Inherits="JBPhotography.Checkout_SelectCalendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <table class="Center">
        <tr>
            <td><asp:Button ID="DaytimeButton" runat="server" Text="Daytime Photography" OnClick="DaytimeButton_Click" /></td>
            <td><asp:Button ID="TwilightButton" runat="server" Text="Twilight Photography" OnClick="TwilightButton_Click" /></td>
        </tr>
    </table>
    </asp:Content>
