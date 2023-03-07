using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class StockContext : DbContext, IStockContext
    {
        public IQueryable<StockEntity> Stocks
        {
            get
            {
                return new List<StockEntity>()
                    {
                            new StockEntity("NWG",291.30m),
                            new StockEntity("HSBA",624.30m),
                            new StockEntity("BARC",171.50m),
                            new StockEntity("NBS", 129.50m),
                            new StockEntity("VMUK",174.55m)
                    }.AsQueryable();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IQueryable<StockExchangeEntity> StockExchange
        {
            get
            {
                return new List<StockExchangeEntity>() {
                    new StockExchangeEntity()
                    {
                        BrokerId = Guid.NewGuid(), NumberOfShares= 100, Price= 1.72m, TickerSymbol = "BARC"
                    },
                    new StockExchangeEntity()
                    {
                        BrokerId = Guid.NewGuid(), NumberOfShares= 5000, Price= 4.72m, TickerSymbol = "HSBA"
                    },
                    new StockExchangeEntity()
                    {
                        BrokerId = Guid.NewGuid(), NumberOfShares= 9000, Price= 1.11m, TickerSymbol = "VMUK"
                    }
                }.AsQueryable();
            }
            set
            {
                //Do nothing, just take the save
            }

        }

        public async Task<bool> SaveChangesAsync()
        {
            // Dummy implementation for EF
            return await Task.FromResult(true);
        }
    }
}
