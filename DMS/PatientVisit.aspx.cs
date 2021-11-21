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
    public partial class PatientVisit : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        void AlertMessage(string msg)
        {
            Response.Write("<script type=\"text/javascript\">alert('" + msg + "')</script>");
        }

        protected void GridViewVisitRecord_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridViewVisitRecord_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVisitID.Text = GridViewVisitRecord.SelectedRow.Cells[1].Text;
            txtPatientIC.Text = GridViewVisitRecord.SelectedRow.Cells[2].Text;
            txtPatientName.Text = GridViewVisitRecord.SelectedRow.Cells[3].Text;
            txtDateVisit.Text = GridViewVisitRecord.SelectedRow.Cells[4].Text;
            txtStatus.Text = GridViewVisitRecord.SelectedRow.Cells[5].Text;
            txtDentVisited.Text = GridViewVisitRecord.SelectedRow.Cells[6].Text;
            txtRoomNo.Text = GridViewVisitRecord.SelectedRow.Cells[7].Text;
            txtDiagnosis.Text = GridViewVisitRecord.SelectedRow.Cells[8].Text;
            txtMedGiven.Text = GridViewVisitRecord.SelectedRow.Cells[9].Text;
            pnlViewVisitBroad.Visible = true;
            pnlViewVisitSpec.Visible = true;
        }

        private void BindGrid()
        {
            if (Session["Patient_ID"] != null)
            {
                string patientId = Session["Patient_ID"].ToString();
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        con.Open();
                        cmd.CommandText = "SELECT dbo.Person.name AS PatientName, dbo.Patient.icNo, dbo.VisitRecord.visitID, dbo.VisitRecord.dateVisit, dbo.VisitRecord.status, " +
                            "dbo.VisitRecord.diagnosis, dbo.VisitRecord.medicineGiven, dbo.VisitRecord.dentistVisited, dbo.VisitRecord.roomNo FROM dbo.Patient " +
                            "INNER JOIN dbo.VisitRecord ON dbo.Patient.patientID = dbo.VisitRecord.patientID INNER JOIN dbo.Person ON dbo.Patient.icNo = dbo.Person.icNo " +
                            "where dbo.VisitRecord.patientID='" + patientId + "'";
                        cmd.Connection = con;
                        DataTable dt = new DataTable();

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            var _reformedData = dt.AsEnumerable().Select(x => new PatientVisitViewModel
                            {
                                visitId = x.Field<string>("visitID"),
                                icNo = x.Field<string>("icNo").ToString(),
                                PatientName = x.Field<string>("PatientName"),
                                dateVisit = ((x.Field<DateTime>("dateVisit")).ToString("MMM dd, yyyy")),
                                status = x.Field<string>("status"),
                                dentistVisited = x.Field<string>("dentistVisited"),
                                roomNo = x.Field<int>("roomNo").ToString(),
                                diagnosis = x.Field<string>("diagnosis"),
                                medicineGiven = x.Field<string>("medicineGiven")
                            }).ToList();

                            GridViewVisitRecord.DataSource = _reformedData;
                            GridViewVisitRecord.DataBind();

                            if(_reformedData.Count > 0)
                            {
                                pnlViewVisitBroad.Visible = true;
                                pnlNoVisitRec.Visible = false;
                            }
                            else
                            {
                                pnlViewVisitBroad.Visible = false;
                                pnlNoVisitRec.Visible = true;
                            }
                        }
                    }
                }
            }

        }

        protected void btnBackPatient_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/patientPage.aspx");
        }

        protected void btnBackVisit_Click(object sender, EventArgs e)
        {
            txtVisitID.Text = "";
            txtPatientName.Text = "";
            txtPatientIC.Text = "";
            txtDateVisit.Text = "";
            txtStatus.Text = "";
            txtDiagnosis.Text = "";
            txtMedGiven.Text = "";
            txtDentVisited.Text = "";
            txtRoomNo.Text = "";
            pnlViewVisitBroad.Visible = true;
            pnlViewVisitSpec.Visible = false;
        }

        protected void btnDeleteVisit_Click(object sender, EventArgs e)
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
                        SqlCommand cmd = new SqlCommand("DELETE FROM VisitRecord WHERE visitID = @visitID", con);
                        cmd.Parameters.AddWithValue("@visitID", txtVisitID.Text);
                        cmd.ExecuteNonQuery();
                        Response.Write("<script type=\"text/javascript\">alert('Patient visit details have been successfully deleted.')</script>");
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
                    Response.Write("<script type=\"text/javascript\">alert('Patient visit details have not been successfully deleted.')</script>");
                }
            }
        }

    }
}