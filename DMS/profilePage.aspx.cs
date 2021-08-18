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
    public partial class profilePage : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["ID"] == null)
            {
                Response.Redirect("~/loginPage.aspx");
            }
            else
            {
                txtID.Text = Session["ID"].ToString();
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Staff.staffID, Staff.email, Staff.position, Address.addressName, Address.postalCode, Address.city, Address.state from Address, Staff, Person where Staff.staffID = @id AND Person.icNo = Staff.icNo AND Person.icNo = Address.icNo", con);
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        txtID.Text = dr["staffID"].ToString();
                        txtPosition.Text = dr["position"].ToString();
                        txtName.Text = dr["name"].ToString();
                        txtIC.Text = dr["icNo"].ToString();
                        txtAge.Text = dr["age"].ToString();
                        txtGender.Text = dr["gender"].ToString();
                        txtEmail.Text = dr["email"].ToString();
                        txtContactNo.Text = dr["contactNo"].ToString();
                        txtAddress1.Text = dr["addressName"].ToString();
                        txtCity.Text = dr["city"].ToString();
                        txtState.Text = dr["state"].ToString();
                        txtZip.Text = dr["postalCode"].ToString();
                    }
                }
                con.Close();
            }
            
        }
    }
}