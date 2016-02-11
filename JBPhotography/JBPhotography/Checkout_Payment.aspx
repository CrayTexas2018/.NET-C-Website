<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Checkout_Payment.aspx.cs" Inherits="JBPhotography.Checkout_Payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
    <br />
    <br />

    <table style="margin-left:100px; float:left;">
        <tr>
            <td>
                <asp:Table ID="ProductTable" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell BackColor ="DarkGray" ForeColor ="White">Product</asp:TableHeaderCell>
                        <asp:TableHeaderCell BackColor ="DarkGray" ForeColor ="White">Price</asp:TableHeaderCell>
                        <asp:TableHeaderCell BackColor ="DarkGray" ForeColor ="White">Remove</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </td>
    </table>
    <table style="margin-right:100px; float:right;">
            <td>
                <asp:Table ID="PropertyTable" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell BackColor ="DarkGray" ForeColor ="White">Property</asp:TableHeaderCell>
                        <asp:TableHeaderCell BackColor ="DarkGray" ForeColor ="White">Information</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </td>
        </tr>
        <tr>
            <td><a href="Checkout_Property.aspx" style="font-size:10px; text-align:center;">Click Here To Change Contract Or Property Information</a></td>
        </tr>
    </table>

    
    <table style="clear:both; margin-left:auto; margin-right:auto; text-align:center; padding-top:15px;">
        <tr><td><b>After Reviewing The Information Above, Press "Pay With Card" Below To Submit Your Order:</b></td></tr>
        <tr><td><b>Check The Following Item(s) to continue:</b></td></tr>
        <tr>
            <td>
                <asp:Label ID="ConfirmLabel" runat="server" Text="By checking the box, I confirm the information above was entered correctly:"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="ConfirmCheckBox" runat="server" />
            </td>
        </tr> 
        <tr>
            <td><asp:Button ID="ContinuePaymentButton" runat="server" Text="Continue To Checkout" OnClick="ContinuePaymentButton_Click1" /></td>
        </tr>
    </table>
</asp:Content>
