using System;
using System.Data.SqlClient;
using System.Text;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class MemberDashboard : System.Web.UI.Page
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("loginsport.aspx");
            }

            if (!IsPostBack)
            {
                CheckPaymentStatus();
                LoadTrainingSessions();
            }

            if (Request.QueryString["markAttendance"] != null)
            {
                MarkAttendance(int.Parse(Request.QueryString["markAttendance"]));
            }

            if (Request.QueryString["assignTraining"] != null)
            {
                AssignTraining(int.Parse(Request.QueryString["assignTraining"]));
            }
        }

        private void CheckPaymentStatus()
        {
            int memberId = (int)Session["UserID"];
            bool isPaid = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Payments WHERE UserID = @UserID AND PaymentDate >= DATEADD(YEAR, -1, GETDATE())";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", memberId);

                connection.Open();
                int paymentCount = (int)command.ExecuteScalar();
                if (paymentCount > 0)
                {
                    isPaid = true;
                }
            }

            if (!isPaid)
            {
                lblPaymentStatus.Text = "You have not made your annual payment. Please proceed to the payment page.";
                lblPaymentStatus.ForeColor = System.Drawing.Color.Red;
                btnProceedToPayment.Visible = true;
            }
            else
            {
                lblPaymentStatus.Text = "Your payment is up to date.";
                lblPaymentStatus.ForeColor = System.Drawing.Color.Green;
                btnProceedToPayment.Visible = false;
            }
        }

        private void LoadTrainingSessions()
        {
            StringBuilder html = new StringBuilder();
            int memberId = (int)Session["UserID"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Query for sessions where the member is already participating
                string query = @"
            SELECT TP.ParticipationID, TS.TrainingName, TS.TrainingDate, TP.Attendance
            FROM TrainingParticipation TP
            INNER JOIN TrainingSessions TS ON TP.TrainingID = TS.TrainingID
            WHERE TP.MemberID = @MemberID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MemberID", memberId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // List all sessions where user is already participating
                while (reader.Read())
                {
                    html.Append("<tr>");
                    html.Append($"<td>{reader["TrainingName"]}</td>");
                    html.Append($"<td>{Convert.ToDateTime(reader["TrainingDate"]).ToString("yyyy-MM-dd")}</td>");

                    // Place "Mark Attendance" button in the Attendance column
                    bool isAttended = Convert.ToBoolean(reader["Attendance"]);
                    if (!isAttended)
                    {
                        html.Append($"<td><a class='btn btn-success' href='MemberDashboard.aspx?markAttendance={reader["ParticipationID"]}'>Mark Attendance</a></td>");
                    }
                    else
                    {
                        html.Append($"<td>Yes</td>");
                    }

                    // Display "Already Assigned" in the Actions column
                    html.Append("<td>Already Assigned</td>");
                    html.Append("</tr>");
                }
                connection.Close();

                // Query for available sessions where the member is NOT assigned
                query = @"
            SELECT TS.TrainingID, TS.TrainingName, TS.TrainingDate
            FROM TrainingSessions TS
            WHERE TS.TrainingID NOT IN (
                SELECT TrainingID 
                FROM TrainingParticipation 
                WHERE MemberID = @MemberID
            ) AND TS.TrainingDate >= GETDATE()";

                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MemberID", memberId);

                connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    html.Append("<tr>");
                    html.Append($"<td>{reader["TrainingName"]}</td>");
                    html.Append($"<td>{Convert.ToDateTime(reader["TrainingDate"]).ToString("yyyy-MM-dd")}</td>");
                    html.Append($"<td>Not Assigned</td>");
                    html.Append($"<td><a class='btn btn-primary' href='MemberDashboard.aspx?assignTraining={reader["TrainingID"]}'>Assign Yourself</a></td>");
                    html.Append("</tr>");
                }
            }

            ltTrainingSessions.Text = html.ToString();
        }



        private void AssignTraining(int trainingId)
        {
            int memberId = (int)Session["UserID"];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO TrainingParticipation (TrainingID, MemberID, AssignedDate, Attendance)
            VALUES (@TrainingID, @MemberID, GETDATE(), 0)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrainingID", trainingId);
                command.Parameters.AddWithValue("@MemberID", memberId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    lblMessage.Text = "You have been successfully assigned to the training session!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

            // Reload the training sessions
            LoadTrainingSessions();
        }


        private void MarkAttendance(int participationId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE TrainingParticipation SET Attendance = 1 WHERE ParticipationID = @ParticipationID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ParticipationID", participationId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    lblMessage.Text = "Attendance marked successfully!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

            LoadTrainingSessions();
        }

        protected void btnProceedToPayment_Click(object sender, EventArgs e)
        {
            Response.Redirect("Payment.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("loginsport.aspx");
        }
    }
}
