using System;
using System.Data.SqlClient;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class signupsport : System.Web.UI.Page
    {
        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            // Get input values
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string role = ddlRole.SelectedValue;

            // Connection string
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True";

            // SQL to insert user
            string query = "INSERT INTO Users (FullName, Email, Password, Role) VALUES (@FullName, @Email, @Password, @Role)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters
                        command.Parameters.AddWithValue("@FullName", fullName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Role", role);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            lblMessage.Text = "Signup successful!";
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblMessage.Text = "Signup failed. Please try again.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}
