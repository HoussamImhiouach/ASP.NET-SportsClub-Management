using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetSportFinalHoussamEddneImhiouach
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is NOT logged in
            if (Session["UserID"] == null)
            {
                // Allow access to the HomePage without redirection
                string currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);
                if (currentPage != "HomePage.aspx")
                {
                    Response.Redirect("loginsport.aspx");
                }
            }
        }

    }
}