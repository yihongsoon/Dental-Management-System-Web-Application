﻿using DMS.Models;
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

using System.IO.Ports;
using System.Threading;
using WhatsAppApi;

namespace DMS
{
    public partial class Detail : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null && Request.QueryString["Id"] != string.Empty)
                {
                    string id = Request.QueryString["Id"].ToString();
                    using (SqlConnection con = new SqlConnection(strCon))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            con.Open();
                            cmd.CommandText = "SELECT appointmentID, appointmentName, dentistToVisit, appointmentDate, appointmentTime, appointmentPurpose, icNo, staffID FROM " +
                                "Appointment where appointmentID like '"+ id + "'";
                            cmd.Connection = con;
                            DataTable dt = new DataTable();

                            SqlDataReader dr = cmd.ExecuteReader();

                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                if (dr != null)
                                {
                                    if (dr.Read())
                                    {
                                        txtAppointID.Text = dr["appointmentID"].ToString();
                                        txtIcNo.Text = dr["icNo"].ToString();
                                        txtName.Text = dr["appointmentName"].ToString();
                                        txtDentToVisit.Text = dr["dentistToVisit"].ToString();
                                        //txtAppointDate.Text = dr["appointmentDate"].ToString();
                                        txtAppointDate.Text = Convert.ToDateTime(dr["appointmentDate"].ToString()).ToString("MMM dd, yyyy");
                                        txtAppointTime.Text = dr["appointmentTime"].ToString();
                                        txtStaffReg.Text = dr["staffID"].ToString();
                                        txtPurpose.Text = dr["appointmentPurpose"].ToString();
                                    }

                                }
                                con.Close();
                            }
                        }
                    }
                }

            }
        }

        void AlertMessage(string msg)
        {
            Response.Write("<script type=\"text/javascript\">alert('" + msg + "')</script>");
        }

        protected void GridViewCalendar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridViewCalendar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBackCalendar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Calender.aspx");
        }

        protected void sendWhatsapp(string number, string message)
        {
            try
            {
                if (number.Length <= 10)
                {
                    //MessageBox.Show("Code added automatically.");
                    number = "+60" + number;
                }

                System.Diagnostics.Process.Start("http://api.whatsapp.com/send?phone=" + number + "&text=" + message);
            }
            catch (Exception ex)
            {
                AlertMessage(ex.Message);
            }
        }

        protected void btnCalendarReminder_Click(object sender, EventArgs e)
        {
            
        }
    }
}