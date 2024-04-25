using AppointmentBooking.Business.Interfaces;
using AppointmentBooking.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Business.Services
{
    public class AgenyConfigurationService : IAgencyConfigurationService
    {
        private readonly IAgencyConfigurationService _configurationRepository;

        public AgenyConfigurationService(IAgencyConfigurationService configurationRepository)
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
