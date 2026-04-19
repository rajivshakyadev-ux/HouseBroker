using HouseBroker.Application.DTOs;
using HouseBroker.Application.Interfaces;
using HouseBroker.Application.Services;
using HouseBroker.Domain.Entities;
using Moq;
using Xunit;

namespace HouseBroker.Tests.Services
{
    public class PropertyListingServiceTests
    {
        private readonly Mock<IPropertyListingRepository> _repoMock;
        private readonly Mock<ICommissionService> _commMock;
        private readonly Mock<IAppDbContext> _contextMock; 
        private readonly PropertyListingService _service;

        public PropertyListingServiceTests()
        {
            _repoMock = new Mock<IPropertyListingRepository>();
            _commMock = new Mock<ICommissionService>();
            _contextMock = new Mock<IAppDbContext>(); 

            _service = new PropertyListingService(
                _contextMock.Object,
                _repoMock.Object,
                _commMock.Object);
        }

        [Fact]
        public async Task CreateListing_ShouldAssignCommissionBeforeSaving()
        {
            var userId = "test-user-id";
            var dto = new CreatePropertyListingDto
            {
                Title = "Luxury Villa",
                Price = 6000000,
                Description = "A beautiful home",
                Location = "Suburbs",
                PropertyListingType = "Sale"
            };

            _commMock.Setup(s => s.CalculateAsync(dto.Price)).ReturnsAsync(105000);

            _repoMock.Setup(r => r.AddAsync(It.IsAny<PropertyListing>()))
                     .ReturnsAsync((PropertyListing p) => p); 
            var result = await _service.CreateAsync(dto, userId);

            Assert.Equal(105000, result.CommissionAmount);
            Assert.Equal(userId, result.BrokerId);

            _repoMock.Verify(r => r.AddAsync(It.IsAny<PropertyListing>()), Times.Once);
        }
    }
}