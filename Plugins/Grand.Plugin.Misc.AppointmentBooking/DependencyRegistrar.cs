using EAppointment.Services;
using Grand.Core.Configuration;
using Grand.Core.DependencyInjection;
using Grand.Core.TypeFinders;
using Grand.Plugin.Misc.AppointmentBooking.Queries.Models;
using Grand.Plugin.Misc.AppointmentManager.ViewModelServices;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Grand.Plugin.Misc.AppointmentBooking
{
    public class DependencyInjection : IDependencyInjection
    {
        public virtual void Register(IServiceCollection serviceCollection, ITypeFinder typeFinder, GrandConfig config)
        {
            serviceCollection.AddScoped<AppointmentBookingPlugin>();
            serviceCollection.AddMediatR(typeof(AppointmentServices).Assembly);
            serviceCollection.AddScoped<IAppointmentsDtoService, AppointmentsDtoService>();
        }

        public int Order {
            get { return 10; }
        }
    }

}
