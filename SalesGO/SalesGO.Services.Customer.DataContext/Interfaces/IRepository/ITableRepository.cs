using SalesGO.Services.Customer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Customer.DataContext.Interfaces.IRepository
{
    public interface ICustomer : IRepository<Setup_Customer>
    {
        Task<IEnumerable<Setup_Customer>> GetDataByBusinessId(string id);
        Task<bool> AddOutlet(Setup_Outlet outlet);
        Task<bool> UpdateOutlet(Setup_Outlet updatedOutlet);


    }
}
