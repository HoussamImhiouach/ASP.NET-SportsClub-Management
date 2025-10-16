<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="ProjetSportFinalHoussamEddineImhiouach.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Header Section -->
    <div style="text-align: center; margin-top: 50px;">
        <h1 id="mainTitle" style="font-size: 48px; color: #007bff; font-weight: bold;">Welcome to SmartFit</h1>
        <p id="motto" style="font-size: 18px; color: gray; font-style: italic;"></p>

        <!-- Buttons -->
        <div style="margin-top: 30px;">
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="action-button login-button" OnClick="btnLogin_Click" />
            <asp:Button ID="btnSignup" runat="server" Text="Sign Up" CssClass="action-button signup-button" OnClick="btnSignup_Click" />
        </div>
    </div>

    <!-- Why Choose Us Section -->
    <div style="margin-top: 50px; padding: 20px; background-color: #f9f9f9;">
        <h2 style="text-align: center; color: #333; font-size: 28px;">Why Choose Us?</h2>
        <div class="features-container">
            <div class="feature-card">
                <i class="fas fa-cogs feature-icon"></i>
                <h3>Efficient Management</h3>
                <p>Manage your sports club effortlessly with our all-in-one platform.</p>
            </div>
            <div class="feature-card">
                <i class="fas fa-dumbbell feature-icon"></i>
                <h3>Training Sessions</h3>
                <p>Plan, assign, and monitor training sessions for all members.</p>
            </div>
            <div class="feature-card">
                <i class="fas fa-chart-line feature-icon"></i>
                <h3>Detailed Statistics</h3>
                <p>Get real-time insights on revenue, participation, and more.</p>
            </div>
        </div>
    </div>

   

    <!-- Styles -->
    <style>
        /* Buttons */
        .action-button {
            margin: 10px;
            padding: 10px 20px;
            font-size: 16px;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .login-button {
            background-color: #007bff;
        }

        .login-button:hover {
            background-color: #0056b3;
        }

        .signup-button {
            background-color: #28a745;
        }

        .signup-button:hover {
            background-color: #218838;
        }

        /* Features Section */
        .features-container {
            display: flex;
            justify-content: center;
            gap: 30px;
            margin-top: 20px;
        }

        .feature-card {
            text-align: center;
            background-color: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
            width: 250px;
            transition: transform 0.3s ease, box-shadow 0.3s ease;
        }

        .feature-card:hover {
            transform: translateY(-10px);
            box-shadow: 0 5px 15px rgba(0, 0, 0, 0.2);
        }

        .feature-icon {
            font-size: 50px;
            color: #007bff;
            margin-bottom: 10px;
        }

        .feature-card h3 {
            color: #007bff;
            font-weight: bold;
        }
    </style>

    <!-- Typewriter Animation Script -->
    <script src="https://kit.fontawesome.com/a076d05399.js" crossorigin="anonymous"></script>
    <script>
        const mottoText = "Empowering teams, one club at a time";
        let index = 0;
        let direction = 1;
        const mottoElement = document.getElementById("motto");

        function typewriterAnimation() {
            if (direction === 1) {
                mottoElement.textContent = mottoText.slice(0, index++);
                if (index > mottoText.length) direction = -1;
            } else {
                mottoElement.textContent = mottoText.slice(0, index--);
                if (index === 0) direction = 1;
            }
            setTimeout(typewriterAnimation, 100);
        }
        window.onload = typewriterAnimation;
    </script>
</asp:Content>
