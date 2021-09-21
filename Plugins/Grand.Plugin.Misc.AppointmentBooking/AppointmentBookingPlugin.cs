using Grand.Core.Plugins;
using Grand.Services.Common;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.AppointmentBooking
{
    public class AppointmentBookingPlugin : BasePlugin, IMiscPlugin
    {
        #region Methods
        public override async Task Install()
        {
            await base.Install();
        }

        public override async Task Uninstall()
        {
            await base.Uninstall();
        }
        #endregion

    }
}
