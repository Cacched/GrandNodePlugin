using EAppointment.Entites;
using Grand.Domain.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAppointment.Services
{
    public class AppointmentServices : IAppointmentServices
    {
        private readonly IRepository<EAppointmentBooking> _appointmentRepository;

        public AppointmentServices(IRepository<EAppointmentBooking> appointmentRepository)
        {
            this._appointmentRepository = appointmentRepository;
        }
        public async Task Delete(EAppointmentBooking model)
        {
            await _appointmentRepository.DeleteAsync(model);
        }

        public  async Task<IList<EAppointmentBooking>> GetAll()
        {
            return await _appointmentRepository.Table.ToListAsync();
        }

        public string GetAppointmentStatus(string appointmentId)
        {
            return _appointmentRepository.GetById(appointmentId).Status.ToString();
        }

        public async Task<EAppointmentBooking> GetById(string appointmentId)
        {
            return await _appointmentRepository.GetByIdAsync(appointmentId);
        }

        public async Task Insert(EAppointmentBooking model)
        {
           await _appointmentRepository.InsertAsync(model);
        }

        public async Task Update(EAppointmentBooking model)
        {
           await _appointmentRepository.UpdateAsync(model);
        }

        public void UpdateAppointmentStatus(string appointmentId)
        {
            throw new NotImplementedException();
        }
    }
}
