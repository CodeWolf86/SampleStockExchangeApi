namespace LondonStockApi.DTO
{
    public class StockDto
    {
        public string TickerSymbol { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
