using System;
using System.Data.SqlClient;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class ReplyMessage : System.Web.UI.Page
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("loginsport.aspx");
                return;
            }

            if (!IsPostBack)
            {
                string replyTo = Request.QueryString["ReplyTo"];
                string subject = Request.QueryString["Subject"];

                txtRecipient.Text = replyTo;
                txtSubject.Text = "RE: " + subject;
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string recipientName = txtRecipient.Text.Trim();
            string subject = txtSubject.Text.Trim();
            string content = txtMessageContent.Text.Trim();
            int senderID = (int)Session["UserID"];

            if (string.IsNullOrEmpty(content))
            {
                lblMessage.Text = "Message content cannot be empty.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int recipientID = GetUserIDByName(recipientName);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Messages (SenderID, ReceiverID, MessageSubject, MessageContent, Timestamp) " +
                               "VALUES (@SenderID, @ReceiverID, @Subject, @Content, @Timestamp)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SenderID", senderID);
                command.Parameters.AddWithValue("@ReceiverID", recipientID);
                command.Parameters.AddWithValue("@Subject", subject);
                command.Parameters.AddWithValue("@Content", content);
                command.Parameters.AddWithValue("@Timestamp", DateTime.Now);

                connection.Open();
                command.ExecuteNonQuery();
            }

            lblMessage.Text = "Reply sent successfully!";
            lblMessage.ForeColor = System.Drawing.Color.Green;
        }

        private int GetUserIDByName(string fullName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id FROM Users WHERE FullName = @FullName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FullName", fullName);

                connection.Open();
                object result = command.ExecuteScalar();

                return result != null ? Convert.ToInt32(result) : -1;
            }
        }
    }
}
