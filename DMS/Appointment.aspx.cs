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
            appointmentId();

        }

        void AlertMessage(string msg)
        {
            Response.Write("<script type=\"text/javascript\">alert('" + msg + "')</script>");
        }

        public void appointmentId()
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 appointmentID FROM Appointment ORDER BY appointmentID DESC", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                if (dr.Read())
                {
                    String appointmentID = dr["appointmentID"].ToString();
                    var prefix = Regex.Match(appointmentID, "^\\D+").Value;
                    var number = Regex.Replace(appointmentID, "^\\D+", "");
                    var i = int.Parse(number) + 1;
                    var newString = prefix + i.ToString(new string('0', number.Length));
                    txtAddAppID.Text = newString;
                }
                else
                {
                    String appointmentID = "A000000";
                    var prefix = Regex.Match(appointmentID, "^\\D+").Value;
                    var number = Regex.Replace(appointmentID, "^\\D+", "");
                    var i = int.Parse(number) + 1;
                    var newString = prefix + i.ToString(new string('0', number.Length));
                    txtAddAppID.Text = newString;
                }
            }
            con.Close();
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

        protected void btnAddAppointment_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid == true)
            {
                SqlConnection con = new SqlConnection(strCon);
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Appointment(appointmentID, appointmentDate, appointmentTime, apointmentPurpose, patientID, staffID) VALUES(@appointmentID, @appointmentDate, @appointmentTime, @apointmentPurpose, @patientID, @staffID)", con);
                    cmd.Parameters.AddWithValue("@appointmentID", txtAddAppID.Text);
                    cmd.Parameters.AddWithValue("@appointmentDate", txtAddDate.Text);
                    cmd.Parameters.AddWithValue("@appointmentTime", txtAddTime.Text);
                    cmd.Parameters.AddWithValue("@apointmentPurpose", txtAddPurpose.Text);
                    cmd.Parameters.AddWithValue("@patientID", txtAddID.Text);
                    cmd.Parameters.AddWithValue("@staffID", txtAddStaff.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script type=\"text/javascript\">alert('Appointment details have been successfully added.');location.href='Appointment.aspx'</script>");
                }
                catch (SqlException ex)
                {
                    AlertMessage(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}