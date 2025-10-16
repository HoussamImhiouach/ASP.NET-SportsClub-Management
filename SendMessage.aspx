<%@ Page Title="Send New Message" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="ProjetSportFinalHoussamEddineImhiouach.SendMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .send-message-container {
            max-width: 800px;
            margin: 20px auto;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 5px;
            background-color: #f9f9f9;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            font-family: Arial, sans-serif;
        }

        h1 {
            color: #333;
            text-align: center;
            margin-bottom: 20px;
        }

        label {
            display: block;
            margin: 10px 0 5px;
            font-weight: bold;
            color: #555;
        }

        .form-control {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 14px;
            box-sizing: border-box;
        }

        .btn-send {
            background-color: #28a745; /* Green for send */
            color: #fff;
            border: none;
            padding: 10px 20px;
            font-size: 16px;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            display: block;
            margin: 0 auto;
        }

        .btn-send:hover {
            background-color: #218838;
        }

        .success-message {
            text-align: center;
            color: #28a745;
            font-weight: bold;
            margin-top: 15px;
        }

        .dropdown {
            height: 40px;
            font-size: 14px;
            padding: 5px;
            border-radius: 5px;
            border: 1px solid #ccc;
            width: 100%;
            margin-bottom: 15px;
        }
    </style>

    <div class="send-message-container">
        <h1>Send a New Message</h1>

        <!-- Recipient Dropdown -->
        <label for="ddlRecipient">To:</label>
        <asp:DropDownList ID="ddlRecipient" runat="server" AppendDataBoundItems="true" CssClass="dropdown">
            <asp:ListItem Text="-- Select a User --" Value="" />
        </asp:DropDownList>

        <!-- Subject -->
        <label for="txtSubject">Subject:</label>
        <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control" Placeholder="Enter the subject"></asp:TextBox>

        <!-- Message Content -->
        <label for="txtMessageContent">Message:</label>
        <asp:TextBox ID="txtMessageContent" runat="server" TextMode="MultiLine" Rows="8" CssClass="form-control" Placeholder="Write your message here..."></asp:TextBox>

        <!-- Send Button -->
        <asp:Button ID="btnSend" runat="server" Text="Send Message" OnClick="btnSend_Click" CssClass="btn-send" />

        <!-- Success Message -->
        <asp:Label ID="lblMessage" runat="server" CssClass="success-message"></asp:Label>
    </div>
</asp:Content>
