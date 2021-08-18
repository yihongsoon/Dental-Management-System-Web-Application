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
    public partial class patientPage : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["username"] == null)
            //    Response.Redirect("loginPage.aspx");

            patientId();
        }

        protected void btnAddVisit_Click(object sender, EventArgs e)
        {
            Response.Redirect("patientVisitPage.aspx");
        }

        public void patientId()
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) As 'Row_Count' FROM  Patient", con);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            String patientID = "P00000";
            var prefix = Regex.Match(patientID, "^\\D+").Value;
            var number = Regex.Replace(patientID, "^\\D+", "");
            var i = int.Parse(number) + 1 + count;
            var newString = prefix + i.ToString(new string('0', number.Length));
            txtPatientID.Text = newString;
        }

        protected void lnkSearchPatient_Click(object sender, EventArgs e)
        {
            tabSearchPatient.Visible = true;
            tabAddPatient.Visible = false;
            tabUpdatePatient.Visible = false;
            tabDeletePatient.Visible = false;
            lnkSearchPatient.CssClass = "nav-link show active";
            lnkAddPatient.CssClass = "nav-link show";
            lnkUpdatePatient.CssClass = "nav-link show";
            lnkDeletePatient.CssClass = "nav-link show";
        }

        protected void lnkAddPatient_Click(object sender, EventArgs e)
        {
            tabSearchPatient.Visible = false;
            tabAddPatient.Visible = true;
            tabUpdatePatient.Visible = false;
            tabDeletePatient.Visible = false;
            lnkSearchPatient.CssClass = "nav-link show";
            lnkAddPatient.CssClass = "nav-link show active";
            lnkUpdatePatient.CssClass = "nav-link show";
            lnkDeletePatient.CssClass = "nav-link show";
        }

        protected void lnkUpdatePatient_Click(object sender, EventArgs e)
        {
            tabSearchPatient.Visible = false;
            tabAddPatient.Visible = false;
            tabUpdatePatient.Visible = true;
            tabDeletePatient.Visible = false;
            lnkSearchPatient.CssClass = "nav-link show";
            lnkAddPatient.CssClass = "nav-link show";
            lnkUpdatePatient.CssClass = "nav-link show active";
            lnkDeletePatient.CssClass = "nav-link show";
        }

        protected void lnkDeletePatient_Click(object sender, EventArgs e)
        {
            tabSearchPatient.Visible = false;
            tabAddPatient.Visible = false;
            tabUpdatePatient.Visible = false;
            tabDeletePatient.Visible = true;
            lnkSearchPatient.CssClass = "nav-link show";
            lnkAddPatient.CssClass = "nav-link show";
            lnkUpdatePatient.CssClass = "nav-link show";
            lnkDeletePatient.CssClass = "nav-link show active";
        }

        protected void btnAddPatient_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("INSERT INTO Person(icNo, name, age, contactNo, gender) VALUES(@icNo, @name, @age, @contactNo, @gender)", con);
            cmd1.Parameters.AddWithValue("@icNo", txtIcNo.Text);
            cmd1.Parameters.AddWithValue("@name", txtName.Text);
            cmd1.Parameters.AddWithValue("@age", txtAge.Text);
            cmd1.Parameters.AddWithValue("@contactNo", txtContactNo.Text);
            cmd1.Parameters.AddWithValue("@gender", ddlAddPatGender.SelectedValue);
            cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("INSERT INTO Patient(patientID, allergies, icNo) VALUES(@patientID, @allergies, @icNo)", con);
            cmd2.Parameters.AddWithValue("@patientID",txtPatientID.Text);
            cmd2.Parameters.AddWithValue("@allergies",txtAllergies.Text);
            cmd2.Parameters.AddWithValue("@icNo",txtIcNo.Text);
            cmd2.ExecuteNonQuery();
            con.Close();
            Response.Write("<script type=\"text/javascript\">alert('Patient details have been successfully added.');location.href='patientPage.aspx'</script>");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if(ddlSearchType.SelectedValue == "name")
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Patient.patientID, Patient.allergies from Patient, Person where Person.name = @name AND Person.icNo = Patient.icNo", con);
                cmd.Parameters.AddWithValue("@name", txtSearchType.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if(dr.Read())
                    {
                        txtSearchID.Text = dr["patientID"].ToString();
                        txtSearchIcNo.Text = dr["icNo"].ToString();
                        txtSearchName.Text = dr["name"].ToString();
                        txtSearchAge.Text = dr["age"].ToString();
                        txtSearchContactNo.Text = dr["contactNo"].ToString();
                        txtSearchGender.Text = dr["gender"].ToString();
                        txtSearchAllergies.Text = dr["allergies"].ToString();
                        pnlSearchPatient.Visible = true;
                        btnBackSearch.Visible = true;
                        patientSearchNotFound.Visible = false;
                    }
                    else
                    {
                        patientSearchNotFound.Visible = true;
                        pnlSearchPatient.Visible = false;
                        btnBackSearch.Visible = false;
                    }
                }
                con.Close();
            }else if(ddlSearchType.SelectedValue == "icNo")
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Patient.patientID, Patient.allergies from Patient, Person where Person.icNo = @icNo AND Person.icNo = Patient.icNo", con);
                cmd.Parameters.AddWithValue("@icNo", txtSearchType.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr != null)
                {
                    if(dr.Read())
                    {
                        txtSearchID.Text = dr["patientID"].ToString();
                        txtSearchIcNo.Text = dr["icNo"].ToString();
                        txtSearchName.Text = dr["name"].ToString();
                        txtSearchAge.Text = dr["age"].ToString();
                        txtSearchContactNo.Text = dr["contactNo"].ToString();
                        txtSearchGender.Text = dr["gender"].ToString();
                        txtSearchAllergies.Text = dr["allergies"].ToString();
                        pnlSearchPatient.Visible = true;
                        btnBackSearch.Visible = true;
                        patientSearchNotFound.Visible = false;
                    }
                    else
                    {
                        patientSearchNotFound.Visible = true;
                        pnlSearchPatient.Visible = false;
                        btnBackSearch.Visible = false;
                    }
                }
                con.Close();
            }else if(ddlSearchType.SelectedValue == "patientID")
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Patient.patientID, Patient.allergies from Patient, Person where Patient.patientID = @patientID AND Person.icNo = Patient.icNo", con);
                cmd.Parameters.AddWithValue("@patientID", txtSearchType.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if(dr.Read())
                    {
                        txtSearchID.Text = dr["patientID"].ToString();
                        txtSearchIcNo.Text = dr["icNo"].ToString();
                        txtSearchName.Text = dr["name"].ToString();
                        txtSearchAge.Text = dr["age"].ToString();
                        txtSearchContactNo.Text = dr["contactNo"].ToString();
                        txtSearchGender.Text = dr["gender"].ToString();
                        txtSearchAllergies.Text = dr["allergies"].ToString();
                        pnlSearchPatient.Visible = true;
                        btnBackSearch.Visible = true;
                        patientSearchNotFound.Visible = false;
                    }
                    else
                    {
                        patientSearchNotFound.Visible = true;
                        pnlSearchPatient.Visible = false;
                        btnBackSearch.Visible = false;
                    }
                }
                con.Close();
            }else
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Patient.patientID, Patient.allergies from Patient, Person where Person.contactNo = @contactNo AND Person.icNo = Patient.icNo", con);
                cmd.Parameters.AddWithValue("@contactNo", txtSearchType.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr != null)
                {
                    if (dr.Read())
                    {
                        txtSearchID.Text = dr["patientID"].ToString();
                        txtSearchIcNo.Text = dr["icNo"].ToString();
                        txtSearchName.Text = dr["name"].ToString();
                        txtSearchAge.Text = dr["age"].ToString();
                        txtSearchContactNo.Text = dr["contactNo"].ToString();
                        txtSearchGender.Text = dr["gender"].ToString();
                        txtSearchAllergies.Text = dr["allergies"].ToString();
                        pnlSearchPatient.Visible = true;
                        btnBackSearch.Visible = true;
                        patientSearchNotFound.Visible = false;
                    }
                    else
                    {
                        patientSearchNotFound.Visible = true;
                        pnlSearchPatient.Visible = false;
                        btnBackSearch.Visible = false;
                    }
                }
                con.Close();
            }
        }

        protected void btnBackSearch_Click(object sender, EventArgs e)
        {
            txtSearchType.Text = "";
            txtSearchID.Text = "";
            txtSearchIcNo.Text = "";
            txtSearchName.Text = "";
            txtSearchAge.Text = "";
            txtSearchContactNo.Text = "";
            txtSearchGender.Text = "";
            txtSearchAllergies.Text = "";

            patientSearchNotFound.Visible = false;
            pnlSearchPatient.Visible = false;
            btnBackSearch.Visible = false;
        }
    }
}