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
    public partial class ChangePassword : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        void changePass()
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            if (txtChangePassNew1.Text == txtChangePassNew2.Text)
            {
                SqlCommand cmd = new SqlCommand("Update Staff set password = @newpass where staffID = @id", con);
                cmd.Parameters.AddWithValue("@newpass", txtChangePassNew1.Text);
                cmd.Parameters.AddWithValue("@id", Session["ID"].ToString());
                cmd.ExecuteNonQuery();
                Session["ID"] = "";
                Session["Role"] = "";
                Response.Write("<script type=\"text/javascript\">alert('Password Changed Successfully');location.href='loginPage.aspx'</script>");
            }
            else
            {
                newPassNotMatch.Visible = true;
                oldPassNotMatch.Visible = false;
            }
            con.Close();
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("~/loginPage.aspx");
            }
        }

        protected void btnPasswordChange_Click(object sender, EventArgs e)
        {
            if (txtChangePassOld.Text != string.Empty && txtChangePassNew1.Text != string.Empty && txtChangePassNew2.Text != string.Empty)
            {
                passwordchangeEmpty.Visible = false;
                try
                {

                    SqlConnection con = new SqlConnection(strCon);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select password from Staff where password = @oldpass AND staffID = @id", con);
                    cmd.Parameters.AddWithValue("@oldpass", txtChangePassOld.Text);
                    cmd.Parameters.AddWithValue("@id", Session["ID"].ToString());
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr != null)
                    {
                        if (dr.Read())
                        {
                            changePass();
                        }
                        else
                        {
                            oldPassNotMatch.Visible = true;
                            newPassNotMatch.Visible = false;
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }
            else
            {
                passwordchangeEmpty.Visible = true;
            }
        }
    }
}