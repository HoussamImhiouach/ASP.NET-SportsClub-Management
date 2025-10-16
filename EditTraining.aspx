<%@ Page Title="Edit Training" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="EditTraining.aspx.cs" Inherits="ProjetSportFinalHoussamEddneImhiouach.EditTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="edit-training-container">
        <h2>Edit Training Session</h2>

        <!-- Training Name Input -->
        <div class="form-group">
            <label for="txtTrainingName">Training Name:</label>
            <asp:TextBox ID="txtTrainingName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <!-- Training Date Input -->
        <div class="form-group">
            <label for="txtTrainingDate">Training Date:</label>
            <asp:TextBox ID="txtTrainingDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
        </div>

        <!-- Update Training Button -->
        <asp:Button ID="btnUpdateTraining" runat="server" Text="Update Training" CssClass="btn btn-success" OnClick="btnUpdateTraining_Click" />

        <!-- Message Label -->
        <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
    </div>

    <!-- Inline CSS -->
    <style>
        .edit-training-container {
            font-family: Arial, sans-serif;
            margin: 0 auto;
            width: 50%;
            padding: 20px;
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.2);
            border-radius: 8px;
            background-color: #ffffff;
            text-align: center;
        }

        h2 {
            color: #333;
            margin-bottom: 20px;
        }

        .form-group {
            margin: 15px 0;
            text-align: left;
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
            font-size: 16px;
        }

        .btn {
            display: inline-block;
            padding: 10px 20px;
            font-size: 16px;
            font-weight: bold;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .btn-success {
            background-color: #28a745;
        }

        .btn-success:hover {
            background-color: #218838;
        }

        .btn:focus {
            outline: none;
            box-shadow: 0 0 5px rgba(40, 167, 69, 0.5);
        }

        .form-group input:focus {
            border-color: #28a745;
            outline: none;
            box-shadow: 0 0 5px rgba(40, 167, 69, 0.5);
        }

        .label-message {
            margin-top: 10px;
            font-weight: bold;
        }
    </style>
</asp:Content>
