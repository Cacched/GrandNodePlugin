using EAppointment.Entites;
using EAppointment.Services;
using Grand.Core;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using Grand.Plugin.Misc.AppointmentManager;
using Grand.Plugin.Misc.AppointmentManager.DTO;
using Grand.Services.Customers;
using Grand.Services.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.AppointmentManager.ViewModelServices
{
    public class CustomerAppointmentsDtoService : ICustomerAppointmentsDtoService
    {
        private readonly IAppointmentServices _bookAppointmentService;
        private readonly ICustomerService _customerService;
        private readonly IWorkContext _workContext;
        private readonly ICustomerActivityService _customerActivityService;

        public CustomerAppointmentsDtoService(IAppointmentServices bookAppointmentService,
            ICustomerService customerService,
            IWorkContext workContext,
            ICustomerActivityService customerActivityService
            )
        {
            _bookAppointmentService = bookAppointmentService;
            _customerService = customerService;
            _workContext = workContext;
            _customerActivityService = customerActivityService;

        }
        public CustomerBookedAppointmentsDto PrepareAppointmentSearchModel()
        {
            var model = new CustomerBookedAppointmentsDto();
            var appointmentStatuses = from AppointmentStatus d in Enum.GetValues(typeof(AppointmentStatus))
                                      select new { ID = ((int)d), Name = d.ToString() };
            var statusList = new SelectList(appointmentStatuses, "ID", "Name");
            statusList.Append(new SelectListItem { Text = "Select Status", Value = "-1", Selected = true });
            model.AppointmentStatusList = statusList;
            return model;
        }
        public async Task<(IEnumerable<BookAppointmentDto> appointmentModels, int totalCount)> PrepareAppointmentModel(BookAppointmentDto models, int pageIndex, int pageSize)
        {
            DateTime? appointmentDate = null;
            var items = new List<BookAppointmentDto>();
            if(models.AppointmentDate!=System.DateTime.MinValue)
            {
                 appointmentDate = models.AppointmentDate;
            }
            
            var appointmentlist = await this._bookAppointmentService.GetAllAppointments(
                pageIndex :0,
                pageSize: int.MaxValue,
                CustomerId: models.CustomerId,
                VaccineId: models.VaccineId,
                VaccineName: models.VaccineName,
                Status: models.StatusId, CustomerName: models.CustomerName, AppointmentId: models.AppointmentId,
                SearchAppointmentDate:appointmentDate
            );

            foreach (var c in appointmentlist)
            {
                items.Add(c.ToBaseModel());
            }


            return (items, appointmentlist.TotalCount);
        }
        public  async Task DeleteSelected(IList<string> selectedIds)
        {
            var appointments = new List<EAppointmentBooking>();
            appointments.AddRange(await _bookAppointmentService.GetAppointmentsByIds(selectedIds.ToArray()));
            for (var i = 0; i < appointments.Count; i++)
            {
                var customerAppointment = appointments[i];
                                
                //activity log 
                await _customerActivityService.InsertActivity("Delete Appointment", customerAppointment.Id, "ActivityLog.DeleteAppointment", customerAppointment.Id);
                
                await _bookAppointmentService.Delete(customerAppointment);

            }
        }

        public virtual async Task<BookAppointmentDto> EditAppointment(BookAppointmentDto model)
        {
            var appointment = model.ToEntityFromBaseModel();
            appointment.EntryDate = System.DateTime.Today;
            await _bookAppointmentService.Update(appointment);
            return appointment.ToBaseModel();
        }

    }

}
