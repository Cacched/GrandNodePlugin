using Grand.Api.Commands.Models.Common;
using Grand.Core;
using Grand.Domain.Customers;
using Grand.Framework.Controllers;
using Grand.Framework.Kendoui;
using Grand.Framework.Mvc.Filters;
using Grand.Plugin.Misc.AppointmentBooking.Commands.Models;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using Grand.Plugin.Misc.AppointmentBooking.Queries.Models;
using Grand.Services.Customers;
using Grand.Services.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.AppointmentBooking.Controllers
{
    public class AppointmentBookingController : BasePluginController
    {
        private readonly IMediator _mediator;
        private readonly IWorkContext _workContext;
        private readonly ICustomerService _customerService;
        private readonly IPermissionService _permissionService;
        public AppointmentBookingController(
            IMediator mediator,
            IWorkContext workContext,
            ICustomerService customerService,
            IPermissionService permissionService
            )
        {
            this._mediator = mediator;
            this._workContext = workContext;
            this._customerService = customerService;
            this._permissionService = permissionService;
        }

        public async Task<IActionResult> BookAppointment()
        {
            if (!_workContext.CurrentCustomer.IsRegistered() || _workContext.CurrentCustomer.IsAdmin())
            {
                return Challenge();
            }
            var model = new BookAppointmentDto();
            var claims = new Dictionary<string, string>();
            claims.Add("Email", this._workContext.CurrentCustomer.Email);
            var customer = _customerService.GetCustomerById(_workContext.CurrentCustomer.Id);
            var token = await _mediator.Send(new GenerateTokenCommand() { Claims = claims });
            ViewBag.token = token;
            model.CustomerId = customer.Result.Id;
            model.CustomerName = customer.Result.GetFullName();
            return View("~/Plugins/Misc.AppointmentBooking/Views/AppointmentBooking/BookAppointment.cshtml", model);
        }

        [HttpPost]
        public  async Task<IActionResult> SaveAppointment([FromForm] BookAppointmentDto model)
        {
            if (ModelState.IsValid)
            {
                model = await _mediator.Send(new AddAppointmentCommand() { Model = model });
                SuccessNotification("Appointment Saved Successfullly");
                return RedirectToAction("AppointmentList");
            }
            return BadRequest(ModelState);
        }

        public async Task<IActionResult> Put([FromBody] BookAppointmentDto model)
        {
            
            if (ModelState.IsValid)
            {
                model = await _mediator.Send(new UpdateAppointmentCommand() { Model = model });
               SuccessNotification("Appointment Saved Successfullly");
                RedirectToAction("AppointmentList");
            }
            return BadRequest(ModelState);
        }

        public async Task<IActionResult> AppointmentList(DataSourceRequest command, BookAppointmentDto model)
        {
            if (!_workContext.CurrentCustomer.IsRegistered() || _workContext.CurrentCustomer.IsAdmin())
            {
                return Challenge();
            }
            var result = await _mediator.Send(new GetAllAppointmentsQuery());
            
            var claims = new Dictionary<string, string>();
            claims.Add("Email", this._workContext.CurrentCustomer.Email);
            var customer = _customerService.GetCustomerById(_workContext.CurrentCustomer.Id);
            var token = await _mediator.Send(new GenerateTokenCommand() { Claims = claims });
            ViewBag.token = token;
            model.CustomerId = customer.Result.Id;
            model.CustomerName = customer.Result.GetFullName();
            return View("~/Plugins/Misc.AppointmentBooking/Views/AppointmentBooking/ManageAppointments.cshtml", result);

        }

    }
}
