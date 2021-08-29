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
            //if (Session["username"] == null)
            //    Response.Redirect("loginPage.aspx");

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
            }
            
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
                    SqlCommand cmd1 = new SqlCommand("INSERT INTO Appointment(appointmentID, appointmentDate, appointmentTime, apointmentPurpose, patientID, staffID) VALUES(@appointmentID, @appointmentDate, @appointmentTime, @apointmentPurpose, @patientID, @staffID)", con);
                    cmd1.Parameters.AddWithValue("@appointmentID", txtAddAppID.Text);
                    cmd1.Parameters.AddWithValue("@appointmentDate", txtAddDate.Text);
                    cmd1.Parameters.AddWithValue("@appointmentTime", txtAddTime.Text);
                    cmd1.Parameters.AddWithValue("@apointmentPurpose", txtAddPurpose.Text);
                    cmd1.Parameters.AddWithValue("@patientID", txtAddID.Text);
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
            if (ddlSearchChoice.SelectedValue == "appointID" || ddlSearchChoice.SelectedValue == "patientID")
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
            if (ddlUpdateSearchType.SelectedValue == "appointID" || ddlUpdateSearchType.SelectedValue == "patientID")
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
            if (ddlDeleteSearchChoice.SelectedValue == "appointID" || ddlDeleteSearchChoice.SelectedValue == "patientID")
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
            if (ddlSearchChoice.SelectedValue == "appointID")
            {

                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.CommandText = "SELECT appointmentID, appointmentDate, appointmentTime, apointmentPurpose, patientID, staffID FROM Appointment where appointmentID LIKE '%' + @appointmentID + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@appointmentID", txtSearchChoice.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            GridViewSearch.DataSource = dt;
                            GridViewSearch.DataBind();
                        }
                    }
                }
            }
            else if (ddlSearchChoice.SelectedValue == "patientID")
            {

                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        var appointmentDate = DateTime.Now;
                        cmd.CommandText = "SELECT appointmentID, appointmentDate, appointmentTime, apointmentPurpose, patientID, staffID FROM Appointment where patientID LIKE '%' + @patientID + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@patientID", txtSearchChoice.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            GridViewSearch.DataSource = dt;
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
                        cmd.CommandText = "SELECT appointmentID, appointmentDate, appointmentTime, apointmentPurpose, patientID, staffID FROM Appointment where appointmentDate LIKE '%' + @appointmentDate + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@appointmentDate", txtSearchDate.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            GridViewSearch.DataSource = dt;
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
                        cmd.CommandText = "SELECT appointmentID, appointmentDate, appointmentTime, apointmentPurpose, patientID, staffID FROM Appointment where appointmentTime LIKE '%' + @appointmentTime + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@appointmentTime", txtSearchTime.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            GridViewSearch.DataSource = dt;
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
            txtPatientID.Text = GridViewSearch.SelectedRow.Cells[2].Text;
            txtAppointDate.Text = GridViewSearch.SelectedRow.Cells[3].Text;
            txtAppointTime.Text = GridViewSearch.SelectedRow.Cells[4].Text;
            txtStaffReg.Text = GridViewSearch.SelectedRow.Cells[5].Text;
            txtPurpose.Text = GridViewSearch.SelectedRow.Cells[6].Text;
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
            txtAppointDate.Text = "";
            txtAppointTime.Text = "";
            txtPurpose.Text = "";
            txtPatientID.Text = "";
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
            if (ddlUpdateSearchType.SelectedValue == "appointID")
            {

                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.CommandText = "SELECT appointmentID, appointmentDate, appointmentTime, apointmentPurpose, patientID, staffID FROM Appointment where appointmentID LIKE '%' + @appointmentID + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@appointmentID", txtUpdateAppointSearch.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            GridViewUpdate.DataSource = dt;
                            GridViewUpdate.DataBind();
                        }
                    }
                }
            }
            else if (ddlUpdateSearchType.SelectedValue == "patientID")
            {

                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        var appointmentDate = DateTime.Now;
                        cmd.CommandText = "SELECT appointmentID, appointmentDate, appointmentTime, apointmentPurpose, patientID, staffID FROM Appointment where patientID LIKE '%' + @patientID + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@patientID", txtUpdateAppointSearch.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            GridViewUpdate.DataSource = dt;
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
                        cmd.CommandText = "SELECT appointmentID, appointmentDate, appointmentTime, apointmentPurpose, patientID, staffID FROM Appointment where appointmentDate LIKE '%' + @appointmentDate + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@appointmentDate", txtUpdateSearchDate.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            GridViewUpdate.DataSource = dt;
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
                        cmd.CommandText = "SELECT appointmentID, appointmentDate, appointmentTime, apointmentPurpose, patientID, staffID FROM Appointment where appointmentTime LIKE '%' + @appointmentTime + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@appointmentTime", txtUpdateSearchTime.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            GridViewUpdate.DataSource = dt;
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
            txtUpdateID.Text = GridViewUpdate.SelectedRow.Cells[2].Text;
            txtUpdateDate.Text = GridViewUpdate.SelectedRow.Cells[3].Text;
            txtUpdateTime.Text = GridViewUpdate.SelectedRow.Cells[4].Text;
            txtUpdateStaff.Text = GridViewUpdate.SelectedRow.Cells[5].Text;
            txtUpdatePurpose.Text = GridViewUpdate.SelectedRow.Cells[6].Text;
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
            txtAppointDate.Text = "";
            txtAppointTime.Text = "";
            txtPurpose.Text = "";
            txtPatientID.Text = "";
            txtStaffReg.Text = "";
            pnlUpdateAppointBroad.Visible = true;
            pnlUpdateAppointSpecific.Visible = false;
            btnBackUpdate.Visible = false;
            this.BindGridUpdate();
        }

        protected void btnUpdateAppoint_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if(Page.IsValid == true)
            {
                SqlConnection con = new SqlConnection(strCon);
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Update Appointment set appointmentDate = @appointmentDate, appointmentTime = @appointmentTime, apointmentPurpose = @apointmentPurpose, patientID = @patientID, staffID = @staffID where appointmentID = @appointmentID", con);
                    cmd.Parameters.AddWithValue("@appointmentID", txtUptAppointID.Text);
                    cmd.Parameters.AddWithValue("@appointmentDate", txtUpdateDate.Text);
                    cmd.Parameters.AddWithValue("@appointmentTime", txtUpdateTime.Text);
                    cmd.Parameters.AddWithValue("@apointmentPurpose", txtUpdatePurpose.Text);
                    cmd.Parameters.AddWithValue("@patientID", txtUpdateID.Text);
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
            if (ddlDeleteSearchChoice.SelectedValue == "appointID")
            {

                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.CommandText = "SELECT appointmentID, appointmentDate, appointmentTime, apointmentPurpose, patientID, staffID FROM Appointment where appointmentID LIKE '%' + @appointmentID + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@appointmentID", txtDeleteAppointSearch.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            GridViewDelete.DataSource = dt;
                            GridViewDelete.DataBind();
                        }
                    }
                }
            }
            else if (ddlDeleteSearchChoice.SelectedValue == "patientID")
            {

                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        var appointmentDate = DateTime.Now;
                        cmd.CommandText = "SELECT appointmentID, appointmentDate, appointmentTime, apointmentPurpose, patientID, staffID FROM Appointment where patientID LIKE '%' + @patientID + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@patientID", txtDeleteAppointSearch.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            GridViewDelete.DataSource = dt;
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
                        cmd.CommandText = "SELECT appointmentID, appointmentDate, appointmentTime, apointmentPurpose, patientID, staffID FROM Appointment where appointmentDate LIKE '%' + @appointmentDate + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@appointmentDate", txtDeleteAppointDate.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            GridViewDelete.DataSource = dt;
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
                        cmd.CommandText = "SELECT appointmentID, appointmentDate, appointmentTime, apointmentPurpose, patientID, staffID FROM Appointment where appointmentTime LIKE '%' + @appointmentTime + '%'";
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@appointmentTime", txtDeleteAppointTime.Text);
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            GridViewDelete.DataSource = dt;
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
            txtDeleteID.Text = GridViewDelete.SelectedRow.Cells[2].Text;
            txtDeleteDate.Text = GridViewDelete.SelectedRow.Cells[3].Text;
            txtDeleteTime.Text = GridViewDelete.SelectedRow.Cells[4].Text;
            txtDeleteStaffReg.Text = GridViewDelete.SelectedRow.Cells[5].Text;
            txtDeletePurpose.Text = GridViewDelete.SelectedRow.Cells[6].Text;
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
            txtDeleteDate.Text = "";
            txtDeleteTime.Text = "";
            txtDeletePurpose.Text = "";
            txtDeleteID.Text = "";
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
        }
    }
}