using DMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            if (Session["ID"] == null)
            {
                Response.Redirect("~/loginPage.aspx");
            }
            else
            {
                txtAddStaff.Text = Session["ID"].ToString();
            }

            appointmentId();

            //SqlConnection con = new SqlConnection(strCon);
            //con.Open();
            //string com = "SELECT Person.icNo, Person.name, Staff.icNo, Staff.position from Person, Staff where Person.icNo = Staff.icNo AND Staff.position = 'Dentist'";
            //SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            //DataTable dt = new DataTable();
            //adpt.Fill(dt);
            //ddlAddDentist.DataSource = dt;
            //ddlAddDentist.DataBind();
            //ddlAddDentist.DataTextField = "name";
            //ddlAddDentist.DataValueField = "name";
            //ddlAddDentist.DataBind();

            //ddlUpdateDentist.DataSource = dt;
            //ddlUpdateDentist.DataBind();
            //ddlUpdateDentist.DataTextField = "name";
            //ddlUpdateDentist.DataValueField = "name";
            //ddlUpdateDentist.DataBind();

            if (!this.IsPostBack)
            {
                if (GridViewSearch.Rows != null)
                {
                    pnlSearchAppointBroad.Visible = true;
                    this.BindGrid();
                }

                if (GridViewUpdate.Rows != null)
                {
                    pnlUpdateAppointBroad.Visible = true;
                    this.BindGridUpdate();
                }

                if (GridViewDelete.Rows != null)
                {
                    pnlDeleteAppointBroad.Visible = true;
                    this.BindGridDelete();
                }
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                string com = "SELECT Person.icNo, Person.name, Staff.icNo, Staff.position from Person, Staff where Person.icNo = Staff.icNo AND Staff.position = 'Dentist'";
                SqlDataAdapter adpt = new SqlDataAdapter(com, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ddlAddDentist.DataSource = dt;
                ddlAddDentist.DataBind();
                ddlAddDentist.DataTextField = "name";
                ddlAddDentist.DataValueField = "name";
                ddlAddDentist.DataBind();

                ddlUpdateDentist.DataSource = dt;
                ddlUpdateDentist.DataBind();
                ddlUpdateDentist.DataTextField = "name";
                ddlUpdateDentist.DataValueField = "name";
                ddlUpdateDentist.DataBind();

            }
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
            txtUpdateAppointSearch.Text = "";
            txtUpdateSearchDate.Text = "";
            txtUpdateSearchTime.Text = "";
            txtDeleteAppointSearch.Text = "";
            txtDeleteAppointDate.Text = "";
            txtDeleteAppointTime.Text = "";
            tabSearchAppoint.Visible = true;
            tabAddAppoint.Visible = false;
            tabUpdateAppoint.Visible = false;
            tabDeleteAppoint.Visible = false;
            lnkSearchAppoint.CssClass = "nav-link show active";
            lnkAddAppoint.CssClass = "nav-link show";
            lnkUpdateAppoint.CssClass = "nav-link show";
            lnkDeleteAppoint.CssClass = "nav-link show";
            this.BindGridUpdate();
            this.BindGridDelete();
        }

        protected void lnkAddAppoint_Click(object sender, EventArgs e)
        {
            txtSearchChoice.Text = "";
            txtSearchDate.Text = "";
            txtSearchTime.Text = "";
            txtDeleteAppointSearch.Text = "";
            txtDeleteAppointDate.Text = "";
            txtDeleteAppointTime.Text = "";
            txtUpdateAppointSearch.Text = "";
            txtUpdateSearchDate.Text = "";
            txtUpdateSearchTime.Text = "";
            tabSearchAppoint.Visible = false;
            tabAddAppoint.Visible = true;
            tabUpdateAppoint.Visible = false;
            tabDeleteAppoint.Visible = false;
            lnkSearchAppoint.CssClass = "nav-link show";
            lnkAddAppoint.CssClass = "nav-link show active";
            lnkUpdateAppoint.CssClass = "nav-link show";
            lnkDeleteAppoint.CssClass = "nav-link show";
            this.BindGrid();
            this.BindGridUpdate();
            this.BindGridDelete();
        }

        protected void lnkUpdateAppoint_Click(object sender, EventArgs e)
        {
            txtSearchChoice.Text = "";
            txtSearchDate.Text = "";
            txtSearchTime.Text = "";
            txtDeleteAppointSearch.Text = "";
            txtDeleteAppointDate.Text = "";
            txtDeleteAppointTime.Text = "";
            tabSearchAppoint.Visible = false;
            tabAddAppoint.Visible = false;
            tabUpdateAppoint.Visible = true;
            tabDeleteAppoint.Visible = false;
            lnkSearchAppoint.CssClass = "nav-link show";
            lnkAddAppoint.CssClass = "nav-link show";
            lnkUpdateAppoint.CssClass = "nav-link show active";
            lnkDeleteAppoint.CssClass = "nav-link show";
            this.BindGrid();
            this.BindGridDelete();
        }

        protected void lnkDeleteAppoint_Click(object sender, EventArgs e)
        {
            txtSearchChoice.Text = "";
            txtSearchDate.Text = "";
            txtSearchTime.Text = "";
            txtUpdateAppointSearch.Text = "";
            txtUpdateSearchDate.Text = "";
            txtUpdateSearchTime.Text = "";
            tabSearchAppoint.Visible = false;
            tabAddAppoint.Visible = false;
            tabUpdateAppoint.Visible = false;
            tabDeleteAppoint.Visible = true;
            lnkSearchAppoint.CssClass = "nav-link show";
            lnkAddAppoint.CssClass = "nav-link show";
            lnkUpdateAppoint.CssClass = "nav-link show";
            lnkDeleteAppoint.CssClass = "nav-link show active";
            this.BindGrid();
            this.BindGridUpdate();
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
                    SqlCommand cmd1 = new SqlCommand("INSERT INTO Appointment(appointmentID, appointmentName, dentistToVisit, appointmentDate, appointmentTime, appointmentPurpose, icNo, staffID) VALUES(@appointmentID, @appointmentName, @dentistToVisit, @appointmentDate, @appointmentTime, @appointmentPurpose, @icNo, @staffID)", con);
                    cmd1.Parameters.AddWithValue("@appointmentID", txtAddAppID.Text);
                    cmd1.Parameters.AddWithValue("@appointmentName", txtAddName.Text);
                    cmd1.Parameters.AddWithValue("@dentistToVisit", ddlAddDentist.SelectedValue);
                    cmd1.Parameters.AddWithValue("@appointmentDate", txtAddDate.Text);
                    cmd1.Parameters.AddWithValue("@appointmentTime", ddlAddTime.SelectedValue);
                    cmd1.Parameters.AddWithValue("@appointmentPurpose", txtAddPurpose.Text);
                    cmd1.Parameters.AddWithValue("@patientID",txtAddIC.Text);
                    cmd1.Parameters.AddWithValue("@icNo", txtAddIC.Text);
                    cmd1.Parameters.AddWithValue("@staffID", txtAddStaff.Text);
                    
                    cmd1.ExecuteNonQuery();
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

        protected void ddlSearchChoice_Select(object sender, EventArgs e)
        {
            if (ddlSearchChoice.SelectedValue == "name" || ddlSearchChoice.SelectedValue == "icNo")
            {
                txtSearchChoice.Visible = true;
                txtSearchDate.Visible = false;
                txtSearchTime.Visible = false;
            }
            else if (ddlSearchChoice.SelectedValue == "appointDate")
            {
                txtSearchChoice.Visible = false;
                txtSearchDate.Visible = true;
                txtSearchTime.Visible = false;
            }
            else
            {
                txtSearchChoice.Visible = false;
                txtSearchDate.Visible = false;
                txtSearchTime.Visible = true;
            }
        }

        protected void ddlUpdateSearchType_Select(object sender, EventArgs e)
        {
            if (ddlUpdateSearchType.SelectedValue == "name" || ddlUpdateSearchType.SelectedValue == "icNo")
            {
                txtUpdateAppointSearch.Visible = true;
                txtUpdateSearchDate.Visible = false;
                txtUpdateSearchTime.Visible = false;
            }
            else if (ddlUpdateSearchType.SelectedValue == "appointDate")
            {
                txtUpdateAppointSearch.Visible = false;
                txtUpdateSearchDate.Visible = true;
                txtUpdateSearchTime.Visible = false;
            }
            else
            {
                txtUpdateAppointSearch.Visible = false;
                txtUpdateSearchDate.Visible = false;
                txtUpdateSearchTime.Visible = true;
            }
        }

        protected void ddlDeleteSearchChoice_Select(object sender, EventArgs e)
        {
            if (ddlDeleteSearchChoice.SelectedValue == "name" || ddlDeleteSearchChoice.SelectedValue == "icNo")
            {
                txtDeleteAppointSearch.Visible = true;
                txtDeleteAppointDate.Visible = false;
                txtDeleteAppointTime.Visible = false;
            }
            else if (ddlDeleteSearchChoice.SelectedValue == "appointDate")
            {
                txtDeleteAppointSearch.Visible = false;
                txtDeleteAppointDate.Visible = true;
                txtDeleteAppointTime.Visible = false;
            }
            else
            {
                txtDeleteAppointSearch.Visible = false;
                txtDeleteAppointDate.Visible = false;
                txtDeleteAppointTime.Visible = true;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

        private void BindGrid()
        {
            if (ddlSearchChoice.SelectedValue == "name")
            {

                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.CommandText = "SELECT appointmentID, appointmentName, dentistToVisit, appointmentDate, appointmentTime, appointmentPurpose, icNo, staffID FROM Appointment where appointmentName LIKE '%' + @appointmentName + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@appointmentName", txtSearchChoice.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            var data = dt.AsEnumerable().Select(x => new AppointmentViewModel
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
                            GridViewSearch.DataSource = data;
                            GridViewSearch.DataBind();
                        }
                    }
                }
            }
            else if (ddlSearchChoice.SelectedValue == "icNo")
            {

                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        var appointmentDate = DateTime.Now;
                        cmd.CommandText = "SELECT appointmentID, appointmentName, dentistToVisit, appointmentDate, appointmentTime, appointmentPurpose, icNo, staffID FROM Appointment where icNo LIKE '%' + @icNo + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@icNo", txtSearchChoice.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            var data = dt.AsEnumerable().Select(x=> new AppointmentViewModel {
                                appointmentID = x.Field<string>("appointmentID"),
                                appointmentName = x.Field<string>("appointmentName"),
                                dentistToVisit = x.Field<string>("dentistToVisit"),
                                appointmentDate = (x.Field<DateTime>("appointmentDate")).ToString("MMM dd, yyyy"),
                                appointmentTime = ((x.Field<TimeSpan>("appointmentTime")).ToString()),
                                appointmentPurpose = x.Field<string>("appointmentPurpose"),
                                icNo = x.Field<string>("icNo"),
                                staffID = x.Field<string>("staffID")
                            }).ToList(); ;
                            GridViewSearch.DataSource = data;
                            GridViewSearch.DataBind();
                        }
                    }
                }
            }
            else if (ddlSearchChoice.SelectedValue == "appointDate")
            {

                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.CommandText = "SELECT appointmentID, appointmentName, dentistToVisit, appointmentDate, appointmentTime, appointmentPurpose, icNo, staffID FROM Appointment where appointmentDate LIKE '%' + @appointmentDate + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@appointmentDate", txtSearchDate.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            var data = dt.AsEnumerable().Select(x => new AppointmentViewModel
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
                            GridViewSearch.DataSource = data;
                            GridViewSearch.DataBind();
                        }
                    }
                }
            }
            else
            {

                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.CommandText = "SELECT appointmentID, appointmentName, dentistToVisit, appointmentDate, appointmentTime, appointmentPurpose, icNo, staffID FROM Appointment where appointmentTime LIKE '%' + @appointmentTime + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@appointmentTime", txtSearchTime.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            var data = dt.AsEnumerable().Select(x => new AppointmentViewModel
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
                            GridViewSearch.DataSource = data;
                            GridViewSearch.DataBind();
                        }
                    }
                }
            }

        }

        protected void onPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewSearch.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }


        protected void GridViewSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAppointID.Text = GridViewSearch.SelectedRow.Cells[1].Text;
            txtIcNo.Text = GridViewSearch.SelectedRow.Cells[2].Text;
            txtName.Text = GridViewSearch.SelectedRow.Cells[3].Text;
            txtDentToVisit.Text = GridViewSearch.SelectedRow.Cells[4].Text;
            txtAppointDate.Text = GridViewSearch.SelectedRow.Cells[5].Text;
            txtAppointTime.Text = GridViewSearch.SelectedRow.Cells[6].Text;
            txtStaffReg.Text = GridViewSearch.SelectedRow.Cells[7].Text;
            txtPurpose.Text = GridViewSearch.SelectedRow.Cells[8].Text;
            pnlSearchAppointBroad.Visible = false;
            pnlSearchPatientSpecific.Visible = true;
            btnBackSearch.Visible = true;
        }

        protected void btnBackSearch_Click(object sender, EventArgs e)
        {
            txtSearchChoice.Text = "";
            txtSearchTime.Text = "";
            txtSearchDate.Text = "";
            txtAppointID.Text = "";
            txtIcNo.Text = "";
            txtName.Text = "";
            txtDentToVisit.Text = "";
            txtAppointDate.Text = "";
            txtAppointTime.Text = "";
            txtPurpose.Text = "";
            txtStaffReg.Text = "";
            pnlSearchAppointBroad.Visible = true;
            pnlSearchPatientSpecific.Visible = false;
            btnBackSearch.Visible = false;
            this.BindGrid();
        }

        protected void btnUpdateAppointSearch_Click(object sender, EventArgs e)
        {
            this.BindGridUpdate();
        }

        private void BindGridUpdate()
        {
            if (ddlUpdateSearchType.SelectedValue == "name")
            {

                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.CommandText = "SELECT appointmentID, appointmentName, dentistToVisit, appointmentDate, appointmentTime, appointmentPurpose, icNo, staffID FROM Appointment where appointmentName LIKE '%' + @appointmentName + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@appointmentName", txtUpdateAppointSearch.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            var data = dt.AsEnumerable().Select(x => new AppointmentViewModel
                            {
                                appointmentID = x.Field<string>("appointmentID"),
                                appointmentName = x.Field<string>("appointmentName"),
                                dentistToVisit = x.Field<string>("dentistToVisit"),
                                appointmentDate = (x.Field<DateTime>("appointmentDate")).ToString("MMM dd, yyyy"),
                                //appointmentDate = (x.Field<DateTime>("appointmentDate")).ToString("dd/MM/yyyy"),
                                appointmentTime = ((x.Field<TimeSpan>("appointmentTime")).ToString()),
                                appointmentPurpose = x.Field<string>("appointmentPurpose"),
                                icNo = x.Field<string>("icNo"),
                                staffID = x.Field<string>("staffID")
                            }).ToList();
                            GridViewUpdate.DataSource = data;
                            GridViewUpdate.DataBind();
                        }
                    }
                }
            }
            else if (ddlUpdateSearchType.SelectedValue == "icNo")
            {

                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        var appointmentDate = DateTime.Now;
                        cmd.CommandText = "SELECT appointmentID, appointmentName, dentistToVisit, appointmentDate, appointmentTime, appointmentPurpose, icNo, staffID FROM Appointment where icNo LIKE '%' + @icNo + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@icNo", txtUpdateAppointSearch.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            var data = dt.AsEnumerable().Select(x => new AppointmentViewModel
                            {
                                appointmentID = x.Field<string>("appointmentID"),
                                appointmentName = x.Field<string>("appointmentName"),
                                dentistToVisit = x.Field<string>("dentistToVisit"),
                                appointmentDate = (x.Field<DateTime>("appointmentDate")).ToString("MMM dd, yyyy"),
                                appointmentTime = ((x.Field<TimeSpan>("appointmentTime")).ToString()),
                                appointmentPurpose = x.Field<string>("appointmentPurpose"),
                                icNo = x.Field<string>("icNo"),
                                staffID = x.Field<string>("staffID")
                            }).ToList(); ;
                            GridViewUpdate.DataSource = data;
                            GridViewUpdate.DataBind();
                        }
                    }
                }
            }
            else if (ddlUpdateSearchType.SelectedValue == "appointDate")
            {

                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.CommandText = "SELECT appointmentID, appointmentName, dentistToVisit, appointmentDate, appointmentTime, appointmentPurpose, icNo, staffID FROM Appointment where appointmentDate LIKE '%' + @appointmentDate + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@appointmentDate", txtUpdateSearchDate.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            var data = dt.AsEnumerable().Select(x => new AppointmentViewModel
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
                            GridViewUpdate.DataSource = data;
                            GridViewUpdate.DataBind();
                        }
                    }
                }
            }
            else
            {

                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.CommandText = "SELECT appointmentID, appointmentName, dentistToVisit, appointmentDate, appointmentTime, appointmentPurpose, icNo, staffID FROM Appointment where appointmentTime LIKE '%' + @appointmentTime + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@appointmentTime", txtUpdateSearchTime.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            var data = dt.AsEnumerable().Select(x => new AppointmentViewModel
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
                            GridViewUpdate.DataSource = data;
                            GridViewUpdate.DataBind();
                        }
                    }
                }
            }
        }

        protected void onPageIndexChangingUpdate(object sender, GridViewPageEventArgs e)
        {
            GridViewUpdate.PageIndex = e.NewPageIndex;
            this.BindGridUpdate();
        }

        protected void GridViewUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUptAppointID.Text = GridViewUpdate.SelectedRow.Cells[1].Text;
            txtUpdateIC.Text = GridViewUpdate.SelectedRow.Cells[2].Text;
            txtUpdateName.Text = GridViewUpdate.SelectedRow.Cells[3].Text;
            ddlUpdateDentist.SelectedValue = GridViewUpdate.SelectedRow.Cells[4].Text;
            txtUpdateDate.Text = Convert.ToDateTime(GridViewUpdate.SelectedRow.Cells[5].Text).ToString("yyyy-MM-dd");
            ddlUpdateTime.SelectedValue = GridViewUpdate.SelectedRow.Cells[6].Text;
            txtUpdateStaff.Text = GridViewUpdate.SelectedRow.Cells[7].Text;
            txtUpdatePurpose.Text = GridViewUpdate.SelectedRow.Cells[8].Text;
            pnlUpdateAppointBroad.Visible = false;
            pnlUpdateAppointSpecific.Visible = true;
            btnBackUpdate.Visible = true;
        }

        protected void btnBackUpdate_Click(object sender, EventArgs e)
        {
            txtUpdateAppointSearch.Text = "";
            txtUpdateSearchDate.Text = "";
            txtUpdateSearchTime.Text = "";
            txtAppointID.Text = "";
            txtIcNo.Text = "";
            txtName.Text = "";
            txtDentToVisit.Text = "";
            txtAppointDate.Text = "";
            txtAppointTime.Text = "";
            txtPurpose.Text = "";
            txtStaffReg.Text = "";
            pnlUpdateAppointBroad.Visible = true;
            pnlUpdateAppointSpecific.Visible = false;
            btnBackUpdate.Visible = false;
            this.BindGridUpdate();
        }

        protected void btnUpdateAppoint_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid == true)
            {
                SqlConnection con = new SqlConnection(strCon);
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update Appointment set appointmentDate = @appointmentDate, appointmentName = @appointmentName, dentistToVisit = @dentistToVisit, appointmentTime = @appointmentTime, appointmentPurpose = @appointmentPurpose, icNo = @icNo, staffID = @staffID where appointmentID = @appointmentID", con);
                    cmd.Parameters.AddWithValue("@appointmentID", txtUptAppointID.Text);
                    cmd.Parameters.AddWithValue("@appointmentName", txtUpdateName.Text);
                    cmd.Parameters.AddWithValue("@dentistToVisit", ddlUpdateDentist.SelectedValue);
                    cmd.Parameters.AddWithValue("@appointmentDate", txtUpdateDate.Text);
                    cmd.Parameters.AddWithValue("@appointmentTime", ddlUpdateTime.SelectedValue);
                    cmd.Parameters.AddWithValue("@appointmentPurpose", txtUpdatePurpose.Text);
                    cmd.Parameters.AddWithValue("@icNo", txtUpdateIC.Text);
                    cmd.Parameters.AddWithValue("@staffID", txtUpdateStaff.Text);
                    cmd.ExecuteNonQuery();
                    AlertMessage("Appointment details have been successfully updated.");
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

        protected void btnDeleteAppointSearch_Click(object sender, EventArgs e)
        {
            this.BindGridDelete();
        }

        private void BindGridDelete()
        {
            if (ddlDeleteSearchChoice.SelectedValue == "name")
            {

                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.CommandText = "SELECT appointmentID, appointmentName, dentistToVisit, appointmentDate, appointmentTime, appointmentPurpose, icNo, staffID FROM Appointment where appointmentName LIKE '%' + @appointmentName + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@appointmentName", txtDeleteAppointSearch.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            var data = dt.AsEnumerable().Select(x => new AppointmentViewModel
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
                            GridViewDelete.DataSource = data;
                            GridViewDelete.DataBind();
                        }
                    }
                }
            }
            else if (ddlDeleteSearchChoice.SelectedValue == "icNo")
            {

                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        var appointmentDate = DateTime.Now;
                        cmd.CommandText = "SELECT appointmentID, appointmentName, dentistToVisit, appointmentDate, appointmentTime, appointmentPurpose, icNo, staffID FROM Appointment where icNo LIKE '%' + @icNo + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@icNo", txtDeleteAppointSearch.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            var data = dt.AsEnumerable().Select(x => new AppointmentViewModel
                            {
                                appointmentID = x.Field<string>("appointmentID"),
                                appointmentName = x.Field<string>("appointmentName"),
                                dentistToVisit = x.Field<string>("dentistToVisit"),
                                appointmentDate = (x.Field<DateTime>("appointmentDate")).ToString("MMM dd, yyyy"),
                                appointmentTime = ((x.Field<TimeSpan>("appointmentTime")).ToString()),
                                appointmentPurpose = x.Field<string>("appointmentPurpose"),
                                icNo = x.Field<string>("icNo"),
                                staffID = x.Field<string>("staffID")
                            }).ToList(); ;
                            GridViewDelete.DataSource = data;
                            GridViewDelete.DataBind();
                        }
                    }
                }
            }
            else if (ddlDeleteSearchChoice.SelectedValue == "appointDate")
            {

                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.CommandText = "SELECT appointmentID, appointmentName, dentistToVisit, appointmentDate, appointmentTime, appointmentPurpose, icNo, staffID FROM Appointment where appointmentDate LIKE '%' + @appointmentDate + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@appointmentDate", txtDeleteAppointDate.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            var data = dt.AsEnumerable().Select(x => new AppointmentViewModel
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
                            GridViewDelete.DataSource = data;
                            GridViewDelete.DataBind();
                        }
                    }
                }
            }
            else
            {

                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.CommandText = "SELECT appointmentID, appointmentName, dentistToVisit, appointmentDate, appointmentTime, appointmentPurpose, icNo, staffID FROM Appointment where appointmentTime LIKE '%' + @appointmentTime + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@appointmentTime", txtDeleteAppointTime.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            var data = dt.AsEnumerable().Select(x => new AppointmentViewModel
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
                            GridViewDelete.DataSource = data;
                            GridViewDelete.DataBind();
                        }
                    }
                }
            }
        }

        protected void onPageIndexChangingDelete(object sender, GridViewPageEventArgs e)
        {
            GridViewDelete.PageIndex = e.NewPageIndex;
            this.BindGridDelete();
        }

        protected void GridViewDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDeleteAppointID.Text = GridViewDelete.SelectedRow.Cells[1].Text;
            txtDeleteIC.Text = GridViewDelete.SelectedRow.Cells[2].Text;
            txtDeleteName.Text = GridViewDelete.SelectedRow.Cells[3].Text;
            txtDeleteToVisit.Text = GridViewDelete.SelectedRow.Cells[4].Text;
            txtDeleteDate.Text = GridViewDelete.SelectedRow.Cells[5].Text;
            txtDeleteTime.Text = GridViewDelete.SelectedRow.Cells[6].Text;
            txtDeleteStaffReg.Text = GridViewDelete.SelectedRow.Cells[7].Text;
            txtDeletePurpose.Text = GridViewDelete.SelectedRow.Cells[8].Text;
            pnlDeleteAppointBroad.Visible = false;
            pnlDeleteAppointSpecific.Visible = true;
            btnBackDelete.Visible = true;
        }

        protected void btnBackDelete_Click(object sender, EventArgs e)
        {
            txtDeleteAppointSearch.Text = "";
            txtDeleteAppointDate.Text = "";
            txtDeleteAppointTime.Text = "";
            txtDeleteAppointID.Text = "";
            txtDeleteIC.Text = "";
            txtDeleteName.Text = "";
            txtDeleteToVisit.Text = "";
            txtDeleteDate.Text = "";
            txtDeleteTime.Text = "";
            txtDeletePurpose.Text = "";
            txtDeleteStaffReg.Text = "";
            pnlDeleteAppointBroad.Visible = true;
            pnlDeleteAppointSpecific.Visible = false;
            btnBackDelete.Visible = false;
            this.BindGridDelete();
        }

        protected void btnDeleteAppointment_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid == true)
            {
                string confirmValue = Request.Form["confirm_value"];

                if (confirmValue == "Yes")
                {
                    SqlConnection con = new SqlConnection(strCon);
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Appointment WHERE appointmentID = @appointmentID", con);
                        cmd.Parameters.AddWithValue("@appointmentID", txtDeleteAppointID.Text);
                        cmd.ExecuteNonQuery();
                        Response.Write("<script type=\"text/javascript\">alert('Appointment details have been successfully deleted.');location.href='Appointment.aspx'</script>");
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
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Appointment Details have not been successfully deleted.')</script>");
                }
            }
        }

        protected void txtAddIC_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.CommandText = "SELECT name from Person where icNo =" + txtAddIC.Text + "";
                        cmd.Connection = con;
                        var _result = cmd.ExecuteScalar();
                        cmd.Dispose();
                        con.Close();
                        if (_result != null)
                            txtAddName.Text = _result.ToString();
                    };
                };
            }
            catch(Exception ex)
            {
                txtAddName.Text = string.Empty;
                Response.Write("<script type=\"text/javascript\">alert('Patient does not exist in the system.')</script>");
            }
           
         
        }
    }
}