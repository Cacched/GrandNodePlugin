using Grand.Domain.Catalog;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grand.Plugin.Misc.AppointmentBooking.DTOs
{
    public class PrepareBookAppointmentModel
    {
        public PrepareBookAppointmentModel()
        {
        }

        public string VaccineId { get; set; }
        public string VaccineName { get; set; }
        public IEnumerable<SelectListItem> VaccineList { get; set; }
           
    }
}
