<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginsport.aspx.cs" Inherits="ProjetSportFinalHoussamEddineImhiouach.loginsport" %>

<!DOCTYPE html>
<html>
<head>
    <title>Login</title>
    <style>
        /* General Styling */
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f9f9f9;
        }

        /* Login Container */
        .login-container {
            max-width: 400px;
            margin: 100px auto;
            background-color: #ffffff;
            border: 1px solid #ddd;
            border-radius: 8px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            padding: 20px;
            text-align: center;
        }

        .login-container h2 {
            margin-bottom: 20px;
            font-size: 28px;
            color: #333;
        }

        /* Form Inputs */
        .login-form {
            display: flex;
            flex-direction: column;
            gap: 15px;
        }

        .login-form label {
            text-align: left;
            font-weight: bold;
            margin-bottom: 5px;
            color: #555;
        }

        .form-input {
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 14px;
            transition: border-color 0.3s ease-in-out;
        }

        .form-input:focus {
            outline: none;
            border-color: #007bff;
        }

        /* Buttons */
        .btn {
            display: inline-block;
            padding: 10px;
            font-size: 16px;
            font-weight: bold;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease-in-out;
        }

        .btn-login {
            background-color: #28a745;
        }

        .btn-login:hover {
            background-color: #218838;
        }

        /* Error Message */
        .error-message {
            font-size: 14px;
            color: #dc3545;
            margin-top: 10px;
        }

        /* Responsive Design */
        @media (max-width: 768px) {
            .login-container {
                width: 90%;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Login</h2>
            <div class="login-form">
                <!-- Email Field -->
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-input" TextMode="Email" Placeholder="Enter your email"></asp:TextBox>

                <!-- Password Field -->
                <label for="txtPassword">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-input" TextMode="Password" Placeholder="Enter your password"></asp:TextBox>

                <!-- Login Button -->
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-login" OnClick="btnLogin_Click" />

                <!-- Message Label -->
                <asp:Label ID="lblMessage" runat="server" CssClass="error-message" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
