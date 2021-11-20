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

        void AlertMessage(string msg)
        {
            Response.Write("<script type=\"text/javascript\">alert('" + msg + "')</script>");
        }

        protected void btnAddVisit_Click(object sender, EventArgs e)
        {
            Response.Redirect("patientVisitPage.aspx");
        }

        public void patientId()
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 patientID FROM Patient ORDER BY patientID DESC", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                if (dr.Read())
                {
                    String patientID = dr["patientID"].ToString();
                    var prefix = Regex.Match(patientID, "^\\D+").Value;
                    var number = Regex.Replace(patientID, "^\\D+", "");
                    var i = int.Parse(number) + 1;
                    var newString = prefix + i.ToString(new string('0', number.Length));
                    txtPatientID.Text = newString;
                }
                else
                {
                    String patientID = "P00000";
                    var prefix = Regex.Match(patientID, "^\\D+").Value;
                    var number = Regex.Replace(patientID, "^\\D+", "");
                    var i = int.Parse(number) + 1;
                    var newString = prefix + i.ToString(new string('0', number.Length));
                    txtPatientID.Text = newString;
                }
            }
            con.Close();
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
            Page.Validate();
            if (Page.IsValid == true)
            {
                SqlConnection con = new SqlConnection(strCon);
                try
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("INSERT INTO Person(icNo, name, age, contactNo, gender) VALUES(@icNo, @name, @age, @contactNo, @gender)", con);
                    cmd1.Parameters.AddWithValue("@icNo", txtIcNo.Text);
                    cmd1.Parameters.AddWithValue("@name", txtName.Text);
                    cmd1.Parameters.AddWithValue("@age", txtAge.Text);
                    cmd1.Parameters.AddWithValue("@contactNo", txtContactNo.Text);
                    cmd1.Parameters.AddWithValue("@gender", ddlAddPatGender.SelectedValue);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("INSERT INTO Patient(patientID, allergies, icNo) VALUES(@patientID, @allergies, @icNo)", con);
                    cmd2.Parameters.AddWithValue("@patientID", txtPatientID.Text);
                    cmd2.Parameters.AddWithValue("@allergies", txtAllergies.Text);
                    cmd2.Parameters.AddWithValue("@icNo", txtIcNo.Text);
                    cmd2.ExecuteNonQuery();

                    Response.Write("<script type=\"text/javascript\">alert('Patient details have been successfully added.');location.href='patientPage.aspx'</script>");
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlSearchType.SelectedValue == "name")
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Patient.patientID, Patient.allergies from Patient, Person where Person.name = @name AND Person.icNo = Patient.icNo", con);
                cmd.Parameters.AddWithValue("@name", txtSearchType.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        Session["Patient_ID"] = dr["patientID"].ToString();
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
            else if (ddlSearchType.SelectedValue == "icNo")
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Patient.patientID, Patient.allergies from Patient, Person where Person.icNo = @icNo AND Person.icNo = Patient.icNo", con);
                cmd.Parameters.AddWithValue("@icNo", txtSearchType.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        Session["Patient_ID"] = dr["patientID"].ToString();
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
            else if (ddlSearchType.SelectedValue == "patientID")
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Patient.patientID, Patient.allergies from Patient, Person where Patient.patientID = @patientID AND Person.icNo = Patient.icNo", con);
                cmd.Parameters.AddWithValue("@patientID", txtSearchType.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        Session["Patient_ID"] = dr["patientID"].ToString();
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
            else
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Patient.patientID, Patient.allergies from Patient, Person where Person.contactNo = @contactNo AND Person.icNo = Patient.icNo", con);
                cmd.Parameters.AddWithValue("@contactNo", txtSearchType.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        Session["Patient_ID"] = dr["patientID"].ToString();
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

        protected void btnUpdatePatientSearch_Click(object sender, EventArgs e)
        {
            if (ddlUpdateSearchType.SelectedValue == "name")
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Patient.patientID, Patient.allergies from Patient, Person where Person.name = @name AND Person.icNo = Patient.icNo", con);
                cmd.Parameters.AddWithValue("@name", txtUpdatePatientSearch.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        Session["Patient_ID"] = dr["patientID"].ToString();
                        txtUpdatePatientID.Text = dr["patientID"].ToString();
                        txtUpdateIcNo.Text = dr["icNo"].ToString();
                        txtUpdatePatientName.Text = dr["name"].ToString();
                        txtUpdatePatientAge.Text = dr["age"].ToString();
                        txtUpdatePatientContact.Text = dr["contactNo"].ToString();
                        ddlUpdateGender.ClearSelection();
                        ddlUpdateGender.SelectedValue = dr["gender"].ToString();
                        txtUpdateAllergy.Text = dr["allergies"].ToString();
                        pnlUpdatePatient.Visible = true;
                        btnBackUpdate.Visible = true;
                        patientUpdateNotFound.Visible = false;
                    }
                    else
                    {
                        Session["Patient_ID"] = string.Empty;
                        patientUpdateNotFound.Visible = true;
                        pnlUpdatePatient.Visible = false;
                        btnBackUpdate.Visible = false;
                    }
                }
                con.Close();
            }
            else if (ddlUpdateSearchType.SelectedValue == "icNo")
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Patient.patientID, Patient.allergies from Patient, Person where Person.icNo = @icNo AND Person.icNo = Patient.icNo", con);
                cmd.Parameters.AddWithValue("@icNo", txtUpdatePatientSearch.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        Session["Patient_ID"] = dr["patientID"].ToString();
                        txtUpdatePatientID.Text = dr["patientID"].ToString();
                        txtUpdateIcNo.Text = dr["icNo"].ToString();
                        txtUpdatePatientName.Text = dr["name"].ToString();
                        txtUpdatePatientAge.Text = dr["age"].ToString();
                        txtUpdatePatientContact.Text = dr["contactNo"].ToString();
                        ddlUpdateGender.ClearSelection();
                        ddlUpdateGender.SelectedValue = dr["gender"].ToString();
                        txtUpdateAllergy.Text = dr["allergies"].ToString();
                        pnlUpdatePatient.Visible = true;
                        btnBackUpdate.Visible = true;
                        patientUpdateNotFound.Visible = false;
                    }
                    else
                    {
                        patientUpdateNotFound.Visible = true;
                        pnlUpdatePatient.Visible = false;
                        btnBackUpdate.Visible = false;
                    }
                }
                con.Close();
            }
            else if (ddlUpdateSearchType.SelectedValue == "patientID")
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Patient.patientID, Patient.allergies from Patient, Person where Patient.patientID = @patientID AND Person.icNo = Patient.icNo", con);
                cmd.Parameters.AddWithValue("@patientID", txtUpdatePatientSearch.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        Session["Patient_ID"] = dr["patientID"].ToString();
                        txtUpdatePatientID.Text = dr["patientID"].ToString();
                        txtUpdateIcNo.Text = dr["icNo"].ToString();
                        txtUpdatePatientName.Text = dr["name"].ToString();
                        txtUpdatePatientAge.Text = dr["age"].ToString();
                        txtUpdatePatientContact.Text = dr["contactNo"].ToString();
                        ddlUpdateGender.ClearSelection();
                        ddlUpdateGender.SelectedValue = dr["gender"].ToString();
                        txtUpdateAllergy.Text = dr["allergies"].ToString();
                        pnlUpdatePatient.Visible = true;
                        btnBackUpdate.Visible = true;
                        patientUpdateNotFound.Visible = false;
                    }
                    else
                    {
                        patientUpdateNotFound.Visible = true;
                        pnlUpdatePatient.Visible = false;
                        btnBackUpdate.Visible = false;
                    }
                }
                con.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Patient.patientID, Patient.allergies from Patient, Person where Person.contactNo = @contactNo AND Person.icNo = Patient.icNo", con);
                cmd.Parameters.AddWithValue("@contactNo", txtUpdatePatientSearch.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        Session["Patient_ID"] = dr["patientID"].ToString();
                        txtUpdatePatientID.Text = dr["patientID"].ToString();
                        txtUpdateIcNo.Text = dr["icNo"].ToString();
                        txtUpdatePatientName.Text = dr["name"].ToString();
                        txtUpdatePatientAge.Text = dr["age"].ToString();
                        txtUpdatePatientContact.Text = dr["contactNo"].ToString();
                        ddlUpdateGender.ClearSelection();
                        ddlUpdateGender.SelectedValue = dr["gender"].ToString();
                        txtUpdateAllergy.Text = dr["allergies"].ToString();
                        pnlUpdatePatient.Visible = true;
                        btnBackUpdate.Visible = true;
                        patientUpdateNotFound.Visible = false;
                    }
                    else
                    {
                        patientUpdateNotFound.Visible = true;
                        pnlUpdatePatient.Visible = false;
                        btnBackUpdate.Visible = false;
                    }
                }
                con.Close();
            }
        }

        protected void btnBackUpdate_Click(object sender, EventArgs e)
        {
            txtSearchType.Text = "";
            txtSearchID.Text = "";
            txtSearchIcNo.Text = "";
            txtSearchName.Text = "";
            txtSearchAge.Text = "";
            txtSearchContactNo.Text = "";
            txtSearchGender.Text = "";
            txtSearchAllergies.Text = "";

            patientUpdateNotFound.Visible = false;
            pnlUpdatePatient.Visible = false;
            btnBackUpdate.Visible = false;
        }

        protected void btnUpdatePatient_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid == true)
            {
                SqlConnection con = new SqlConnection(strCon);
                try
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("Update Person set name = @name, age = @age, contactNo = @contact, gender = @gender where icNo = @icNo", con);
                    cmd1.Parameters.AddWithValue("@icNo", txtUpdateIcNo.Text);
                    cmd1.Parameters.AddWithValue("@name", txtUpdatePatientName.Text);
                    cmd1.Parameters.AddWithValue("@age", txtUpdatePatientAge.Text);
                    cmd1.Parameters.AddWithValue("@contact", txtUpdatePatientContact.Text);
                    cmd1.Parameters.AddWithValue("@gender", ddlUpdateGender.SelectedValue);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("Update Patient set allergies = @allergies where icNo = @icNo", con);
                    cmd2.Parameters.AddWithValue("@allergies", txtUpdateAllergy.Text);
                    cmd2.Parameters.AddWithValue("@icNo", txtUpdateIcNo.Text);
                    cmd2.ExecuteNonQuery();
                    AlertMessage("Patient details have been successfully updated.");
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

        protected void btnDeletePatientSearch_Click(object sender, EventArgs e)
        {
            if (ddlDeleteSearchType.SelectedValue == "name")
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Patient.patientID, Patient.allergies from Patient, Person where Person.name = @name AND Person.icNo = Patient.icNo", con);
                cmd.Parameters.AddWithValue("@name", txtDeletePatientSearch.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        txtDeletePatientID.Text = dr["patientID"].ToString();
                        txtDeleteIcNo.Text = dr["icNo"].ToString();
                        txtDeletePatientName.Text = dr["name"].ToString();
                        txtDeletePatientAge.Text = dr["age"].ToString();
                        txtDeletePatientContact.Text = dr["contactNo"].ToString();
                        txtDeletePatientGender.Text = dr["gender"].ToString();
                        txtDeleteAllergy.Text = dr["allergies"].ToString();
                        pnlDeletePatient.Visible = true;
                        btnBackDelete.Visible = true;
                        patientDeleteNotFound.Visible = false;
                    }
                    else
                    {
                        patientDeleteNotFound.Visible = true;
                        pnlDeletePatient.Visible = false;
                        btnBackDelete.Visible = false;
                    }
                }
                con.Close();
            }
            else if (ddlDeleteSearchType.SelectedValue == "icNo")
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Patient.patientID, Patient.allergies from Patient, Person where Person.icNo = @icNo AND Person.icNo = Patient.icNo", con);
                cmd.Parameters.AddWithValue("@icNo", txtDeletePatientSearch.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtDeletePatientID.Text = dr["patientID"].ToString();
                    txtDeleteIcNo.Text = dr["icNo"].ToString();
                    txtDeletePatientName.Text = dr["name"].ToString();
                    txtDeletePatientAge.Text = dr["age"].ToString();
                    txtDeletePatientContact.Text = dr["contactNo"].ToString();
                    txtDeletePatientGender.Text = dr["gender"].ToString();
                    txtDeleteAllergy.Text = dr["allergies"].ToString();
                    pnlDeletePatient.Visible = true;
                    btnBackDelete.Visible = true;
                    patientDeleteNotFound.Visible = false;
                }
                else
                {
                    patientDeleteNotFound.Visible = true;
                    pnlDeletePatient.Visible = false;
                    btnBackDelete.Visible = false;
                }
                con.Close();
            }
            else if (ddlDeleteSearchType.SelectedValue == "patientID")
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Patient.patientID, Patient.allergies from Patient, Person where Patient.patientID = @patientID AND Person.icNo = Patient.icNo", con);
                cmd.Parameters.AddWithValue("@patientID", txtDeletePatientSearch.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtDeletePatientID.Text = dr["patientID"].ToString();
                    txtDeleteIcNo.Text = dr["icNo"].ToString();
                    txtDeletePatientName.Text = dr["name"].ToString();
                    txtDeletePatientAge.Text = dr["age"].ToString();
                    txtDeletePatientContact.Text = dr["contactNo"].ToString();
                    txtDeletePatientGender.Text = dr["gender"].ToString();
                    txtDeleteAllergy.Text = dr["allergies"].ToString();
                    pnlDeletePatient.Visible = true;
                    btnBackDelete.Visible = true;
                    patientDeleteNotFound.Visible = false;
                }
                else
                {
                    patientDeleteNotFound.Visible = true;
                    pnlDeletePatient.Visible = false;
                    btnBackDelete.Visible = false;
                }
                con.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Patient.patientID, Patient.allergies from Patient, Person where Person.contactNo = @contactNo AND Person.icNo = Patient.icNo", con);
                cmd.Parameters.AddWithValue("@contactNo", txtDeletePatientSearch.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtDeletePatientID.Text = dr["patientID"].ToString();
                    txtDeleteIcNo.Text = dr["icNo"].ToString();
                    txtDeletePatientName.Text = dr["name"].ToString();
                    txtDeletePatientAge.Text = dr["age"].ToString();
                    txtDeletePatientContact.Text = dr["contactNo"].ToString();
                    txtDeletePatientGender.Text = dr["gender"].ToString();
                    txtDeleteAllergy.Text = dr["allergies"].ToString();
                    pnlDeletePatient.Visible = true;
                    btnBackDelete.Visible = true;
                    patientDeleteNotFound.Visible = false;
                }
                else
                {
                    patientDeleteNotFound.Visible = true;
                    pnlDeletePatient.Visible = false;
                    btnBackDelete.Visible = false;
                }
                con.Close();
            }
        }

        protected void btnBackDelete_Click(object sender, EventArgs e)
        {
            txtDeletePatientSearch.Text = "";
            txtDeletePatientID.Text = "";
            txtDeleteIcNo.Text = "";
            txtDeletePatientName.Text = "";
            txtDeletePatientAge.Text = "";
            txtDeletePatientContact.Text = "";
            txtDeletePatientGender.Text = "";
            txtDeleteAllergy.Text = "";
            pnlDeletePatient.Visible = false;
            btnBackDelete.Visible = false;
            patientDeleteNotFound.Visible = false;
        }

        protected void btnDeletePatient_Click(object sender, EventArgs e)
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
                        SqlCommand cmd = new SqlCommand("DELETE FROM Person WHERE icNo = @icNo", con);
                        cmd.Parameters.AddWithValue("@icNo", txtDeleteIcNo.Text);
                        cmd.ExecuteNonQuery();
                        Response.Write("<script type=\"text/javascript\">alert('Patient details have been successfully deleted.');location.href='patientPage.aspx'</script>");
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
                    Response.Write("<script type=\"text/javascript\">alert('Patient Details have not been successfully deleted.')</script>");
                }
            }
        }

        protected void btnViewVisit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PatientVisit.aspx");
        }
    }
}