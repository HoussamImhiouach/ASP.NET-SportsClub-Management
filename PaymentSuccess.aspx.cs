using System;
using System.Data.SqlClient;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class PaymentSuccess : System.Web.UI.Page
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null || Session["PlanName"] == null || Session["Amount"] == null)
            {
                lblMessage.Text = "Session expired or invalid payment details.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (!IsPostBack)
            {
                SavePaymentToDatabase();
            }
        }

        private void SavePaymentToDatabase()
        {
            int userId = (int)Session["UserID"];
            string planName = Session["PlanName"].ToString();
            decimal amount = Convert.ToDecimal(Session["Amount"]);
            DateTime paymentDate = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Payments (UserID, PlanName, Amount, PaymentDate) 
                                 VALUES (@UserID, @PlanName, @Amount, @PaymentDate)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userId);
                command.Parameters.AddWithValue("@PlanName", planName);
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@PaymentDate", paymentDate);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Your membership payment has been updated successfully.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMessage.Text = "Failed to save the payment. Please contact support.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberDashboard.aspx");
        }
    }
}
