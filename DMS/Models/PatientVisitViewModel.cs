using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class PatientVisitViewModel
    {
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Display(Name = "icNo")]
        public string icNo { get; set; }
        [Display(Name = "Visit ID")]
        public string visitId { get; set; }
        [Display(Name = "Date Visit")]
        public string dateVisit { get; set; }
        [Display(Name = "Status")]
        public string status { get; set; }
        [Display(Name = "Diagnosis")]
        public string diagnosis { get; set; }
        [Display(Name = "Medicine Given")]
        public string medicineGiven { get; set; }
        [Display(Name = "Dentist Visited")]
        public string dentistVisited { get; set; }
        [Display(Name = "Room No")]
        public string roomNo { get; set; }
    }
}