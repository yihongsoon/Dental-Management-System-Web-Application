using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS
{
    public partial class dmsMasterpage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["Role"] as string))
            {
                if (Session["Role"].ToString() == "STAFF")
                {
                    hyplnkStaff.Enabled = false;
                    btnSignOut.Visible = true;
                    hyplnkViewAttendance.Visible = true;
                    hyplnkViewProfile.Visible = true;
                    hyplnkChangePassword.Visible = true;
                    welcomeName.Text = Session["ID"].ToString();
                }
                else if (Session["Role"].ToString() == "ADMIN")
                {
                    hyplnkStaff.Enabled = true;
                    btnSignOut.Visible = true;
                    hyplnkViewAttendance.Visible = false;
                    hyplnkViewProfile.Visible = false;
                    hyplnkChangePassword.Visible = false;
                    welcomeName.Text = Session["ID"].ToString();
                }
            }
            else
            {
                Response.Redirect("loginPage.aspx");
            }

        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session["ID"] = "";
            Session["Role"] = "";
            Response.Redirect("~/loginPage.aspx");
        }
    }
}