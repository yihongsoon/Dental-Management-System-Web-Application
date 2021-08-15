using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DMS
{
    public partial class mainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["username"] == null)
            //    Response.Redirect("loginPage.aspx");

        }

        protected void imgBtnCalendar_Click(object sender, ImageClickEventArgs e)
        {
            calendar1.Visible = true;
        }

        protected void calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtAddDate.Text = calendar1.SelectedDate.ToShortDateString();
            calendar1.Visible = false;
            
        }
    }
}