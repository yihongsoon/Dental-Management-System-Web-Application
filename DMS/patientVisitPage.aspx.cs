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
    public partial class patientVisitPage : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["username"] == null)
            //    Response.Redirect("loginPage.aspx");
            if (Session["Patient_ID"] != null)
            {
                txtPatientID.Text = Session["Patient_ID"].ToString();
            }
            visitID();
        }

        protected void btnBackPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("patientPage.aspx");
        }

        void AlertMessage(string msg)
        {
            Response.Write("<script type=\"text/javascript\">alert('" + msg + "')</script>");
        }

        public void visitID()
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 visitID FROM VisitRecord ORDER BY visitID DESC", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                if (dr.Read())
                {
                    String visitID = dr["visitID"].ToString();
                    var prefix = Regex.Match(visitID, "^\\D+").Value;
                    var number = Regex.Replace(visitID, "^\\D+", "");
                    var i = int.Parse(number) + 1;
                    var newString = prefix + i.ToString(new string('0', number.Length));
                    txtVisitID.Text = newString;
                }
                else
                {
                    String visitID = "V000000";
                    var prefix = Regex.Match(visitID, "^\\D+").Value;
                    var number = Regex.Replace(visitID, "^\\D+", "");
                    var i = int.Parse(number) + 1;
                    var newString = prefix + i.ToString(new string('0', number.Length));
                    txtVisitID.Text = newString;
                }
            }
            con.Close();
        }

        protected void btnAddVisitDetails_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid == true)
            {
                SqlConnection con = new SqlConnection(strCon);
                try
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("INSERT INTO VisitRecord (visitID, dateVisit, status, diagnosis, medicineGiven, dentistVisited, roomNo, patientID) VALUES(@visitID, @dateVisit, @status, @diagnosis, @medicineGiven, @dentistVisited, @roomNo, @patientID)", con);
                    cmd1.Parameters.AddWithValue("@visitID", txtVisitID.Text);
                    cmd1.Parameters.AddWithValue("@dateVisit", txtDateVisit.Text);
                    cmd1.Parameters.AddWithValue("@status", ddlPresence.SelectedValue);
                    cmd1.Parameters.AddWithValue("@diagnosis", txtDiagnosis.Text);
                    cmd1.Parameters.AddWithValue("@medicineGiven", txtMedicineGiven.Text);
                    cmd1.Parameters.AddWithValue("@dentistVisited", txtDentistVisit.Text);
                    cmd1.Parameters.AddWithValue("@roomNo", Convert.ToInt32(txtRoomNo.Text));
                    cmd1.Parameters.AddWithValue("@patientID", txtPatientID.Text);
                    cmd1.ExecuteNonQuery();

                    con.Close();
                    Response.Write("<script type=\"text/javascript\">alert('Patient visit details have been successfully added.');location.href='patientPage.aspx'</script>");
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