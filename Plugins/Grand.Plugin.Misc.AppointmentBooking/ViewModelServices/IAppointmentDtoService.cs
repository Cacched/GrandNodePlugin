using System;
using System.Collections.Generic;
using System.Text;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using Grand.Plugin.Misc.AppointmentBooking.DTOs;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.AppointmentBooking.ViewModelServices
{
    public interface IAppointmentDtoService
    {
        Task<BookAppointmentDto> UpdateAppointment(BookAppointmentDto model);
        Task<BookAppointmentDto> InsertAppointment(BookAppointmentDto model);
        Task<(IEnumerable<BookAppointmentDto> appointmentModels, int totalCount)> PrepareAppointmentModel(ListAppointmentsDto model, int pageIndex, int pageSize);

    }
}
