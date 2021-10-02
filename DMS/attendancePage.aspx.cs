using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.IO;

namespace DMS
{
    public partial class attendancePage : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("loginPage.aspx");
            }
            else
            {
                fillin();
            }

        } 

        public void fillin()
        {
            txtID.Text = Session["ID"].ToString();            
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Staff.staffID, Staff.position, Staff.icNo, Person.name from Staff, Person where Staff.staffID = @id AND Person.icNo = Staff.icNo", con);
            cmd.Parameters.AddWithValue("@id", Session["ID"].ToString());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                if (dr.Read())
                {
                    txtID.Text = dr["staffID"].ToString();
                    txtPosition.Text = dr["position"].ToString();
                    txtName.Text = dr["name"].ToString();
                    txtIC.Text = dr["icNo"].ToString();
                }
            }
            con.Close();
            con.Open();
            int count = 0;
            SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) from Attendance where staffID = @id AND month = @month", con);
            cmd2.Parameters.AddWithValue("@id", Session["ID"].ToString());
            cmd2.Parameters.AddWithValue("@month", DateTime.Now.Month);
            count = Convert.ToInt32(cmd2.ExecuteScalar());
            txtMonth.Text = DateTime.Now.Month.ToString();
            txtTotalAttendance.Text = count.ToString();
            con.Close();
        }

        protected void lnkCheckIn_Click(object sender, EventArgs e)
        {
            pnlAttendance.Visible = false;
            pnlCheckIn.Visible = true;
            pnlCheckOut.Visible = false;
            pnlDetails.Visible = false;
            pnlQrCode.Visible = false;
            pnlQrCodeCheckOut.Visible = false;
            lnkAttendance.CssClass = "nav-link show";
            lnkCheckIn.CssClass = "nav-link show active";
            lnkCheckOut.CssClass = "nav-link show";
            lnkDetails.CssClass = "nav-link show";
        }

        protected void lnkCheckOut_Click(object sender, EventArgs e)
        {
            pnlAttendance.Visible = false;
            pnlCheckIn.Visible = false;
            pnlCheckOut.Visible = true;
            pnlDetails.Visible = false;
            pnlQrCode.Visible = false;
            pnlQrCodeCheckOut.Visible = false;
            lnkAttendance.CssClass = "nav-link show";
            lnkCheckIn.CssClass = "nav-link show";
            lnkCheckOut.CssClass = "nav-link show active";
            lnkDetails.CssClass = "nav-link show";
        }

        protected void lnkDetails_Click(object sender, EventArgs e)
        {
            pnlAttendance.Visible = false;
            pnlCheckIn.Visible = false;
            pnlCheckOut.Visible = false;
            pnlDetails.Visible = true;
            pnlQrCode.Visible = false;
            pnlQrCodeCheckOut.Visible = false;
            lnkAttendance.CssClass = "nav-link show";
            lnkCheckIn.CssClass = "nav-link show";
            lnkCheckOut.CssClass = "nav-link show";
            lnkDetails.CssClass = "nav-link show active";
        }

        protected void lnkAttendance_Click(object sender, EventArgs e)
        {
            pnlAttendance.Visible = true;
            pnlCheckIn.Visible = false;
            pnlCheckOut.Visible = false;
            pnlDetails.Visible = false;
            pnlQrCode.Visible = false;
            pnlQrCodeCheckOut.Visible = false;
            lnkAttendance.CssClass = "nav-link show active";
            lnkCheckIn.CssClass = "nav-link show";
            lnkCheckOut.CssClass = "nav-link show";
            lnkDetails.CssClass = "nav-link show";
        }

        protected void btnCheckIn_Click(object sender, EventArgs e)
        {

            if (txtCheckInIC.Text != string.Empty && txtCheckInPass.Text != string.Empty)
            {
                emptyField.Visible = false;
                try
                {
                    SqlConnection con = new SqlConnection(strCon);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from Staff where Staff.icNo = @ic AND Staff.password = @pass", con);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO Attendance(staffID, workingDate, checkInTime, checkOutTime, offday, publicHoliday, day, month, year)" +
                    //    " VALUES(@id, @workingDate, @InTime, @OutTime, @off, @holiday, @day, @month, @year)", con);
                    cmd.Parameters.AddWithValue("@ic", txtCheckInIC.Text);
                    cmd.Parameters.AddWithValue("@pass", txtCheckInPass.Text);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr != null)
                    {
                        if (dr.Read())
                        {
                            checkInInsert();
                            checkInFail.Visible = false;
                        }
                        else
                        {
                            checkInFail.Visible = true;
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }
            else
            {
                emptyField.Visible = true;
            }
        }

        public void checkInInsert()
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Attendance where staffID = @id AND workingDate = @workingDate", con);
                //SqlCommand cmd = new SqlCommand("INSERT INTO Attendance(staffID, workingDate, checkInTime, checkOutTime, offday, publicHoliday, day, month, year)" +
                //    " VALUES(@id, @workingDate, @InTime, @OutTime, @off, @holiday, @day, @month, @year)", con);
                cmd.Parameters.AddWithValue("@id", Session["ID"].ToString());                
                cmd.Parameters.AddWithValue("@workingDate", Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")));
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    if(dr.Read())
                    {                       
                        ShowMessage("Duplicated Check In");
                    }
                    else
                    {
                        SqlConnection con2 = new SqlConnection(strCon);
                        con2.Open();
                        SqlCommand cmd2 = new SqlCommand("INSERT INTO Attendance(staffID, workingDate, checkInTime, day, month, year)" +
                            " VALUES(@id, @workingDate, @InTime, @day, @month, @year)", con2);
                        cmd2.Parameters.AddWithValue("@id", Session["ID"].ToString());
                        var date = DateTime.Now.ToString("dd-MM-yyyy");
                        cmd2.Parameters.AddWithValue("@workingDate", DateTime.Now);
                        var time24 = DateTime.Now.ToString("HH:mm:ss");                                          
                        cmd2.Parameters.AddWithValue("@InTime", time24);
                        cmd2.Parameters.AddWithValue("@day", DateTime.Now.Day);
                        cmd2.Parameters.AddWithValue("@month", DateTime.Now.Month);
                        cmd2.Parameters.AddWithValue("@year", DateTime.Now.Year);
                        cmd2.ExecuteNonQuery();
                        con2.Close();
                        ShowMessage("Check In Successfully");
                    }
                }
                
                con.Close();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            

        }
        void ShowMessage(string msg)
        {
            //ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script  language = 'javascript' > alert('" + msg + "');</ script > ");
            Response.Write("<script type=\"text/javascript\">alert('" + msg + "')</script>");
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (txtCheckOutIC.Text != string.Empty && txtCheckOutPassword.Text != string.Empty)
            {
                checkOutEmpty.Visible = false;
                try
                {
                    SqlConnection con = new SqlConnection(strCon);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from Staff where Staff.icNo = @ic AND Staff.password = @pass", con);
                    //SqlCommand cmd = new SqlCommand("INSERT INTO Attendance(staffID, workingDate, checkInTime, checkOutTime, offday, publicHoliday, day, month, year)" +
                    //    " VALUES(@id, @workingDate, @InTime, @OutTime, @off, @holiday, @day, @month, @year)", con);
                    cmd.Parameters.AddWithValue("@ic", txtCheckOutIC.Text);
                    cmd.Parameters.AddWithValue("@pass", txtCheckOutPassword.Text);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr != null)
                    {
                        if (dr.Read())
                        {
                            checkOutInsert();
                            checkOutInvalid.Visible = false;
                        }
                        else
                        {
                            checkOutInvalid.Visible = true;
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }
            else
            {
                checkOutEmpty.Visible = true;
            }
        }

        public void checkOutInsert()
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select checkOutTime from Attendance where staffID = @id AND workingDate = @workingDate", con);
                //SqlCommand cmd = new SqlCommand("INSERT INTO Attendance(staffID, workingDate, checkInTime, checkOutTime, offday, publicHoliday, day, month, year)" +
                //    " VALUES(@id, @workingDate, @InTime, @OutTime, @off, @holiday, @day, @month, @year)", con);
                cmd.Parameters.AddWithValue("@id", Session["ID"].ToString());
                cmd.Parameters.AddWithValue("@workingDate", Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")));
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    if (dr.Read())
                    {
                        if(dr.IsDBNull(dr.GetOrdinal("checkOutTime")))
                        {
                            SqlConnection con2 = new SqlConnection(strCon);
                            con2.Open();
                            SqlCommand cmd2 = new SqlCommand("Update Attendance set checkOutTime = @OutTime Where workingDate = @workingDateCheckOut", con2);
                            var time24 = DateTime.Now.ToString("HH:mm:ss");
                            cmd2.Parameters.AddWithValue("@OutTime", time24);
                            cmd2.Parameters.AddWithValue("@workingDateCheckOut", Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")));
                            cmd2.ExecuteNonQuery();
                            con2.Close();
                            ShowMessage("Check Out Successfully");
                        }
                        else
                        {
                            ShowMessage("Duplicate Check Out");
                        }
                    }
                    else
                    {
                        ShowMessage("Please Check In First");
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }


        }

        protected void lnkbtnQRCheckIn_Click(object sender, EventArgs e)
        {
            pnlQrCode.Visible = true;
            pnlCheckIn.Visible = false;
        }

        protected void btnBackQRCheckIn_Click(object sender, EventArgs e)
        {
            pnlQrCode.Visible = false;
            pnlCheckIn.Visible = true;
        }

        protected void QRCheckIn_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(HiddenField1.Value.ToString(), @"^[\d]{12}(,[\w\.-]+@[\w\.-]+\.\w{2,4})$"))
            {
                string[] splitvalue = HiddenField1.Value.ToString().Split(',');
                string first = splitvalue[0];
                string second = splitvalue[1];
                QRCheckInCheck(first, second);
                pnlQrCode.Visible = false;
                pnlCheckIn.Visible = true;
            }
            else
            {
                ShowMessage("Wrong QR Code, Please Scan Again");
                pnlQrCode.Visible = true;
                pnlCheckIn.Visible = false;
            }

        }

        protected void QRCheckInCheck(string ic, string email)
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Staff where icNo = @ic AND email = @email", con);
                //SqlCommand cmd = new SqlCommand("INSERT INTO Attendance(staffID, workingDate, checkInTime, checkOutTime, offday, publicHoliday, day, month, year)" +
                //    " VALUES(@id, @workingDate, @InTime, @OutTime, @off, @holiday, @day, @month, @year)", con);
                cmd.Parameters.AddWithValue("@ic", ic.ToString());
                cmd.Parameters.AddWithValue("@email", email.ToString());
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    if (dr.Read())
                    {
                        QRCheckInInsert();
                    }
                    else
                    {
                        ShowMessage("Check In Fail");
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        public void QRCheckInInsert()
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Attendance where staffID = @id AND workingDate = @workingDate", con);
                //SqlCommand cmd = new SqlCommand("INSERT INTO Attendance(staffID, workingDate, checkInTime, checkOutTime, offday, publicHoliday, day, month, year)" +
                //    " VALUES(@id, @workingDate, @InTime, @OutTime, @off, @holiday, @day, @month, @year)", con);
                cmd.Parameters.AddWithValue("@id", Session["ID"].ToString());
                cmd.Parameters.AddWithValue("@workingDate", Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")));
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    if (dr.Read())
                    {
                        ShowMessage("Duplicated Check In");
                    }
                    else
                    {
                        SqlConnection con2 = new SqlConnection(strCon);
                        con2.Open();
                        SqlCommand cmd2 = new SqlCommand("INSERT INTO Attendance(staffID, workingDate, checkInTime, day, month, year)" +
                            " VALUES(@id, @workingDate, @InTime, @day, @month, @year)", con2);
                        cmd2.Parameters.AddWithValue("@id", Session["ID"].ToString());
                        var date = DateTime.Now.ToString("dd-MM-yyyy");
                        cmd2.Parameters.AddWithValue("@workingDate", DateTime.Now);
                        var time24 = DateTime.Now.ToString("HH:mm:ss");
                        cmd2.Parameters.AddWithValue("@InTime", time24);
                        cmd2.Parameters.AddWithValue("@day", DateTime.Now.Day);
                        cmd2.Parameters.AddWithValue("@month", DateTime.Now.Month);
                        cmd2.Parameters.AddWithValue("@year", DateTime.Now.Year);
                        cmd2.ExecuteNonQuery();
                        con2.Close();
                        ShowMessage("Check In Successfully");
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }


        }

        protected void lnkbtnQRCheckOut_Click(object sender, EventArgs e)
        {
            pnlQrCodeCheckOut.Visible = true;
            pnlCheckOut.Visible = false;
        }

        protected void btnBackQRCheckOut_Click(object sender, EventArgs e) 
        {
            pnlQrCodeCheckOut.Visible = false;
            pnlCheckOut.Visible = true;
        }

        protected void btnQRCheckOut_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(HiddenField2.Value.ToString(), @"^[\d]{12}(,[\w\.-]+@[\w\.-]+\.\w{2,4})$"))
            {
                string[] splitvalue = HiddenField2.Value.ToString().Split(',');
                string first = splitvalue[0];
                string second = splitvalue[1];
                QRCheckOutCheck(first, second);
                pnlQrCodeCheckOut.Visible = false;
                pnlCheckOut.Visible = true;
            }
            else
            {
                ShowMessage("Wrong QR Code, Please Scan Again");
                pnlQrCodeCheckOut.Visible = true;
                pnlCheckOut.Visible = false;
            }
        }

        protected void QRCheckOutCheck(string ic, string email)
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Staff where icNo = @ic AND email = @email", con);
                //SqlCommand cmd = new SqlCommand("INSERT INTO Attendance(staffID, workingDate, checkInTime, checkOutTime, offday, publicHoliday, day, month, year)" +
                //    " VALUES(@id, @workingDate, @InTime, @OutTime, @off, @holiday, @day, @month, @year)", con);
                cmd.Parameters.AddWithValue("@ic", ic.ToString());
                cmd.Parameters.AddWithValue("@email", email.ToString());
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    if (dr.Read())
                    {
                        QRCheckOutInsert();
                    }
                    else
                    {
                        ShowMessage("Check Out Fail");
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        public void QRCheckOutInsert()
        {
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select checkOutTime from Attendance where staffID = @id AND workingDate = @workingDate", con);
                //SqlCommand cmd = new SqlCommand("INSERT INTO Attendance(staffID, workingDate, checkInTime, checkOutTime, offday, publicHoliday, day, month, year)" +
                //    " VALUES(@id, @workingDate, @InTime, @OutTime, @off, @holiday, @day, @month, @year)", con);
                cmd.Parameters.AddWithValue("@id", Session["ID"].ToString());
                cmd.Parameters.AddWithValue("@workingDate", Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")));
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    if (dr.Read())
                    {
                        if (dr.IsDBNull(dr.GetOrdinal("checkOutTime")))
                        {
                            SqlConnection con2 = new SqlConnection(strCon);
                            con2.Open();
                            SqlCommand cmd2 = new SqlCommand("Update Attendance set checkOutTime = @OutTime Where workingDate = @workingDateCheckOut", con2);
                            var time24 = DateTime.Now.ToString("HH:mm:ss");
                            cmd2.Parameters.AddWithValue("@OutTime", time24);
                            cmd2.Parameters.AddWithValue("@workingDateCheckOut", Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")));
                            cmd2.ExecuteNonQuery();
                            con2.Close();
                            ShowMessage("Check Out Successfully");
                        }
                        else
                        {
                            ShowMessage("Duplicate Check Out");
                        }
                    }
                    else
                    {
                        ShowMessage("Please Check In First");
                    }
                }

                con.Close();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }


        }

        protected void btnGenerateExcel_Click(object sender, EventArgs e)
        {
           this.BindGrid();
           ExportGridToExcel();
        }

        protected void btnGeneratePDF_Click(object sender, EventArgs e)
        {
            this.BindGrid();
            ExportGridToPDF();
        }
        protected void onPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPrint.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }

        private void BindGrid()
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT workingDate, checkInTime, checkOutTime, day, month , year from Attendance where staffID = @id and month = @month", con);
            cmd.Parameters.AddWithValue("@month", DateTime.Now.Month.ToString());
            cmd.Parameters.AddWithValue("@id", Session["ID"].ToString());
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
                GridViewPrint.DataSource = dt;
                GridViewPrint.DataBind();
            }
            con.Close();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }
        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "" + Session["ID"].ToString() + "_MonthlyAttendanceReport_" + DateTime.Now.ToString("ddMMyyyy") + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "Application/x-msexcel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridViewPrint.GridLines = GridLines.Both;
            GridViewPrint.HeaderStyle.Font.Bold = true;
            GridViewPrint.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }

        private void ExportGridToPDF()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "" + Session["ID"].ToString() + "_MonthlyAttendanceReport_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            GridViewPrint.GridLines = GridLines.Both;
            GridViewPrint.HeaderStyle.Font.Bold = true;
            GridViewPrint.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
    }
}