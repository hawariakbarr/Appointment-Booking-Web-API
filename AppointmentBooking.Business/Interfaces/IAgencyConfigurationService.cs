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
        /// <summary>
        /// get latest configuration data order by date descending
        /// </summary>
        /// <returns></returns>
        Task<AgencyConfiguration> GetCurrentConfiguration();

        /// <summary>
        /// add new configuration including maxDays allower perday and
        /// array of public holidays
        /// </summary>
        /// <param name="agencyConfiguration"></param>
        /// <returns></returns>
        Task AddConfiguration(AgencyConfiguration agencyConfiguration);

        /// <summary>
        /// updatin existing configuration including maxDays allower perday and
        /// array of public holidays
        /// </summary>
        /// <param name="configurationI"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        Task UpdateConfiguration(int configurationId, AgencyConfiguration configuration);
    }
}
