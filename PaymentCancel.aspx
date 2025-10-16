<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentCancel.aspx.cs" Inherits="ProjetSportFinalHoussamEddineImhiouach.PaymentCancel" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Cancelled</title>
</head>
<body>
    <h2>Payment Cancelled</h2>
    <p>Your payment has been cancelled. If this was a mistake, please try again.</p>
    <asp:Button ID="btnRetry" runat="server" Text="Retry Payment" OnClick="btnRetry_Click" />
</body>
</html>
