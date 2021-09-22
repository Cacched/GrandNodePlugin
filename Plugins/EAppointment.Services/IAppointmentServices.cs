using EAppointment.Entites;
using Grand.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EAppointment.Services
{
    public interface IAppointmentServices
    {
        Task Insert(EAppointmentBooking model);
        Task Update(EAppointmentBooking model);
        Task Delete(EAppointmentBooking model);
        Task<IList<EAppointmentBooking>> GetAll();
        Task<EAppointmentBooking> GetById(string appointmentId);
        Task<List<EAppointmentBooking>> GetAppointmentByCustomerId(string CustomerId);
        string GetAppointmentStatus(string appointmentId);
        void UpdateAppointmentStatus(string appointmentId);
        public Task<IPagedList<EAppointmentBooking>> GetAllAppointments(
           string PatientsId = null,
           DateTime? createdFromUtc = null,
           DateTime? createdToUtc = null,
           int pageIndex = 0,
           int pageSize = int.MaxValue,
           int Status = 0, string PatientsFullName = null, string phone = null, string AppointmentId = null);

    }
}
