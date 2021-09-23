using EAppointment.Entites;
using Grand.Core.Mapper;
using Grand.Plugin.Misc.AppointmentBooking.DTOs;
using Grand.Plugin.Misc.AppointmentBooking.Models;
using Grand.Plugin.Misc.AppointmentManager.DTO;

namespace Grand.Plugin.Misc.AppointmentManager
{
    public static class Extensions
    {
        public static CustomerBookedAppointmentsDto ToModel(this EAppointmentBooking entity)
        {
            return entity.MapTo<EAppointmentBooking, CustomerBookedAppointmentsDto>();
        }

        public static EAppointmentBooking ToEntity(this CustomerBookedAppointmentsDto model)
        {
            return model.MapTo<CustomerBookedAppointmentsDto, EAppointmentBooking>();
        }

        public static BookAppointmentDto ToBaseModel(this EAppointmentBooking entity)
        {
            return entity.MapTo<EAppointmentBooking, BookAppointmentDto>();
        }

        public static EAppointmentBooking ToEntityFromBaseModel(this BookAppointmentDto model)
        {
            return model.MapTo<BookAppointmentDto, EAppointmentBooking>();
        }

        public static CustomerBookedAppointmentsDto FromBaseModelToListModel(this BookAppointmentDto basemodel)
        {
            return basemodel.MapTo<BookAppointmentDto, CustomerBookedAppointmentsDto>();
        }
        public static BookAppointmentDto FromListModelToBaseModel(this CustomerBookedAppointmentsDto model)
        {
            return model.MapTo<CustomerBookedAppointmentsDto, BookAppointmentDto>();
        }

    }
}
