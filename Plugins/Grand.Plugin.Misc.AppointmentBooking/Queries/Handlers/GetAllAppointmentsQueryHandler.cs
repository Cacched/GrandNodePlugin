using EAppointment.Entites;
using EAppointment.Services;
using Grand.Plugin.Misc.AppointmentBooking.DTOs;
using Grand.Plugin.Misc.AppointmentBooking.Queries.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.AppointmentBooking.Queries.Handlers
{
    public class GetAllAppointmentsQueryHandler : IRequestHandler<GetAllAppointmentsQuery, IList<ListAppointmentsDto>>
    {
        private readonly IAppointmentServices _appointmentService;

        public GetAllAppointmentsQueryHandler(IAppointmentServices appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<IList<ListAppointmentsDto>> Handle(GetAllAppointmentsQuery request, CancellationToken cancellationToken)
        {
            IList<EAppointmentBooking> allBookings = await _appointmentService.GetAll();
            IList<ListAppointmentsDto> allBookingsDto = new List<ListAppointmentsDto>();
            foreach (var item in allBookings)
            {
                allBookingsDto.Add(item.ToListModel());
            }

            return allBookingsDto;
        }
    }
}
