<%@ Page Title="Payment Success" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="PaymentSuccess.aspx.cs" Inherits="ProjetSportFinalHoussamEddineImhiouach.PaymentSuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Payment Successful!</h1>
    <p>
        Your membership payment has been successfully processed.<br />
        Thank you for choosing our club!
    </p>

    <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
    <br />
    <asp:Button ID="btnBackToDashboard" runat="server" Text="Back to Dashboard" OnClick="btnBackToDashboard_Click" />
</asp:Content>
