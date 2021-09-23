using Grand.Domain;
using Grand.Domain.Common;
using Grand.Domain.Orders;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;


namespace EAppointment.Entites
{
    public class EAppointmentBooking: BaseEntity
    {
        public EAppointmentBooking()
        {
            AppointmentGuid = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the Appointment Guid
        /// </summary>
        public Guid AppointmentGuid { get; set; }
        /// <summary>
        /// Gets or sets the Vaccine Guid
        /// </summary>
        public string VaccineId { get; set; }
        /// <summary>
        /// Gets or sets the Vaccine Name
        /// </summary>
        public string VaccineName { get; set; }
        /// <summary>
        /// Gets or sets the Customer Name
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets the Customer Guid
        /// </summary>
        public string CustomerId { get; set; }
        /// <summary>
        /// Gets or sets the Remarks for this Appointment
        /// </summary>
        public string  Remarks { get; set; }
        /// <summary>
        /// Gets or sets the Entry date of the Appointment
        /// </summary>
        public DateTime EntryDate { get; set; }
        /// <summary>
        /// Gets or sets the actual Appointment date that is scheduled
        /// </summary>
        public DateTime AppointmentDate { get; set; }
        /// <summary>
        /// Gets or sets the Status of the Appointment
        /// </summary>
        public AppointmentStatus Status { get; set; }
    }

    public enum AppointmentStatus
    {
        Received,
        Processing,
        Confirmed,
        Completed,
        Cancelled
    }

}
