using Grand.Core.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Grand.Plugin.Misc.AppointmentBooking.Validators.AppointmentFormValidations;

namespace Grand.Plugin.Misc.AppointmentBooking.Models
{
    public class BookAppointmentDto
    {
        public BookAppointmentDto()
        {
            VaccinesList = new List<SelectListItem>();
            AppointmentStatusList = new List<SelectListItem>();
        }
        public string AppointmentId { get; set; }

        [Required(ErrorMessage = "Please Select a Vaccine")]
        public string VaccineId { get; set; }
        public string VaccineName { get; set; }
        public List<SelectListItem> VaccinesList { get; set; }

        [Required(ErrorMessage = "Please select Doze")]
        public string Doze { get; set; }
        /// <summary>
        /// Gets or sets the Customer Guid
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the Remarks for this Appointment
        /// </summary>
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Please enter Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter Blood Pressure")]
        public string BloodPressure { get; set; }

        [Required(ErrorMessage = "Please enter Temperature")]
        public string Temperature { get; set; }

        [Required(ErrorMessage = "Please enter Weight")]
        public string Weight { get; set; }

        /// <summary>
        /// Gets or sets the Remarks for this Appointment
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// Gets or sets the Entry date of the Appointment
        /// </summary>
        public DateTime EntryDate { get; set; }
        /// <summary>
        /// Gets or sets the  actual Appointment date that is scheduled
        /// </summary>
        [Required(ErrorMessage = "Please choose appointment date.")]
        [Display(Name = "Appointment Date")]
        [CustomAppointmentDate(ErrorMessage = "Appointment Date must be greater than or equal to Today's Date.")]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; }
        /// <summary>
        /// Gets or sets the Status of the Appointment
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets the Status Id of the Appointment
        /// </summary>
        public int StatusId { get; set; }
        public List<SelectListItem> AppointmentStatusList { get; set; }
    }

}
