using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Web.UI.WebControls;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class AssignTraining : System.Web.UI.Page
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Request.QueryString["unassign"] != null)
                {
                    UnassignMember(int.Parse(Request.QueryString["unassign"]));
                    return; 
                }

                // Load page data
                LoadTrainings();
                LoadMembers();
                DisplayTrainingAssignments();
            }
        }

        private void LoadTrainings()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT TrainingID, TrainingName FROM TrainingSessions";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                ddlTrainings.DataSource = table;
                ddlTrainings.DataTextField = "TrainingName";
                ddlTrainings.DataValueField = "TrainingID";
                ddlTrainings.DataBind();
            }
        }

        private void LoadMembers()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, FullName FROM Users WHERE Role = 'Member'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);

                cblMembers.DataSource = table;
                cblMembers.DataTextField = "FullName";
                cblMembers.DataValueField = "Id";
                cblMembers.DataBind();
            }
        }

        protected void btnAssignTraining_Click(object sender, EventArgs e)
        {
            int trainingId = int.Parse(ddlTrainings.SelectedValue);
            DateTime assignedDate = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (ListItem member in cblMembers.Items)
                {
                    if (member.Selected)
                    {
                        // Prevent duplicate assignments
                        string checkQuery = "SELECT COUNT(*) FROM TrainingParticipation WHERE TrainingID = @TrainingID AND MemberID = @MemberID";
                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, connection))
                        {
                            checkCmd.Parameters.AddWithValue("@TrainingID", trainingId);
                            checkCmd.Parameters.AddWithValue("@MemberID", member.Value);
                            int exists = (int)checkCmd.ExecuteScalar();

                            if (exists == 0) // Only insert if not already assigned
                            {
                                string query = "INSERT INTO TrainingParticipation (TrainingID, MemberID, AssignedDate) VALUES (@TrainingID, @MemberID, @AssignedDate)";
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@TrainingID", trainingId);
                                    command.Parameters.AddWithValue("@MemberID", member.Value);
                                    command.Parameters.AddWithValue("@AssignedDate", assignedDate);
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
                lblMessage.Text = "Training assigned successfully!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }

            DisplayTrainingAssignments();
        }

        private void DisplayTrainingAssignments()
        {
            StringBuilder html = new StringBuilder();
            html.Append("<table border='1'><tr><th>Training Name</th><th>Member Name</th><th>Assigned Date</th><th>Actions</th></tr>");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT TP.ParticipationID, TS.TrainingName, U.FullName, TP.AssignedDate
                    FROM TrainingParticipation TP
                    INNER JOIN TrainingSessions TS ON TP.TrainingID = TS.TrainingID
                    INNER JOIN Users U ON TP.MemberID = U.Id";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    html.Append("<tr>");
                    html.Append($"<td>{reader["TrainingName"]}</td>");
                    html.Append($"<td>{reader["FullName"]}</td>");
                    html.Append($"<td>{Convert.ToDateTime(reader["AssignedDate"]).ToString("yyyy-MM-dd")}</td>");
                    html.Append($"<td><a href='AssignTraining.aspx?unassign={reader["ParticipationID"]}'>Unassign</a></td>");
                    html.Append("</tr>");
                }

                html.Append("</table>");
                ltTrainingAssignments.Text = html.ToString();
            }
        }

        private void UnassignMember(int participationId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM TrainingParticipation WHERE ParticipationID = @ParticipationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ParticipationID", participationId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    lblMessage.Text = "Member unassigned successfully!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;

                    // Redirect to the same page to refresh the display
                    Response.Redirect("AssignTraining.aspx");
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            
            Session.Clear();
            Session.Abandon();
            Response.Redirect("loginsport.aspx");
        }

    }
}
