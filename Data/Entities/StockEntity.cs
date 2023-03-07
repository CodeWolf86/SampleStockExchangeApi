namespace Data.Entities
{
    public class StockEntity
    {
        public string TickerSymbol { get; set; }
        public decimal Price { get; set; }
        
        public StockEntity(string tickerSymbol, decimal price)
        {
            TickerSymbol = tickerSymbol;
            Price = price;
        }
    }
}