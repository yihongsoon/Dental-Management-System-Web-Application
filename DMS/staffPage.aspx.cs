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
    public partial class staffPage : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["ID"] == null)
            //{
            //    Response.Redirect("~/loginPage.aspx");
            //}
            id();
            
        }

        public void id()
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) As 'Row_Count' FROM  Staff", con);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            String staffID = "S10000";
            var prefix = Regex.Match(staffID, "^\\D+").Value;
            var number = Regex.Replace(staffID, "^\\D+", "");
            var i = int.Parse(number) + 1 + count;
            var newString = prefix + i.ToString(new string('0', number.Length));
            txtAddID.Text = newString;
        }


        protected void lnkAdd_Click(object sender, EventArgs e)
        {
            tabstaffAdd.Visible = true;
            tabstaffAttendance.Visible = false;
            tabstaffDelete.Visible = false;
            tabstaffSearch.Visible = false;
            tabstaffUpdate.Visible = false;
            lnkAdd.CssClass = "nav-link show active";
            lnkAttendance.CssClass = "nav-link show";
            lnkDelete.CssClass = "nav-link show";
            lnkSearch.CssClass = "nav-link show";
            lnkUpdate.CssClass = "nav-link show";
        }

        protected void lnkUpdate_Click(object sender, EventArgs e)
        {
            tabstaffAdd.Visible = false;
            tabstaffAttendance.Visible = false;
            tabstaffDelete.Visible = false;
            tabstaffSearch.Visible = false;
            tabstaffUpdate.Visible = true;
            lnkAdd.CssClass = "nav-link show";
            lnkAttendance.CssClass = "nav-link show";
            lnkDelete.CssClass = "nav-link show";
            lnkSearch.CssClass = "nav-link show";
            lnkUpdate.CssClass = "nav-link show active";
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            tabstaffAdd.Visible = false;
            tabstaffAttendance.Visible = false;
            tabstaffDelete.Visible = true;
            tabstaffSearch.Visible = false;
            tabstaffUpdate.Visible = false;
            lnkAdd.CssClass = "nav-link show";
            lnkAttendance.CssClass = "nav-link show";
            lnkDelete.CssClass = "nav-link show active";
            lnkSearch.CssClass = "nav-link show";
            lnkUpdate.CssClass = "nav-link show";
        }

        protected void lnkAttendance_Click(object sender, EventArgs e)
        {
            tabstaffAdd.Visible = false;
            tabstaffAttendance.Visible = true;
            tabstaffDelete.Visible = false;
            tabstaffSearch.Visible = false;
            tabstaffUpdate.Visible = false;
            lnkAdd.CssClass = "nav-link show";
            lnkAttendance.CssClass = "nav-link show active";
            lnkDelete.CssClass = "nav-link show";
            lnkSearch.CssClass = "nav-link show";
            lnkUpdate.CssClass = "nav-link show";
        }

        protected void lnkSearch_Click(object sender, EventArgs e)
        {
            tabstaffAdd.Visible = false;
            tabstaffAttendance.Visible = false;
            tabstaffDelete.Visible = false;
            tabstaffSearch.Visible = true;
            tabstaffUpdate.Visible = false;
            lnkAdd.CssClass = "nav-link show";
            lnkAttendance.CssClass = "nav-link show";
            lnkDelete.CssClass = "nav-link show";
            lnkSearch.CssClass = "nav-link show  active";
            lnkUpdate.CssClass = "nav-link show";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            SqlCommand cmd1 = new SqlCommand("INSERT INTO Person(icNo, name, age, contactNo, gender) VALUES(@icNo, @name, @age, @contact, @gender)", con);
            cmd1.Parameters.AddWithValue("@icNo", txtAddIC.Text);
            cmd1.Parameters.AddWithValue("@name", txtAddName.Text);
            cmd1.Parameters.AddWithValue("@age", txtAddAge.Text);
            cmd1.Parameters.AddWithValue("@contact", txtAddContactNo.Text);
            cmd1.Parameters.AddWithValue("@gender", ddlAddGender.SelectedValue);
            cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("INSERT INTO Staff(staffID, email, password, position, icNo) VALUES(@staffID, @email, @password, @position, @icNo)", con);
            cmd2.Parameters.AddWithValue("@staffID", txtAddID.Text);
            cmd2.Parameters.AddWithValue("@email", txtAddEmail.Text);
            cmd2.Parameters.AddWithValue("@password", txtAddIC.Text);
            cmd2.Parameters.AddWithValue("@position", ddlAddPosition.SelectedValue);
            cmd2.Parameters.AddWithValue("@icNo", txtAddIC.Text);
            cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand("INSERT INTO Address(addressName, postalCode, city, state, icNo) VALUES(@addressName, @postalCode, @city, @state, @icNo)", con);
            string address = txtAddAddress1.Text + " " + txtAddAddress2.Text;
            cmd3.Parameters.AddWithValue("@addressName", address);
            cmd3.Parameters.AddWithValue("@postalCode", txtAddZip.Text);
            cmd3.Parameters.AddWithValue("@city", txtAddCity.Text);
            cmd3.Parameters.AddWithValue("@state", txtAddState.Text);
            cmd3.Parameters.AddWithValue("@icNo", txtAddIC.Text);
            cmd3.ExecuteNonQuery();
            con.Close();
            Response.Write("<script type=\"text/javascript\">alert('Staff Added Successfully');location.href='staffPage.aspx'</script>");
        }

        protected void btnSearchProfile_Click(object sender, EventArgs e)
        {

            if (ddlSearchCriteria.SelectedValue == "name")
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Staff.staffID, Staff.email, Staff.position, Address.addressName, Address.postalCode, Address.city, Address.state from Address, Staff, Person where Person.name = @name AND Person.icNo = Staff.icNo AND Person.icNo = Address.icNo", con);
                cmd.Parameters.AddWithValue("@name", txtSearch.Text);
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
                        pnlsearchResult.Visible = true;
                        btnBackSearch.Visible = true;
                        noResult.Visible = false;
                    }
                    else
                    {
                        noResult.Visible = true;
                        pnlsearchResult.Visible = false;
                        btnBackSearch.Visible = false;
                    }
                }
                con.Close();
            }else if (ddlSearchCriteria.SelectedValue == "contact")
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Staff.staffID, Staff.email, Staff.position, Address.addressName, Address.postalCode, Address.city, Address.state from Address, Staff, Person where Person.contactNo = @contact AND Person.icNo = Staff.icNo AND Person.icNo = Address.icNo", con);
                cmd.Parameters.AddWithValue("@contact", txtSearch.Text);
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
                        pnlsearchResult.Visible = true;
                        btnBackSearch.Visible = true;
                        noResult.Visible = false;
                    }
                    else
                    {
                        noResult.Visible = true;
                        pnlsearchResult.Visible = false;
                        btnBackSearch.Visible = false;
                    }
                }
                con.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Staff.staffID, Staff.email, Staff.position, Address.addressName, Address.postalCode, Address.city, Address.state from Address, Staff, Person where Staff.staffID = @id AND Person.icNo = Staff.icNo AND Person.icNo = Address.icNo", con);
                cmd.Parameters.AddWithValue("@id", txtSearch.Text);
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
                        pnlsearchResult.Visible = true;
                        btnBackSearch.Visible = true;
                        noResult.Visible = false;
                    }
                    else
                    {
                        noResult.Visible = true;
                        pnlsearchResult.Visible = false;
                        btnBackSearch.Visible = false;
                    }
                }
                con.Close();
            }
            

            
        }

        protected void btnBackSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtID.Text = "";
            txtPosition.Text = "";
            txtName.Text = "";
            txtIC.Text = "";
            txtAge.Text = "";
            txtGender.Text = "";
            txtEmail.Text = "";
            txtContactNo.Text = "";
            txtAddress1.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
            pnlsearchResult.Visible = false;
            btnBackSearch.Visible = false;
            noResult.Visible = false;
        }

        protected void btnUpdateSearch_Click(object sender, EventArgs e)
        {
            if (ddlUpdateSearchCriteria.SelectedValue == "name")
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Staff.staffID, Staff.email, Staff.position, Address.addressName, Address.postalCode, Address.city, Address.state from Address, Staff, Person where Person.name = @name AND Person.icNo = Staff.icNo AND Person.icNo = Address.icNo", con);
                cmd.Parameters.AddWithValue("@name", txtUpdateSearch.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        txtUpdateID.Text = dr["staffID"].ToString();
                        txtUpdatePosition.Text = dr["position"].ToString();
                        txtUpdateName.Text = dr["name"].ToString();
                        txtUpdateIC.Text = dr["icNo"].ToString();
                        txtUpdateAge.Text = dr["age"].ToString();
                        txtUpdateGender.Text = dr["gender"].ToString();
                        txtUpdateEmail.Text = dr["email"].ToString();
                        txtUpdateContact.Text = dr["contactNo"].ToString();
                        txtUpdateAddress1.Text = dr["addressName"].ToString();
                        txtUpdateCity.Text = dr["city"].ToString();
                        txtUpdateState.Text = dr["state"].ToString();
                        txtUpdateZip.Text = dr["postalCode"].ToString();
                        pnlUpdateSearchResult.Visible = true;
                        btnUpdateBack.Visible = true;
                        noresultUpdate.Visible = false;
                    }
                    else
                    {
                        noresultUpdate.Visible = true;
                        pnlUpdateSearchResult.Visible = false;
                        btnUpdateBack.Visible = false;
                    }
                }
                con.Close();
            }
            else if (ddlUpdateSearchCriteria.SelectedValue == "contact")
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Staff.staffID, Staff.email, Staff.position, Address.addressName, Address.postalCode, Address.city, Address.state from Address, Staff, Person where Person.contactNo = @contact AND Person.icNo = Staff.icNo AND Person.icNo = Address.icNo", con);
                cmd.Parameters.AddWithValue("@contact", txtUpdateSearch.Text);
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
                        pnlUpdateSearchResult.Visible = true;
                        btnUpdateBack.Visible = true;
                        noresultUpdate.Visible = false;
                    }
                    else
                    {
                        noresultUpdate.Visible = true;
                        pnlUpdateSearchResult.Visible = false;
                        btnUpdateBack.Visible = false;
                    }
                }
                con.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Staff.staffID, Staff.email, Staff.position, Address.addressName, Address.postalCode, Address.city, Address.state from Address, Staff, Person where Staff.staffID = @id AND Person.icNo = Staff.icNo AND Person.icNo = Address.icNo", con);
                cmd.Parameters.AddWithValue("@id", txtUpdateSearch.Text);
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
                        pnlUpdateSearchResult.Visible = true;
                        btnUpdateBack.Visible = true;
                        noresultUpdate.Visible = false;
                    }
                    else
                    {
                        noresultUpdate.Visible = true;
                        pnlUpdateSearchResult.Visible = false;
                        btnUpdateBack.Visible = false;
                    }
                }
                con.Close();
            }
        }

        protected void btnUpdateBack_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtPosition.Text = "";
            txtName.Text = "";
            txtIC.Text = "";
            txtAge.Text = "";
            txtGender.Text = "";
            txtEmail.Text = "";
            txtContactNo.Text = "";
            txtAddress1.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZip.Text = "";
            pnlUpdateSearchResult.Visible = false;
            btnUpdateBack.Visible = false;
            noresultUpdate.Visible = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}