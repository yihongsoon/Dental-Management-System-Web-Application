using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS
{
    public partial class loginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text == string.Empty || txtEmail.Text == string.Empty)
            {
                emptyField.Visible = true;
            }else if(txtPassword.Text != string.Empty && txtEmail.Text == string.Empty)
            {
                emptyField.Visible = true;
            }else if(txtPassword.Text == string.Empty && txtEmail.Text != string.Empty)
            {
                emptyField.Visible = true;
            }else if (txtPassword.Text != string.Empty && txtEmail.Text != string.Empty)
            {
                emptyField.Visible = false;
            }

        }

        protected void btnPassR_Click(object sender, EventArgs e)
        {
            if (txtpassREmail.Text == string.Empty || txtPassRICNo.Text == string.Empty)
            {
                emptyFieldPassRecovery.Visible = true;
            }
            else if (txtPassRICNo.Text != string.Empty && txtpassREmail.Text == string.Empty)
            {
                emptyFieldPassRecovery.Visible = true;
            }
            else if (txtPassRICNo.Text == string.Empty && txtpassREmail.Text != string.Empty)
            {
                emptyFieldPassRecovery.Visible = true;
            }
            else if (txtPassRICNo.Text != string.Empty && txtpassREmail.Text != string.Empty)
            {
                emptyFieldPassRecovery.Visible = false;
            }
        }
    }
}