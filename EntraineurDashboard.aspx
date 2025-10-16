<%@ Page Title="Entraineur Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="EntraineurDashboard.aspx.cs" Inherits="ProjetSportFinalHoussamEddineImhiouach.EntraineurDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="dashboard-container">
        <h1>Entraineur Dashboard</h1>

        <!-- Navigation Links -->
        <div class="nav-links">
            <a href="SendMessage.aspx" class="btn btn-primary">Send Message</a>
            <a href="ViewMessages.aspx" class="btn btn-primary">View Messages</a>
            <a href="ManageTraining.aspx" class="btn btn-success">Training Management</a>
            <a href="AssignTraining.aspx" class="btn btn-warning">Training Assignment</a>
        </div>

        <!-- Training Sessions Table -->
        <div class="table-container">
            <h3>Your Training Sessions</h3>
            <table class="training-table">
                <thead>
                    <tr>
                        <th>Training Name</th>
                        <th>Training Date</th>
                        <th>Attendance</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Literal ID="ltTrainingSessions" runat="server"></asp:Literal>
                </tbody>
            </table>
        </div>

        <!-- Attendance Action -->
        <div class="attendance-actions">
            <asp:Button ID="btnSaveAttendance" runat="server" Text="Save Attendance" CssClass="btn btn-success" OnClick="btnSaveAttendance_Click" />
            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
        </div>

        <!-- Logout -->
        <div class="logout-section">
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-danger" OnClick="btnLogout_Click" />
        </div>
    </div>

    <!-- Inline CSS for Styling -->
    <style>
        .dashboard-container {
            font-family: Arial, sans-serif;
            margin: 20px auto;
            width: 90%;
        }

        h1, h3 {
            text-align: center;
            color: #333;
        }

        .nav-links {
            text-align: center;
            margin-bottom: 20px;
        }

        .btn {
            display: inline-block;
            padding: 10px 15px;
            margin: 5px;
            text-decoration: none;
            font-size: 14px;
            border-radius: 5px;
            color: white;
        }

        .btn-primary {
            background-color: #007bff;
        }

        .btn-primary:hover {
            background-color: #0056b3;
        }

        .btn-success {
            background-color: #28a745;
        }

        .btn-success:hover {
            background-color: #218838;
        }

        .btn-warning {
            background-color: #ffc107;
            color: #333;
        }

        .btn-warning:hover {
            background-color: #e0a800;
        }

        .btn-danger {
            background-color: #dc3545;
        }

        .btn-danger:hover {
            background-color: #c82333;
        }

        .table-container {
            margin: 20px auto;
            width: 100%;
        }

        .training-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
        }

        .training-table th, .training-table td {
            padding: 12px;
            border: 1px solid #ddd;
            text-align: center;
        }

        .training-table th {
            background-color: #007bff;
            color: white;
        }

        .training-table tr:hover {
            background-color: #f1f1f1;
        }

        .attendance-actions {
            text-align: center;
            margin-top: 20px;
        }

        .logout-section {
            text-align: right;
            margin-top: 20px;
        }
    </style>
</asp:Content>
