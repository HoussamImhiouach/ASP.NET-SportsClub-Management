using System;
using System.Data.SqlClient;
using System.Text;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class ManageMembers : System.Web.UI.Page
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is logged in and has the "Administrator" role
            if (Session["UserRole"] == null || Session["UserRole"].ToString() != "Administrator")
            {
                Response.Redirect("loginsport.aspx");
            }

            if (!IsPostBack)
            {
                LoadMembers();
            }
        }

        // Add Member Logic
        protected void btnAddMember_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = ddlRole.SelectedValue;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "All fields are required.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Users (FullName, Email, Password, Role, DateRegistered) VALUES (@FullName, @Email, @Password, @Role, @DateRegistered)";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@DateRegistered", DateTime.Now);

                    connection.Open();
                    cmd.ExecuteNonQuery();

                    lblMessage.Text = "✅ Member added successfully!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }

                // Clear form fields
                txtFullName.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
                ddlRole.SelectedIndex = 0;

                // Refresh the member list
                LoadMembers();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "❌ Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Load Members into Table
        private void LoadMembers()
        {
            StringBuilder memberRows = new StringBuilder();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users ORDER BY DateRegistered DESC";
                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    memberRows.Append("<tr>");
                    memberRows.Append($"<td>{reader["Id"]}</td>");
                    memberRows.Append($"<td>{reader["FullName"]}</td>");
                    memberRows.Append($"<td>{reader["Email"]}</td>");
                    memberRows.Append($"<td>{reader["Role"]}</td>");
                    memberRows.Append($"<td>{Convert.ToDateTime(reader["DateRegistered"]).ToString("yyyy-MM-dd")}</td>");
                    memberRows.Append("<td>");
                    memberRows.Append($"<a class='btn btn-yellow' href='EditMember.aspx?id={reader["Id"]}' style='margin-right: 10px;'>Edit</a>");
                    memberRows.Append($"<a class='btn btn-red' href='ManageMembers.aspx?deleteId={reader["Id"]}' onclick=\"return confirm('Are you sure you want to delete this member?');\">Delete</a>");
                    memberRows.Append("</td>");
                    memberRows.Append("</tr>");
                }
            }

            ltMemberRows.Text = memberRows.ToString();
        }

        // Delete Member Logic
        private void DeleteMember(int memberId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Step 1: Delete related records in TrainingParticipation
                    string deleteParticipationQuery = "DELETE FROM TrainingParticipation WHERE MemberID = @MemberID";
                    using (SqlCommand cmdParticipation = new SqlCommand(deleteParticipationQuery, connection))
                    {
                        cmdParticipation.Parameters.AddWithValue("@MemberID", memberId);
                        cmdParticipation.ExecuteNonQuery();
                    }

                    // Step 2: Delete the member from Users table
                    string deleteUserQuery = "DELETE FROM Users WHERE Id = @Id";
                    using (SqlCommand cmdUser = new SqlCommand(deleteUserQuery, connection))
                    {
                        cmdUser.Parameters.AddWithValue("@Id", memberId);
                        int rowsAffected = cmdUser.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lblMessage.Text = "✅ Member deleted successfully!";
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblMessage.Text = "❌ Member could not be deleted.";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "❌ Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

            // Reload the members list
            LoadMembers();
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear session
            Session.Clear();
            Session.Abandon();
            Response.Redirect("loginsport.aspx");
        }

        
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["deleteId"]))
            {
                int memberId;
                if (int.TryParse(Request.QueryString["deleteId"], out memberId))
                {
                    DeleteMember(memberId);
                }
            }
        }

        protected void btnAdminDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }

    }
}
