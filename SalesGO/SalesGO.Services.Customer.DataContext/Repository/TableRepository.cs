using MongoDB.Driver;
using SalesGO.Services.Customer.DataContext.Interfaces.IContext;
using SalesGO.Services.Customer.DataContext.Interfaces.IRepository;
using SalesGO.Services.Customer.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Customer.DataContext.Repository
{
    public class CustomerRepository : Repository<Setup_Customer>, ICustomer
    {
        private readonly ICustomerContext _context;

        public CustomerRepository(ICustomerContext context) : base(context)
        {
            _context = context;
        }

    }
}
