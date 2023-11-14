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
using NetTopologySuite.Geometries; // Add this namespace

// Add this namespace
// other properties

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

        public async Task<List<Setup_Outlet>> GetOutletByRadius(double centerLat, double centerLong, double radiusMiles)
        {
            var centerPoint = new Point(centerLong, centerLat) { SRID = 4326 };

            // Create a circular buffer with the specified radius around the center point
            var buffer = centerPoint.Buffer(radiusMiles * 1609.34); // Convert miles to meters

            // Query outlets that intersect with the buffer (within the specified radius)
            var outletsWithinRadius = await _context.Setup_Outlet
                .Where(outlet => outlet.Location.Intersects(buffer))
                .ToListAsync();

            return outletsWithinRadius;


        }

        public async Task<List<Setup_Outlet>> GetOutletByRadiusByCustomer(double centerLat, double centerLong, double radiusMiles, int customerId)
        {

            var centerPoint = new Point(centerLong, centerLat) { SRID = 4326 };

            // Create a circular buffer with the specified radius around the center point
            var buffer = centerPoint.Buffer(radiusMiles * 1609.34); // Convert miles to meters

            // Query outlets that intersect with the buffer (within the specified radius)
            var outletsWithinRadius = await _context.Setup_Outlet
                .Where(outlet => outlet.Location.Intersects(buffer)&&outlet.customerId== customerId)
                .ToListAsync();

            return outletsWithinRadius;

        }
   

      
    }
}
