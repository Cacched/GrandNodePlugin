using Grand.Plugin.Misc.AppointmentBooking.Models;
using Grand.Plugin.Misc.AppointmentManager.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.AppointmentManager.ViewModelServices
{
    public interface ICustomerAppointmentsDtoService
    {
        Task<(IEnumerable<BookAppointmentDto> appointmentModels, int totalCount)> PrepareAppointmentModel(BookAppointmentDto models, int pageIndex, int pageSize);
        Task DeleteSelected(IList<string> selectedIds);
        Task<BookAppointmentDto> EditAppointment(BookAppointmentDto model);

    }
}
