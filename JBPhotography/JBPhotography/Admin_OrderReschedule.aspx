<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Admin_OrderReschedule.aspx.cs" Inherits="JBPhotography.Admin_OrderReschedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <table class="Center">
        <tr>
            <td>
                <asp:TextBox ID="startTextBox" Placeholder="Start" runat="server"></asp:TextBox><br />
            </td>
            <td>
                <asp:TextBox ID="endTextBox" Placeholder="End" runat="server"></asp:TextBox><br />
            </td>
        </tr>
    </table>

    <table class ="Center">
        <tr>
            <td>
                <asp:Button ID="FindOrdersButton" runat="server" Text="Find Orders" OnClick="FindOrdersButton_Click" /><br />
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
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
