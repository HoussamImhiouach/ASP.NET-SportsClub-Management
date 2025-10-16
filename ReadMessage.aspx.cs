using System;
using System.Data.SqlClient;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class ReadMessage : System.Web.UI.Page
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True;";
        private int messageID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("loginsport.aspx");
                return;
            }

            if (!IsPostBack)
            {
                if (int.TryParse(Request.QueryString["MessageID"], out messageID))
                {
                    LoadMessageDetails(messageID);
                }
                else
                {
                    Response.Redirect("ViewMessages.aspx");
                }
            }
        }

        private void LoadMessageDetails(int messageID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT U.FullName AS SenderName, M.MessageSubject, M.MessageContent, M.Timestamp
                    FROM Messages M
                    INNER JOIN Users U ON M.SenderID = U.Id
                    WHERE M.MessageID = @MessageID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MessageID", messageID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    lblSender.Text = reader["SenderName"].ToString();
                    lblSubject.Text = reader["MessageSubject"].ToString();
                    lblTimestamp.Text = Convert.ToDateTime(reader["Timestamp"]).ToString("yyyy-MM-dd HH:mm");
                    ltContent.Text = reader["MessageContent"].ToString();
                }
                else
                {
                    Response.Redirect("ViewMessages.aspx");
                }
            }
        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            // Redirect to SendMessage page with prefilled details
            Response.Redirect($"ReplyMessage.aspx?ReplyTo={lblSender.Text}&Subject=RE: {lblSubject.Text}");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Messages WHERE MessageID = @MessageID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MessageID", Request.QueryString["MessageID"]);

                connection.Open();
                command.ExecuteNonQuery();
            }

            // Redirect to message list after deletion
            Response.Redirect("ViewMessages.aspx");
        }
    }
}
