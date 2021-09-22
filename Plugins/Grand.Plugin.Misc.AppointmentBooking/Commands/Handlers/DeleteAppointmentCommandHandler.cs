using EAppointment.Services;
using Grand.Plugin.Misc.AppointmentBooking.Commands.Models;
using Grand.Plugin.Misc.AppointmentBooking.DTOs;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.AppointmentBooking.Commands.Handlers
{
    class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, ListAppointmentsDto>
    {
        private readonly IAppointmentServices _appointmentService;

        public DeleteAppointmentCommandHandler(
            IAppointmentServices appointmentService
           )
        {
            _appointmentService = appointmentService;
        }

        public async Task<ListAppointmentsDto> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = request.Model.ToEntityFromListModel();
            await _appointmentService.Delete(appointment);
            return appointment.ToListModel();
        }

    }
}
