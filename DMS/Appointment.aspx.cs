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
    public partial class mainPage : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["username"] == null)
            //    Response.Redirect("loginPage.aspx");
            AppointmentId();

        }

        public void AppointmentId()
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) As 'Row_Count' FROM  Appointment", con);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            String appointmentID = "A00000";
            var prefix = Regex.Match(appointmentID, "^\\D+").Value;
            var number = Regex.Replace(appointmentID, "^\\D+", "");
            var i = int.Parse(number) + 1 + count;
            var newString = prefix + i.ToString(new string('0', number.Length));
            txtAddAppID.Text = newString;
        }

        protected void lnkSearchAppoint_Click(object sender, EventArgs e)
        {
            tabSearchAppoint.Visible = true;
            tabAddAppoint.Visible = false;
            tabUpdateAppoint.Visible = false;
            tabDeleteAppoint.Visible = false;
            lnkSearchAppoint.CssClass = "nav-link show active";
            lnkAddAppoint.CssClass = "nav-link show";
            lnkUpdateAppoint.CssClass = "nav-link show";
            lnkDeleteAppoint.CssClass = "nav-link show";
        }

        protected void lnkAddAppoint_Click(object sender, EventArgs e)
        {
            tabSearchAppoint.Visible = false;
            tabAddAppoint.Visible = true;
            tabUpdateAppoint.Visible = false;
            tabDeleteAppoint.Visible = false;
            lnkSearchAppoint.CssClass = "nav-link show";
            lnkAddAppoint.CssClass = "nav-link show active";
            lnkUpdateAppoint.CssClass = "nav-link show";
            lnkDeleteAppoint.CssClass = "nav-link show";
        }

        protected void lnkUpdateAppoint_Click(object sender, EventArgs e)
        {
            tabSearchAppoint.Visible = false;
            tabAddAppoint.Visible = false;
            tabUpdateAppoint.Visible = true;
            tabDeleteAppoint.Visible = false;
            lnkSearchAppoint.CssClass = "nav-link show";
            lnkAddAppoint.CssClass = "nav-link show";
            lnkUpdateAppoint.CssClass = "nav-link show active";
            lnkDeleteAppoint.CssClass = "nav-link show";
        }

        protected void lnkDeleteAppoint_Click(object sender, EventArgs e)
        {
            tabSearchAppoint.Visible = false;
            tabAddAppoint.Visible = false;
            tabUpdateAppoint.Visible = false;
            tabDeleteAppoint.Visible = true;
            lnkSearchAppoint.CssClass = "nav-link show";
            lnkAddAppoint.CssClass = "nav-link show";
            lnkUpdateAppoint.CssClass = "nav-link show";
            lnkDeleteAppoint.CssClass = "nav-link show active";
        }
    }
}