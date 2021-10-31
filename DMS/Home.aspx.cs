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
                        todayAppointNotFound.Visible = false;
                    }
                }
            }
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

        protected void btnReminderToday_Click(object sender, EventArgs e)
        {

        }
    }
}