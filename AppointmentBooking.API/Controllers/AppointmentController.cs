using AppointmentBooking.Business.Interfaces;
using AppointmentBooking.Common.DTOs;
using AppointmentBooking.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _bookingService;

        public AppointmentController(IAppointmentService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookAppointment([FromBody] AppointmentBookingRequest request)
        {
            var appointment = new Appointment
            {
                Date = request.Date,
                CustomerName = request.CustomerName
            };

            var result = await _bookingService.BookAppointment(appointment);
            if (result == null)
                return BadRequest("Unable to book appointment.");

            return Ok(result);
        }

        [HttpGet("today-appointment")]
        public async Task<IActionResult> GetTodayAppointment([FromQuery] DateTime? date)
        {
            // Check if date is null, and if so, set it to today's date
            if (!date.HasValue)
                date = DateTime.Today;

            var appointments = await _bookingService.GetAppointmentByDate(date.Value);
            return Ok(appointments);
        }

    }
}
