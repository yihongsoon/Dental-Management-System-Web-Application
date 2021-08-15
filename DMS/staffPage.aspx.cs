using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS
{
    public partial class staffPage : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["ID"] == null)
            //{
            //    Response.Redirect("~/loginPage.aspx");
            //}
            id();
            
        }

        public void id()
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) As 'Row_Count' FROM  Staff", con);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            String staffID = "S10000";
            var prefix = Regex.Match(staffID, "^\\D+").Value;
            var number = Regex.Replace(staffID, "^\\D+", "");
            var i = int.Parse(number) + 1 + count;
            var newString = prefix + i.ToString(new string('0', number.Length));
            txtAddID.Text = newString;
        }


        protected void lnkAdd_Click(object sender, EventArgs e)
        {
            tabstaffAdd.Visible = true;
            tabstaffAttendance.Visible = false;
            tabstaffDelete.Visible = false;
            tabstaffSearch.Visible = false;
            tabstaffUpdate.Visible = false;
            lnkAdd.CssClass = "nav-link show active";
            lnkAttendance.CssClass = "nav-link show";
            lnkDelete.CssClass = "nav-link show";
            lnkSearch.CssClass = "nav-link show";
            lnkUpdate.CssClass = "nav-link show";
        }

        protected void lnkUpdate_Click(object sender, EventArgs e)
        {
            tabstaffAdd.Visible = false;
            tabstaffAttendance.Visible = false;
            tabstaffDelete.Visible = false;
            tabstaffSearch.Visible = false;
            tabstaffUpdate.Visible = true;
            lnkAdd.CssClass = "nav-link show";
            lnkAttendance.CssClass = "nav-link show";
            lnkDelete.CssClass = "nav-link show";
            lnkSearch.CssClass = "nav-link show";
            lnkUpdate.CssClass = "nav-link show active";
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            tabstaffAdd.Visible = false;
            tabstaffAttendance.Visible = false;
            tabstaffDelete.Visible = true;
            tabstaffSearch.Visible = false;
            tabstaffUpdate.Visible = false;
            lnkAdd.CssClass = "nav-link show";
            lnkAttendance.CssClass = "nav-link show";
            lnkDelete.CssClass = "nav-link show active";
            lnkSearch.CssClass = "nav-link show";
            lnkUpdate.CssClass = "nav-link show";
        }

        protected void lnkAttendance_Click(object sender, EventArgs e)
        {
            tabstaffAdd.Visible = false;
            tabstaffAttendance.Visible = true;
            tabstaffDelete.Visible = false;
            tabstaffSearch.Visible = false;
            tabstaffUpdate.Visible = false;
            lnkAdd.CssClass = "nav-link show";
            lnkAttendance.CssClass = "nav-link show active";
            lnkDelete.CssClass = "nav-link show";
            lnkSearch.CssClass = "nav-link show";
            lnkUpdate.CssClass = "nav-link show";
        }

        protected void lnkSearch_Click(object sender, EventArgs e)
        {
            tabstaffAdd.Visible = false;
            tabstaffAttendance.Visible = false;
            tabstaffDelete.Visible = false;
            tabstaffSearch.Visible = true;
            tabstaffUpdate.Visible = false;
            lnkAdd.CssClass = "nav-link show";
            lnkAttendance.CssClass = "nav-link show";
            lnkDelete.CssClass = "nav-link show";
            lnkSearch.CssClass = "nav-link show  active";
            lnkUpdate.CssClass = "nav-link show";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}