using System;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear the session
            Session.Clear();
            Session.Abandon();

            
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetNoStore();

            // Display success message
            Response.Write("Success");
        }
    }
}
