using EAppointment.Services;
using Grand.Core;
using Grand.Plugin.Misc.AppointmentManager;
using Grand.Plugin.Misc.AppointmentManager.DTO;
using Grand.Services.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.AppointmentManager.ViewModelServices
{
    public class CustomerAppointmentsDtoService : ICustomerAppointmentsDtoService
    {
        private readonly IAppointmentServices _bookAppointmentService;
        private readonly ICustomerService _customerService;
        private readonly IWorkContext _workContext;

        public CustomerAppointmentsDtoService(IAppointmentServices bookAppointmentService,
            ICustomerService customerService,
            IWorkContext workContext
            )
        {
            this._bookAppointmentService = bookAppointmentService;
            this._customerService = customerService;
            this._workContext = workContext;
        }


        public async Task<(IEnumerable<CustomerBookedAppointmentsDto> appointmentModels, int totalCount)> PrepareAppointmentModel(CustomerBookedAppointmentsDto model, int pageIndex, int pageSize)
        {
            var items = new List<CustomerBookedAppointmentsDto>();
            var appointmentlist = await this._bookAppointmentService.GetAllAppointments(
                PatientsId: model.SearchCustomerId,
                pageIndex: pageIndex - 1,
                pageSize: pageSize,
                PatientsFullName: model.SearchCustomerName,
                Status: (int)model.AvailableAppointmentStatuses,
                AppointmentId: model.SearchAppointmentId
            );

            foreach (var c in appointmentlist)
            {
                var appointmentModel = new CustomerBookedAppointmentsDto();
                items.Add(c.ToModel());
            }


            return (items, appointmentlist.TotalCount);
        }

    }

}
