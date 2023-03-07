using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.GetAllStockQuery
{
    public class GetAllStockResult
    {
        public IEnumerable<Stock> Stocks { get; set; }

        public GetAllStockResult(IEnumerable<Stock> stocks)
        {
            Stocks = stocks;
        }

    }
}
