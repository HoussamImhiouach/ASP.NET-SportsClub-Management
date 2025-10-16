<%@ Page Title="AI Chatbot" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Chatbot.aspx.cs" Inherits="ProjetSportFinalHoussamEddineImhiouach.Chatbot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="chat-container">
        <!-- Chat Header with Logout Button -->
        <div class="chat-header">
            🤖 FitBot - Your AI Chat Assistant
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="logout-btn" OnClick="btnLogout_Click" />
        </div>

        <!-- Chat Messages -->
        <div id="chatMessages" runat="server" class="chat-messages"></div>

        <!-- Input Section -->
        <div class="chat-input">
            <asp:TextBox ID="txtUserInput" runat="server" CssClass="input-box" placeholder="Type your message..." autocomplete="off"></asp:TextBox>
            <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="send-btn" OnClick="btnSend_Click" UseSubmitBehavior="false" />
        </div>
    </div>

    <!-- JavaScript for Enter Key Submission -->
    <script>
        document.getElementById('<%= txtUserInput.ClientID %>').addEventListener('keypress', function (e) {
            if (e.key === 'Enter') {
                e.preventDefault();
                document.getElementById('<%= btnSend.ClientID %>').click();
            }
        });
    </script>

    <!-- CSS Styles -->
    <style>
        /* Chat Container */
        .chat-container {
            max-width: 500px;
            margin: 50px auto;
            border: 1px solid #ccc;
            border-radius: 10px;
            box-shadow: 0px 5px 15px rgba(0, 0, 0, 0.2);
            overflow: hidden;
            background-color: #fff;
            font-family: Arial, sans-serif;
        }

        /* Chat Header */
        .chat-header {
            background-color: #007bff;
            color: #fff;
            padding: 15px;
            text-align: center;
            font-size: 20px;
            font-weight: bold;
            position: relative;
        }

        /* Logout Button */
        .logout-btn {
            position: absolute;
            top: 10px;
            right: 10px;
            padding: 5px 10px;
            background-color: #dc3545;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            font-size: 12px;
        }

        .logout-btn:hover {
            background-color: #c82333;
        }

        /* Chat Messages */
        .chat-messages {
            height: 350px;
            padding: 15px;
            overflow-y: auto;
            background-color: #f9f9f9;
            scroll-behavior: smooth;
        }

        /* Chat Messages - User and Bot */
        .message {
            margin: 10px 0;
            padding: 8px 12px;
            border-radius: 10px;
            font-size: 14px;
            line-height: 1.5;
            max-width: 80%;
        }

        .message.user {
            background-color: #d1ecf1;
            color: #0c5460;
            text-align: right;
            float: right;
            clear: both;
        }

        .message.bot {
            background-color: #d4edda;
            color: #155724;
            text-align: left;
            float: left;
            clear: both;
        }

        /* Chat Input */
        .chat-input {
            display: flex;
            align-items: center;
            padding: 10px;
            background-color: #f1f1f1;
            border-top: 1px solid #ddd;
        }

        .input-box {
            flex: 1;
            padding: 8px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 5px;
            outline: none;
        }

        .input-box:focus {
            border-color: #007bff;
        }

        .send-btn {
            margin-left: 10px;
            padding: 8px 15px;
            font-size: 14px;
            background-color: #28a745;
            color: #fff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .send-btn:hover {
            background-color: #218838;
        }
    </style>
</asp:Content>
