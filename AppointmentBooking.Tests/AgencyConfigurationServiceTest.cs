using Moq;
using Xunit;
using AppointmentBooking.Business.Services;
using AppointmentBooking.Business.Interfaces;
using AppointmentBooking.Common.Models;
using System.Threading.Tasks;
using AppointmentBooking.Data.Interfaces;

public class AgencyConfigurationServiceTests
{
    private readonly Mock<IAgencyConfigurationRepository> _mockRepository;
    private readonly AgencyConfigurationService _configurationService;

    public AgencyConfigurationServiceTests()
    {
        _mockRepository = new Mock<IAgencyConfigurationRepository>();
        _configurationService = new AgencyConfigurationService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetCurrentConfiguration_ReturnsConfiguration_WhenExists()
    {
        // Arrange
        var expectedConfiguration = new AgencyConfiguration { MaxAppointmentPerDay = 20, PublicHolidays = [] };
        _mockRepository.Setup(repo => repo.GetCurrentConfiguration()).ReturnsAsync(expectedConfiguration);

        // Act
        var configuration = await _configurationService.GetCurrentConfiguration();

        // Assert
        Assert.Equal(expectedConfiguration, configuration);
    }

    [Fact]
    public async Task AddConfiguration_CallsRepositoryAdd_Once()
    {
        // Arrange
        var newConfiguration = new AgencyConfiguration { MaxAppointmentPerDay = 30 };

        // Act
        await _configurationService.AddConfiguration(newConfiguration);

        // Assert
        _mockRepository.Verify(repo => repo.AddConfiguration(newConfiguration), Times.Once);
    }

    [Fact]
    public async Task UpdateConfiguration_CallsRepositoryUpdate_Once()
    {
        // Arrange
        var updatedConfiguration = new AgencyConfiguration { MaxAppointmentPerDay = 25 };
        int configurationId = 1;

        // Act
        await _configurationService.UpdateConfiguration(configurationId, updatedConfiguration);

        // Assert
        _mockRepository.Verify(repo => repo.UpdateConfiguration(configurationId, updatedConfiguration), Times.Once);
    }
}
