using EAppointment.Services;
using Grand.Plugin.Misc.AppointmentBooking.Commands.Models;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.AppointmentBooking.Commands.Handlers
{
    class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, BookAppointmentDto>
    {
        private readonly IAppointmentServices _appointmentService;
        public async Task<BookAppointmentDto> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = request.Model.ToEntity();
            await _appointmentService.Update(appointment);
            return appointment.ToModel();
        }
    }
}
