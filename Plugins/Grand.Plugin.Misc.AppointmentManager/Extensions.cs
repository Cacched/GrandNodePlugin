using EAppointment.Entites;
using Grand.Core.Mapper;
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

    }
}
