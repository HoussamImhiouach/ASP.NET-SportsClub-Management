using System;
using System.Data.SqlClient;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class PresidentDashboard : System.Web.UI.Page
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Verify User Role
            if (Session["UserRole"] == null || Session["UserRole"].ToString() != "President")
            {
                Response.Redirect("loginsport.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadDashboardStatistics();
            }
        }

        private void LoadDashboardStatistics()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Member Statistics
                lblTotalMembers.Text = GetScalarValue("SELECT COUNT(*) FROM Users", conn);

                // Revenue Statistics
                lblTotalRevenue.Text = GetScalarValue("SELECT ISNULL(SUM(Amount), 0) FROM Payments", conn);
                lblBasicRevenue.Text = GetScalarValue("SELECT ISNULL(SUM(Amount), 0) FROM Payments WHERE PlanName = 'Basic'", conn);
                lblPremiumRevenue.Text = GetScalarValue("SELECT ISNULL(SUM(Amount), 0) FROM Payments WHERE PlanName = 'Premium'", conn);
                lblPremiumPlusRevenue.Text = GetScalarValue("SELECT ISNULL(SUM(Amount), 0) FROM Payments WHERE PlanName = 'PremiumPlus'", conn);

                // Training Statistics
                lblTotalTrainings.Text = GetScalarValue("SELECT COUNT(*) FROM TrainingSessions", conn);
                lblUpcomingTrainings.Text = GetScalarValue("SELECT COUNT(*) FROM TrainingSessions WHERE TrainingDate >= GETDATE()", conn);

                // Latest Payment Date
                lblLatestPaymentDate.Text = GetScalarValue("SELECT ISNULL(MAX(PaymentDate), 'N/A') FROM Payments", conn);
            }
        }

        private string GetScalarValue(string query, SqlConnection conn)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                var result = cmd.ExecuteScalar();
                return result?.ToString() ?? "0";
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
