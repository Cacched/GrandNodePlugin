﻿using Grand.Core.Routing;
using Microsoft.AspNetCore.Routing;

namespace Grand.Plugin.Misc.AppointmentBooking
{
    class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(IEndpointRouteBuilder routeBuilder)
        {

            //var pattern = "";
            //RegisterAPIRoute(routeBuilder, pattern);
        }
        //private void RegisterAPIRoute(IEndpointRouteBuilder routeBuilder, string pattern)
        //{
        //    routeBuilder.MapControllerRoute("Plugin.Misc.AppointmentBooking.BookAppointment",
        //      $"{pattern}/book-appointment",
        //      new { controller = "AppointmentBooking", action = "BookAppointment" });
        //}

        public int Priority {
            get {
                return 10;
            }
        }
    }
}
