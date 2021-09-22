using AutoMapper;
using EAppointment.Entites;
using Grand.Core.Mapper;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using Grand.Plugin.Misc.AppointmentBooking.DTOs;

namespace Grand.Plugin.Misc.AppointmentBooking
{
    public class AppointmentBookingProfile : Profile, IAutoMapperProfile
    {
        public AppointmentBookingProfile()
        {
            CreateMap<BookAppointmentDto, EAppointmentBooking>();
            CreateMap<EAppointmentBooking, BookAppointmentDto>();
            CreateMap<EAppointmentBooking, ListAppointmentsDto>()
                .ForMember(dest =>
                    dest.CustomerName,
                    opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest =>
                    dest.AppointmentId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                    dest.CustomerId,
                    opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest =>
                    dest.Status,
                    opt => opt.MapFrom(src => src.Status))
             .ForMember(dest =>
                    dest.VaccineName,
                    opt => opt.MapFrom(src => src.VaccineName));
            CreateMap<ListAppointmentsDto, EAppointmentBooking>()
                .ForMember(dest =>
                    dest.CustomerName,
                    opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.AppointmentId))
                .ForMember(dest =>
                    dest.CustomerId,
                    opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest =>
                    dest.Status,
                    opt => opt.MapFrom(src => src.Status))
             .ForMember(dest =>
                    dest.VaccineName,
                    opt => opt.MapFrom(src => src.VaccineName));
        }
        public int Order => 1;
    }
}
