<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Checkout_Calendar.aspx.cs" Inherits="JBPhotography.Checkout_Calendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
   

    <!--<h1><object type="image/svg+xml" data="\Images\CheckoutPath\selectday.svg" width="700">Your browser does not support SVG</object></h1>-->
    <br />
    
    <table class="PropertyInfo">
        <tr><asp:Label ID="TopLabel" runat="server" Text=""></asp:Label></tr>
        <tr><td><br /></td></tr>
        <tr>
            <td><h4 style="text-align:center;">Available <%Response.Write("" + Session["isDay"]); %> Appointments</h4></td>
        </tr>
        <tr>
            <%if ("" + Session["isDay"] == "Daytime")
                {%>
            <script>
                var w = window.innerWidth;
                var h = window.innerHeight;
            </script>
            <td class="Center"><asp:Calendar ID="DaytimeCalendar" runat="server" OnDayRender="DaytimeCalendar_DayRender" width="800" OnSelectionChanged="DaytimeCalendar_SelectionChanged" Height="400px" ShowGridLines="True">
            <DayHeaderStyle BackColor="DarkGray" BorderColor="Black" Font-Overline="False" ForeColor="Red" />
            <DayStyle ForeColor="Black" />
            <TodayDayStyle Font-Bold="True" Font-Underline="True" />
        </asp:Calendar></td>
            <%}
    else if ("" + Session["isDay"] == "Twilight")
    { %>
            <td class="Center"><asp:Calendar ID="TwilightCalendar" runat="server" OnDayRender="TwilightCalendar_DayRender" Width ="800px" OnSelectionChanged="TwilightCalendar_SelectionChanged" Height="400px" ShowGridLines="True">
            <DayHeaderStyle BackColor="DarkGray" BorderColor="Black" Font-Overline="False" ForeColor="Red" />
            <DayStyle ForeColor="Black" />
            <TodayDayStyle Font-Bold="True" Font-Underline="True" />
        </asp:Calendar></td> <%} %>
        </tr>
    </table>

    <table class="Center">

        <tr>
            <td><asp:Image ID="Image1" runat="server" CssClass="Center" ImageUrl="~/Images/calendar.png" Width="800px" /></td>
        </tr>

        <tr>
            <td class="Center">
                <asp:Label ID="DaySelectedLabel" runat="server" Text=""><br /></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NextButton"><asp:Button ID="ContinueButton" runat="server" enabled="false" Text="Continue To Next Step" OnClick="ContinueButton_Click" CssClass="btn btn-primary"  /></td>
        </tr>   
    </table>
</asp:Content>
