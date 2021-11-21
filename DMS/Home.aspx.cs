using DMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using WhatsAppApi;
namespace DMS
{
    public partial class Home : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.CommandText = "SELECT appointmentID, appointmentName, dentistToVisit, appointmentDate, appointmentTime, appointmentPurpose, icNo, staffID FROM Appointment";
                    cmd.Connection = con;
                    DataTable dt = new DataTable();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        var data = dt.AsEnumerable().Where(x => x.Field<DateTime>("appointmentDate").Date == DateTime.Now.Date).Select(x => new AppointmentViewModel
                        {
                            appointmentID = x.Field<string>("appointmentID"),
                            appointmentName = x.Field<string>("appointmentName"),
                            dentistToVisit = x.Field<string>("dentistToVisit"),
                            appointmentDate = (x.Field<DateTime>("appointmentDate")).ToString("MMM dd, yyyy"),
                            appointmentTime = ((x.Field<TimeSpan>("appointmentTime")).ToString()),
                            appointmentPurpose = x.Field<string>("appointmentPurpose"),
                            icNo = x.Field<string>("icNo"),
                            staffID = x.Field<string>("staffID")
                        }).ToList();
                        GridViewTodayAppoint.DataSource = data;
                        GridViewTodayAppoint.DataBind();
                        if (data.Count > 0)
                        {
                            pnlGridToday.Visible = true;
                            pnlNotFound.Visible = false;
                        }
                        else
                        {
                            pnlGridToday.Visible = false;
                            pnlNotFound.Visible = true;
                        }
                    }



                }
            }
        }

        void AlertMessage(string msg)
        {
            Response.Write("<script type=\"text/javascript\">alert('" + msg + "')</script>");
        }

        protected void GridViewTodayAppoint_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridViewTodayAppoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAppointID.Text = GridViewTodayAppoint.SelectedRow.Cells[1].Text;
            txtIcNo.Text = GridViewTodayAppoint.SelectedRow.Cells[2].Text;
            txtName.Text = GridViewTodayAppoint.SelectedRow.Cells[3].Text;
            txtDentToVisit.Text = GridViewTodayAppoint.SelectedRow.Cells[4].Text;
            txtAppointDate.Text = GridViewTodayAppoint.SelectedRow.Cells[5].Text;
            txtAppointTime.Text = GridViewTodayAppoint.SelectedRow.Cells[6].Text;
            txtStaffReg.Text = GridViewTodayAppoint.SelectedRow.Cells[7].Text;
            txtPurpose.Text = GridViewTodayAppoint.SelectedRow.Cells[8].Text;
            pnlGridToday.Visible = true;
            pnlTodayDetails.Visible = true;
        }

        protected void btnBackToday_Click(object sender, EventArgs e)
        {
            txtAppointID.Text = "";
            txtIcNo.Text = "";
            txtName.Text = "";
            txtDentToVisit.Text = "";
            txtAppointDate.Text = "";
            txtAppointTime.Text = "";
            txtPurpose.Text = "";
            txtStaffReg.Text = "";
            pnlGridToday.Visible = true;
            pnlTodayDetails.Visible = false;
        }

        protected void sendWhatsapp(string number, string message)
        {
            try
            {
                if(number.Length <= 10)
                {
                    //MessageBox.Show("Code added automatically.");
                    number = "+60" + number;
                }
             
                System.Diagnostics.Process.Start("http://api.whatsapp.com/send?phone=" + number + "&text=" + message);
            }
            catch(Exception ex)
            {
                AlertMessage(ex.Message);
            }
        }

        protected void btnReminderToday_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strCon);


            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT Appointment.appointmentName, Appointment.appointmentDate, Appointment.appointmentTime, Person.contactNo, Appointment.appointmentID " +
                "from Person, Appointment where Person.icNo = Appointment.icNo AND Appointment.appointmentID = '"+txtAppointID.Text+"'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Session["appointmentName"] = dr[0];
                    Session["appointmentDate"] = dr[1];
                    Session["appointmentTime"] = dr[2];
                    Session["contactNo"] = dr[3];
                    Session["appointmentID"] = dr[4];
                }
                con.Close();
            }
            con.Close();
            String msg = "Hello " + Session["appointmentName"].ToString() + ", " +
                           "we are sending from TARUC Dental Clinic. " +
                           "Please be reminded that you will be having an appointment with us today at " + Session["appointmentTime"].ToString() + ". " +
                           "Thank You!";
            sendWhatsapp(Session["contactNo"].ToString(), msg);
        }
    }
}