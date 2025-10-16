using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetSportFinalHoussamEddneImhiouach
{
    public partial class DeleteMember : System.Web.UI.Page
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClubManagementDB;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            string memberId = Request.QueryString["id"];

            if (!string.IsNullOrEmpty(memberId))
            {
                DeleteMemberById(memberId);
            }
            Response.Redirect("ManageMembers.aspx");
        }

        private void DeleteMemberById(string memberId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Users WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", memberId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}