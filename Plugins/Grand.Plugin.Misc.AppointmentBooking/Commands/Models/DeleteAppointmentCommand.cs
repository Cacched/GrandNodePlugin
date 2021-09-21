﻿using Grand.Plugin.Misc.AppointmentBooking.Models;
using MediatR;

namespace Grand.Plugin.Misc.AppointmentBooking.Commands.Models
{
    public class DeleteAppointmentCommand : IRequest<BookAppointmentDto>
    {
        public BookAppointmentDto Model { get; set; }
    }
}
