using AppointmentBooking.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentBooking.Data.Interfaces
{
    public interface IAgencyConfigurationRepository
    {
        /// <summary>
        /// get agency configuration data
        /// return default value if data is null
        /// default value is set for 20 appointment allowed perday
        /// and public holiday 5 days later from today
        /// </summary>
        /// <returns></returns>
        Task<AgencyConfiguration> GetCurrentConfiguration();

        /// <summary>
        /// update existing configuration 
        /// get data by id
        /// </summary>
        /// <param name="configurationId"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        Task UpdateConfiguration(int configurationId, AgencyConfiguration configuration);

        /// <summary>
        /// added new configuration maximum allowed appointment perday
        /// and define public holidays if needed
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        Task AddConfiguration(AgencyConfiguration configuration);
    }
}
