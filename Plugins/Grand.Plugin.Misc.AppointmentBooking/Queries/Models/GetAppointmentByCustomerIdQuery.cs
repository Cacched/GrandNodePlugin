using Grand.Plugin.Misc.AppointmentBooking.Models;
using MediatR;
using System.Collections.Generic;

namespace Grand.Plugin.Misc.AppointmentBooking.Queries.Models
{
    public class GetAppointmentByCustomerIdQuery : IRequest<IList<BookAppointmentDto>>
    {
        public string CustomerId{ get; set; }
    }
}
