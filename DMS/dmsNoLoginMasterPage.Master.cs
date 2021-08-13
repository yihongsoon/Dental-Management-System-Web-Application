using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS
{
    public partial class dmsNoLoginMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hyplnkStaff.Enabled = false;
            hyplnkPatient.Enabled = false;
            hyplnkAppointment.Enabled = false;
            hyplnkReport.Enabled = false;
            hyplnkViewProfile.Visible = false;
            hyplnkViewAttendance.Visible = false;
            btnSignOut.Visible = false;
            WelcomeName.Visible = false;
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("loginPage.aspx");
        }
    }
}