using HouseBroker.Application.Interfaces;
using HouseBroker.Application.Services;
using HouseBroker.Domain.Entities;
using Moq;

namespace HouseBroker.Tests.Services
{
    public class CommissionServiceTests
    {
        private readonly Mock<ICommissionRepository> _repoMock;
        private readonly ICommissionService _service;

        public CommissionServiceTests()
        {
            _repoMock = new Mock<ICommissionRepository>();
            SetupMockRates();
            _service = new CommissionService(_repoMock.Object);
        }

        private void SetupMockRates()
        {
            _repoMock.Setup(r => r.GetRateByPriceAsync(It.IsAny<decimal>()))
                     .ReturnsAsync((decimal price) =>
                     {
                         if (price < 5_000_000)
                             return price * 0.02m;

                         if (price <= 10_000_000)
                             return price * 0.0175m;

                         return price * 0.015m;
                     });
        }

        [Theory]
        [InlineData(4_000_000, 80_000)]     // < 50 Lakh → 2%
        [InlineData(7_500_000, 131_250)]    // 50 Lakh – 1 Crore → 1.75%
        [InlineData(15_000_000, 225_000)]   // > 1 Crore → 1.5%
        public async Task CalculateCommission_ShouldReturnCorrectAmount(decimal price, decimal expected)
        {
            var result = await _service.CalculateAsync(price);
            Assert.Equal(expected, result);
        }
    }
}
