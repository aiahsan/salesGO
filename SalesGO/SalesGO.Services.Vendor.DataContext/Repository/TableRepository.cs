using MongoDB.Bson;
using MongoDB.Driver;
using SalesGO.Services.Vendor.DataContext.Interfaces.IContext;
using SalesGO.Services.Vendor.DataContext.Interfaces.IRepository;
using SalesGO.Services.Vendor.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Vendor.DataContext.Repository
{
    public class VendorRepository : Repository<Setup_Vendor>, IVendor
    {
        private readonly IVendorContext _context;

        public VendorRepository(IVendorContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Setup_Vendor>> GetDataByBusinessId(string id)
        {

            var filter = Builders<Setup_Vendor>.Filter.Eq("businessId", id);
            var data = await _DbSet.FindAsync(filter);
            return data.ToList(); 

           
        }
    }

}
