using EAppointment.Entites;
using EAppointment.Services;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using Grand.Plugin.Misc.AppointmentBooking.Queries.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.AppointmentBooking.Queries.Handlers
{
    public class GetAllAppointmentsQueryHandler : IRequestHandler<GetAllAppointmentsQuery, IList<BookAppointmentDto>>
    {
        private readonly IAppointmentServices _appointmentService;

        public GetAllAppointmentsQueryHandler(IAppointmentServices appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<IList<BookAppointmentDto>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            IList<EAppointmentBooking> allBookings = await _appointmentService.GetAll();
            IList<BookAppointmentDto> allBookingsDto = new List<BookAppointmentDto>();
            foreach (var item in allBookings)
            {
                allBookingsDto.Add(item.ToModel());
            }

            return allBookingsDto;
        }
    }
}
