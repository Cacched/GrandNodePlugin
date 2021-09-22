using Grand.Plugin.Misc.AppointmentBooking.DTOs;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using MediatR;

namespace Grand.Plugin.Misc.AppointmentBooking.Commands.Models
{
    public class UpdateAppointmentCommand : IRequest<ListAppointmentsDto>
    {
        public ListAppointmentsDto Model { get; set; }
    }
}
