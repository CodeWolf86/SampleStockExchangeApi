using Data.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.GetStockQuery
{
    public class GetStockQueryHandler : IRequestHandler<GetStockQuery, GetStockResult>
    {
        private IStockContext _context;
        public GetStockQueryHandler(IStockContext context) 
        {
            _context = context;
        }

        public async Task<GetStockResult> Handle(GetStockQuery request, CancellationToken cancellationToken)
        {
            var stockResult = _context.Stocks.FirstOrDefault(s => s.TickerSymbol.Equals(request.TickerSymbol, StringComparison.InvariantCultureIgnoreCase));
            Stock? stock = null;
            if (stockResult != null)
            {
                stock = new Stock { Price = stockResult.Price, TickerSymbol = stockResult.TickerSymbol };
            }
            return new GetStockResult(stock);
        }
    }
}