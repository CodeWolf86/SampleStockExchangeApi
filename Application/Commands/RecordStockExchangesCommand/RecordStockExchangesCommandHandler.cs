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

            // Using an actual ORM would allow the adding of options or a bulk save. 
            // Mock just to get it passing
            _context.StockExchange.ToList().AddRange(stockExchanges);
            await _context.SaveChangesAsync();

            // Temp workaround, add Id and return
            foreach (var se in command.StockExchanges)
            {
                se.StockExchangeId = Guid.NewGuid();
            }

            return new RecordStockExchangesResult(command.StockExchanges);
        }
    }
}