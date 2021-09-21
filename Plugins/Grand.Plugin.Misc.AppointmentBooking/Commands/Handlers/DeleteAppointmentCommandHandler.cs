using EAppointment.Services;
using Grand.Plugin.Misc.AppointmentBooking.Commands.Models;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.AppointmentBooking.Commands.Handlers
{
    class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, BookAppointmentDto>
    {
        private readonly IAppointmentServices _appointmentService;

        public DeleteAppointmentCommandHandler(
            IAppointmentServices appointmentService
           )
        {
            _appointmentService = appointmentService;
        }

        public async Task<BookAppointmentDto> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = request.Model.ToEntity();
            await _appointmentService.Delete(appointment);
            return appointment.ToModel();
        }

    }
}
