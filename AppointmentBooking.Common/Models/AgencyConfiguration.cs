using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Common.Models
{
    public class AgencyConfiguration
    {
        public int Id { get; set; }
        public int MaxAppointmentPerDay { get; set; }
        public List<DateTime> PublicHolidays { get; set; } = [];
    }
}
