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
    public partial class loginPage : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            String password = txtPassword.Text;
            String email = txtEmail.Text.ToUpper();
            String adminword = "admin";
            String upperadmin = adminword.ToUpper();

            if (txtPassword.Text != string.Empty && txtEmail.Text != string.Empty)
            {
                emptyField.Visible = false;
                try
                {
                    if (email.Contains(upperadmin))
                    {
                        SqlConnection con = new SqlConnection(strCon);
                        con.Open();
                        SqlCommand cmd = new SqlCommand("select adminID from Admin where adminPassword = @adminPass AND adminEmail = @adminEmail", con);
                        cmd.Parameters.AddWithValue("@adminPass", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@adminEmail", txtEmail.Text);
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr != null)
                        {
                            if (dr.Read())
                            {
                                Session["ID"] = dr["adminID"].ToString();
                                Response.Redirect("~/profilePage.aspx");
                            }
                            else
                            {
                                loginFail.Visible = true;
                            }
                        }
                        con.Close();
                    }
                    else
                    {
                        SqlConnection con = new SqlConnection(strCon);
                        con.Open();
                        SqlCommand cmd = new SqlCommand("select staffID from Staff where email = @staffEmail AND password = @staffpass", con);
                        cmd.Parameters.AddWithValue("@staffpass", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@staffEmail", txtEmail.Text);
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr != null)
                        {
                            if (dr.Read())
                            {
                                Session["ID"] = dr["staffID"].ToString();
                                Response.Redirect("~/profilePage.aspx");
                            }
                            else
                            {
                                loginFail.Visible = true;
                            }
                        }
                        con.Close();
                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }
            else
            {
                emptyField.Visible = true;
            }

        }

        protected void btnPassR_Click(object sender, EventArgs e)
        {
            if (txtPassRICNo.Text != string.Empty && txtpassREmail.Text != string.Empty)
            {
                emptyFieldPassRecovery.Visible = false;
                try
                {
                    
                        SqlConnection con = new SqlConnection(strCon);
                        con.Open();
                        SqlCommand cmd = new SqlCommand("select email, icNo from Staff where icNo = @recoveryIC AND email = @recoveryEmail", con);
                        cmd.Parameters.AddWithValue("@recoveryIC", txtPassRICNo.Text);
                        cmd.Parameters.AddWithValue("@recoveryEmail", txtpassREmail.Text);
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr != null)
                        {
                            if (dr.Read())
                            {
                            success.Visible = true;
                            }
                            else
                            {
                            failMatchIcEmail.Visible = true;
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
                emptyFieldPassRecovery.Visible = true;
            }
        }
    }
}