namespace Domain.Models
{
    public class Stock
    {
        public string TickerSymbol { get; set; } = default!;
        public decimal Price { get; set; }

    }
}