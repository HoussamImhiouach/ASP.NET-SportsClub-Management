using System;
using System.Data.SqlClient;
using System.Configuration;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class Payment : System.Web.UI.Page
    {
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("loginsport.aspx");
            }

            // Always bind data if RadioButtonList is empty
            if (!IsPostBack || rblPlans.Items.Count == 0)
            {
                PopulatePlans();
            }
        }

        private void PopulatePlans()
        {
            rblPlans.Items.Clear(); // Clear previous values
            rblPlans.Items.Add(new System.Web.UI.WebControls.ListItem("Basic Plan - $100", "Basic|100"));
            rblPlans.Items.Add(new System.Web.UI.WebControls.ListItem("Premium Plan - $250", "Premium|250"));
            rblPlans.Items.Add(new System.Web.UI.WebControls.ListItem("Premium+ Plan - $300", "PremiumPlus|300"));
        }

        protected void btnPayPal_Click(object sender, EventArgs e)
        {
            if (rblPlans.SelectedItem == null)
            {
                lblMessage.Text = "Please select a plan before proceeding.";
                return;
            }

            try
            {
                // Parse the selected plan
                string[] selectedPlan = rblPlans.SelectedValue.Split('|');
                string planName = selectedPlan[0];
                decimal amount = Convert.ToDecimal(selectedPlan[1]);

                // Retrieve UserID from Session
                string userId = Session["UserID"].ToString();

                // Insert purchase into the database
                SavePurchaseToDatabase(userId, planName, amount);

                // Store details in Session for confirmation
                Session["PlanName"] = planName;
                Session["Amount"] = amount;

                Response.Redirect("PaymentSuccess.aspx");
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred: " + ex.Message;
            }
        }


                    

        private void SavePurchaseToDatabase(string userId, string planName, decimal amount)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    INSERT INTO Payments (UserID, PlanName, Amount, PaymentDate)
                    VALUES (@UserID, @PlanName, @Amount, GETDATE())";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@PlanName", planName);
                    cmd.Parameters.AddWithValue("@Amount", amount);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
