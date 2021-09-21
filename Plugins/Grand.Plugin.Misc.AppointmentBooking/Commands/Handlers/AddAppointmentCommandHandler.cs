using EAppointment.Services;
using Grand.Plugin.Misc.AppointmentBooking.Commands.Models;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.AppointmentBooking.Commands.Handlers
{
    public class AddAppointmentCommandHandler : IRequestHandler<AddAppointmentCommand, BookAppointmentDto>
    {
        private readonly IAppointmentServices _appointmentService;

        public AddAppointmentCommandHandler(
            IAppointmentServices appointmentService
           )
        {
            _appointmentService = appointmentService;
        }

        public async Task<BookAppointmentDto> Handle(AddAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = request.Model.ToEntity();
            appointment.EntryDate = DateTime.UtcNow;
            await _appointmentService.Insert(appointment);
            //activity log
            return appointment.ToModel();
        }
    }
}
