using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Vendor.DataContext.Interfaces.IRepository
{
    

    public interface IRepository<T> where  T:class  
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetDataById(string id);
        Task<bool> Create(T product);
        Task<bool> Update(T product, FilterDefinition<T> filter);
        Task<bool> Delete(FilterDefinition<T> filter);

     }
}
