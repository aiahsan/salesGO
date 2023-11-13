using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Customer.DataContext.Interfaces.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> filter = null);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter); 
        Task<bool> InsertAsync(T product); 
        Task<bool> UpdateAsync(T product, Expression<Func<T, bool>> filter);
  

    }
}
