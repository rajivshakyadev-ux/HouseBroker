using HouseBroker.Application.DTOs;
using HouseBroker.Application.Interfaces;
using HouseBroker.Application.Services;
using HouseBroker.Domain.Entities;
using Moq;
using Xunit; // Ensure you have this for [Fact]

namespace HouseBroker.Tests.Services
{
    public class ListingServiceTests
    {
        private readonly Mock<IPropertyListingRepository> _repoMock;
        private readonly Mock<ICommissionService> _commMock;
        private readonly Mock<IAppDbContext> _contextMock; 
        private readonly PropertyListingService _service;

        public ListingServiceTests()
        {
            _repoMock = new Mock<IPropertyListingRepository>();
            _commMock = new Mock<ICommissionService>();
            _contextMock = new Mock<IAppDbContext>(); 

            _service = new PropertyListingService(
                _contextMock.Object,
                _repoMock.Object,
                _commMock.Object
            );
        }

        [Fact]
        public async Task CreateListing_ShouldAssignCommissionBeforeSaving()
        {
            // Arrange
            var userId = "test-user-id";
            var dto = new CreatePropertyListingDto
            {
                Title = "Luxury Villa",
                Price = 6000000,
                Description = "A beautiful home",
                Location = "Suburbs",
                PropertyListingType = "Sale"
            };

            // Mock the commission service logic
            _commMock.Setup(s => s.CalculateAsync(dto.Price)).ReturnsAsync(105000);

            // FIX: Repository now takes 1 argument (the Entity), not 2 (DTO + string)
            _repoMock.Setup(r => r.AddAsync(It.IsAny<PropertyListing>()))
                     .ReturnsAsync((PropertyListing p) => p); // Returns the entity it received

            // Act
            // FIX: The service method was renamed to CreateAsync
            var result = await _service.CreateAsync(dto, userId);

            // Assert
            Assert.Equal(105000, result.CommissionAmount);
            Assert.Equal(userId, result.BrokerId); // Verify the ID was mapped correctly

            // FIX: Verify the new signature
            _repoMock.Verify(r => r.AddAsync(It.IsAny<PropertyListing>()), Times.Once);
        }
    }
}