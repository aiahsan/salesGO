using SalesGO.Services.Customer.DataContext.Interfaces.IContext;
using SalesGO.Services.Customer.DataContext.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Customer.DataContext.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ICustomerContext _context;

        public UnitOfWork(ICustomerContext context)
        {
            this._context = context;
            Customer = new CustomerRepository(context);

        }
        public ICustomer Customer { get; private set; }
    }
}
