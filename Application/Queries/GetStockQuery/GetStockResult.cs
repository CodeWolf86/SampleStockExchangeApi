using Domain.Models;

namespace Application.Queries.GetStockQuery
{
    public class GetStockResult
    {
        public Stock? Stock { get; set; }

        public GetStockResult(Stock? stock)
        {
            Stock = stock;
        }

    }
}
