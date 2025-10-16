<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="ProjetSportFinalHoussamEddineImhiouach.Payment" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Select Your Membership Plan</h2>
        
        <!-- RadioButtonList for Plans -->
        <asp:RadioButtonList ID="rblPlans" runat="server">
    <asp:ListItem Value="Basic|100">Basic Plan - $100</asp:ListItem>
    <asp:ListItem Value="Premium|250">Premium Plan - $250</asp:ListItem>
    <asp:ListItem Value="PremiumPlus|300">Premium+ Plan - $300</asp:ListItem>
</asp:RadioButtonList>


        <!-- Message Label -->
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <br /><br />

        <!-- PayPal Payment Button -->
        <asp:Button ID="btnPayPal" runat="server" Text="Proceed to PayPal" OnClick="btnPayPal_Click" />
    </form>
</body>
</html>