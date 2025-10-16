using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class UnassignMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Ensure "id" parameter exists in the query string
            if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out int participationId))
            {
                UnassignMemberFromTraining(participationId);
            }
            else
            {
                lblMessage.Text = "Invalid request.";
            }
        }

        private void UnassignMemberFromTraining(int participationId)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM TrainingParticipation WHERE ParticipationID = @ParticipationID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ParticipationID", participationId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Member successfully unassigned.";
                        Response.Redirect("ManageTraining.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Error: Member could not be unassigned.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred: " + ex.Message;
            }
        }
    }
}
