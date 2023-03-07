using Domain.Models;

namespace Application.Commands.RecordStockExchangesCommand
{
    public class RecordStockExchangesResult
    {
        public IEnumerable<StockExchange> StockExchanges;

        public RecordStockExchangesResult(IEnumerable<StockExchange> stockExchanges)
        {
            StockExchanges = stockExchanges;
        }
    }
}
