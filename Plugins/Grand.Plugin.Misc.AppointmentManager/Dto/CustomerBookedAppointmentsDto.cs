using EAppointment.Entites;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Grand.Plugin.Misc.AppointmentManager.DTO
{
    public class CustomerBookedAppointmentsDto
    {
        public CustomerBookedAppointmentsDto()
        {
        }
        public string SearchStatusId{ get; set; }
        public string SearchStatusValue{ get; set; }
        public string SearchCustomerId { get; set; }
        public string SearchAppointmentId { get; set; }
        public string SearchCustomerName { get; set; }
        public string SearchVaccineId { get; set; }
        public string SearchVaccineName { get; set; }
        public DateTime? SearchAppointmentDate { get; set; }
        public SelectList AppointmentStatusList { get; set; }
    }
}
