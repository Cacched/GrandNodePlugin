using EAppointment.Services;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using Grand.Plugin.Misc.AppointmentBooking.Queries.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.AppointmentBooking.Queries.Handlers
{
    public class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, BookAppointmentDto>
    {
        private readonly IAppointmentServices _appointmentService;
        public GetAppointmentByIdQueryHandler(IAppointmentServices appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public async Task<BookAppointmentDto> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            return (await _appointmentService.GetById(request.Model.AppointmentId)).ToModel();
        }
    }
}
