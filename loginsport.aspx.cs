using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class loginsport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If the user is already logged in, redirect to their respective dashboard
            if (Session["UserRole"] != null)
            {
                RedirectToDashboard(Session["UserRole"].ToString());
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Get input values
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Connection string
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id, Role FROM Users WHERE Email = @Email AND Password = @Password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read()) // Successful login
                    {
                        // Store User ID, Role, and Email in session
                        Session["UserID"] = reader["Id"];
                        Session["UserRole"] = reader["Role"];
                        Session["UserEmail"] = email;

                        string userRole = reader["Role"].ToString();

                        // Redirect based on role
                        RedirectToDashboard(userRole);
                    }
                    else
                    {
                        // Invalid info
                        lblMessage.Text = "Invalid email or password. Please try again.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                lblMessage.Text = "An error occurred: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        // Redirect users to their respective dashboards
        private void RedirectToDashboard(string role)
        {
            switch (role)
            {
                case "Administrator":
                    Response.Redirect("AdminDashboard.aspx", false);
                    break;
                case "Entraineur":
                    Response.Redirect("EntraineurDashboard.aspx", false);
                    break;
                case "President":
                    Response.Redirect("PresidentDashboard.aspx", false);
                    break;
                case "Member":
                    Response.Redirect("MemberDashboard.aspx", false);
                    break;
                default:
                    Response.Redirect("loginsport.aspx", false);
                    break;
            }
        }
    }
}
