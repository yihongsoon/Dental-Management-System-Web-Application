using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS
{
    public partial class patientVisitPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("loginPage.aspx");
        }

        protected void btnBackPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("patientPage.aspx");
        }
    }
}