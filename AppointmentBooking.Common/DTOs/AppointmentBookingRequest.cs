using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Common.DTOs
{
    public class AppointmentBookingRequest
    {
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
    }
}
