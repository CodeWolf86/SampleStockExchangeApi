using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class StockExchangeEntity
    {
        public string TickerSymbol { get; set; } = default!;
        public StockEntity Stock { get; set; } = default!;
        public decimal Price { get; set; }
        public long NumberOfShares { get; set; }
        public Guid BrokerId { get; set; }
        public BrokerEntity Broker { get; set; } = default!;
    }
}
