using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using SalesGO.Services.Customer.DataContext.DataContext;
using SalesGO.Services.Customer.DataContext.Interfaces.IRepository;
using SalesGO.Services.Customer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SalesGO.Services.Customer.DataContext.Repository
{
    public class CustomerRepository : Repository<Setup_Customer>, ICustomerRepo
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
            : base(context)
        {
            _context = context;
        }
         
    }

    public class OutletRepository : Repository<Setup_Outlet>, IOutletRepo
    {
        private readonly CustomerContext _context;

        public OutletRepository(CustomerContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<Setup_Outlet>> GetOutletsbyBusinessId(string businessId)
        {

          return await _context.Setup_Outlet.Include(x => x.Customer).Where(x => x.Customer.businessId == businessId).ToListAsync();

         }

    }
}
