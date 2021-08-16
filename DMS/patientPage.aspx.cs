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

            id();
        }

        protected void btnAddVisit_Click(object sender, EventArgs e)
        {
            Response.Redirect("patientVisitPage.aspx");
        }

        public void id()
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
    }
}