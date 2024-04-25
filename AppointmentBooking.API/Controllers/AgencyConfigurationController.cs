using AppointmentBooking.Business.Interfaces;
using AppointmentBooking.Common.DTOs;
using AppointmentBooking.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyConfigurationController : ControllerBase
    {
        private readonly IAgencyConfigurationService _configurationService;

        public AgencyConfigurationController(IAgencyConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetConfiguration()
        {
            var config = await _configurationService.GetCurrentConfiguration();
            return Ok(config);
        }

        [HttpPost("add-agency-configuration")]
        public async Task<IActionResult> AddAgencyConfiguration([FromBody] AgencyConfigurationRequest request)
        {
            var configuration = new AgencyConfiguration()
            {
                MaxAppointmentPerDay = request.MaxAppointmentPerDay,
                PublicHolidays = request.PublicHolidays,
                CreatedDate = DateTime.UtcNow
            };
            await _configurationService.AddConfiguration(configuration);
            return Ok("Configuration added successfully.");
        }

        [HttpPut("update-agency-configuration")]
        public async Task<IActionResult> UpdateConfiguration([FromQuery] int id, [FromBody] AgencyConfigurationRequest request)
        {
            var configuration = new AgencyConfiguration()
            {
                MaxAppointmentPerDay = request.MaxAppointmentPerDay,
                PublicHolidays = request.PublicHolidays,
                CreatedDate = DateTime.UtcNow
            };
            await _configurationService.UpdateConfiguration(id, configuration);
            return Ok("Configuration updated successfully.");
        }
    }
}
