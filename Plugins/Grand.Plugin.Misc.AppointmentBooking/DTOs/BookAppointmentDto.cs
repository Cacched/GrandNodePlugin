using Grand.Core.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Grand.Plugin.Misc.AppointmentBooking.Models
{
    public class BookAppointmentDto
    {
        public BookAppointmentDto()
        {
            VaccinesList = new List<SelectListItem>();
        }
        public string AppointmentId { get; set; }
        public string VaccineId { get; set; }
        public string VaccineName { get; set; }
        public List<SelectListItem> VaccinesList { get; set; }
        public string Doze { get; set; }
        /// <summary>
        /// Gets or sets the Customer Guid
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the Remarks for this Appointment
        /// </summary>
        public string CustomerName { get; set; }
        public int Age { get; set; }
        public string BloodPressure { get; set; }
        public string Temperature { get; set; }
        public string Weight { get; set; }

        /// <summary>
        /// Gets or sets the Remarks for this Appointment
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// Gets or sets the Entry date of the Appointment
        /// </summary>
        [GrandResourceDisplayName("Admin.Catalog.Products.Fields.Calendar.StartDate")]
        public DateTime EntryDate { get; set; }
        /// <summary>
        /// Gets or sets the  actual Appointment date that is scheduled
        /// </summary>
        [GrandResourceDisplayName("Admin.Catalog.Products.Fields.Calendar.StartDate")]
        public DateTime AppointmentDate { get; set; }
        /// <summary>
        /// Gets or sets the Status of the Appointment
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets the Status Id of the Appointment
        /// </summary>
        public int StatusId { get; set; }

    }

}
