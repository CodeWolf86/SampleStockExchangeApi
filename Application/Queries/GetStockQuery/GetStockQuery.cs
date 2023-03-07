using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetStockQuery
{
    public class GetStockQuery : IRequest<GetStockResult>
    {
        public string TickerSymbol { get; set; }

        public GetStockQuery(string tickerSymbol)        {
            TickerSymbol = tickerSymbol;
        }

    }
}
