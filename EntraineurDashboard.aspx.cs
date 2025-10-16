using System;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class EntraineurDashboard : System.Web.UI.Page
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTrainingSessions();
            }
        }

        private void LoadTrainingSessions()
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("loginsport.aspx");
                return;
            }

            StringBuilder html = new StringBuilder();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT TS.TrainingID, TS.TrainingName, TS.TrainingDate
                    FROM TrainingSessions TS
                    WHERE TS.EntraineurID = @EntraineurID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EntraineurID", Session["UserID"]);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    html.Append("<h3>Training: " + reader["TrainingName"] + " (" + Convert.ToDateTime(reader["TrainingDate"]).ToString("yyyy-MM-dd") + ")</h3>");
                    html.Append("<table border='1'><tr><th>Member Name</th><th>Attendance</th></tr>");

                    LoadAssignedMembers(html, (int)reader["TrainingID"]);

                    html.Append("</table>");
                }
            }

            ltTrainingSessions.Text = html.ToString();
        }

        private void LoadAssignedMembers(StringBuilder html, int trainingID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT TP.ParticipationID, U.FullName, TP.Attendance
            FROM TrainingParticipation TP
            INNER JOIN Users U ON TP.MemberID = U.Id
            WHERE TP.TrainingID = @TrainingID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrainingID", trainingID);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int participationID = (int)reader["ParticipationID"];
                    bool attendance = (bool)reader["Attendance"];

                    html.Append("<tr>");
                    html.Append("<td>" + reader["FullName"] + "</td>");
                    html.Append($@"
                <td>
                    <label>
                        <input type='radio' name='attendance_{participationID}' value='true' {(attendance ? "checked" : "")} /> Present
                    </label>
                    <label>
                        <input type='radio' name='attendance_{participationID}' value='false' {(!attendance ? "checked" : "")} /> Absent
                    </label>
                </td>");
                    html.Append("</tr>");
                }
            }
        }



        protected void btnSaveAttendance_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("loginsport.aspx");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (string key in Request.Form.Keys)
                {
                    if (key != null && key.StartsWith("attendance_"))
                    {
                        int participationID = int.Parse(key.Replace("attendance_", ""));
                        bool attendanceValue = Request.Form[key] == "true";

                        string query = "UPDATE TrainingParticipation SET Attendance = @Attendance WHERE ParticipationID = @ParticipationID";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Attendance", attendanceValue);
                            command.Parameters.AddWithValue("@ParticipationID", participationID);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }

            lblMessage.Text = "Attendance updated successfully!";
            lblMessage.ForeColor = System.Drawing.Color.Green;

            // Reload updated data
            LoadTrainingSessions();
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
