using EAppointment.Services;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using Grand.Plugin.Misc.AppointmentBooking.Queries.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.AppointmentBooking.Queries.Handlers
{
    public class GetAppointmentByCustomerIdQueryHandler : IRequestHandler<GetAppointmentByCustomerIdQuery, IList<BookAppointmentDto>>
    {
        private readonly IAppointmentServices _appointmentService;
        public GetAppointmentByCustomerIdQueryHandler(IAppointmentServices appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public async Task<IList<BookAppointmentDto>> Handle(GetAppointmentByCustomerIdQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentService.GetAppointmentByCustomerId(request.CustomerId);
            IList<BookAppointmentDto> appointmentsDto = new List<BookAppointmentDto>();
            foreach (var item in appointments)
            {
                appointmentsDto.Add(item.ToModel());
            }
            return appointmentsDto;
        }
    }
}
