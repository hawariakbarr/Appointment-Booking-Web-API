using Moq;
using Xunit;
using AppointmentBooking.Business.Interfaces;
using AppointmentBooking.Business.Services;
using AppointmentBooking.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppointmentBooking.Data.Interfaces;

public class AppointmentServiceTests
{
    private readonly Mock<IAppointmentRepository> _mockAppointmentRepo;
    private readonly Mock<IAgencyConfigurationService> _mockConfigService;
    private readonly AppointmentService _appointmentService;

    public AppointmentServiceTests()
    {
        _mockAppointmentRepo = new Mock<IAppointmentRepository>();
        _mockConfigService = new Mock<IAgencyConfigurationService>();
        _appointmentService = new AppointmentService(_mockAppointmentRepo.Object, _mockConfigService.Object);
    }

    [Fact]
    public async Task BookAppointment_BooksAppointmentOnNextAvailableDate()
    {
        // Arrange
        var testAppointment = new Appointment { Date = DateTime.Today, CustomerName = "John Doe" };
        var config = new AgencyConfiguration { MaxAppointmentPerDay = 1, PublicHolidays = new List<DateTime>() };

        _mockConfigService.Setup(x => x.GetCurrentConfiguration()).ReturnsAsync(config);
        _mockAppointmentRepo.Setup(x => x.GetAppointmentCountByDate(It.IsAny<DateTime>())).ReturnsAsync(0);

        // Act
        var bookedAppointment = await _appointmentService.BookAppointment(testAppointment);

        // Assert
        Assert.Equal(DateTime.Today, bookedAppointment.Date);
        Assert.Contains("token_", bookedAppointment.Token);
        _mockAppointmentRepo.Verify(x => x.AddAppointment(It.IsAny<Appointment>()), Times.Once);
    }

    [Fact]
    public async Task GetAppointmentByDate_ReturnsAppointmentsOnSpecificDate()
    {
        // Arrange
        var testDate = DateTime.Today;
        var expectedAppointments = new List<Appointment>
        {
            new Appointment { Date = testDate, CustomerName = "John Doe" }
        };

        _mockAppointmentRepo.Setup(x => x.GetAppointmentByDate(testDate))
            .ReturnsAsync(expectedAppointments);

        // Act
        var appointments = await _appointmentService.GetAppointmentByDate(testDate);
        var firstAppointment = appointments.FirstOrDefault();  // Using FirstOrDefault to access the first element

        // Assert
        Assert.NotNull(appointments);
        Assert.NotNull(firstAppointment);  // Ensure there is at least one appointment
        Assert.Equal("John Doe", firstAppointment.CustomerName);
    }
}
