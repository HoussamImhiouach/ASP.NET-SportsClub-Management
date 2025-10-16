using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class ManageTraining : System.Web.UI.Page
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTrainings();
                LoadDropdowns();
            }
        }

        // Load Trainings and Participants
        private void LoadTrainings()
        {
            StringBuilder trainingData = new StringBuilder();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT t.TrainingID, t.TrainingName, t.TrainingDate, 
                    STRING_AGG(u.FullName, ', ') AS Participants
                    FROM TrainingSessions t
                    LEFT JOIN TrainingParticipation tp ON t.TrainingID = tp.TrainingID
                    LEFT JOIN Users u ON tp.MemberID = u.Id
                    GROUP BY t.TrainingID, t.TrainingName, t.TrainingDate";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                TrainingRepeater.DataSource = dt;
                TrainingRepeater.DataBind();
            }
        }

        // Load dropdowns for assigning members
        private void LoadDropdowns()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Load Trainings
                SqlCommand cmdTrainings = new SqlCommand("SELECT TrainingID, TrainingName FROM TrainingSessions", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmdTrainings);
                DataTable dtTrainings = new DataTable();
                adapter.Fill(dtTrainings);
                ddlTrainings.DataSource = dtTrainings;
                ddlTrainings.DataTextField = "TrainingName";
                ddlTrainings.DataValueField = "TrainingID";
                ddlTrainings.DataBind();

                // Load Members
                SqlCommand cmdMembers = new SqlCommand("SELECT Id, FullName FROM Users WHERE Role = 'Member'", conn);
                SqlDataAdapter adapterMembers = new SqlDataAdapter(cmdMembers);
                DataTable dtMembers = new DataTable();
                adapterMembers.Fill(dtMembers);
                ddlMembers.DataSource = dtMembers;
                ddlMembers.DataTextField = "FullName";
                ddlMembers.DataValueField = "Id";
                ddlMembers.DataBind();
            }
        }

        // Add Training
        protected void btnAddTraining_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO TrainingSessions (TrainingName, TrainingDate) VALUES (@Name, @Date)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", txtTrainingName.Text.Trim());
                cmd.Parameters.AddWithValue("@Date", txtTrainingDate.Text.Trim());

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            txtTrainingName.Text = string.Empty;
            txtTrainingDate.Text = string.Empty;
            LoadTrainings();
            LoadDropdowns();
        }

        // Assign Member to Training
        protected void btnAssignMember_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Check for existing assignment
                string checkQuery = "SELECT COUNT(*) FROM TrainingParticipation WHERE TrainingID = @TrainingID AND MemberID = @MemberID";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@TrainingID", ddlTrainings.SelectedValue);
                checkCmd.Parameters.AddWithValue("@MemberID", ddlMembers.SelectedValue);

                conn.Open();
                int count = (int)checkCmd.ExecuteScalar();

                if (count == 0) // If no existing record
                {
                    // Insert new assignment
                    string insertQuery = "INSERT INTO TrainingParticipation (TrainingID, MemberID, AssignedDate) VALUES (@TrainingID, @MemberID, @Date)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@TrainingID", ddlTrainings.SelectedValue);
                    insertCmd.Parameters.AddWithValue("@MemberID", ddlMembers.SelectedValue);
                    insertCmd.Parameters.AddWithValue("@Date", DateTime.Now);

                    insertCmd.ExecuteNonQuery();
                    lblMessage.Text = "Member assigned successfully!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    // Show message if duplicate found
                    lblMessage.Text = "Error: This member is already assigned to the selected training.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

            // Reload the list after updating
            LoadTrainings();
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
