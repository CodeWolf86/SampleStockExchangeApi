using Application.Queries.GetAllStockQuery;
using AutoFixture.NUnit3;
using Data.Entities;
using Data.Interfaces;
using FluentAssertions;
using Moq;
using TestExtensions;

namespace Application.UnitTests
{
    /// <summary>
    /// More tests required overall but gives a sample
    /// </summary>
    public class GetAllStockQueryHandlerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [AutoMoqData, Test]
        public async Task WhenCallingGetAllStockQuery_ReturnsAllStock(List<StockEntity> stocks, [Frozen] Mock<IStockContext> stockContext, GetAllStockQueryHandler handler)
        {
            // Arrange
            stockContext.Setup(s => s.Stocks).Returns(stocks);

            // Act
            var results = await handler.Handle(new GetAllStockQuery(), new CancellationToken());

            // Assert
            results.Stocks.Should().HaveCount(3);
            results.Stocks.Should().BeEquivalentTo(stocks);
        }
    }
}