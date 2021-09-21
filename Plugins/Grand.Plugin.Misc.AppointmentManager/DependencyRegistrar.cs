using Grand.Core.Configuration;
using Grand.Core.DependencyInjection;
using Grand.Core.TypeFinders;
using Grand.Plugin.Misc.AppointmentManager;
using Microsoft.Extensions.DependencyInjection;

namespace Grand.Plugin.Misc.AppointmentBooking
{
    public class DependencyInjection : IDependencyInjection
    {
        public virtual void Register(IServiceCollection serviceCollection, ITypeFinder typeFinder, GrandConfig config)
        {
            serviceCollection.AddScoped<AppointmentManagerPlugin>();
        }

        public int Order {
            get { return 10; }
        }
    }

}
