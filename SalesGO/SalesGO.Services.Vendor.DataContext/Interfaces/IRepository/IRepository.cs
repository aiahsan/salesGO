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
        Task Create(T product);
        Task<bool> Update(T product);
        Task<bool> Delete(string id);

     }
}
