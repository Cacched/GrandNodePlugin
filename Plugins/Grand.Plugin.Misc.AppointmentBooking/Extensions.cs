using EAppointment.Entites;
using Grand.Core.Mapper;
using Grand.Plugin.Misc.AppointmentBooking.Models;

namespace Grand.Plugin.Misc.AppointmentBooking
{
    public static class Extensions
    {
        public static BookAppointmentDto ToModel(this EAppointmentBooking entity)
        {
            return entity.MapTo<EAppointmentBooking, BookAppointmentDto>();
        }

        public static EAppointmentBooking ToEntity(this BookAppointmentDto model)
        {
            return model.MapTo<BookAppointmentDto, EAppointmentBooking>();
        }

    }
}
