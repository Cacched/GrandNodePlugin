using Grand.Api.Commands.Models.Common;
using Grand.Core;
using Grand.Domain.Customers;
using Grand.Framework.Controllers;
using Grand.Framework.Kendoui;
using Grand.Framework.Mvc.Filters;
using Grand.Plugin.Misc.AppointmentBooking.Commands.Models;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using Grand.Plugin.Misc.AppointmentBooking.DTOs;
using Grand.Plugin.Misc.AppointmentBooking.Queries.Models;
using Grand.Services.Customers;
using Grand.Services.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grand.Framework.Security.Authorization;
using EAppointment.Entites;
using Grand.Plugin.Misc.AppointmentManager.ViewModelServices;

namespace Grand.Plugin.Misc.AppointmentBooking.Controllers
{
    public class AppointmentBookingController : BasePluginController
    {
        private readonly IMediator _mediator;
        private readonly IWorkContext _workContext;
        private readonly ICustomerService _customerService;
        private readonly IPermissionService _permissionService;
        private readonly IAppointmentsDtoService _appointmentDtoService;
        public AppointmentBookingController(
            IMediator mediator,
            IWorkContext workContext,
            ICustomerService customerService,
            IPermissionService permissionService,
            IAppointmentsDtoService appointmentDtoService
            )
        {
            _mediator = mediator;
            _workContext = workContext;
            _customerService = customerService;
            _permissionService = permissionService;
            _appointmentDtoService = appointmentDtoService;
        }

        public async Task<IActionResult> BookAppointment()
        {
            if (!_workContext.CurrentCustomer.IsRegistered() || _workContext.CurrentCustomer.IsAdmin())
            {
                return Challenge();
            }
            
            var claims = new Dictionary<string, string>();
            claims.Add("Email", this._workContext.CurrentCustomer.Email);
            var customer = _customerService.GetCustomerById(_workContext.CurrentCustomer.Id);
            var token = await _mediator.Send(new GenerateTokenCommand() { Claims = claims });
            ViewBag.token = token;
            var model =  _appointmentDtoService.PrepareBookAppointmentModel(customer.Result);
            return View("~/Plugins/Misc.AppointmentBooking/Views/AppointmentBooking/BookAppointment.cshtml", model);
        }

        [HttpPost]
        public  async Task<IActionResult> SaveAppointment([FromForm] BookAppointmentDto model)
        {
            if (ModelState.IsValid)
            {
                await _appointmentDtoService.InsertAppointment(model);
                SuccessNotification("Appointment Saved Successfullly");
                return RedirectToAction("ViewAppointments");
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> EditAppointment([FromBody] ListAppointmentsDto models)
        {
            
            if (ModelState.IsValid)
            {
                await _appointmentDtoService.EditAppointment(models);
                return RedirectToAction("ViewAppointments");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAppointment([FromBody] ListAppointmentsDto models)
        {

            if (ModelState.IsValid)
            {
                await _appointmentDtoService.DeleteSelected(models);
                return RedirectToAction("ViewAppointments");
            }
            return BadRequest(ModelState);
        }

        public async Task<IActionResult> ViewAppointments()
        {
            if (!_workContext.CurrentCustomer.IsRegistered() || _workContext.CurrentCustomer.IsAdmin())
            {
                return Challenge();
            }
            var claims = new Dictionary<string, string>();
            claims.Add("Email", this._workContext.CurrentCustomer.Email);
            var customer = _customerService.GetCustomerById(_workContext.CurrentCustomer.Id);
            var token = await _mediator.Send(new GenerateTokenCommand() { Claims = claims });
            ViewBag.token = token;
            return View("~/Plugins/Misc.AppointmentBooking/Views/AppointmentBooking/ManageAppointments.cshtml",new ListAppointmentsDto());
        }

        [PermissionAuthorizeAction(PermissionActionName.List)]
        [HttpPost]
        public async Task<IActionResult> AppointmentList(DataSourceRequest command, ListAppointmentsDto model)
        {
            string customerId = _workContext.CurrentCustomer.Id;
            //var (enquiryModels, totalCount) = await _appointmentDtoService.PrepareAppointmentModel(model, command.Page, command.PageSize);
            var appointmemtData = await _mediator.Send(new GetAppointmentByCustomerIdQuery() { CustomerId=customerId});
            var gridModel = new DataSourceResult {
                Data = appointmemtData,
                Total = appointmemtData.Count()
            };

            return Json(gridModel);

        }

    }
}
