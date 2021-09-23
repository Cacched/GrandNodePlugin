using EAppointment.Entites;
using Grand.Domain;
using Grand.Domain.Customers;
using Grand.Domain.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
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
        public async Task<IList<EAppointmentBooking>> GetAppointmentByCustomerId(string CustomerId)
        {
            return await _appointmentRepository.Table.Where(x=>x.CustomerId == CustomerId).ToListAsync();
        }

        public string GetAppointmentStatus(string appointmentId)
        {
            return _appointmentRepository.GetById(appointmentId).Status.ToString();
        }

        public async Task<EAppointmentBooking> GetById(string appointmentId)
        {
            return await _appointmentRepository.GetByIdAsync(appointmentId);
        }
        public async Task<IList<EAppointmentBooking>> GetAppointmentsByIds(string[] appointmentIds)
        {
            if (appointmentIds == null || appointmentIds.Length == 0)
                return new List<EAppointmentBooking>();

            var query = from c in _appointmentRepository.Table
                        where appointmentIds.Contains(c.Id)
                        select c;
            var appointmentBookings = await query.ToListAsync();
            //sort by passed identifiers
            var sortedAppointments = new List<EAppointmentBooking>();
            foreach (var id in appointmentIds)
            {
                var appointment = appointmentBookings.Find(x => x.Id == id);
                if (appointment != null)
                    sortedAppointments.Add(appointment);
            }
            return sortedAppointments;
        }

        public async Task Insert(EAppointmentBooking model)
        {
           await _appointmentRepository.InsertAsync(model);
        }

        public async Task Update(EAppointmentBooking model)
        {
            await _appointmentRepository.UpdateAsync(model);
        }

        public async Task UpdateAppointmentStatus(string appointmentId, AppointmentStatus changedStatus)
        {
            var appointment = GetById(appointmentId);
            appointment.Result.Status = changedStatus;
            await Update(appointment.Result);
        }

        public async Task<IPagedList<EAppointmentBooking>> GetAllAppointments(
           int pageIndex = 0,
           int pageSize = int.MaxValue,
           string CustomerId = "",
           string VaccineId = "",
           string VaccineName = null,
           int Status = 0, string CustomerName = null, string AppointmentId = "", DateTime? SearchAppointmentDate = null)
        {
            #region Get enquiries

            //enquiries
            var builder = Builders<EAppointmentBooking>.Filter;
            var filter = FilterDefinition<EAppointmentBooking>.Empty;
            var filterSpecification = FilterDefinition<EAppointmentBooking>.Empty;

            
            //filtering
            if(SearchAppointmentDate.HasValue)
            {
                filter = filter & builder.Where(o => o.AppointmentDate == SearchAppointmentDate);
            }
            if (!string.IsNullOrEmpty(AppointmentId))
            {
                filter = filter & builder.Where(o => o.AppointmentGuid.ToString() == AppointmentId);
            }
            if (!string.IsNullOrWhiteSpace(CustomerId))
            {
                filter = filter & builder.Where(o => CustomerId == o.CustomerId);
            }
            if (!string.IsNullOrWhiteSpace(AppointmentId))
            {
                filter = filter & builder.Where(o => AppointmentId == o.Id);
            }
            if (!string.IsNullOrWhiteSpace(VaccineId))
            {
                filter = filter & builder.Where(o => VaccineId == o.VaccineId);
            }
            if (!string.IsNullOrWhiteSpace(CustomerName))
            {
                filter = filter & builder.Where(o => CustomerName.ToLower() == o.CustomerName.ToLower());
            }
            if (!string.IsNullOrWhiteSpace(VaccineName))
            {
                filter = filter & builder.Where(o => VaccineName.ToLower() == o.VaccineName.ToLower());
            }
            //if (Status>=0)
            //{
            //    filter = filter & builder.Where(o => Status == (int)o.Status);
            //}


            var builderSort = Builders<EAppointmentBooking>.Sort.Descending(x => x.EntryDate);

            var appointmentList = await PagedList<EAppointmentBooking>.Create(_appointmentRepository.Collection, filter, builderSort, pageIndex, pageSize);

            return appointmentList;

            #endregion
        }
    }
}
