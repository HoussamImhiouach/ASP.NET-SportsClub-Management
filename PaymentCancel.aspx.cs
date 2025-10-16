using System;

namespace ProjetSportFinalHoussamEddineImhiouach
{
    public partial class PaymentCancel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRetry_Click(object sender, EventArgs e)
        {
            Response.Redirect("Payment.aspx");
        }
    }
}
