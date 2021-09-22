using Grand.Plugin.Misc.AppointmentManager.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.AppointmentManager.ViewModelServices
{
    public interface ICustomerAppointmentsDtoService
    {
        Task<(IEnumerable<CustomerBookedAppointmentsDto> appointmentModels, int totalCount)> PrepareAppointmentModel(CustomerBookedAppointmentsDto model, int pageIndex, int pageSize);

    }
}
