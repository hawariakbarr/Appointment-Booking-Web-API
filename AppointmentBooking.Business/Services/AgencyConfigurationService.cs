using AppointmentBooking.Business.Interfaces;
using AppointmentBooking.Common.Models;
using AppointmentBooking.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Business.Services
{
    public class AgencyConfigurationService : IAgencyConfigurationService
    {
        private readonly IAgencyConfigurationRepository _configurationRepository;

        public AgencyConfigurationService(IAgencyConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public async Task<AgencyConfiguration> GetCurrentConfiguration()
        {
            return await _configurationRepository.GetCurrentConfiguration();
        }

        public async Task AddConfiguration(AgencyConfiguration configuration)
        {
            await _configurationRepository.AddConfiguration(configuration);
        }

        public async Task UpdateConfiguration(int configurationId, AgencyConfiguration configuration)
        {
            await _configurationRepository.UpdateConfiguration(configurationId, configuration);
        }
    }
}
