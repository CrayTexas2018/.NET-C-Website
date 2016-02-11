<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Checkout_StripePayment.aspx.cs" Inherits="JBPhotography.Checkout_StripePayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
    <table class="Center">

        <tr><td><h4>Please Press Pay With Card To Finalize Your Checkout And To Place Your Order:<br /><br /></h4></td></tr>
        
        <tr><td>
        <form action="?" method="POST">
            <script
            src="https://checkout.stripe.com/checkout.js" class="stripe-button"
            data-key="pk_xfeJlPTrorAK4StIG0NJnbuIl8RMN"
            data-amount="<%Response.Write(Session["ChargeTotalCents"]);%>"
            data-name="James Bruce Photography"
            data-description="Photography Package <%Response.Write(Session["ChargeTotal"]);%>"
            data-image="https://nicedeb.files.wordpress.com/2008/05/rt_redneck3_070709_ssh.jpg"
            data-locale="auto">
            </script>
        </form>
            </td></tr>
    </table>
</asp:Content>
