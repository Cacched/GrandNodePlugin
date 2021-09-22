using AutoMapper;
using EAppointment.Entites;
using Grand.Core.Mapper;
using Grand.Plugin.Misc.AppointmentManager.DTO;

namespace Grand.Plugin.Misc.AppointmentBooking
{
    public class CustomerAppointmentBookingProfile : Profile, IAutoMapperProfile
    {
        public CustomerAppointmentBookingProfile()
        {
            CreateMap<EAppointmentBooking, CustomerBookedAppointmentsDto>()
                .ForMember(dest =>
                    dest.AvailableAppointmentStatuses,
                    opt => opt.MapFrom(src => src.Status))
                .ForMember(dest =>
                    dest.SearchAppointmentId,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest =>
                    dest.SearchCustomerId,
                    opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest =>
                    dest.SearchCustomerName,
                    opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest =>
                    dest.SearchVaccineName,
                    opt => opt.MapFrom(src => src.VaccineName))
                .ForMember(dest =>
                        dest.SearchVaccineId,
                        opt => opt.MapFrom(src => src.VaccineId));

            CreateMap<CustomerBookedAppointmentsDto, EAppointmentBooking>()
                .ForMember(dest =>
                    dest.CustomerName,
                    opt => opt.MapFrom(src => src.SearchCustomerName))
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.SearchAppointmentId))
                .ForMember(dest =>
                    dest.CustomerId,
                    opt => opt.MapFrom(src => src.SearchCustomerId))
                .ForMember(dest =>
                    dest.Status,
                    opt => opt.MapFrom(src => src.AvailableAppointmentStatuses))
             .ForMember(dest =>
                    dest.VaccineName,
                    opt => opt.MapFrom(src => src.SearchVaccineName))
             .ForMember(dest =>
                    dest.VaccineId,
                    opt => opt.MapFrom(src => src.SearchVaccineId));
        }
        public int Order => 1;
    }
}
