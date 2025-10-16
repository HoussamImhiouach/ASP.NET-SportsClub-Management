using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetSportFinalHoussamEddneImhiouach
{
    public partial class DeleteTraining : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Validate the TrainingID from query string
            if (!IsPostBack && !int.TryParse(Request.QueryString["id"], out int trainingId))
            {
                lblMessage.Text = "Invalid Training ID.";
                btnConfirmDelete.Enabled = false;
            }
        }

        protected void btnConfirmDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Request.QueryString["id"], out int trainingId))
            {
                string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // Step 1: Delete related entries in TrainingParticipation
                        string deleteParticipationQuery = "DELETE FROM TrainingParticipation WHERE TrainingID = @TrainingID";
                        SqlCommand deleteParticipationCmd = new SqlCommand(deleteParticipationQuery, connection);
                        deleteParticipationCmd.Parameters.AddWithValue("@TrainingID", trainingId);
                        deleteParticipationCmd.ExecuteNonQuery();

                        // Step 2: Delete the training session
                        string deleteTrainingQuery = "DELETE FROM TrainingSessions WHERE TrainingID = @TrainingID";
                        SqlCommand deleteTrainingCmd = new SqlCommand(deleteTrainingQuery, connection);
                        deleteTrainingCmd.Parameters.AddWithValue("@TrainingID", trainingId);
                        deleteTrainingCmd.ExecuteNonQuery();

                        Response.Redirect("ManageTraining.aspx");
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "An error occurred: " + ex.Message;
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            else
            {
                lblMessage.Text = "Invalid Training ID.";
            }
        }


        private void DeleteTrainingSession(int trainingId)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM TrainingSessions WHERE TrainingID = @TrainingID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrainingID", trainingId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "Training session deleted successfully!";
                        Response.Redirect("ManageTraining.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Error: Training session not found.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "An error occurred: " + ex.Message;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}