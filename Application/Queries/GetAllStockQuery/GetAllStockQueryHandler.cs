using Data.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.GetAllStockQuery
{
    public class GetAllStockQueryHandler : IRequestHandler<GetAllStockQuery, GetAllStockResult>
    {
        private IStockContext _context;
        public GetAllStockQueryHandler(IStockContext context) 
        {
            _context = context;
        }

        public async Task<GetAllStockResult> Handle(GetAllStockQuery request, CancellationToken cancellationToken)
        {
            var stocksResult = _context.Stocks.Select(s => new Stock
            {
                Price = s.Price,
                TickerSymbol = s.TickerSymbol
            }).ToList();

            return new GetAllStockResult(stocksResult);
        }
    }
}