using DMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DMS
{
    /// <summary>
    /// Summary description for CalenderHandler
    /// </summary>
    public class CalenderHandler : IHttpHandler
    {
        string strCon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            IList<CalenderViewModel> calender = new List<CalenderViewModel>();
            using (SqlConnection con = new SqlConnection(strCon))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.CommandText = "SELECT appointmentID, appointmentName, dentistToVisit, appointmentDate, appointmentTime, appointmentPurpose, icNo, staffID FROM Appointment";
                    cmd.Connection = con;
                    //cmd.Parameters.AddWithValue("@appointmentName", txtSearchChoice.Text);
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                        calender = dt.AsEnumerable().Select(x => new CalenderViewModel
                        {
                            id = x.Field<string>("appointmentID"),
                            title = x.Field<string>("appointmentName"),
                            start = ((x.Field<DateTime>("appointmentDate")).ToString("yyyy-MM-dd") + " " + (x.Field<TimeSpan>("appointmentTime")).ToString()),
                            end = ((x.Field<DateTime>("appointmentDate")).ToString("yyyy-MM-dd") + " " + (x.Field<TimeSpan>("appointmentTime")).ToString()),
                            groupId = x.Field<string>("icNo")
                        }).ToList();
                    }
                }
            }
            System.Web.Script.Serialization.JavaScriptSerializer oSerializer =
         new System.Web.Script.Serialization.JavaScriptSerializer();
            string sJSON = oSerializer.Serialize(calender);
            context.Response.Write(sJSON);

        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}