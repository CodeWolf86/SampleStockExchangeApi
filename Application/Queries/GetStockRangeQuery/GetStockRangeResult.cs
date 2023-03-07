using Domain.Models;

namespace Application.Queries.GetStockRangeQuery
{
    public class GetStockRangeResult
    {
        public IEnumerable<Stock> Stocks { get; set; }

        public GetStockRangeResult(IEnumerable<Stock> stocks)
        {
            Stocks = stocks;
        }

    }
}
