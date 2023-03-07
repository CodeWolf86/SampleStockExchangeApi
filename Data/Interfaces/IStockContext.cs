using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces
{
    /// <summary>
    /// This is a generic interface to mimic a given ORM implementation for this sample application
    /// It's presumed to be entity framework, but in the interest of brevity of development the back end
    /// data implementation is hardcoded
    /// 
    /// The assumption would be to use EntityFramework core as the ORM, but rather than code first 
    /// or database first, create a DACPAC project as a way to create the data store.
    /// 
    /// Any other ORM could be used and this abstraction facilitates the loose coupling.
    /// 
    /// </summary>
    public interface IStockContext
    {
        ICollection<StockEntity> Stocks { get; set; }
        ICollection<StockExchangeEntity> StockExchange { get; set; }
        Task<bool> SaveChangesAsync();
    }
}