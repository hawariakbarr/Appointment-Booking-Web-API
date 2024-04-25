using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Common.DTOs
{
    public class AgencyConfigurationRequest
    {
        public int MaxAppointmentPerDay { get; set; }
        public List<DateTime> PublicHolidays { get; set; } = [];
    }
}
