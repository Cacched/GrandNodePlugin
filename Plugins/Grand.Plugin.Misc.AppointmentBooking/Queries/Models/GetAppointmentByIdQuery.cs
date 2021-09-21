using Grand.Plugin.Misc.AppointmentBooking.Models;
using MediatR;

namespace Grand.Plugin.Misc.AppointmentBooking.Queries.Models
{
    public class GetAppointmentByIdQuery : IRequest<BookAppointmentDto>
    {
        public BookAppointmentDto Model { get; set; }
    }
}
