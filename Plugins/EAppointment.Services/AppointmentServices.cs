using EAppointment.Entites;
using Grand.Domain;
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
        public  Task<List<EAppointmentBooking>> GetAppointmentByCustomerId(string CustomerId)
        {
            return _appointmentRepository.Collection.FindAsync(CustomerId).Result.ToListAsync();
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

        public async Task<IPagedList<EAppointmentBooking>> GetAllAppointments(
           string PatientsId = null,
           DateTime? createdFromUtc = null,
           DateTime? createdToUtc = null,
           int pageIndex = 0,
           int pageSize = int.MaxValue,
           string Status = null,  string PatientsFullName = null, string phone = null, string AppointmentId = null)
        {
            #region Get enquiries

            //enquiries
            var builder = Builders<EAppointmentBooking>.Filter;
            var filter = FilterDefinition<EAppointmentBooking>.Empty;
            var filterSpecification = FilterDefinition<EAppointmentBooking>.Empty;

            
            //filtering
            if (createdFromUtc.HasValue)
            {
                filter = filter & builder.Where(o => createdFromUtc.Value <= o.EntryDate);
            }
            if (!string.IsNullOrEmpty(AppointmentId))
            {
                filter = filter & builder.Where(o => o.AppointmentGuid.ToString() == AppointmentId);
            }
            if (createdToUtc.HasValue)
            {
                filter = filter & builder.Where(o => createdToUtc.Value.AddDays(1) >= o.EntryDate);
            }

            if (!string.IsNullOrWhiteSpace(PatientsId))
            {
                filter = filter & builder.Where(o => PatientsId == o.CustomerId);
            }

                       
            var builderSort = Builders<EAppointmentBooking>.Sort.Descending(x => x.EntryDate);


            var appointmentList = await PagedList<EAppointmentBooking>.Create(_appointmentRepository.Collection, filter, builderSort, pageIndex, pageSize);

            return appointmentList;

            #endregion
        }

    }
}
