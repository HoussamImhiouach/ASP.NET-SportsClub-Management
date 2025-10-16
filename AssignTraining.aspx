<%@ Page Title="Assign Training" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="AssignTraining.aspx.cs" Inherits="ProjetSportFinalHoussamEddineImhiouach.AssignTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="assign-training-container">
        <!-- Page Title -->
        <h1>Assign Training to Members</h1>
        <a href="EntraineurDashboard.aspx" class="btn btn-secondary">Back to Dashboard</a>

        <hr />

        <!-- Training Dropdown -->
        <div class="form-section">
            <label for="ddlTrainings">Select Training Session:</label>
            <asp:DropDownList ID="ddlTrainings" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>

        <!-- Members Checkbox List -->
        <div class="form-section">
            <label for="cblMembers">Select Members:</label>
            <asp:CheckBoxList ID="cblMembers" runat="server" CssClass="checkbox-list"></asp:CheckBoxList>
        </div>

        <!-- Submit Button -->
        <div class="form-actions">
            <asp:Button ID="btnAssignTraining" runat="server" Text="Assign Training" CssClass="btn btn-success" OnClick="btnAssignTraining_Click" />
        </div>

        <!-- Message Display -->
        <asp:Label ID="lblMessage" runat="server" CssClass="message-label" Visible="false"></asp:Label>

        <hr />

        <!-- Training Assignments Display -->
        <h2>Training Assignments</h2>
        <div class="assignments-table">
            <asp:Literal ID="ltTrainingAssignments" runat="server"></asp:Literal>
        </div>

        <!-- Logout Button -->
        <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-danger logout-btn" OnClick="btnLogout_Click" />
    </div>

    <!-- CSS Styling -->
    <style>
        .assign-training-container {
            margin: 50px auto;
            padding: 20px;
            width: 70%;
            background-color: #ffffff;
            border: 1px solid #ddd;
            border-radius: 10px;
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.2);
            font-family: Arial, sans-serif;
        }

        h1, h2 {
            color: #333;
            text-align: center;
            margin-bottom: 20px;
        }

        hr {
            border: 1px solid #ddd;
            margin: 20px 0;
        }

        .form-section {
            margin-bottom: 20px;
        }

        label {
            display: block;
            font-weight: bold;
            margin-bottom: 8px;
            color: #555;
        }

        .form-control {
            width: 100%;
            padding: 8px;
            font-size: 16px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .checkbox-list {
            margin-bottom: 20px;
        }

        .btn {
            display: inline-block;
            padding: 10px 20px;
            font-size: 16px;
            font-weight: bold;
            border: none;
            border-radius: 5px;
            color: #fff;
            cursor: pointer;
            text-decoration: none;
            text-align: center;
        }

        .btn-success {
            background-color: #28a745;
        }

        .btn-success:hover {
            background-color: #218838;
        }

        .btn-secondary {
            background-color: #6c757d;
        }

        .btn-secondary:hover {
            background-color: #5a6268;
        }

        .btn-danger {
            background-color: #dc3545;
        }

        .btn-danger:hover {
            background-color: #c82333;
        }

        .form-actions {
            text-align: center;
            margin-top: 20px;
        }

        .logout-btn {
            float: right;
            margin-top: 20px;
        }

        .message-label {
            display: block;
            text-align: center;
            font-weight: bold;
            color: #28a745;
            margin: 15px 0;
        }

        .assignments-table {
            margin-top: 20px;
            overflow-x: auto;
        }
    </style>
</asp:Content>
