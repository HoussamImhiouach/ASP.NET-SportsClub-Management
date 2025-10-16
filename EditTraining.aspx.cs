using System;
using System.Data.SqlClient;

namespace ProjetSportFinalHoussamEddneImhiouach
{
    public partial class EditTraining : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve the TrainingID from the query string
                if (int.TryParse(Request.QueryString["id"], out int trainingId))
                {
                    LoadTrainingDetails(trainingId);
                }
                else
                {
                    lblMessage.Text = "Invalid Training ID.";
                }
            }
        }

        private void LoadTrainingDetails(int trainingId)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TrainingName, TrainingDate FROM TrainingSessions WHERE TrainingID = @TrainingID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrainingID", trainingId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Populate the textboxes with training details
                        txtTrainingName.Text = reader["TrainingName"].ToString();
                        txtTrainingDate.Text = Convert.ToDateTime(reader["TrainingDate"]).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        lblMessage.Text = "Training session not found.";
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

        protected void btnUpdateTraining_Click(object sender, EventArgs e)
        {
            // Retrieve the TrainingID from the query string
            if (int.TryParse(Request.QueryString["id"], out int trainingId))
            {
                UpdateTrainingDetails(trainingId);
            }
            else
            {
                lblMessage.Text = "Invalid Training ID.";
            }
        }

        private void UpdateTrainingDetails(int trainingId)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE TrainingSessions SET TrainingName = @TrainingName, TrainingDate = @TrainingDate WHERE TrainingID = @TrainingID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrainingName", txtTrainingName.Text.Trim());
                command.Parameters.AddWithValue("@TrainingDate", txtTrainingDate.Text.Trim());
                command.Parameters.AddWithValue("@TrainingID", trainingId);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Redirect to ManageTraining.aspx after successful update
                        Response.Redirect("ManageTraining.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Error: Unable to update the training session.";
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
