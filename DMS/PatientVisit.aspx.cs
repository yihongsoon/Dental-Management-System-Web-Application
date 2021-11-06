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

        protected void GridViewVisitRecord_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridViewVisitRecord_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                        cmd.CommandText = "SELECT dbo.Person.name AS PatientName, dbo.Patient.icNo, dbo.VisitRecord.visitID, dbo.VisitRecord.dateVisit, dbo.VisitRecord.status, dbo.VisitRecord.diagnosis, dbo.VisitRecord.medicineGiven, dbo.VisitRecord.dentistVisited, dbo.VisitRecord.roomNo, dbo.VisitRecord.totalVisit FROM dbo.Patient INNER JOIN dbo.VisitRecord ON dbo.Patient.patientID = dbo.VisitRecord.patientID INNER JOIN dbo.Person ON dbo.Patient.icNo = dbo.Person.icNo where dbo.VisitRecord.patientID='" + patientId + "'";
                        cmd.Connection = con;
                        DataTable dt = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            GridViewVisitRecord.DataSource = dt;
                            GridViewVisitRecord.DataBind();
                        }
                    }
                }
            }

        }

        protected void btnBackPatient_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/patientPage.aspx");
        }

    }
}