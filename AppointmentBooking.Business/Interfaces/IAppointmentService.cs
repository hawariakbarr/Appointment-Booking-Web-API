using AppointmentBooking.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Business.Interfaces
{
    public interface IAppointmentService
    {
        Task<Appointment> BookAppointment(Appointment appointment);
        Task<IEnumerable<Appointment>> GetAppointmentByDate(DateTime date);
    }
}
