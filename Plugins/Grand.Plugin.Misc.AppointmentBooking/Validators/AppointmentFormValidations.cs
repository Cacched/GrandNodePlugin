using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Grand.Plugin.Misc.AppointmentBooking.Validators
{
    public class AppointmentFormValidations
    {
        public class CustomAppointmentDate : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime dateTime = Convert.ToDateTime(value);
                return dateTime >= DateTime.Now;
            }
        }
    }
}
