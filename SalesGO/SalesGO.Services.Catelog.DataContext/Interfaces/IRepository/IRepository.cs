 using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Catelog.Interfaces.IRepository
{
    

    public interface IRepository<T> where  T:class  
    {
        
       
        Task<int> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
         Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> BatchFiltersync(Expression<Func<T, bool>> filter = null, int pageNumber = 1, int pageSize = 10);

    }
}
