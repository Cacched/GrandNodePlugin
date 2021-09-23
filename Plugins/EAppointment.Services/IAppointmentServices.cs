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
        Task<IList<EAppointmentBooking>> GetAppointmentsByIds(string[] appointmentIds);
        Task<IList<EAppointmentBooking>> GetAppointmentByCustomerId(string CustomerId);
        string GetAppointmentStatus(string appointmentId);
        Task UpdateAppointmentStatus(string appointmentId, AppointmentStatus changedStatus);
        Task<IPagedList<EAppointmentBooking>> GetAllAppointments(
         int pageIndex = 0,
        int pageSize = int.MaxValue,
        string CustomerId = "",
        string VaccineId = "",
        string VaccineName = null,
        int Status = 0, string CustomerName = null, string AppointmentId = "", DateTime? SearchAppointmentDate=null);

    }
}
