using Data.Entities;
using Data.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Commands.RecordStockExchangesCommand
{
    public class RecordStockExchangesCommandHandler : IRequestHandler<RecordStockExchangesCommand, RecordStockExchangesResult>
    {
        private IStockContext _context;
        public RecordStockExchangesCommandHandler(IStockContext context)
        {
            _context = context;
        }

        public async Task<RecordStockExchangesResult> Handle(RecordStockExchangesCommand command, CancellationToken cancellationToken)
        {
            var stockExchanges = command.StockExchanges.Select(s => new StockExchangeEntity
            {
                BrokerId = s.BrokerId,
                NumberOfShares = s.NumberOfShares,
                TickerSymbol = s.TickerSymbol,
                Price = s.Price,
            });

            foreach(var se in stockExchanges)
            {
                _context.StockExchange.Add(se);
            }
            await _context.SaveChangesAsync();

            return new RecordStockExchangesResult(command.StockExchanges);
        }
    }
}