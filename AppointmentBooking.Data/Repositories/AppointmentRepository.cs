using AppointmentBooking.Common.Models;
using AppointmentBooking.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAppointment(Appointment appointment)
        {
            _context.Appointment.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentByDate(DateTime date)
        {
            return await _context.Appointment.Where(a => a.Date.Date == date.Date).ToListAsync();
        }

        public async Task<int> GetAppointmentCountByDate(DateTime date)
        {
            return await _context.Appointment.CountAsync(a => a.Date.Date == date.Date);
        }
    }
}
