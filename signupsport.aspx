    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signupsport.aspx.cs" Inherits="ProjetSportFinalHoussamEddineImhiouach.signupsport" %>

<!DOCTYPE html>
<html>
<head>
    <title>Sign Up</title>

    <style>
        /* General Styling */
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f9f9f9;
        }

        /* Sign Up Container */
        .signup-container {
            max-width: 450px;
            margin: 50px auto;
            background-color: #ffffff;
            border: 1px solid #ddd;
            border-radius: 8px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            padding: 20px;
            text-align: center;
        }

        .signup-container h2 {
            margin-bottom: 20px;
            font-size: 28px;
            color: #333;
        }

        /* Form Inputs */
        .signup-form {
            display: flex;
            flex-direction: column;
            gap: 15px;
        }

        .signup-form label {
            text-align: left;
            font-weight: bold;
            color: #555;
        }

        .form-input, .form-dropdown {
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 14px;
            transition: border-color 0.3s ease-in-out;
        }

        .form-input:focus, .form-dropdown:focus {
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
            text-decoration: none;
        }

        .btn-signup {
            background-color: #28a745;
        }

        .btn-signup:hover {
            background-color: #218838;
        }

        .btn-login {
            background-color: #007bff;
            margin-left: 5px;
        }

        .btn-login:hover {
            background-color: #0056b3;
        }

        /* Error Message */
        .error-message {
            font-size: 14px;
            color: #dc3545;
            margin-top: 10px;
        }

        /* Login Redirect */
        .login-redirect {
            margin-top: 20px;
            font-size: 14px;
            color: #555;
        }

        .login-redirect a {
            color: white;
            text-decoration: none;
            font-weight: bold;
            margin-left: 5px;
        }

        .login-redirect a:hover {
            text-decoration: underline;
        }

        /* Responsive Design */
        @media (max-width: 768px) {
            .signup-container {
                width: 90%;
            }
        }
    </style>

</head>
<body>

    <!-- Sign Up Form -->
    <form id="form1" runat="server">
        <div class="signup-container">
            <h2>Sign Up</h2>
            <div class="signup-form">
                <!-- Full Name Field -->
                <label for="txtFullName">Full Name:</label>
                <asp:TextBox ID="txtFullName" runat="server" CssClass="form-input" Placeholder="Enter your full name"></asp:TextBox>

                <!-- Email Field -->
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-input" Placeholder="Enter your email"></asp:TextBox>

                <!-- Password Field -->
                <label for="txtPassword">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-input" TextMode="Password" Placeholder="Enter your password"></asp:TextBox>

                <!-- Role Dropdown -->
                <label for="ddlRole">Role:</label>
                <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-dropdown">
                    <asp:ListItem Value="Member">Member</asp:ListItem>
                    <asp:ListItem Value="Administrator">Administrator</asp:ListItem>
                    <asp:ListItem Value="Entraineur">Entraineur</asp:ListItem>
                    <asp:ListItem Value="President">President</asp:ListItem>
                </asp:DropDownList>

                <!-- Sign Up Button -->
                <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" CssClass="btn btn-signup" OnClick="btnSignUp_Click" />

                <!-- Message Label -->
                <asp:Label ID="lblMessage" runat="server" CssClass="error-message" ForeColor="Red"></asp:Label>
            </div>

            <!-- Already Have an Account -->
            <div class="login-redirect">
                Already have an account?
                <a href="loginsport.aspx" class="btn btn-login">Login</a>
            </div>
        </div>
    </form>

</body>
</html>
