using Grand.Plugin.Misc.AppointmentBooking.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Grand.Plugin.Misc.AppointmentBooking.Queries.Models
{
    public class GetAllAppointmentsQuery : IRequest<IList<ListAppointmentsDto>>
    {
    }
}
