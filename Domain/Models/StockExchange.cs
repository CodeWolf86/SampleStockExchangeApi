namespace Domain.Models
{
    public class StockExchange : Stock
    {
        public Guid StockExchangeId { get; set; }
        public long NumberOfShares { get; set; }
        public Guid BrokerId { get; set; }
    }
}