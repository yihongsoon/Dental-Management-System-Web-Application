using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                fillinSecond();
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
        }

        public void fillinSecond()
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();

            con.Close();
        }

        protected void lnkCheckIn_Click(object sender, EventArgs e)
        {
            pnlAttendance.Visible = false;
            pnlCheckIn.Visible = true;
            pnlCheckOut.Visible = false;
            pnlDetails.Visible = false;
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
                            SqlCommand cmd2 = new SqlCommand("Update Attendance set checkOutTime = @OutTime", con2);
                            var time24 = DateTime.Now.ToString("HH:mm:ss");
                            cmd2.Parameters.AddWithValue("@OutTime", time24);
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
    }
}