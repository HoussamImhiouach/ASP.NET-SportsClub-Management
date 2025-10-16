<%@ Page Title="Member Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="MemberDashboard.aspx.cs" Inherits="ProjetSportFinalHoussamEddineImhiouach.MemberDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .btn {
    padding: 8px 15px;
    border-radius: 5px;
    text-decoration: none;
    font-weight: bold;
    transition: background-color 0.3s ease;
}

.btn-primary {
    background-color: #007bff;
    color: white;
}

.btn-primary:hover {
    background-color: #0056b3;
}

.btn-info {
    background-color: #17a2b8;
    color: white;
}

.btn-info:hover {
    background-color: #138496;
}

.btn-danger {
    background-color: #dc3545;
    color: white;
}

.btn-danger:hover {
    background-color: #c82333;
}
.btn {
    padding: 5px 10px;
    text-decoration: none;
    border-radius: 5px;
    transition: background-color 0.3s ease;
    color: white;
    font-weight: bold;
}

.btn-success {
    background-color: #28a745;
}

.btn-success:hover {
    background-color: #218838;
}

.btn-primary {
    background-color: #007bff;
}

.btn-primary:hover {
    background-color: #0056b3;
}

table {
    width: 100%;
    border-collapse: collapse;
}

th, td {
    padding: 12px; /* Adjust padding for spacing */
    text-align: center;
    border: 1px solid #ddd;
    word-wrap: break-word; /* Prevent text overlap */
}

th {
    background-color: #f2f2f2;
    font-weight: bold;
}

tr:nth-child(even) {
    background-color: #f9f9f9; /* Alternate row colors for readability */
}

tr:hover {
    background-color: #f1f1f1; /* Hover effect */
}

.btn {
    display: inline-block; /* Ensure buttons stay in line */
    margin: 2px; /* Add margin to separate buttons */
    padding: 6px 10px; /* Adjust button padding */
    font-size: 14px;
    text-decoration: none;
    border-radius: 5px;
    color: white;
    transition: background-color 0.3s ease;
}

.btn-primary {
    background-color: #007bff;
}

.btn-primary:hover {
    background-color: #0056b3;
}


    </style>
    <h1>Welcome to the Member Dashboard</h1>
    <div>
        <a href="SendMessage.aspx" class="btn btn-primary">Send Message</a>
        <a href="ViewMessages.aspx" class="btn btn-info">View Messages</a>
    </div>

    <!-- Payment Status -->
    <div style="margin-top: 20px;">
        <asp:Label ID="lblPaymentStatus" runat="server" Text="" Font-Bold="true"></asp:Label>
        <asp:Button ID="btnProceedToPayment" runat="server" Text="Proceed to Payment" OnClick="btnProceedToPayment_Click" Visible="false" CssClass="btn btn-danger" />
    </div>

    <hr />

    <!-- Training Sessions Table -->
    <h3>Your Training Sessions</h3>
    <table border="1" style="width: 100%; border-collapse: collapse; text-align: center;">
        <tr style="background-color: #f2f2f2; font-weight: bold;">
            <th>Training Name</th>
            <th>Training Date</th>
            <th>Attendance</th>
            <th>Actions</th>
        </tr>
        <asp:Literal ID="ltTrainingSessions" runat="server"></asp:Literal>
    </table>

    <br />
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-info" Font-Bold="true"></asp:Label>

    <!-- Logout Button -->
    <br />
    <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-danger" />
</asp:Content>
