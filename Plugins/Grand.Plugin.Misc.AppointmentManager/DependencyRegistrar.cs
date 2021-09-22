using Grand.Core.Configuration;
using Grand.Core.DependencyInjection;
using Grand.Core.TypeFinders;
using Grand.Plugin.Misc.AppointmentManager;
using Grand.Plugin.Misc.AppointmentManager.ViewModelServices;
using Microsoft.Extensions.DependencyInjection;

namespace Grand.Plugin.Misc.AppointmentBooking
{
    public class DependencyInjection : IDependencyInjection
    {
        public virtual void Register(IServiceCollection serviceCollection, ITypeFinder typeFinder, GrandConfig config)
        {
            serviceCollection.AddScoped<AppointmentManagerPlugin>();
            serviceCollection.AddScoped<ICustomerAppointmentsDtoService, CustomerAppointmentsDtoService>();
        }

        public int Order {
            get { return 10; }
        }
    }

}
