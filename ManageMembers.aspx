<%@ Page Title="Manage Members" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageMembers.aspx.cs" Inherits="ProjetSportFinalHoussamEddineImhiouach.ManageMembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="manage-members-container">
        <h1>👥 Member Management</h1>

        <!-- Add Member Form -->
        <h2>➕ Add Member</h2>
        <div class="add-member-form">
            <label>Full Name:</label>
            <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Enter full name"></asp:TextBox><br />

            <label>Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control" placeholder="Enter email"></asp:TextBox><br />

            <label>Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter password"></asp:TextBox><br />

            <label>Role:</label>
            <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control">
                <asp:ListItem Value="Member">Member</asp:ListItem>
                <asp:ListItem Value="Administrator">Administrator</asp:ListItem>
                <asp:ListItem Value="Entraineur">Entraineur</asp:ListItem>
                <asp:ListItem Value="President">President</asp:ListItem>
            </asp:DropDownList><br />

            <asp:Button ID="btnAddMember" runat="server" Text="Add Member" OnClick="btnAddMember_Click" CssClass="btn btn-green" />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" CssClass="error-message"></asp:Label>
        </div>

        <hr />

        <!-- Member List -->
        <h2>📋 All Members</h2>
        <table class="members-table">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Full Name</th>
                    <th>Email</th>
                    <th>Role</th>
                    <th>Date Registered</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                <asp:Literal ID="ltMemberRows" runat="server"></asp:Literal>
            </tbody>
        </table>

        <!-- Logout Button -->
        <div style="margin-bottom: 10px;">
    <asp:Button ID="btnAdminDashboard" runat="server" Text="Admin Dashboard" OnClick="btnAdminDashboard_Click" CssClass="btn btn-primary" />
    <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" CssClass="btn btn-danger" style="margin-left: 10px;" />
</div>

    </div>

    <!-- Styles for Manage Members -->
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f9fa;
        }

        .manage-members-container {
            max-width: 900px;
            margin: 50px auto;
            padding: 20px;
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
        }

        h1, h2 {
            color: #007bff;
            text-align: center;
        }

        hr {
            border: 0;
            border-top: 1px solid #ddd;
            margin: 20px 0;
        }

        .add-member-form {
            margin-bottom: 20px;
        }

        label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ccc;
            border-radius: 5px;
        }

        .btn {
            display: inline-block;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            text-decoration: none;
            color: red;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            margin-top: 10px;
        }

        .btn-green { background-color: #28a745; }
        .btn-green:hover { background-color: #218838; }

        .btn-yellow { background-color: #ffc107; }
        .btn-yellow:hover { background-color: #e0a800; }

        .btn-red { background-color: #dc3545; }
        .btn-red:hover { background-color: #c82333; }

        .error-message { color: #dc3545; font-weight: bold; }

        .members-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .members-table th, .members-table td {
            padding: 12px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }

        .members-table th {
            background-color: #007bff;
            color: white;
        }

        .members-table tr:hover {
            background-color: #f1f1f1;
        }

        .logout-btn {
            float: right;
            color:red;
        }
    </style>
</asp:Content>
