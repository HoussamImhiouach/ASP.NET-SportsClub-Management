using System;
using System.Data.SqlClient;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserRole"] == null || Session["UserRole"].ToString() != "Administrator")
            {
                Response.Redirect("loginsport.aspx");
            }

            if (!IsPostBack)
            {
                LoadStatistics();
            }
        }

        private void LoadStatistics()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Total Members Count
                    SqlCommand cmdTotalMembers = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Role = 'Member'", connection);
                    int totalMembers = (int)cmdTotalMembers.ExecuteScalar();
                    lblTotalMembers.Text = totalMembers.ToString();

                    // Total Training Sessions Count
                    SqlCommand cmdTotalTrainings = new SqlCommand("SELECT COUNT(*) FROM TrainingSessions", connection);
                    int totalTrainings = (int)cmdTotalTrainings.ExecuteScalar();
                    lblTotalTrainings.Text = totalTrainings.ToString();
                }
                catch (Exception ex)
                {
                    // Handle errors gracefully
                    lblTotalMembers.Text = "Error loading statistics";
                    lblTotalTrainings.Text = "Error loading statistics";
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear the session and redirect to the login page
            Session.Clear();
            Session.Abandon();
            Response.Redirect("loginsport.aspx");
        }

    }
}
