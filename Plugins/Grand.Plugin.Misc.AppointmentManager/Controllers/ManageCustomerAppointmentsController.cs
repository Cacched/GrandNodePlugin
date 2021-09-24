using EAppointment.Entites;
using Grand.Framework.Controllers;
using Grand.Framework.Kendoui;
using Grand.Framework.Mvc.Filters;
using Grand.Framework.Security.Authorization;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using Grand.Plugin.Misc.AppointmentManager.DTO;
using Grand.Plugin.Misc.AppointmentManager.ViewModelServices;
using Grand.Services.Security;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var model = _customerAppointmentsViewModelService.PrepareAppointmentSearchModel();
            return View("~/Plugins/Misc.AppointmentManager/Views/ManageCustomerAppointments/ManageCustomerAppointmentBookings.cshtml", model);
        }
        //[PermissionAuthorizeAction(PermissionActionName.List)]
        [HttpGet]
        public async Task<IActionResult> CustomerAppointmentsList(DataSourceRequest command,  BookAppointmentDto model)
        {
            var (customerModelList, totalCount) = await _customerAppointmentsViewModelService.PrepareAppointmentModel(model, command.Page, command.PageSize);
            var gridModel = new DataSourceResult {
                Data = customerModelList,
                Total = totalCount
            };

            return Json(gridModel);
        }
        [PermissionAuthorizeAction(PermissionActionName.Edit)]
        [HttpPut]
        public async Task<IActionResult> EditAppointment( BookAppointmentDto models)
        {

            if (ModelState.IsValid)
            {
                models = await _customerAppointmentsViewModelService.EditAppointment(models);

                return Json(new { Result = true });
            }
            return BadRequest(ModelState);
        }

        
        [PermissionAuthorizeAction(PermissionActionName.Delete)]
        public async Task<IActionResult> DeleteSelected(ICollection<string> selectedIds)
        {
            if (selectedIds != null)
            {
                await _customerAppointmentsViewModelService.DeleteSelected(selectedIds.ToList());
            }
            return Json(new { Result = true });
        }

        public async Task<IActionResult> AppointmentStatusList(ICollection<string> selectedIds)
        {
            if (selectedIds != null)
            {
                await _customerAppointmentsViewModelService.DeleteSelected(selectedIds.ToList());
            }
            return Json(new { Result = true });
        }
        [HttpGet]
        public IActionResult GetAppointmentStatusList()
        {
            try
            {
                var model = _customerAppointmentsViewModelService.PrepareAppointmentSearchModel().AppointmentStatusList;
                return Json(model.Items);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
