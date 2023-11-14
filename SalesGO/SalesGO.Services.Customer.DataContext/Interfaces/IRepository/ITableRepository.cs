using MongoDB.Driver.Linq;
using SalesGO.Services.Customer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Customer.DataContext.Interfaces.IRepository
{
    public interface ICustomerRepo : IRepository<Setup_Customer>
    {



        

    }

    public interface IOutletRepo : IRepository<Setup_Outlet>
    {

        Task<List<Setup_Outlet>> GetOutletsbyBusinessId(string businessId);
        Task<List<Setup_Outlet>> GetOutletByRadius(double centerLat, double centerLong, double radiusMiles);
        Task<List<Setup_Outlet>> GetOutletByRadiusByCustomer(double centerLat, double centerLong, double radiusMiles,int customerId);

    }
}
