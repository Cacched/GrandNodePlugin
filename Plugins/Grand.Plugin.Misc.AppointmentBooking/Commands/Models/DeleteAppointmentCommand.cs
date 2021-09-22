using Grand.Plugin.Misc.AppointmentBooking.DTOs;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using MediatR;

namespace Grand.Plugin.Misc.AppointmentBooking.Commands.Models
{
    public class DeleteAppointmentCommand : IRequest<ListAppointmentsDto>
    {
        public ListAppointmentsDto Model { get; set; }
    }
}
