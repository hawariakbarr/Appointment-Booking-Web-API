using AppointmentBooking.Common.Models;
using AppointmentBooking.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Data.Repositories
{
    public class AgencyConfigurationRepository : IAgencyConfigurationRepository
    {
        private readonly AppDbContext _context;

        public AgencyConfigurationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AgencyConfiguration> GetCurrentConfiguration()
        {
            var latestConfiguration = await _context.Configuration
                                                    .OrderByDescending(c => c.CreatedDate)
                                                    .FirstOrDefaultAsync();

            return latestConfiguration ?? new AgencyConfiguration
            {
                MaxAppointmentPerDay = 20,
                PublicHolidays = new List<DateTime> { DateTime.Now.AddDays(5), DateTime.Now.AddDays(7) },
                CreatedDate = DateTime.UtcNow
            };
        }

        public async Task UpdateConfiguration(int configurationId, AgencyConfiguration configuration)
        {
            var config = await _context.Configuration.FirstOrDefaultAsync(x => x.Id == configurationId);
            if (config != null)
            {
                config.MaxAppointmentPerDay = configuration.MaxAppointmentPerDay;
                config.PublicHolidays = configuration.PublicHolidays;
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddConfiguration(AgencyConfiguration configuration)
        {
            _context.Configuration.Add(configuration);
            await _context.SaveChangesAsync();
        }
    }
}
