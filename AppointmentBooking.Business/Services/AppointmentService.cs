using AppointmentBooking.Business.Interfaces;
using AppointmentBooking.Common.Models;
using AppointmentBooking.Data.Interfaces;
using static AppointmentBooking.Common.Utilities.TokenUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Business.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IAgencyConfigurationService _configurationService;

        public AppointmentService(IAppointmentRepository appointmentRepository, IAgencyConfigurationService configurationService)
        {
            _appointmentRepository = appointmentRepository;
            _configurationService = configurationService;
        }

        public async Task<Appointment> BookAppointment(Appointment appointment)
        {
            var config = await _configurationService.GetCurrentConfiguration();
            var nextAvailableDate = FindNextAvailableDate(appointment.Date, config);

            appointment.Date = nextAvailableDate;
            appointment.Token = GenerateToken(appointment.CustomerName);
            await _appointmentRepository.AddAppointment(appointment);

            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentByDate(DateTime date)
        {
            return await _appointmentRepository.GetAppointmentByDate(date);
        }
        private DateTime FindNextAvailableDate(DateTime startDate, AgencyConfiguration config)
        {
            var date = startDate;
            while (config.PublicHolidays.Contains(date) || _appointmentRepository.GetAppointmentCountByDate(date).Result >= config.MaxAppointmentPerDay)
            {
                date = date.AddDays(1);
            }
            return date;
        }


    }
}
