using EAppointment.Entites;
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
        string GetAppointmentStatus(string appointmentId);
        void UpdateAppointmentStatus(string appointmentId);

    }
}
