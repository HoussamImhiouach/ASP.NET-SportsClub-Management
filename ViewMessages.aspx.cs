using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class ViewMessages : System.Web.UI.Page
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Redirect if user is not logged in
            if (Session["UserID"] == null)
            {
                Response.Redirect("loginsport.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadMessages();
            }
        }

        private void LoadMessages()
        {
            int receiverID = Convert.ToInt32(Session["UserID"]);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT M.MessageID, U.FullName AS SenderName, M.MessageSubject, M.Timestamp, M.IsRead
                    FROM Messages M
                    INNER JOIN Users U ON M.SenderID = U.Id
                    WHERE M.ReceiverID = @ReceiverID
                    ORDER BY M.Timestamp DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@ReceiverID", receiverID);
                DataTable table = new DataTable();
                adapter.Fill(table);

                // Set GridView data source
                gvMessages.DataSource = table;
                gvMessages.DataBind();

                // to highlight unread messages
                foreach (GridViewRow row in gvMessages.Rows)
                {
                    bool isRead = Convert.ToBoolean(table.Rows[row.RowIndex]["IsRead"]);
                    row.CssClass = isRead ? "read" : "unread";
                }
            }
        }

        protected void gvMessages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewMessage")
            {
                int messageID = Convert.ToInt32(e.CommandArgument);
                MarkMessageAsRead(messageID);
                Response.Redirect($"ReadMessage.aspx?MessageID={messageID}");
            }
        }

        private void MarkMessageAsRead(int messageID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Messages SET IsRead = 1 WHERE MessageID = @MessageID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MessageID", messageID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
