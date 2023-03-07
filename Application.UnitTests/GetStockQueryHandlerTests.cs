using Application.Queries.GetAllStockQuery;
using Application.Queries.GetStockQuery;
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
    public class GetStockQueryHandlerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [AutoMoqData, Test]
        public async Task WhenCallingGetStockQuery_ReturnsNotFound(List<StockEntity> stocks, [Frozen] Mock<IStockContext> stockContext, GetStockQueryHandler handler)
        {
            // Arrange
            stockContext.Setup(s => s.Stocks).Returns(stocks.AsQueryable());

            // Act
            var results = await handler.Handle(new GetStockQuery("NWG"), new CancellationToken());

            // Assert
            results.Stock.Should().BeNull();
        }

        [AutoMoqData, Test]
        public async Task WhenCallingGetStockQuery_ReturnsIndividualStock(List<StockEntity> stocks, [Frozen] Mock<IStockContext> stockContext, GetStockQueryHandler handler)
        {
            // Arrange
            var natWestStock = new StockEntity("NWG", 1.23m);
            stocks.Add(natWestStock);
            stockContext.Setup(s => s.Stocks).Returns(stocks.AsQueryable());

            // Act
            var results = await handler.Handle(new GetStockQuery("NWG"), new CancellationToken());

            // Assert
            results.Stock.Should().BeEquivalentTo(natWestStock);
        }
    }
}