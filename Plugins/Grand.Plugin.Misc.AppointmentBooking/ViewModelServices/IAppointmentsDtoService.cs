using Grand.Domain.Customers;
using Grand.Plugin.Misc.AppointmentBooking.DTOs;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.AppointmentManager.ViewModelServices
{
    public interface IAppointmentsDtoService
    {
        BookAppointmentDto PrepareBookAppointmentModel(Customer customer);
        Task DeleteSelected(ListAppointmentsDto models);
        Task EditAppointment(ListAppointmentsDto model);
        Task InsertAppointment(BookAppointmentDto model);

    }
}
