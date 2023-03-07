using Data.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.GetStockRangeQuery
{
    public class GetStockRangeQueryHandler : IRequestHandler<GetStockRangeQuery, GetStockRangeResult>
    {
        private IStockContext _context;
        public GetStockRangeQueryHandler(IStockContext context) 
        {
            _context = context;
        }

        public async Task<GetStockRangeResult> Handle(GetStockRangeQuery request, CancellationToken cancellationToken)
        {
            var stocksResult = _context.Stocks.Where(s => request.TickerSymbols.Contains(s.TickerSymbol)).Select(s => new Stock
            {
                Price = s.Price,
                TickerSymbol = s.TickerSymbol
            }).ToList();

            return new GetStockRangeResult(stocksResult);
        }
    }
}