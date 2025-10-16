using System;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("loginsport.aspx");
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            Response.Redirect("signupsport.aspx");
        }
    }
}
