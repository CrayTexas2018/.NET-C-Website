<%@ Page Title="" Language="C#" MasterPageFile="~/MainTemplate.Master" AutoEventWireup="true" CodeBehind="Checkout_Property.aspx.cs" Inherits="JBPhotography.Checkout_Property" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
    <asp:Label ID="TopLabel" runat="server" Text=""></asp:Label>

    <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
    <table class="PropertyInfo">
            <tr>
                <td><h4>Property Information:</h4></td>
            </tr>
            <tr>
                <td>House Size (Sqare Feet):</td>
                <td><asp:TextBox ID="HouseSizeTextBox" MaxLength="8" runat="server" CssClass="textBox" AutoCompleteType="Disabled"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:RegularExpressionValidator id="RegularExpressionValidator1" ControlToValidate="HouseSizeTextBox" ValidationExpression="\d+" Display="Static" EnableClientScript="true" ErrorMessage="Please enter numbers without decimals only" runat="server"/></td>
            </tr>

            <tr>
                <td>Lot Size (Acres):</td>
                <td><asp:TextBox ID="LotSizeTextBox" MaxLength="8" Placeholder="Less than 2" AutoCompleteType="Disabled" CssClass="textBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:CompareValidator runat="server" ID="cValidator" ControlToValidate="LotSizeTextBox" Type="Double" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" /></td>
            </tr>

            <tr>
                <td>Approximate Listing Price:</td>
                <td><asp:TextBox ID="ListingPriceTextBox" MaxLength="8" AutoCompleteType="Disabled" CssClass="textBox" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:CompareValidator runat="server" ID="CompareValidator1" ControlToValidate="ListingPriceTextBox" Type="Currency" Operator="DataTypeCheck" EnableClientScript="true" ErrorMessage="Invalid format!" Display="Dynamic" /></td>
            </tr>

            <tr>
                <td>Property Address:</td>
                <td><asp:TextBox ID="HouseAddressTextBox" AutoCompleteType="Disabled" CssClass="textBox" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td><asp:Label ID="LockBoxCodeLabel" runat="server" Text="How To Access Property <br /> (Lockbox, gate, agent, owner)"></asp:Label></td>
                <td><asp:TextBox ID="LockBoxCodeTextBox" AutoCompleteType="Disabled" CssClass="textBox" runat="server" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>

            <tr><td><br /></td></tr>

        <tr>
            <td><h4>Contact Information</h4></td>
        </tr>

        <tr>
            <td><asp:Label ID="RealtorNameLabel" runat="server" Text="Realtor Name:"></asp:Label></td>
            <td><asp:TextBox ID="RealtorNameTextBox" AutoCompleteType="Disabled" CssClass="textBox"  runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td><asp:Label ID="RealtorEmailLabel" runat="server" Text="Realtor Email:"></asp:Label></td>
            <td><asp:TextBox ID="RealtorEmailTextBox" AutoCompleteType="Disabled" CssClass="textBox" TextMode="Email" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td><asp:Label ID="RealtorPhoneLabel" runat="server" Text="Realtor Phone Number:"></asp:Label></td>
            <td><asp:TextBox ID="RealtorPhoneTextBox" AutoCompleteType="Disabled" CssClass="textBox"  runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td><asp:Label ID="RealtorCompanyLabel" runat="server" Text="Realtor Company:"></asp:Label></td>
            <td><asp:TextBox ID="RealtorCompanyTextBox"  AutoCompleteType="Disabled" CssClass="textBox" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td><asp:Label ID="HomeOwnerNameLabel" runat="server" Text="Home Owner Name <br /> (If Agent Not Present):"></asp:Label></td>
            <td><asp:TextBox ID="HomeOwnerNameTextBox" AutoCompleteType="Disabled" CssClass="textBox" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td><asp:Label ID="HomeOwnerPhoneLabel" runat="server" Text="Home Owner Phone <br /> (If Agent Not Present):"></asp:Label></td>
            <td><asp:TextBox ID="HomeOwnerPhoneTextBox" AutoCompleteType="Disabled" CssClass="textBox" runat="server"></asp:TextBox></td>
        </tr>
    </table>

    <div class="Center">
        <br />
        <h4>Note To Photographer (If Applicable):</h4>
        <br />
        <asp:TextBox ID="NoteTextBox" runat="server" AutoCompleteType="Disabled" Height="100px" Width ="500px" TextMode="MultiLine"></asp:TextBox>
        <br /><br /><br />
    </div>

    <br />
    <asp:Button ID="ContinueButton" runat="server" Text="Continue To Next Step" CssClass="NextButton" OnClick="ContinueButton_Click" />
    <br /><br />
</asp:Content>
