using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;
using System.Data;
using System.Globalization;



namespace DMS
{
    public partial class reportPage : System.Web.UI.Page
    {        
        string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("~/loginPage.aspx");
            }
            buttonGenerateCheck();
        }

        private void buttonGenerateCheck()
        {
            int year = DateTime.Now.Year;
            if(year.ToString() == ddlYear.SelectedValue)
            {
                int month = DateTime.Now.Month;
                if (month == 1)
                {
                    BtnGen1.CssClass = "mt-2 btn btn-secondary";
                    BtnGen2.CssClass = "mt-2 btn btn-secondary";
                    BtnGen3.CssClass = "mt-2 btn btn-secondary";
                    BtnGen4.CssClass = "mt-2 btn btn-secondary";
                    BtnGen5.CssClass = "mt-2 btn btn-secondary";
                    BtnGen6.CssClass = "mt-2 btn btn-secondary";
                    BtnGen7.CssClass = "mt-2 btn btn-secondary";
                    BtnGen8.CssClass = "mt-2 btn btn-secondary";
                    BtnGen9.CssClass = "mt-2 btn btn-secondary";
                    BtnGen10.CssClass = "mt-2 btn btn-secondary";
                    BtnGen11.CssClass = "mt-2 btn btn-secondary";
                    BtnGen12.CssClass = "mt-2 btn btn-secondary";
                    BtnGen1.Enabled = false;
                    BtnGen2.Enabled = false;
                    BtnGen3.Enabled = false;
                    BtnGen4.Enabled = false;
                    BtnGen5.Enabled = false;
                    BtnGen6.Enabled = false;
                    BtnGen7.Enabled = false;
                    BtnGen8.Enabled = false;
                    BtnGen9.Enabled = false;
                    BtnGen10.Enabled = false;
                    BtnGen11.Enabled = false;
                    BtnGen12.Enabled = false;
                }
                else if (month == 2)
                {
                    BtnGen1.CssClass = "mt-2 btn btn-primary";
                    BtnGen2.CssClass = "mt-2 btn btn-secondary";
                    BtnGen3.CssClass = "mt-2 btn btn-secondary";
                    BtnGen4.CssClass = "mt-2 btn btn-secondary";
                    BtnGen5.CssClass = "mt-2 btn btn-secondary";
                    BtnGen6.CssClass = "mt-2 btn btn-secondary";
                    BtnGen7.CssClass = "mt-2 btn btn-secondary";
                    BtnGen8.CssClass = "mt-2 btn btn-secondary";
                    BtnGen9.CssClass = "mt-2 btn btn-secondary";
                    BtnGen10.CssClass = "mt-2 btn btn-secondary";
                    BtnGen11.CssClass = "mt-2 btn btn-secondary";
                    BtnGen12.CssClass = "mt-2 btn btn-secondary";
                    BtnGen1.Enabled = true;
                    BtnGen2.Enabled = false;
                    BtnGen3.Enabled = false;
                    BtnGen4.Enabled = false;
                    BtnGen5.Enabled = false;
                    BtnGen6.Enabled = false;
                    BtnGen7.Enabled = false;
                    BtnGen8.Enabled = false;
                    BtnGen9.Enabled = false;
                    BtnGen10.Enabled = false;
                    BtnGen11.Enabled = false;
                    BtnGen12.Enabled = false;
                }
                else if (month == 3)
                {
                    BtnGen1.CssClass = "mt-2 btn btn-primary";
                    BtnGen2.CssClass = "mt-2 btn btn-primary";
                    BtnGen3.CssClass = "mt-2 btn btn-secondary";
                    BtnGen4.CssClass = "mt-2 btn btn-secondary";
                    BtnGen5.CssClass = "mt-2 btn btn-secondary";
                    BtnGen6.CssClass = "mt-2 btn btn-secondary";
                    BtnGen7.CssClass = "mt-2 btn btn-secondary";
                    BtnGen8.CssClass = "mt-2 btn btn-secondary";
                    BtnGen9.CssClass = "mt-2 btn btn-secondary";
                    BtnGen10.CssClass = "mt-2 btn btn-secondary";
                    BtnGen11.CssClass = "mt-2 btn btn-secondary";
                    BtnGen12.CssClass = "mt-2 btn btn-secondary";
                    BtnGen1.Enabled = true;
                    BtnGen2.Enabled = true;
                    BtnGen3.Enabled = false;
                    BtnGen4.Enabled = false;
                    BtnGen5.Enabled = false;
                    BtnGen6.Enabled = false;
                    BtnGen7.Enabled = false;
                    BtnGen8.Enabled = false;
                    BtnGen9.Enabled = false;
                    BtnGen10.Enabled = false;
                    BtnGen11.Enabled = false;
                    BtnGen12.Enabled = false;
                }
                else if (month == 4)
                {
                    BtnGen1.CssClass = "mt-2 btn btn-primary";
                    BtnGen2.CssClass = "mt-2 btn btn-primary";
                    BtnGen3.CssClass = "mt-2 btn btn-primary";
                    BtnGen4.CssClass = "mt-2 btn btn-secondary";
                    BtnGen5.CssClass = "mt-2 btn btn-secondary";
                    BtnGen6.CssClass = "mt-2 btn btn-secondary";
                    BtnGen7.CssClass = "mt-2 btn btn-secondary";
                    BtnGen8.CssClass = "mt-2 btn btn-secondary";
                    BtnGen9.CssClass = "mt-2 btn btn-secondary";
                    BtnGen10.CssClass = "mt-2 btn btn-secondary";
                    BtnGen11.CssClass = "mt-2 btn btn-secondary";
                    BtnGen12.CssClass = "mt-2 btn btn-secondary";
                    BtnGen1.Enabled = true;
                    BtnGen2.Enabled = true;
                    BtnGen3.Enabled = true;
                    BtnGen4.Enabled = false;
                    BtnGen5.Enabled = false;
                    BtnGen6.Enabled = false;
                    BtnGen7.Enabled = false;
                    BtnGen8.Enabled = false;
                    BtnGen9.Enabled = false;
                    BtnGen10.Enabled = false;
                    BtnGen11.Enabled = false;
                    BtnGen12.Enabled = false;
                }
                else if (month == 5)
                {
                    BtnGen1.CssClass = "mt-2 btn btn-primary";
                    BtnGen2.CssClass = "mt-2 btn btn-primary";
                    BtnGen3.CssClass = "mt-2 btn btn-primary";
                    BtnGen4.CssClass = "mt-2 btn btn-primary";
                    BtnGen5.CssClass = "mt-2 btn btn-secondary";
                    BtnGen6.CssClass = "mt-2 btn btn-secondary";
                    BtnGen7.CssClass = "mt-2 btn btn-secondary";
                    BtnGen8.CssClass = "mt-2 btn btn-secondary";
                    BtnGen9.CssClass = "mt-2 btn btn-secondary";
                    BtnGen10.CssClass = "mt-2 btn btn-secondary";
                    BtnGen11.CssClass = "mt-2 btn btn-secondary";
                    BtnGen12.CssClass = "mt-2 btn btn-secondary";
                    BtnGen1.Enabled = true;
                    BtnGen2.Enabled = true;
                    BtnGen3.Enabled = true;
                    BtnGen4.Enabled = true;
                    BtnGen5.Enabled = false;
                    BtnGen6.Enabled = false;
                    BtnGen7.Enabled = false;
                    BtnGen8.Enabled = false;
                    BtnGen9.Enabled = false;
                    BtnGen10.Enabled = false;
                    BtnGen11.Enabled = false;
                    BtnGen12.Enabled = false;
                }
                else if (month == 6)
                {
                    BtnGen1.CssClass = "mt-2 btn btn-primary";
                    BtnGen2.CssClass = "mt-2 btn btn-primary";
                    BtnGen3.CssClass = "mt-2 btn btn-primary";
                    BtnGen4.CssClass = "mt-2 btn btn-primary";
                    BtnGen5.CssClass = "mt-2 btn btn-primary";
                    BtnGen6.CssClass = "mt-2 btn btn-secondary";
                    BtnGen7.CssClass = "mt-2 btn btn-secondary";
                    BtnGen8.CssClass = "mt-2 btn btn-secondary";
                    BtnGen9.CssClass = "mt-2 btn btn-secondary";
                    BtnGen10.CssClass = "mt-2 btn btn-secondary";
                    BtnGen11.CssClass = "mt-2 btn btn-secondary";
                    BtnGen12.CssClass = "mt-2 btn btn-secondary";
                    BtnGen1.Enabled = true;
                    BtnGen2.Enabled = true;
                    BtnGen3.Enabled = true;
                    BtnGen4.Enabled = true;
                    BtnGen5.Enabled = true;
                    BtnGen6.Enabled = false;
                    BtnGen7.Enabled = false;
                    BtnGen8.Enabled = false;
                    BtnGen9.Enabled = false;
                    BtnGen10.Enabled = false;
                    BtnGen11.Enabled = false;
                    BtnGen12.Enabled = false;
                }
                else if (month == 7)
                {
                    BtnGen1.CssClass = "mt-2 btn btn-primary";
                    BtnGen2.CssClass = "mt-2 btn btn-primary";
                    BtnGen3.CssClass = "mt-2 btn btn-primary";
                    BtnGen4.CssClass = "mt-2 btn btn-primary";
                    BtnGen5.CssClass = "mt-2 btn btn-primary";
                    BtnGen6.CssClass = "mt-2 btn btn-primary";
                    BtnGen7.CssClass = "mt-2 btn btn-secondary";
                    BtnGen8.CssClass = "mt-2 btn btn-secondary";
                    BtnGen9.CssClass = "mt-2 btn btn-secondary";
                    BtnGen10.CssClass = "mt-2 btn btn-secondary";
                    BtnGen11.CssClass = "mt-2 btn btn-secondary";
                    BtnGen12.CssClass = "mt-2 btn btn-secondary";
                    BtnGen1.Enabled = true;
                    BtnGen2.Enabled = true;
                    BtnGen3.Enabled = true;
                    BtnGen4.Enabled = true;
                    BtnGen5.Enabled = true;
                    BtnGen6.Enabled = true;
                    BtnGen7.Enabled = false;
                    BtnGen8.Enabled = false;
                    BtnGen9.Enabled = false;
                    BtnGen10.Enabled = false;
                    BtnGen11.Enabled = false;
                    BtnGen12.Enabled = false;
                }
                else if (month == 8)
                {
                    BtnGen1.CssClass = "mt-2 btn btn-primary";
                    BtnGen2.CssClass = "mt-2 btn btn-primary";
                    BtnGen3.CssClass = "mt-2 btn btn-primary";
                    BtnGen4.CssClass = "mt-2 btn btn-primary";
                    BtnGen5.CssClass = "mt-2 btn btn-primary";
                    BtnGen6.CssClass = "mt-2 btn btn-primary";
                    BtnGen7.CssClass = "mt-2 btn btn-primary";
                    BtnGen8.CssClass = "mt-2 btn btn-secondary";
                    BtnGen9.CssClass = "mt-2 btn btn-secondary";
                    BtnGen10.CssClass = "mt-2 btn btn-secondary";
                    BtnGen11.CssClass = "mt-2 btn btn-secondary";
                    BtnGen12.CssClass = "mt-2 btn btn-secondary";
                    BtnGen1.Enabled = true;
                    BtnGen2.Enabled = true;
                    BtnGen3.Enabled = true;
                    BtnGen4.Enabled = true;
                    BtnGen5.Enabled = true;
                    BtnGen6.Enabled = true;
                    BtnGen7.Enabled = true;
                    BtnGen8.Enabled = false;
                    BtnGen9.Enabled = false;
                    BtnGen10.Enabled = false;
                    BtnGen11.Enabled = false;
                    BtnGen12.Enabled = false;
                }
                else if (month == 9)
                {
                    BtnGen1.CssClass = "mt-2 btn btn-primary";
                    BtnGen2.CssClass = "mt-2 btn btn-primary";
                    BtnGen3.CssClass = "mt-2 btn btn-primary";
                    BtnGen4.CssClass = "mt-2 btn btn-primary";
                    BtnGen5.CssClass = "mt-2 btn btn-primary";
                    BtnGen6.CssClass = "mt-2 btn btn-primary";
                    BtnGen7.CssClass = "mt-2 btn btn-primary";
                    BtnGen8.CssClass = "mt-2 btn btn-primary";
                    BtnGen9.CssClass = "mt-2 btn btn-secondary";
                    BtnGen10.CssClass = "mt-2 btn btn-secondary";
                    BtnGen11.CssClass = "mt-2 btn btn-secondary";
                    BtnGen12.CssClass = "mt-2 btn btn-secondary";
                    BtnGen1.Enabled = true;
                    BtnGen2.Enabled = true;
                    BtnGen3.Enabled = true;
                    BtnGen4.Enabled = true;
                    BtnGen5.Enabled = true;
                    BtnGen6.Enabled = true;
                    BtnGen7.Enabled = true;
                    BtnGen8.Enabled = true;
                    BtnGen9.Enabled = false;
                    BtnGen10.Enabled = false;
                    BtnGen11.Enabled = false;
                    BtnGen12.Enabled = false;
                }
                else if (month == 10)
                {
                    BtnGen1.CssClass = "mt-2 btn btn-primary";
                    BtnGen2.CssClass = "mt-2 btn btn-primary";
                    BtnGen3.CssClass = "mt-2 btn btn-primary";
                    BtnGen4.CssClass = "mt-2 btn btn-primary";
                    BtnGen5.CssClass = "mt-2 btn btn-primary";
                    BtnGen6.CssClass = "mt-2 btn btn-primary";
                    BtnGen7.CssClass = "mt-2 btn btn-primary";
                    BtnGen8.CssClass = "mt-2 btn btn-primary";
                    BtnGen9.CssClass = "mt-2 btn btn-primary";
                    BtnGen10.CssClass = "mt-2 btn btn-secondary";
                    BtnGen11.CssClass = "mt-2 btn btn-secondary";
                    BtnGen12.CssClass = "mt-2 btn btn-secondary";
                    BtnGen1.Enabled = true;
                    BtnGen2.Enabled = true;
                    BtnGen3.Enabled = true;
                    BtnGen4.Enabled = true;
                    BtnGen5.Enabled = true;
                    BtnGen6.Enabled = true;
                    BtnGen7.Enabled = true;
                    BtnGen8.Enabled = true;
                    BtnGen9.Enabled = true;
                    BtnGen10.Enabled = false;
                    BtnGen11.Enabled = false;
                    BtnGen12.Enabled = false;
                }
                else if (month == 11)
                {
                    BtnGen1.CssClass = "mt-2 btn btn-primary";
                    BtnGen2.CssClass = "mt-2 btn btn-primary";
                    BtnGen3.CssClass = "mt-2 btn btn-primary";
                    BtnGen4.CssClass = "mt-2 btn btn-primary";
                    BtnGen5.CssClass = "mt-2 btn btn-primary";
                    BtnGen6.CssClass = "mt-2 btn btn-primary";
                    BtnGen7.CssClass = "mt-2 btn btn-primary";
                    BtnGen8.CssClass = "mt-2 btn btn-primary";
                    BtnGen9.CssClass = "mt-2 btn btn-primary";
                    BtnGen10.CssClass = "mt-2 btn btn-primary";
                    BtnGen11.CssClass = "mt-2 btn btn-secondary";
                    BtnGen12.CssClass = "mt-2 btn btn-secondary";
                    BtnGen1.Enabled = true;
                    BtnGen2.Enabled = true;
                    BtnGen3.Enabled = true;
                    BtnGen4.Enabled = true;
                    BtnGen5.Enabled = true;
                    BtnGen6.Enabled = true;
                    BtnGen7.Enabled = true;
                    BtnGen8.Enabled = true;
                    BtnGen9.Enabled = true;
                    BtnGen10.Enabled = true;
                    BtnGen11.Enabled = false;
                    BtnGen12.Enabled = false;
                }
                else if (month == 12)
                {
                    BtnGen1.CssClass = "mt-2 btn btn-primary";
                    BtnGen2.CssClass = "mt-2 btn btn-primary";
                    BtnGen3.CssClass = "mt-2 btn btn-primary";
                    BtnGen4.CssClass = "mt-2 btn btn-primary";
                    BtnGen5.CssClass = "mt-2 btn btn-primary";
                    BtnGen6.CssClass = "mt-2 btn btn-primary";
                    BtnGen7.CssClass = "mt-2 btn btn-primary";
                    BtnGen8.CssClass = "mt-2 btn btn-primary";
                    BtnGen9.CssClass = "mt-2 btn btn-primary";
                    BtnGen10.CssClass = "mt-2 btn btn-primary";
                    BtnGen11.CssClass = "mt-2 btn btn-primary";
                    BtnGen12.CssClass = "mt-2 btn btn-secondary";
                    BtnGen1.Enabled = true;
                    BtnGen2.Enabled = true;
                    BtnGen3.Enabled = true;
                    BtnGen4.Enabled = true;
                    BtnGen5.Enabled = true;
                    BtnGen6.Enabled = true;
                    BtnGen7.Enabled = true;
                    BtnGen8.Enabled = true;
                    BtnGen9.Enabled = true;
                    BtnGen10.Enabled = true;
                    BtnGen11.Enabled = true;
                    BtnGen12.Enabled = false;
                }
                else
                {
                    BtnGen1.CssClass = "mt-2 btn btn-secondary";
                    BtnGen2.CssClass = "mt-2 btn btn-secondary";
                    BtnGen3.CssClass = "mt-2 btn btn-secondary";
                    BtnGen4.CssClass = "mt-2 btn btn-secondary";
                    BtnGen5.CssClass = "mt-2 btn btn-secondary";
                    BtnGen6.CssClass = "mt-2 btn btn-secondary";
                    BtnGen7.CssClass = "mt-2 btn btn-secondary";
                    BtnGen8.CssClass = "mt-2 btn btn-secondary";
                    BtnGen9.CssClass = "mt-2 btn btn-secondary";
                    BtnGen10.CssClass = "mt-2 btn btn-secondary";
                    BtnGen11.CssClass = "mt-2 btn btn-secondary";
                    BtnGen12.CssClass = "mt-2 btn btn-secondary";
                    BtnGen1.Enabled = false;
                    BtnGen2.Enabled = false;
                    BtnGen3.Enabled = false;
                    BtnGen4.Enabled = false;
                    BtnGen5.Enabled = false;
                    BtnGen6.Enabled = false;
                    BtnGen7.Enabled = false;
                    BtnGen8.Enabled = false;
                    BtnGen9.Enabled = false;
                    BtnGen10.Enabled = false;
                    BtnGen11.Enabled = false;
                    BtnGen12.Enabled = false;
                }
            }
            else
            {
                BtnGen1.CssClass = "mt-2 btn btn-primary";
                BtnGen2.CssClass = "mt-2 btn btn-primary";
                BtnGen3.CssClass = "mt-2 btn btn-primary";
                BtnGen4.CssClass = "mt-2 btn btn-primary";
                BtnGen5.CssClass = "mt-2 btn btn-primary";
                BtnGen6.CssClass = "mt-2 btn btn-primary";
                BtnGen7.CssClass = "mt-2 btn btn-primary";
                BtnGen8.CssClass = "mt-2 btn btn-primary";
                BtnGen9.CssClass = "mt-2 btn btn-primary";
                BtnGen10.CssClass = "mt-2 btn btn-primary";
                BtnGen11.CssClass = "mt-2 btn btn-primary";
                BtnGen12.CssClass = "mt-2 btn btn-primary";
                BtnGen1.Enabled = true;
                BtnGen2.Enabled = true;
                BtnGen3.Enabled = true;
                BtnGen4.Enabled = true;
                BtnGen5.Enabled = true;
                BtnGen6.Enabled = true;
                BtnGen7.Enabled = true;
                BtnGen8.Enabled = true;
                BtnGen9.Enabled = true;
                BtnGen10.Enabled = true;
                BtnGen11.Enabled = true;
                BtnGen12.Enabled = true;
            }            
        }

        protected void lnkSearch_Click(object sender, EventArgs e)
        {
            pnlGenerate.Visible = false;
            pnlSearch.Visible = true;
            lnkSearch.CssClass = "nav-link show active";
            lnkGenerate.CssClass = "nav-link show";
        }

        protected void lnkGenerate_Click(object sender, EventArgs e)
        {
            pnlGenerate.Visible = true;
            pnlSearch.Visible = false;
            lnkSearch.CssClass = "nav-link show";
            lnkGenerate.CssClass = "nav-link show active";
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonGenerateCheck();
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }
        

        void ShowMessage(string msg)
        {                     
            Response.Write("<script type=\"text/javascript\">alert('" + msg + "')</script>");
        }

        
        //12 Button START
        protected void BtnGen1_Click(object sender, EventArgs e)
        {
            if(ddlCategory.SelectedValue == "Attendance")
            {
                attendance(BtnGen1.Text);
            }
            else if(ddlCategory.SelectedValue == "Appointment")
            {
                appointment(BtnGen1.Text);
            }
            else if(ddlCategory.SelectedValue == "PatientVisit")
            {
                patientVisit(BtnGen1.Text);
            }
        }

        protected void BtnGen2_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue == "Attendance")
            {
                attendance(BtnGen2.Text);
            }
            else if (ddlCategory.SelectedValue == "Appointment")
            {
                appointment(BtnGen2.Text);
            }
            else if (ddlCategory.SelectedValue == "PatientVisit")
            {
                patientVisit(BtnGen2.Text);
            }
        }

        protected void BtnGen3_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue == "Attendance")
            {
                attendance(BtnGen3.Text);
            }
            else if (ddlCategory.SelectedValue == "Appointment")
            {
                appointment(BtnGen3.Text);
            }
            else if (ddlCategory.SelectedValue == "PatientVisit")
            {
                patientVisit(BtnGen3.Text);
            }
        }

        protected void BtnGen4_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue == "Attendance")
            {
                attendance(BtnGen4.Text);
            }
            else if (ddlCategory.SelectedValue == "Appointment")
            {
                appointment(BtnGen4.Text);
            }
            else if (ddlCategory.SelectedValue == "PatientVisit")
            {
                patientVisit(BtnGen4.Text);
            }
        }

        protected void BtnGen5_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue == "Attendance")
            {
                attendance(BtnGen5.Text);
            }
            else if (ddlCategory.SelectedValue == "Appointment")
            {
                appointment(BtnGen5.Text);
            }
            else if (ddlCategory.SelectedValue == "PatientVisit")
            {
                patientVisit(BtnGen5.Text);
            }
        }

        protected void BtnGen6_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue == "Attendance")
            {
                attendance(BtnGen6.Text);
            }
            else if (ddlCategory.SelectedValue == "Appointment")
            {
                appointment(BtnGen6.Text);
            }
            else if (ddlCategory.SelectedValue == "PatientVisit")
            {
                patientVisit(BtnGen6.Text);
            }
        }

        protected void BtnGen7_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue == "Attendance")
            {
                attendance(BtnGen7.Text);
            }
            else if (ddlCategory.SelectedValue == "Appointment")
            {
                appointment(BtnGen7.Text);
            }
            else if (ddlCategory.SelectedValue == "PatientVisit")
            {
                patientVisit(BtnGen7.Text);
            }
        }

        protected void BtnGen8_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue == "Attendance")
            {
                attendance(BtnGen8.Text);
            }
            else if (ddlCategory.SelectedValue == "Appointment")
            {
                appointment(BtnGen8.Text);
            }
            else if (ddlCategory.SelectedValue == "PatientVisit")
            {
                patientVisit(BtnGen8.Text);
            }
        }

        protected void BtnGen9_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue == "Attendance")
            {
                attendance(BtnGen9.Text);
            }
            else if (ddlCategory.SelectedValue == "Appointment")
            {
                appointment(BtnGen9.Text);
            }
            else if (ddlCategory.SelectedValue == "PatientVisit")
            {
                patientVisit(BtnGen9.Text);
            }
        }

        protected void BtnGen10_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue == "Attendance")
            {
                attendance(BtnGen10.Text);
            }
            else if (ddlCategory.SelectedValue == "Appointment")
            {
                appointment(BtnGen10.Text);
            }
            else if (ddlCategory.SelectedValue == "PatientVisit")
            {
                patientVisit(BtnGen10.Text);
            }
        }

        protected void BtnGen11_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue == "Attendance")
            {
                attendance(BtnGen11.Text);
            }
            else if (ddlCategory.SelectedValue == "Appointment")
            {
                appointment(BtnGen11.Text);
            }
            else if (ddlCategory.SelectedValue == "PatientVisit")
            {
                patientVisit(BtnGen11.Text);
            }
        }

        protected void BtnGen12_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue == "Attendance")
            {
                attendance(BtnGen12.Text);
            }
            else if (ddlCategory.SelectedValue == "Appointment")
            {
                appointment(BtnGen12.Text);
            }
            else if (ddlCategory.SelectedValue == "PatientVisit")
            {
                patientVisit(BtnGen12.Text);
            }
        }

        //12 Button END

        //PATIENTVISIT START
        private void patientVisit(string btntext)
        {
            string reportname = ddlCategory.SelectedValue + btntext + ddlYear.SelectedValue;
            
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select reportName from Report where reportName = @name", con);
                cmd.Parameters.AddWithValue("@name", reportname);
                SqlDataReader dr = cmd.ExecuteReader();
                byte[] pdfBytes;
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        ShowMessage("Already Generated, View or print in Search Tab");
                    }
                    else
                    {
                        this.BindGridPatientVisit(btntext);
                        int rowCount = GridViewPatientVisit.Rows.Count;

                        if (rowCount != 0)
                        {
                            using (StringWriter sw = new StringWriter())
                            {
                                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                                {
                                    GridViewPatientVisit.RenderControl(hw);
                                    StringReader sr = new StringReader(sw.ToString());
                                    Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                                    //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

                                    using (MemoryStream memoryStream = new MemoryStream())
                                    {
                                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                                        pdfDoc.Open();
                                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                                        //htmlparser.Parse(sr);
                                        pdfDoc.Close();
                                        pdfBytes = memoryStream.ToArray();
                                        memoryStream.Close();
                                    }
                                }
                            }
                            SqlConnection con2 = new SqlConnection(strCon);
                            con2.Open();
                            SqlCommand cmd2 = new SqlCommand("INSERT INTO Report(reportName, reportCategory, reportByte, reportMonth, reportYear) " +
                                "VALUES(@name, @category, @byte, @month, @year)", con2);
                            cmd2.Parameters.AddWithValue("@name", reportname);
                            cmd2.Parameters.AddWithValue("@category", ddlCategory.SelectedValue);
                            cmd2.Parameters.AddWithValue("@byte", pdfBytes);
                            cmd2.Parameters.AddWithValue("@month", btntext);
                            cmd2.Parameters.AddWithValue("@year", ddlYear.SelectedValue);
                            cmd2.ExecuteNonQuery();
                            con2.Close();
                            ShowMessage("Generate Successfully, View Or Print In Search Tab");
                        }
                        else
                        {
                            ShowMessage("No Data for Report to Generate");
                        }
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        protected void GridViewPatientVisit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewPatientVisit.PageIndex = e.NewPageIndex;
            this.BindGridPatientVisit(btnnumber);
        }
        private void BindGridPatientVisit(string btntext)
        {

            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT visitID, dateVisit, status, diagnosis, medicineGiven , dentistVisited, roomNo, totalVisit, patientID from VisitRecord WHERE MONTH(dateVisit)= @text;", con);
            cmd.Parameters.AddWithValue("@text", btntext);
            //cmd.Parameters.AddWithValue("@dateto", Convert.ToDateTime(datet));
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
                GridViewPatientVisit.DataSource = dt;
                GridViewPatientVisit.DataBind();
            }
            con.Close();
            btnnumber = btntext;
        }
        //PATIENTVISIT END

        //APPOINTMENT START
        private void appointment(string btntext)
        {
            string reportname = ddlCategory.SelectedValue + btntext + ddlYear.SelectedValue;
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select reportName from Report where reportName = @name", con);
                cmd.Parameters.AddWithValue("@name", reportname);
                SqlDataReader dr = cmd.ExecuteReader();
                byte[] pdfBytes;
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        ShowMessage("Already Generated, View or print in Search Tab");
                    }
                    else
                    {
                        this.BindGridAppointment(btntext);
                        int rowCount = GridViewAppointment.Rows.Count;

                        if (rowCount != 0)
                        {
                            using (StringWriter sw = new StringWriter())
                            {
                                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                                {
                                    GridViewAppointment.RenderControl(hw);
                                    StringReader sr = new StringReader(sw.ToString());
                                    Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                                    //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

                                    using (MemoryStream memoryStream = new MemoryStream())
                                    {
                                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                                        pdfDoc.Open();
                                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                                        //htmlparser.Parse(sr);
                                        pdfDoc.Close();
                                        pdfBytes = memoryStream.ToArray();
                                        memoryStream.Close();
                                    }
                                }
                            }
                            SqlConnection con2 = new SqlConnection(strCon);
                            con2.Open();
                            SqlCommand cmd2 = new SqlCommand("INSERT INTO Report(reportName, reportCategory, reportByte, reportMonth, reportYear) " +
                                "VALUES(@name, @category, @byte, @month, @year)", con2);
                            cmd2.Parameters.AddWithValue("@name", reportname);
                            cmd2.Parameters.AddWithValue("@category", ddlCategory.SelectedValue);
                            cmd2.Parameters.AddWithValue("@byte", pdfBytes);
                            cmd2.Parameters.AddWithValue("@month", btntext);
                            cmd2.Parameters.AddWithValue("@year", ddlYear.SelectedValue);
                            cmd2.ExecuteNonQuery();
                            con2.Close();
                            ShowMessage("Generate Successfully, View Or Print In Search Tab");
                        }
                        else
                        {
                            ShowMessage("No Data for Report to Generate");
                        }                  
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        protected void GridViewAppointment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewAppointment.PageIndex = e.NewPageIndex;
            this.BindGridAppointment(btnnumber);
        }
        private void BindGridAppointment(String btntext)
        {       
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT appointmentID, appointmentName, dentistToVisit, appointmentDate, appointmentTime , appointmentPurpose, icNo, staffID from Appointment WHERE MONTH(appointmentDate)= @text;", con);
            cmd.Parameters.AddWithValue("@text", btntext);
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
                GridViewAppointment.DataSource = dt;
                GridViewAppointment.DataBind();
            }
            con.Close();
            btnnumber = btntext;
        }
        //APPOINTMENT END
        string btnnumber;
        //ATTENDANCE START
        protected void GridViewAttendance_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewAttendance.PageIndex = e.NewPageIndex;
            this.BindGridAttendance(btnnumber);
        }
        private void BindGridAttendance(string btntext)
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT workingDate, checkInTime, checkOutTime, day, month , year from Attendance where month = @month", con);
            cmd.Parameters.AddWithValue("@month", Int64.Parse(btntext));
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
                GridViewAttendance.DataSource = dt;
                GridViewAttendance.DataBind();
            }
            con.Close();
            btnnumber = btntext;
        }

        protected void attendance(string btntext)
        {
            string reportname = ddlCategory.SelectedValue + btntext + ddlYear.SelectedValue;
            try
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select reportName from Report where reportName = @name", con);
                cmd.Parameters.AddWithValue("@name", reportname);
                SqlDataReader dr = cmd.ExecuteReader();
                byte[] pdfBytes;
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        ShowMessage("Already Generated, View or print in Search Tab");
                    }
                    else
                    {
                        this.BindGridAttendance(btntext);
                        int rowCount = GridViewAttendance.Rows.Count;

                        if (rowCount != 0)
                        {
                            using (StringWriter sw = new StringWriter())
                            {
                                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                                {
                                    GridViewAttendance.RenderControl(hw);
                                    StringReader sr = new StringReader(sw.ToString());
                                    Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                                    //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

                                    using (MemoryStream memoryStream = new MemoryStream())
                                    {
                                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                                        pdfDoc.Open();
                                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                                        //htmlparser.Parse(sr);
                                        pdfDoc.Close();
                                        pdfBytes = memoryStream.ToArray();
                                        memoryStream.Close();
                                    }
                                }
                            }
                            SqlConnection con2 = new SqlConnection(strCon);
                            con2.Open();
                            SqlCommand cmd2 = new SqlCommand("INSERT INTO Report(reportName, reportCategory, reportByte, reportMonth, reportYear) " +
                                "VALUES(@name, @category, @byte, @month, @year)", con2);
                            cmd2.Parameters.AddWithValue("@name", reportname);
                            cmd2.Parameters.AddWithValue("@category", ddlCategory.SelectedValue);
                            cmd2.Parameters.AddWithValue("@byte", pdfBytes);
                            cmd2.Parameters.AddWithValue("@month", btntext);
                            cmd2.Parameters.AddWithValue("@year", ddlYear.SelectedValue);
                            cmd2.ExecuteNonQuery();
                            con2.Close();
                            ShowMessage("Generate Successfully, View Or Print In Search Tab");
                        }
                        else
                        {
                            ShowMessage("No Data for Report to Generate");
                        }
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            //Response.ClearContent();
            //Response.ClearHeaders();
            //Response.ContentType = "application/pdf";
            //string FileName = "" + Session["ID"].ToString() + "_StaffMonthlyAttendanceReport_" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";
            //Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            //Response.BinaryWrite(pdfBytes);
            //Response.End();
            //Response.Flush();
            //Response.Clear();
        }
        //ATTENDANCE END

        protected void btnSearchReport_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text == string.Empty)
            {
                noInput.Visible = true;
                pnlsearchResult.Visible = false;
            }
            else
            {
                noInput.Visible = false;
                BindGridSearch();                
            }
            
        }

        protected void gridViewSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewSearchResult.PageIndex = e.NewPageIndex;
            this.BindGridSearch();
        }

        private void BindGridSearch()
        {
            SqlConnection con = new SqlConnection(strCon);
            if (ddlSearchCriteria.SelectedValue == "name")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT reportName, reportCategory, reportMonth, reportYear from Report where reportName like @Name", con);
                cmd.Parameters.AddWithValue("@Name", "%" + txtSearch.Text + "%");
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (!dr.Read())
                    {
                        noResult.Visible = true;
                        pnlsearchResult.Visible = false;
                    }
                    else
                    {
                        con.Close();
                        con.Open();
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            gridViewSearchResult.DataSource = dt;
                            gridViewSearchResult.DataBind();
                        }
                        noResult.Visible = false;
                        pnlsearchResult.Visible = true;
                        con.Close();
                    }
                }               
                con.Close();
            }
            else if (ddlSearchCriteria.SelectedValue == "category")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT reportName, reportCategory, reportMonth, reportYear from Report where reportCategory like @Name", con);
                cmd.Parameters.AddWithValue("@Name", "%" + txtSearch.Text + "%");
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (!dr.Read())
                    {
                        noResult.Visible = true;
                        pnlsearchResult.Visible = false;
                    }
                    else
                    {
                        con.Close();
                        con.Open();
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            gridViewSearchResult.DataSource = dt;
                            gridViewSearchResult.DataBind();
                        }
                        noResult.Visible = false;
                        pnlsearchResult.Visible = true;
                        con.Close();
                    }
                }
                con.Close();
            }
            else if (ddlSearchCriteria.SelectedValue == "year")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT reportName, reportCategory, reportMonth, reportYear from Report where reportYear like @Name", con);
                cmd.Parameters.AddWithValue("@Name", "%" + txtSearch.Text + "%");
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (!dr.Read())
                    {
                        noResult.Visible = true;
                        pnlsearchResult.Visible = false;
                    }
                    else
                    {
                        con.Close();
                        con.Open();
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            gridViewSearchResult.DataSource = dt;
                            gridViewSearchResult.DataBind();
                        }
                        noResult.Visible = false;
                        pnlsearchResult.Visible = true;
                        con.Close();
                    }
                }
                con.Close();
            }   
        }

        protected void gridViewSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = gridViewSearchResult.SelectedRow.Cells[1].Text;
            string category = gridViewSearchResult.SelectedRow.Cells[2].Text;
            string reportMonth = gridViewSearchResult.SelectedRow.Cells[3].Text;
            string reportYear = gridViewSearchResult.SelectedRow.Cells[4].Text;


            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("select reportByte from Report where reportName = @name and reportCategory = @category and reportMonth = @month and reportYear = @year", con);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@category", category);
            cmd.Parameters.AddWithValue("@month", reportMonth);
            cmd.Parameters.AddWithValue("@year", reportYear);
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {              
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        byte[] pdfBytes = (byte[])dr["reportByte"];
                        Response.ClearContent();
                        Response.ClearHeaders();
                        Response.ContentType = "application/pdf";
                        string FileName = "" + name + "GeneratedIn" + DateTime.Now.ToString("ddMMyyyy") + ".pdf";
                        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                        Response.BinaryWrite(pdfBytes);
                        Response.End();
                        Response.Flush();
                        Response.Clear();
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