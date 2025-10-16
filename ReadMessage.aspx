<%@ Page Title="Read Message" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReadMessage.aspx.cs" Inherits="ProjetSportFinalHoussamEddineImhiouach.ReadMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .message-container {
            max-width: 800px;
            margin: 20px auto;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 5px;
            background-color: #f9f9f9;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        h1 {
            font-family: Arial, sans-serif;
            color: #333;
            text-align: center;
            margin-bottom: 20px;
        }

        .message-details p {
            font-size: 16px;
            margin: 10px 0;
            line-height: 1.6;
        }

        hr {
            border: 0;
            border-top: 1px solid #ccc;
        }

        .button-group {
            margin-top: 20px;
            text-align: center;
        }

        .btn {
            display: inline-block;
            margin: 5px;
            padding: 10px 20px;
            font-size: 14px;
            color: #fff;
            text-decoration: none;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .btn-reply {
            background-color: #28a745; /* Green for reply */
        }

        .btn-reply:hover {
            background-color: #218838;
        }

        .btn-delete {
            background-color: #dc3545; /* Red for delete */
        }

        .btn-delete:hover {
            background-color: #c82333;
        }
    </style>

    <div class="message-container">
        <h1>Message Details</h1>
        <div class="message-details">
            <p><strong>From:</strong> <asp:Label ID="lblSender" runat="server"></asp:Label></p>
            <p><strong>Subject:</strong> <asp:Label ID="lblSubject" runat="server"></asp:Label></p>
            <p><strong>Received On:</strong> <asp:Label ID="lblTimestamp" runat="server"></asp:Label></p>
            <hr />
            <p>
                <asp:Literal ID="ltContent" runat="server"></asp:Literal>
            </p>
        </div>
        <div class="button-group">
            <!-- Reply and Delete Buttons -->
            <asp:Button ID="btnReply" runat="server" Text="Reply" OnClick="btnReply_Click" CssClass="btn btn-reply" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="btn btn-delete" />
        </div>
    </div>
</asp:Content>
