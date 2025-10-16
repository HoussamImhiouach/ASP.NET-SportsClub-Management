using System;
using System.Data.SqlClient;
using System.Data;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class SendMessage : System.Web.UI.Page
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
                LoadRecipients();
            }
        }

        private void LoadRecipients()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, FullName FROM Users WHERE Id != @CurrentUserID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CurrentUserID", Session["UserID"]);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                ddlRecipient.DataSource = dt;
                ddlRecipient.DataTextField = "FullName";
                ddlRecipient.DataValueField = "Id";
                ddlRecipient.DataBind();
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlRecipient.SelectedValue))
            {
                lblMessage.Text = "Please select a recipient.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string subject = txtSubject.Text.Trim();
            string content = txtMessageContent.Text.Trim();
            int senderID = (int)Session["UserID"];
            int recipientID = int.Parse(ddlRecipient.SelectedValue);

            if (string.IsNullOrEmpty(content))
            {
                lblMessage.Text = "Message content cannot be empty.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

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

            lblMessage.Text = "Message sent successfully!";
            lblMessage.ForeColor = System.Drawing.Color.Green;

            // Clear fields
            ddlRecipient.SelectedIndex = 0;
            txtSubject.Text = "";
            txtMessageContent.Text = "";
        }
    }
}
