using Grand.Core.Plugins;
using Grand.Framework.Menu;
using Grand.Services.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Grand.Plugin.Misc.AppointmentManager
{
    public class AppointmentManagerPlugin : BasePlugin, IMiscPlugin, IAdminMenuPlugin
    {
        #region Methods
        public override async Task Install()
        {
            await base.Install();
        }

        public async Task ManageSiteMap(SiteMapNode rootNode)
        {
            var pluginNode = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "Misc.AppointmentManagement");
            if (pluginNode == null)
            {
                rootNode.ChildNodes.Add(new SiteMapNode() {
                    SystemName = "Misc.AppointmentManagement",
                    ResourceName = "Appointment Manager",
                    Visible = true,
                    IconClass = "icon-puzzle",

                });

                pluginNode = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "Misc.AppointmentManagement");
            }
            var Menu = new SiteMapNode();
            Menu.Visible = true;
            Menu.ResourceName = "Manage Apointments";
            Menu.SystemName = "ConfigureAppointments";
            Menu.ControllerName = "ManageCustomerAppointments";
            Menu.ActionName = "ViewCustomerAppointments";
            if (pluginNode != null)
                pluginNode.ChildNodes.Add(Menu);
            else
                rootNode.ChildNodes.Add(Menu);

            await Task.CompletedTask;
        }
        public override async Task Uninstall()
        {
            await base.Uninstall();
        }
        #endregion
    }


}

