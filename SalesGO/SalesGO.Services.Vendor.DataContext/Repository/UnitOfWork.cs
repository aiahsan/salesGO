using SalesGO.Services.Vendor.DataContext.Interfaces.IContext;
using SalesGO.Services.Vendor.DataContext.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Vendor.DataContext.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IVendorContext _context;

        public UnitOfWork(IVendorContext context)
        {
            this._context = context;
            Vendor = new VendorRepository(context);
            
        }
        public IVendor Vendor { get;private set; }
    }
}
