using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetSportFinalHoussamEddneImhiouach
{
    public partial class EditMember : System.Web.UI.Page
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string memberId = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(memberId))
                {
                    LoadMemberDetails(memberId);
                }
                else
                {
                    Response.Redirect("ManageMembers.aspx");
                }
            }
        }

        private void LoadMemberDetails(string memberId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT FullName, Email, Role FROM Users WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", memberId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtFullName.Text = reader["FullName"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                                ddlRole.SelectedValue = reader["Role"].ToString();
                            }
                            else
                            {
                                lblMessage.Text = "Member not found!";
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string memberId = Request.QueryString["id"];
            string fullName = txtFullName.Text;
            string email = txtEmail.Text;
            string role = ddlRole.SelectedValue;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Users SET FullName = @FullName, Email = @Email, Role = @Role WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", fullName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Role", role);
                        command.Parameters.AddWithValue("@Id", memberId);
                        command.ExecuteNonQuery();
                    }
                }

                lblMessage.Text = "Member updated successfully!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("ManageMembers.aspx");
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}