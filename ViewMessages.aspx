<%@ Page Title="View Messages" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewMessages.aspx.cs" Inherits="ProjetSportFinalHoussamEddineImhiouach.ViewMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* General Styles */
        .message-container {
            max-width: 900px;
            margin: 20px auto;
            padding: 20px;
            background: #f9f9f9;
            border: 1px solid #ddd;
            border-radius: 5px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            font-family: Arial, sans-serif;
        }

        h1 {
            color: #333;
            text-align: center;
            margin-bottom: 20px;
        }

        /* GridView Styling */
        .grid-view {
            width: 100%;
            border-collapse: collapse;
        }

        .grid-view th {
            background-color: #343a40;
            color: #fff;
            padding: 10px;
            text-align: left;
        }

        .grid-view td {
            padding: 10px;
            border: 1px solid #ddd;
        }

        .grid-view tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .unread {
            background-color: #ffff99; /* Yellow for unread messages */
        }

        .read {
            background-color: #f1f1f1; /* Light gray for read messages */
        }

        /* Action Link Styling */
        .action-link {
            color: #007bff;
            text-decoration: none;
            font-weight: bold;
        }

        .action-link:hover {
            text-decoration: underline;
            color: #0056b3;
        }

        /* No Messages Label */
        .no-messages {
            text-align: center;
            font-size: 16px;
            color: #666;
            margin-top: 20px;
        }
    </style>

    <div class="message-container">
        <h1>Received Messages</h1>

        <!-- GridView for Messages -->
        <asp:GridView ID="gvMessages" runat="server" AutoGenerateColumns="False" CssClass="grid-view" OnRowCommand="gvMessages_RowCommand" ShowHeaderWhenEmpty="True" EmptyDataText="You have no messages.">
            <Columns>
                <asp:BoundField DataField="SenderName" HeaderText="From" />
                <asp:BoundField DataField="MessageSubject" HeaderText="Subject" />
                <asp:BoundField DataField="Timestamp" HeaderText="Received On" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkView" runat="server" Text="View" CommandName="ViewMessage" CommandArgument='<%# Eval("MessageID") %>' CssClass="action-link" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle CssClass="no-messages" />
        </asp:GridView>
    </div>
</asp:Content>
