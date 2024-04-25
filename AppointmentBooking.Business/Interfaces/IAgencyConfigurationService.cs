using AppointmentBooking.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Business.Interfaces
{
    public interface IAgencyConfigurationService
    {
        Task<AgencyConfiguration> GetCurrentConfiguration();
        Task AddConfiguration(AgencyConfiguration agencyConfiguration);
        Task UpdateConfiguration(int configurationI, AgencyConfiguration configuration);
    }
}
