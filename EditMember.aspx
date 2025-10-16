<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditMember.aspx.cs" Inherits="ProjetSportFinalHoussamEddneImhiouach.EditMember" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Edit Member</title>
    <style>
        /* General Body Style */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f9;
            color: #333;
        }

        /* Container */
        .form-container {
            width: 400px;
            margin: 50px auto;
            padding: 20px;
            background: #fff;
            border-radius: 8px;
            box-shadow: 0px 5px 15px rgba(0, 0, 0, 0.2);
        }

        .form-container h2 {
            text-align: center;
            color: #007bff;
            margin-bottom: 20px;
        }

        /* Labels */
        label {
            font-weight: bold;
            display: block;
            margin: 10px 0 5px;
        }

        /* Input Fields */
        .form-container input, 
        .form-container select {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 14px;
            box-sizing: border-box;
        }

        .form-container input:focus, 
        .form-container select:focus {
            border-color: #007bff;
            outline: none;
            box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
        }

        /* Buttons */
        .button-container {
            text-align: center;
            margin-top: 20px;
        }

        .btn {
            display: inline-block;
            padding: 10px 20px;
            font-size: 14px;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            text-decoration: none;
            transition: background-color 0.3s ease;
        }

        .btn-save {
            background-color: #28a745;
        }

        .btn-save:hover {
            background-color: #218838;
        }

        .btn-cancel {
            background-color: #dc3545;
            margin-left: 10px;
        }

        .btn-cancel:hover {
            background-color: #c82333;
        }

        /* Message Label */
        .message {
            text-align: center;
            font-size: 14px;
            margin-bottom: 10px;
        }
    </style>
</head>
<body>
    <div class="form-container">
        <h2>Edit Member</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="message" Text=""></asp:Label>
        <form id="form1" runat="server">
            <label for="txtFullName">Full Name:</label>
            <asp:TextBox ID="txtFullName" runat="server" CssClass="input-field" />

            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="input-field" />

            <label for="ddlRole">Role:</label>
            <asp:DropDownList ID="ddlRole" runat="server" CssClass="input-field">
                <asp:ListItem Text="Member" Value="Member"></asp:ListItem>
                <asp:ListItem Text="Administrator" Value="Administrator"></asp:ListItem>
                <asp:ListItem Text="Entraineur" Value="Entraineur"></asp:ListItem>
                <asp:ListItem Text="President" Value="President"></asp:ListItem>
            </asp:DropDownList>

            <div class="button-container">
                <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-save" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-cancel" PostBackUrl="ManageMembers.aspx" />
            </div>
        </form>
    </div>
</body>
</html>
