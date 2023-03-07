using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetStockRangeQuery
{
    public class GetStockRangeQuery : IRequest<GetStockRangeResult>
    {
        public IEnumerable<string> TickerSymbols { get; set; }

        public GetStockRangeQuery(IEnumerable<string> tickerSymbols)        {
            TickerSymbols = tickerSymbols;
        }

    }
}
