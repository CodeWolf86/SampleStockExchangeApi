using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.RecordStockExchangesCommand
{
    public class RecordStockExchangesCommand : IRequest<RecordStockExchangesResult>
    {
        public IEnumerable<StockExchange> StockExchanges { get; set; }
        public RecordStockExchangesCommand(IEnumerable<StockExchange> stockExchanges)
        {
            StockExchanges = stockExchanges;
        }
    }
}
