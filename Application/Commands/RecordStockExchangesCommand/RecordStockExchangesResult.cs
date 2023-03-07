using Domain.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Commands.RecordStockExchangesCommand
{
    public class RecordStockExchangesResult
    {
        public IEnumerable<StockExchange> StockExchanges;

        public RecordStockExchangesResult(IEnumerable<StockExchange> stockExchanges)
        {
            // Temp workaround, add Id to simulate saving to database.
            if(stockExchanges == null || !stockExchanges.Any())
            {
                StockExchanges = new List<StockExchange>();
            }
            else
            {
                var sList = stockExchanges.ToList();
                foreach (var se in sList)
                {
                    se.StockExchangeId = Guid.NewGuid();
                }

                StockExchanges = sList;
            }
        }
    }
}
