<%@ Page Title="Administrator Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="ProjetSportFinalHoussamEddineImhiouach.AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="admin-container">
        <h1>Welcome, Administrator!</h1>

        <!-- Quick Navigation Links -->
        <div class="quick-links">
            <a href="SendMessage.aspx" class="btn btn-blue">Send Message</a>
            <a href="ViewMessages.aspx" class="btn btn-blue">View Messages</a>
        </div>

        <hr />

        <!-- Statistics Section -->
        <h2>📊 Statistics</h2>
        <div class="stats">
            <p>Total Members: <span class="stat-number"><asp:Label ID="lblTotalMembers" runat="server"></asp:Label></span></p>
            <p>Total Training Sessions: <span class="stat-number"><asp:Label ID="lblTotalTrainings" runat="server"></asp:Label></span></p>
        </div>

        <hr />

        <!-- Quick Links Section -->
        <h2>⚡ Quick Links</h2>
        <ul class="quick-links-list">
            <li><a href="ManageMembers.aspx" class="link-btn">Manage Members</a></li>
            <li><a href="ManageTraining.aspx" class="link-btn">Manage Training Sessions</a></li>
        </ul>

        <!-- Logout Button -->
        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-red logout-btn" />
    </div>

    <!-- Styles for Admin Dashboard -->
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f8f9fa;
            color: #333;
        }

        .admin-container {
            max-width: 900px;
            margin: 50px auto;
            padding: 20px;
            background: #fff;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
        }

        h1 {
            text-align: center;
            color: #007bff;
            font-size: 28px;
        }

        h2 {
            color: #343a40;
            margin-bottom: 10px;
        }

        hr {
            border: 0;
            border-top: 1px solid #ddd;
            margin: 20px 0;
        }

        /* Quick Links */
        .quick-links {
            text-align: center;
            margin-bottom: 20px;
        }

        .btn {
            display: inline-block;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            text-decoration: none;
            color: white;
            font-size: 16px;
            cursor: pointer;
            margin: 5px;
            transition: background-color 0.3s ease;
        }

        .btn-blue {
            background-color: #007bff;
        }

        .btn-blue:hover {
            background-color: #0056b3;
        }

        .btn-red {
            background-color: #dc3545;
        }

        .btn-red:hover {
            background-color: #c82333;
        }

        /* Statistics */
        .stats p {
            font-size: 18px;
            margin: 10px 0;
        }

        .stat-number {
            font-weight: bold;
            color: #28a745;
        }

        /* Quick Links List */
        .quick-links-list {
            list-style-type: none;
            padding: 0;
            margin: 10px 0;
        }

        .quick-links-list li {
            margin: 10px 0;
        }

        .link-btn {
            color: #007bff;
            text-decoration: none;
            font-size: 18px;
            transition: color 0.3s ease;
        }

        .link-btn:hover {
            color: #0056b3;
            text-decoration: underline;
        }

        /* Logout Button */
        .logout-btn {
            float: right;
        }
    </style>
</asp:Content>
