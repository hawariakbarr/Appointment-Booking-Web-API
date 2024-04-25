using AppointmentBooking.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Data.Interfaces
{
    public interface IAppointmentRepository
    {
        /// <summary>
        /// add new booking appointment data
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        Task AddAppointment(Appointment appointment);

        /// <summary>
        /// get list of appointment by date 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<IEnumerable<Appointment>> GetAppointmentByDate(DateTime date);

        /// <summary>
        /// get total count of appointments by input date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        Task<int> GetAppointmentCountByDate(DateTime date);
    }
}
