namespace LondonStockApi.DTO
{
    public class StockExchangeDto : StockDto
    {
        public long NumberOfShares { get; set; }
        public Guid BrokerId { get; set; }
    }
}
