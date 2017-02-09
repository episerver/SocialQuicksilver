﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfigControl.ascx.cs" Inherits="Apps_Marketing_Promotions_FixedShippingChargeForOrderSubtotal" %>
<table class="DataForm">
    <tr>
        <td colspan="2" class="FormFieldCell">
            <b><i><asp:Label ID="lblDescription" runat="server"></asp:Label></i></b><br /><br />
        </td>
    </tr>
    <tr>
        <td colspan="2" class="FormSpacerCell">
        </td>
    </tr>
    <tr>
        <td class="FormLabelCell">
            <span>Order Subtotal: </span></td>
        <td class="FormFieldCell">
            <asp:TextBox ID="txtOrderTotal" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvOrderTotal" runat="server" ControlToValidate="txtOrderTotal" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvOrderTotal" runat="server" ValueToCompare="-1" ControlToValidate="txtOrderTotal" 
	            ErrorMessage="Must enter a positive decimal value" Operator="GreaterThan" Type="Double"></asp:CompareValidator> 
        </td>
    </tr>
    <tr>
        <td colspan="2" class="FormSpacerCell">
        </td>
    </tr>
    <tr>
        <td class="FormLabelCell">
            <span>Shipping Method: </span></td>
        <td class="FormFieldCell">
            <asp:DropDownList ID="ddlShippingMethods" runat="server" DataTextField="DisplayName" DataValueField="ShippingMethodId"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="2" class="FormSpacerCell">
        </td>
    </tr>    
    <tr>
        <td class="FormLabelCell">
            <span>Shipping Charge: </span></td>
        <td class="FormFieldCell">
            <asp:TextBox ID="txtCharge" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rqvDiscount" runat="server" ControlToValidate="txtCharge" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvDiscount" runat="server" ValueToCompare="-1" ControlToValidate="txtCharge" 
	            ErrorMessage="Must enter a positive decimal value" Operator="GreaterThan" Type="Double"></asp:CompareValidator> 
        </td>
    </tr>
    <tr>
        <td colspan="2" class="FormSpacerCell">
        </td>
    </tr>    
</table>
