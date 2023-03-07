using Application.Queries.GetAllStockQuery;
using Application.Queries.GetStockQuery;
using Application.Queries.GetStockRangeQuery;
using LondonStockApi.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LondonStockApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private IMediator _mediator { get; }
        private readonly ILogger<StockController> Logger;

        public StockController(IMediator mediator, ILogger<StockController> logger)
        {
            Logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetStockValues")]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllStockQuery());

            if (!response.Stocks.Any())
            {
                return NotFound();
            }

            var stockDtos = response.Stocks.Select(s => new StockDto { Price = s.Price, TickerSymbol = s.TickerSymbol }).ToList();
            return Ok(stockDtos);
        }

        [HttpGet("{tickerSymbol}", Name ="GetStockValue")]
        public async Task<IActionResult> GetByTickerSymbol(string tickerSymbol)
        {
            var response = await _mediator.Send(new GetStockQuery(tickerSymbol));
            if (response.Stock == null)
            {
                return NotFound();
            }

            return Ok(new StockDto { Price = response.Stock.Price, TickerSymbol = response.Stock.TickerSymbol });
        }

        [HttpPost(Name = "GetRangeOfStockValue")]
        public async Task<IActionResult> GetRangeOfStocks(IEnumerable<string> stocks)
        {
            var response = await _mediator.Send(new GetStockRangeQuery(stocks));
            if (!response.Stocks.Any())
            {
                return NotFound();
            }

            var stockDtos = response.Stocks.Select(s => new StockDto { Price = s.Price, TickerSymbol = s.TickerSymbol }).ToList();
            return Ok(stockDtos);
        }

    }
}