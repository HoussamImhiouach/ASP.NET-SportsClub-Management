<%@ Page Title="Delete Training" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="DeleteTraining.aspx.cs" Inherits="ProjetSportFinalHoussamEddneImhiouach.DeleteTraining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="delete-training-container">
        <h2>Delete Training Session</h2>
        <p>Are you sure you want to delete this training session?</p>
        
        <!-- Display Deletion Message -->
        <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>
        
        <!-- Confirmation and Cancel Buttons -->
        <div class="button-container">
            <asp:Button ID="btnConfirmDelete" runat="server" Text="Confirm Delete" CssClass="btn btn-danger" OnClick="btnConfirmDelete_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" PostBackUrl="ManageTraining.aspx" />
        </div>
    </div>

    <!-- Inline CSS -->
    <style>
        .delete-training-container {
            font-family: Arial, sans-serif;
            margin: 50px auto;
            width: 50%;
            padding: 20px;
            background-color: #ffffff;
            border: 1px solid #ddd;
            border-radius: 8px;
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.2);
            text-align: center;
        }

        h2 {
            color: #dc3545;
            margin-bottom: 20px;
        }

        p {
            font-size: 18px;
            color: #333;
            margin-bottom: 20px;
        }

        .message-label {
            display: block;
            font-weight: bold;
            margin: 10px 0;
            color: #dc3545;
        }

        .button-container {
            margin-top: 20px;
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
            margin-right: 10px;
        }

        .btn-danger {
            background-color: #dc3545;
        }

        .btn-danger:hover {
            background-color: #c82333;
        }

        .btn-secondary {
            background-color: #6c757d;
        }

        .btn-secondary:hover {
            background-color: #5a6268;
        }

        .btn:focus {
            outline: none;
            box-shadow: 0 0 5px rgba(220, 53, 69, 0.5);
        }
    </style>
</asp:Content>
