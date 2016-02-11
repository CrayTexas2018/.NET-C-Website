<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Admin_Orders.aspx.cs" Inherits="JBPhotography.Admin_Orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 259px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <table class="Center">
        <tr>
            <td>
                <asp:Button ID="FindOrdersButton" runat="server" Text="Find Orders" OnClick="FindOrdersButton_Click" />
            </td>
        </tr>
    </table>

    <table class ="Center">
        <tr>
            <td>
                <asp:TextBox ID="startTextBox" runat="server"></asp:TextBox>
                <asp:TextBox ID="endTextBox" runat="server"></asp:TextBox>
                <br />
            </td>
        </tr>

        <tr>
            <td>
                <asp:CheckBox ID="TwilightCheckbox" runat="server" OnCheckedChanged="TwilightCheckbox_CheckedChanged" /> Twilight? <br />
            </td>
        </tr>
    </table>

    <table class="Center">
        <tr>
            <td>
                <asp:Calendar ID="startDateCalendar" runat="server" OnSelectionChanged="startDateCalendar_SelectionChanged" OnDayRender="startDateCalendar_DayRender">
                    <TodayDayStyle Font-Underline="True" />
                </asp:Calendar>
            </td>
            <td class="auto-style1">
                <asp:Calendar ID="endDateCalendar" runat="server" OnSelectionChanged="endDateCalendar_SelectionChanged" OnDayRender="endDateCalendar_DayRender">
                    <TodayDayStyle Font-Underline="True" />
                </asp:Calendar>
            </td>
        </tr>
    </table>

    <asp:Table ID="OrderTable" runat="server" GridLines="Both"></asp:Table>

    
</asp:Content>
