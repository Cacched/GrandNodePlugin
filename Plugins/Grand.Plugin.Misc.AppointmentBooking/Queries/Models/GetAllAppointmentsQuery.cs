using Grand.Plugin.Misc.AppointmentBooking.Models;
using MediatR;
using System.Collections.Generic;

namespace Grand.Plugin.Misc.AppointmentBooking.Queries.Models
{
    public class GetAllAppointmentsQuery : IRequest<IList<BookAppointmentDto>>
    {
    }
}
