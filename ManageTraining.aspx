<%@ Page Title="Manage Trainings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ManageTraining.aspx.cs" Inherits="ProjetSportFinalHoussamEddineImhiouach.ManageTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="manage-training-container">
        <h1>Manage Trainings</h1>


        <!-- Add Training Section -->
        <div class="section">
            <h3>Add Training</h3>
            <div class="form-group">
                <label for="txtTrainingName">Training Name:</label>
                <asp:TextBox ID="txtTrainingName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtTrainingDate">Training Date:</label>
                <asp:TextBox ID="txtTrainingDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="btnAddTraining" runat="server" Text="Add Training" CssClass="btn btn-success" OnClick="btnAddTraining_Click" />
        </div>

        <hr />

        <!-- Assign Member Section -->
        <div class="section">
            <h3>Assign Member to Training</h3>
            <div class="form-group">
                <label for="ddlTrainings">Select Training:</label>
                <asp:DropDownList ID="ddlTrainings" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="ddlMembers">Select Member:</label>
                <asp:DropDownList ID="ddlMembers" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <asp:Button ID="btnAssignMember" runat="server" Text="Assign Member" CssClass="btn btn-primary" OnClick="btnAssignMember_Click" />
        </div>

        <hr />

        <!-- Display Trainings and Participants -->
        <div class="section">
            <h3>All Trainings and Participants</h3>
            <asp:Repeater ID="TrainingRepeater" runat="server">
                <HeaderTemplate>
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>Training Name</th>
                                <th>Training Date</th>
                                <th>Participants</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("TrainingName") %></td>
                        <td><%# Eval("TrainingDate", "{0:yyyy-MM-dd}") %></td>
                        <td><%# Eval("Participants") %></td>
                        <td>
                            <a href='EditTraining.aspx?id=<%# Eval("TrainingID") %>' class="btn btn-warning btn-sm">Edit</a>
                            <a href='DeleteTraining.aspx?id=<%# Eval("TrainingID") %>' class="btn btn-danger btn-sm">Delete</a>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>

        <!-- Logout Button -->
        <div class="logout-section">
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-danger" OnClick="btnLogout_Click" />
        </div>
    </div>

    <!-- Inline CSS -->
    <style>
        .manage-training-container {
            font-family: Arial, sans-serif;
            margin: 20px auto;
            width: 90%;
        }

        h1, h3 {
            text-align: center;
            color: #333;
            margin-bottom: 20px;
        }

        .section {
            margin-bottom: 30px;
        }

        .form-group {
            margin: 10px 0;
        }

        label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box;
        }

        .btn {
            display: inline-block;
            padding: 10px 15px;
            font-size: 14px;
            border-radius: 5px;
            color: #fff;
            text-decoration: none;
            cursor: pointer;
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

        .table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
        }

        .table th, .table td {
            border: 1px solid #ddd;
            padding: 12px;
            text-align: center;
        }

        .table th {
            background-color: #007bff;
            color: white;
        }

        .table-striped tbody tr:nth-child(odd) {
            background-color: #f9f9f9;
        }

        .table-striped tbody tr:hover {
            background-color: #f1f1f1;
        }

        .logout-section {
            text-align: right;
            margin-top: 20px;
        }
    </style>
</asp:Content>
