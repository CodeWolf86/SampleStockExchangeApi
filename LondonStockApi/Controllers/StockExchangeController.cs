using Application.Commands.RecordStockExchangesCommand;
using Application.Queries.GetAllStockQuery;
using Application.Queries.GetStockQuery;
using Application.Queries.GetStockRangeQuery;
using Domain.Models;
using LondonStockApi.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LondonStockApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockExchangeController : ControllerBase
    {
        private IMediator _mediator { get; }
        private readonly ILogger<StockExchangeController> Logger;

        public StockExchangeController(IMediator mediator, ILogger<StockExchangeController> logger)
        {
            Logger = logger;
            _mediator = mediator;
        }

        [HttpPost(Name = "RecordStockExchanges")]
        public async Task<IActionResult> GetRangeOfStocks(IEnumerable<StockExchangeDto> stocks)
        {
            IEnumerable<StockExchange> stockExchanges = new List<StockExchange>();
            if(stocks != null &&  stocks.Any())
            {
                stockExchanges = stocks.Select(s => new StockExchange
                {
                    BrokerId = s.BrokerId,
                    NumberOfShares = s.NumberOfShares,
                    Price = s.Price,
                    TickerSymbol = s.TickerSymbol
                });
            }

            var response = await _mediator.Send(new RecordStockExchangesCommand(stockExchanges));
            return Ok(response.StockExchanges.Select(s => new { s.StockExchangeId, s.TickerSymbol, s.BrokerId }));
        }

    }
}