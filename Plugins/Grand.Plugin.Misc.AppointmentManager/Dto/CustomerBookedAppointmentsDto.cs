using EAppointment.Entites;
using System;

namespace Grand.Plugin.Misc.AppointmentManager.DTO
{
    public class CustomerBookedAppointmentsDto
    {
        public CustomerBookedAppointmentsDto()
        {
        }
        public AppointmentStatus AvailableAppointmentStatuses { get; set; }
        public string SearchCustomerId { get; set; }
        public string SearchAppointmentId { get; set; }
        public string SearchCustomerName { get; set; }
        public string SearchVaccineId { get; set; }
        public string SearchVaccineName { get; set; }
        public DateTime? SearchAppointmentDate { get; set; }

    }
}
