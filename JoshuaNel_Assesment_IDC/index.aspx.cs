using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JoshuaNel_Assesment_IDC
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void clientCapturebtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientCapture.aspx");
        }

        protected void clientOverviewbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClientOverview.aspx");
        }

        protected void paymentCapturebtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaymentCapture.aspx");
        }
    }
}