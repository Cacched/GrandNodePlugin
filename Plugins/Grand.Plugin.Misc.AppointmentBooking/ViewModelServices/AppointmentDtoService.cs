using EAppointment.Services;
using Grand.Core;
using Grand.Services.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using Grand.Plugin.Misc.AppointmentBooking.DTOs;
using EAppointment.Entites;

namespace Grand.Plugin.Misc.AppointmentBooking.ViewModelServices
{
    public class AppointmentDtoService : IAppointmentDtoService
    {
        private readonly IAppointmentServices _bookAppointmentService;
        private readonly ICustomerService _customerService;
        private readonly IWorkContext _workContext;

        public AppointmentDtoService(IAppointmentServices bookAppointmentService,
            ICustomerService customerService,
            IWorkContext workContext
            )
        {
            this._bookAppointmentService = bookAppointmentService;
            this._customerService = customerService;
            this._workContext = workContext;
        }
        public async Task<BookAppointmentDto> InsertAppointment(BookAppointmentDto model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.CustomerId))
                {
                    throw new ArgumentException("No Patient/Customer found with the specified id");
                }
                else if (model.AppointmentDate == DateTime.MinValue)
                {
                    throw new ArgumentException("Invalid Date provided");
                }
                else if(model.Age<0)
                {
                    throw new ArgumentException("Invalid Age provided, must be greater than zero");
                }
                else if (string.IsNullOrEmpty(model.BloodPressure))
                {
                    throw new ArgumentException("Invalid Blood Pressure data");
                }
                else if (string.IsNullOrEmpty(model.Temperature))
                {
                    throw new ArgumentException("Invalid Body Temperature data");
                }
                else if (string.IsNullOrEmpty(model.Weight))
                {
                    throw new ArgumentException("Invalid Body Weight data");
                }
                else if (string.IsNullOrEmpty(model.VaccineId))
                {
                    throw new ArgumentException("No Vaccine found with the specified id");
                }
                else
                {
                    await _bookAppointmentService.Insert(model.ToEntity());
                }
            }
            catch
            {

            }
            return model;
        }


        public async Task<BookAppointmentDto> UpdateAppointment(BookAppointmentDto model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.CustomerId))
                {
                    throw new ArgumentException("No Patient/Customer found with the specified id");
                }
                else if (model.AppointmentDate == DateTime.MinValue)
                {
                    throw new ArgumentException("Invalid Date provided");
                }
                else if (model.Age < 0)
                {
                    throw new ArgumentException("Invalid Age provided, must be greater than zero");
                }
                else if (string.IsNullOrEmpty(model.BloodPressure))
                {
                    throw new ArgumentException("Invalid Blood Pressure data");
                }
                else if (string.IsNullOrEmpty(model.Temperature))
                {
                    throw new ArgumentException("Invalid Body Temperature data");
                }
                else if (string.IsNullOrEmpty(model.Weight))
                {
                    throw new ArgumentException("Invalid Body Weight data");
                }
                else if (string.IsNullOrEmpty(model.VaccineId))
                {
                    throw new ArgumentException("No Vaccine found with the specified id");
                }
                else
                {
                    await _bookAppointmentService.Update(model.ToEntity());
                }
            }
            catch
            {

            }
            return model;
        }



        public async Task<(IEnumerable<BookAppointmentDto> appointmentModels, int totalCount)> PrepareAppointmentModel(ListAppointmentsDto model, int pageIndex, int pageSize)
        {
            var items = new List<BookAppointmentDto>();
            var appointmentlist = await this._bookAppointmentService.GetAllAppointments(
                PatientsId: model.CustomerId,
                pageIndex: pageIndex - 1,
                pageSize: pageSize,
                PatientsFullName: model.CustomerName,
                Status: model.Status,
                AppointmentId: model.AppointmentId
            );

            foreach (var c in appointmentlist)
            {
                var appointmentModel = new BookAppointmentDto();
                items.Add(c.ToModel());
            }


            return (items, appointmentlist.TotalCount);
        }

    }

}
