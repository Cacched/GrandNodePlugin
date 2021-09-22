using Grand.Framework.Controllers;
using Grand.Framework.Kendoui;
using Grand.Framework.Mvc.Filters;
using Grand.Framework.Security.Authorization;
using Grand.Plugin.Misc.AppointmentManager.DTO;
using Grand.Plugin.Misc.AppointmentManager.ViewModelServices;
using Grand.Services.Security;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.AppointmentManager.Controllers
{
    [Area("Admin")]
    [AuthorizeAdmin]
    public class ManageCustomerAppointmentsController : BasePluginController
    {
        private readonly ICustomerAppointmentsDtoService _customerAppointmentsViewModelService;
        public ManageCustomerAppointmentsController(ICustomerAppointmentsDtoService customerAppointmentsViewModelService)
        {
            _customerAppointmentsViewModelService = customerAppointmentsViewModelService;
        }

        public IActionResult ViewCustomerAppointments()
        {
            return View("~/Plugins/Misc.AppointmentManager/Views/ManageCustomerAppointments/ManageCustomerAppointmentBookings.cshtml", new CustomerBookedAppointmentsDto());
        }
        [PermissionAuthorizeAction(PermissionActionName.List)]
        [HttpPost]
        public async Task<IActionResult> CustomerAppointmentsList(DataSourceRequest command, CustomerBookedAppointmentsDto model)
        {
            var (customerModelList, totalCount) = await _customerAppointmentsViewModelService.PrepareAppointmentModel(model, command.Page, command.PageSize);
            var gridModel = new DataSourceResult {
                Data = customerModelList,
                Total = totalCount
            };

            return Json(gridModel);
        }
    }
}
