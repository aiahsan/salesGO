using SalesGO.Services.Customer.DataContext.DataContext;
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
        private CustomerContext _context;

        public UnitOfWork(CustomerContext context)
        {
            this._context = context;
            _CustoemrRepo = new CustomerRepository(context);
            _OutletRepo = new OutletRepository(context);

        }
        public ICustomerRepo _CustoemrRepo { get; private set; }

        public IOutletRepo _OutletRepo { get; private set; }

    }
}
