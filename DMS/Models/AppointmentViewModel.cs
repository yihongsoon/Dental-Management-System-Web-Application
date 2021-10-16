using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class AppointmentViewModel
    {
        [Display(Name = "Appointment Id")]
        public string appointmentID { get; set; }
        [Display(Name = "Appointment Name")]
        public string appointmentName { get; set; }
        [Display(Name = "Dentist To Visit")]
        public string dentistToVisit { get; set; }
        [Display(Name = "Appointment Date")]
        public string appointmentDate { get; set; }
        [Display(Name = "Appointment Time")]
        public string appointmentTime { get; set; }
        [Display(Name = "Appointment Purpose")]
        public string appointmentPurpose { get; set; }
        [Display(Name = "IC No")]
        public string icNo { get; set; }
        [Display(Name = "staffID")]
        public string staffID { get; set; }
    }
}