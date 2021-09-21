using AutoMapper;
using EAppointment.Entites;
using Grand.Core.Mapper;
using Grand.Plugin.Misc.AppointmentBooking.Models;

namespace Grand.Plugin.Misc.AppointmentBooking
{
    public class AppointmentBookingProfile : Profile, IAutoMapperProfile
    {
        public AppointmentBookingProfile()
        {
            CreateMap<BookAppointmentDto, EAppointmentBooking>();
            CreateMap<EAppointmentBooking, BookAppointmentDto>();
        }
        public int Order => 1;
    }
}
