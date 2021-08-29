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
            if (Session["ID"] == null)
            {
                Response.Redirect("~/loginPage.aspx");
            }
            id();
            
        }
        void ShowMessage(string msg)
        {
            //ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script  language = 'javascript' > alert('" + msg + "');</ script > ");
            Response.Write("<script type=\"text/javascript\">alert('" + msg + "')</script>");
        }
        public void id()
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            //SqlCommand cmd = new SqlCommand("SELECT COUNT(*) As 'Row_Count' FROM  Staff", con);
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 staffID FROM Staff ORDER BY staffID DESC", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                if (dr.Read())
                {
                    String staffID = dr["staffID"].ToString();
                    var prefix = Regex.Match(staffID, "^\\D+").Value;
                    var number = Regex.Replace(staffID, "^\\D+", "");
                    var i = int.Parse(number) + 1;
                    var newString = prefix + i.ToString(new string('0', number.Length));
                    txtAddID.Text = newString;
                }
                else
                {
                    String staffID = "S10000";
                    var prefix = Regex.Match(staffID, "^\\D+").Value;
                    var number = Regex.Replace(staffID, "^\\D+", "");
                    var i = int.Parse(number) + 1;
                    var newString = prefix + i.ToString(new string('0', number.Length));
                    txtAddID.Text = newString;
                }
            }
            
            con.Close();
            
            
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
            Page.Validate();
            if (Page.IsValid == true) {
                SqlConnection con = new SqlConnection(strCon);
                try
                {
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
                    //ShowMessage("Staff Added Successfully");
                    Response.Write("<script type=\"text/javascript\">alert('Staff Added Successfully');location.href='staffPage.aspx'</script>");
                }
                catch (SqlException ex)
                {
                    ShowMessage(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
              
            //Response.Write("<script type=\"text/javascript\">alert('Staff Added Successfully');location.href='staffPage.aspx'</script>");
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
                        ddlUpdatePosition.ClearSelection();
                        ddlUpdatePosition.SelectedValue = dr["position"].ToString();
                        txtUpdateName.Text = dr["name"].ToString();
                        txtUpdateIC.Text = dr["icNo"].ToString();
                        txtUpdateAge.Text = dr["age"].ToString();
                        ddlUpdateGender.ClearSelection();
                        ddlUpdateGender.SelectedValue = dr["gender"].ToString();
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
                        txtUpdateID.Text = dr["staffID"].ToString();
                        ddlUpdatePosition.ClearSelection();
                        ddlUpdatePosition.SelectedValue = dr["position"].ToString();
                        txtUpdateName.Text = dr["name"].ToString();
                        txtUpdateIC.Text = dr["icNo"].ToString();
                        txtUpdateAge.Text = dr["age"].ToString();
                        ddlUpdateGender.ClearSelection();
                        ddlUpdateGender.SelectedValue = dr["gender"].ToString();
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
                        txtUpdateID.Text = dr["staffID"].ToString();
                        ddlUpdatePosition.ClearSelection();
                        ddlUpdatePosition.SelectedValue = dr["position"].ToString();
                        txtUpdateName.Text = dr["name"].ToString();
                        txtUpdateIC.Text = dr["icNo"].ToString();
                        txtUpdateAge.Text = dr["age"].ToString();
                        ddlUpdateGender.ClearSelection();
                        ddlUpdateGender.SelectedValue = dr["gender"].ToString();
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
            Page.Validate();
            if (Page.IsValid == true)
            {
                SqlConnection con = new SqlConnection(strCon);
                try
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("Update Person set name = @name, age = @age, contactNo = @contact, gender = @gender where icNo = @icNO", con);
                    cmd1.Parameters.AddWithValue("@icNo", txtUpdateIC.Text);
                    cmd1.Parameters.AddWithValue("@name", txtUpdateName.Text);
                    cmd1.Parameters.AddWithValue("@age", txtUpdateAge.Text);
                    cmd1.Parameters.AddWithValue("@contact", txtUpdateContact.Text);
                    cmd1.Parameters.AddWithValue("@gender", ddlUpdateGender.SelectedValue);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("Update Staff set email = @email, position = @position where icNo = @icNO", con);
                    cmd2.Parameters.AddWithValue("@email", txtUpdateEmail.Text);
                    cmd2.Parameters.AddWithValue("@position", ddlUpdatePosition.SelectedValue);
                    cmd2.Parameters.AddWithValue("@icNo", txtUpdateIC.Text);
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd3 = new SqlCommand("Update Address set addressName = @addressName, postalCode = @postalCode, city = @city, state = @state where icNo = @icNO", con);
                    cmd3.Parameters.AddWithValue("@addressName", txtUpdateAddress1.Text);
                    cmd3.Parameters.AddWithValue("@postalCode", txtUpdateZip.Text);
                    cmd3.Parameters.AddWithValue("@city", txtUpdateCity.Text);
                    cmd3.Parameters.AddWithValue("@state", txtUpdateState.Text);
                    cmd3.Parameters.AddWithValue("@icNo", txtUpdateIC.Text);
                    cmd3.ExecuteNonQuery();
                    ShowMessage("Staff Updated Successfully");
                }
                catch (SqlException ex)
                {
                    ShowMessage(ex.Message);
                }
                finally
                {                   
                    con.Close();
                }
            }
            //Response.Write("<script type=\"text/javascript\">alert('Staff Updated Successfully')</script>");
        }

        protected void btnDeleteSearch_Click(object sender, EventArgs e)
        {
            if (ddlDeleteCriteria.SelectedValue == "name")
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Staff.staffID, Staff.email, Staff.position, Address.addressName, Address.postalCode, Address.city, Address.state from Address, Staff, Person where Person.name = @name AND Person.icNo = Staff.icNo AND Person.icNo = Address.icNo", con);
                cmd.Parameters.AddWithValue("@name", txtDeleteCriteria.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        txtDeleteID.Text = dr["staffID"].ToString();
                        txtDeletePosition.Text = dr["position"].ToString();
                        txtDeleteName.Text = dr["name"].ToString();
                        txtDeleteIC.Text = dr["icNo"].ToString();
                        txtDeleteAge.Text = dr["age"].ToString();
                        txtDeleteGender.Text = dr["gender"].ToString();
                        txtDeleteEmail.Text = dr["email"].ToString();
                        txtDeleteContactNo.Text = dr["contactNo"].ToString();
                        txtDeleteAddress1.Text = dr["addressName"].ToString();
                        txtDeleteCity.Text = dr["city"].ToString();
                        txtDeleteState.Text = dr["state"].ToString();
                        txtDeleteZip.Text = dr["postalCode"].ToString();
                        pnlDeleteSearchResult.Visible = true;
                        btnDeleteBack.Visible = true;
                        noresultDelete.Visible = false;
                    }
                    else
                    {
                        noresultDelete.Visible = true;
                        pnlDeleteSearchResult.Visible = false;
                        btnDeleteBack.Visible = false;
                    }
                }
                con.Close();
            }
            else if (ddlDeleteCriteria.SelectedValue == "contact")
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Staff.staffID, Staff.email, Staff.position, Address.addressName, Address.postalCode, Address.city, Address.state from Address, Staff, Person where Person.contactNo = @contact AND Person.icNo = Staff.icNo AND Person.icNo = Address.icNo", con);
                cmd.Parameters.AddWithValue("@contact", txtDeleteCriteria.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        txtDeleteID.Text = dr["staffID"].ToString();
                        txtDeletePosition.Text = dr["position"].ToString();
                        txtDeleteName.Text = dr["name"].ToString();
                        txtDeleteIC.Text = dr["icNo"].ToString();
                        txtDeleteAge.Text = dr["age"].ToString();
                        txtDeleteGender.Text = dr["gender"].ToString();
                        txtDeleteEmail.Text = dr["email"].ToString();
                        txtDeleteContactNo.Text = dr["contactNo"].ToString();
                        txtDeleteAddress1.Text = dr["addressName"].ToString();
                        txtDeleteCity.Text = dr["city"].ToString();
                        txtDeleteState.Text = dr["state"].ToString();
                        txtDeleteZip.Text = dr["postalCode"].ToString();
                        pnlDeleteSearchResult.Visible = true;
                        btnDeleteBack.Visible = true;
                        noresultDelete.Visible = false;
                    }
                    else
                    {
                        noresultDelete.Visible = true;
                        pnlDeleteSearchResult.Visible = false;
                        btnDeleteBack.Visible = false;
                    }
                }
                con.Close();
            }
            else
            {
                SqlConnection con = new SqlConnection(strCon);
                con.Open();
                SqlCommand cmd = new SqlCommand("select Person.icNo, Person.name, Person.age, Person.contactNo, Person.gender, Staff.staffID, Staff.email, Staff.position, Address.addressName, Address.postalCode, Address.city, Address.state from Address, Staff, Person where Staff.staffID = @id AND Person.icNo = Staff.icNo AND Person.icNo = Address.icNo", con);
                cmd.Parameters.AddWithValue("@id", txtDeleteCriteria.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.Read())
                    {
                        txtDeleteID.Text = dr["staffID"].ToString();
                        txtDeletePosition.Text = dr["position"].ToString();
                        txtDeleteName.Text = dr["name"].ToString();
                        txtDeleteIC.Text = dr["icNo"].ToString();
                        txtDeleteAge.Text = dr["age"].ToString();
                        txtDeleteGender.Text = dr["gender"].ToString();
                        txtDeleteEmail.Text = dr["email"].ToString();
                        txtDeleteContactNo.Text = dr["contactNo"].ToString();
                        txtDeleteAddress1.Text = dr["addressName"].ToString();
                        txtDeleteCity.Text = dr["city"].ToString();
                        txtDeleteState.Text = dr["state"].ToString();
                        txtDeleteZip.Text = dr["postalCode"].ToString();
                        pnlDeleteSearchResult.Visible = true;
                        btnDeleteBack.Visible = true;
                        noresultDelete.Visible = false;
                    }
                    else
                    {
                        noresultDelete.Visible = true;
                        pnlDeleteSearchResult.Visible = false;
                        btnDeleteBack.Visible = false;
                    }
                }
                con.Close();
            }
        }

        protected void btnDeleteBack_Click(object sender, EventArgs e)
        {
            txtDeleteID.Text = "";
            txtDeletePosition.Text = "";
            txtDeleteName.Text = "";
            txtDeleteIC.Text = "";
            txtDeleteAge.Text = "";
            txtDeleteGender.Text = "";
            txtDeleteEmail.Text = "";
            txtDeleteContactNo.Text = "";
            txtDeleteAddress1.Text = "";
            txtDeleteCity.Text = "";
            txtDeleteState.Text = "";
            txtDeleteZip.Text = "";
            pnlDeleteSearchResult.Visible = false;
            btnDeleteBack.Visible = false;
            noresultDelete.Visible = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid == true)
            {
                SqlConnection con = new SqlConnection(strCon);
                try
                {
                    con.Open();
                    //SqlCommand cmd1 = new SqlCommand("DELETE FROM Staff, Address, Person WHERE Staff.icNo = @icNo1, Address.icNo = @icNo2, Person.icNo = @icNo3", con);
                    //cmd1.Parameters.AddWithValue("@icNo1", txtDeleteIC.Text);
                    //cmd1.Parameters.AddWithValue("@icNo2", txtDeleteIC.Text);
                    //cmd1.Parameters.AddWithValue("@icNo3", txtDeleteIC.Text);
                    //cmd1.ExecuteNonQuery();
                    //SqlCommand cmd2 = new SqlCommand("DELETE FROM Staff, Address, Person WHERE Staff.icNo = @icNo1, Address.icNo = @icNo2, Person.icNo = @icNo3", con);
                    //cmd2.Parameters.AddWithValue("@icNo1", txtDeleteIC.Text);
                    //cmd2.Parameters.AddWithValue("@icNo2", txtDeleteIC.Text);
                    //cmd2.Parameters.AddWithValue("@icNo3", txtDeleteIC.Text);
                    //cmd2.ExecuteNonQuery();
                    SqlCommand cmd3 = new SqlCommand("DELETE FROM Person WHERE icNo = @icNo", con);
                    cmd3.Parameters.AddWithValue("@icNo", txtDeleteIC.Text);
                    cmd3.ExecuteNonQuery();
                    Response.Write("<script type=\"text/javascript\">alert('Staff Deleted Successfully');location.href='staffPage.aspx'</script>");
                    //ShowMessage("Staff Deleted Successfully");
                }
                catch (SqlException ex)
                {
                    ShowMessage(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}