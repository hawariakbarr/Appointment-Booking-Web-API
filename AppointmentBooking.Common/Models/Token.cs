using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Common.Models
{
    public class Token
    {
        public int AppointmentId { get; set; }
        public DateTime Issued { get; set; }
    }
}
