<%@ Page Title="President Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="PresidentDashboard.aspx.cs" Inherits="ProjetSportFinalHoussamEddineImhiouach.PresidentDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="dashboard-container">
        <h1 class="page-title">Welcome to the President Dashboard</h1>
        <p class="subtitle">Here are the latest statistics for your club:</p>
        <hr />

        <!-- Member Statistics -->
        <div class="stats-section">
            <h3>Total Members:</h3>
            <span class="stat-number"><asp:Label ID="lblTotalMembers" runat="server" Text="0"></asp:Label></span>
        </div>

        <!-- Revenue Statistics -->
        <div class="stats-section">
            <h3>Total Revenue: <span class="highlight">$<asp:Label ID="lblTotalRevenue" runat="server" Text="0"></asp:Label></span></h3>
            <h4>Revenue Breakdown:</h4>
            <ul>
                <li>Basic Plan: <span class="highlight">$<asp:Label ID="lblBasicRevenue" runat="server" Text="0"></asp:Label></span></li>
                <li>Premium Plan: <span class="highlight">$<asp:Label ID="lblPremiumRevenue" runat="server" Text="0"></asp:Label></span></li>
                <li>Premium+ Plan: <span class="highlight">$<asp:Label ID="lblPremiumPlusRevenue" runat="server" Text="0"></asp:Label></span></li>
            </ul>
        </div>

        <!-- Training Statistics -->
        <div class="stats-section">
            <h3>Training Statistics:</h3>
            <ul>
                <li>Total Training Sessions: <span class="highlight"><asp:Label ID="lblTotalTrainings" runat="server" Text="0"></asp:Label></span></li>
                <li>Upcoming Training Sessions: <span class="highlight"><asp:Label ID="lblUpcomingTrainings" runat="server" Text="0"></asp:Label></span></li>
            </ul>
        </div>

        <!-- Latest Payment -->
        <div class="stats-section">
            <h3>Latest Payment:</h3>
            <span class="highlight"><asp:Label ID="lblLatestPaymentDate" runat="server" Text="N/A"></asp:Label></span>
        </div>

        <hr />
        <!-- Logout Button -->
        <div class="button-container">
            <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-danger" />
        </div>
    </div>

    <!-- CSS Styles -->
    <style>
        .dashboard-container {
            margin: 20px auto;
            padding: 20px;
            width: 80%;
            background-color: #f8f9fa;
            border: 1px solid #ddd;
            border-radius: 8px;
            box-shadow: 0 0 8px rgba(0, 0, 0, 0.1);
        }

        .page-title {
            color: #333;
            font-size: 28px;
            text-align: center;
            margin-bottom: 10px;
        }

        .subtitle {
            text-align: center;
            font-size: 18px;
            color: #777;
        }

        .stats-section {
            margin-bottom: 20px;
        }

        h3, h4 {
            color: #007bff;
        }

        .highlight {
            color: #28a745;
            font-weight: bold;
        }

        .stat-number {
            font-size: 24px;
            font-weight: bold;
            color: #343a40;
        }

        ul {
            list-style-type: none;
            padding-left: 0;
        }

        li {
            margin: 5px 0;
            font-size: 16px;
        }

        .button-container {
            text-align: center;
            margin-top: 20px;
        }

        .btn {
            padding: 8px 16px;
            font-size: 16px;
            cursor: pointer;
            border: none;
            border-radius: 4px;
        }

        .btn-danger {
            background-color: #dc3545;
            color: white;
        }

        .btn-danger:hover {
            background-color: #c82333;
        }
    </style>
</asp:Content>
