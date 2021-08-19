using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DMS
{
    public partial class loginPage : System.Web.UI.Page
    {
        string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        void SendEmail()
        {
            string to = txtpassREmail.Text; //To address    
            string from = "dentalmsystem@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "Hi!" + Environment.NewLine + Environment.NewLine + "Your Password have been reset to your IC, " + Environment.NewLine + Environment.NewLine + "Please change your password within 30 minutes." + Environment.NewLine + Environment.NewLine + "Dental Management System" + Environment.NewLine + Environment.NewLine + "This is an automated email. Please do not reply to this email.";
            message.Subject = "Password Recovery";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = false;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("dentalmsystem@gmail.com", "DMSassignment");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        void changePass()
        {
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            
            SqlCommand cmd = new SqlCommand("Update Staff set password = @newpass where icNo = @ic", con);
            cmd.Parameters.AddWithValue("@newpass", txtPassRICNo.Text);
            cmd.Parameters.AddWithValue("@ic", txtPassRICNo.Text);
            cmd.ExecuteNonQuery();
            con.Close();
        }

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
                                Session["Role"] = "ADMIN";
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
                                Session["Role"] = "STAFF";
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
                            changePass();
                            success.Visible = true;
                            SendEmail();
                            failMatchIcEmail.Visible = false;
                        }
                            else
                            {
                            success.Visible = false;
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

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            pnllogin.Visible = true;
            pnlPasswordRecover.Visible = false;
            lnkLogin.CssClass = "nav-link show active";
            lnkPasswordRecover.CssClass = "nav-link show";
            emptyField.Visible = false;
            emptyFieldPassRecovery.Visible = false;
        }

        protected void lnkPasswordRecover_Click(object sender, EventArgs e)
        {
            pnllogin.Visible = false;
            pnlPasswordRecover.Visible = true;
            lnkLogin.CssClass = "nav-link show";
            lnkPasswordRecover.CssClass = "nav-link show active";
            emptyField.Visible = false;
            emptyFieldPassRecovery.Visible = false;
        }



        
    }
}