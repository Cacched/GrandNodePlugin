using EAppointment.Entites;
using Grand.Core.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Grand.Plugin.Misc.AppointmentBooking.DTOs
{
    public class ListAppointmentsDto
    {
        public ListAppointmentsDto()
        {
        }
        public DateTime AppointmentDate { get; set; }
        public DateTime EntryDate{ get; set; }
        public string AppointmentId { get; set; }
        public string Status { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string VaccineName { get; set; }
    }

}

