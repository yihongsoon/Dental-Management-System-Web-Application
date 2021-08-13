using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS
{
    public partial class profilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["ID"] == null)
            {
                Response.Redirect("~/loginPage.aspx");
            }
            txtID.Text = Session["ID"].ToString();
        }
    }
}