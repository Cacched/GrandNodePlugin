using EAppointment.Services;
using Grand.Plugin.Misc.AppointmentBooking.Commands.Models;
using Grand.Plugin.Misc.AppointmentBooking.DTOs;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.AppointmentBooking.Commands.Handlers
{
    class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, ListAppointmentsDto>
    {
        private readonly IAppointmentServices _appointmentService;
        public UpdateAppointmentCommandHandler(IAppointmentServices appointmentServices)
        {
            _appointmentService = appointmentServices;
        }
        public async Task<ListAppointmentsDto> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = request.Model.ToEntityFromListModel();
            await _appointmentService.Update(appointment);
            return appointment.ToListModel();
        }
    }
}
