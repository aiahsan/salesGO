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

        public CustomerRepository(ICustomerContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<bool> AddOutlet(Setup_Outlet outlet)
        {
            try
            {
                var filter = Builders<Setup_Customer>.Filter.Eq(
                    c => c.customerId,
                    outlet.customerId
                );
                var update = Builders<Setup_Customer>.Update.Push(c => c.Outlets, outlet);

                var updateResult = await _DbSet.UpdateOneAsync(filter, update);

                return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        } 
        public async Task<bool> UpdateOutlet(Setup_Outlet updatedOutlet)
        {
            try
            {
                var filter = Builders<Setup_Customer>.Filter.And(
                    Builders<Setup_Customer>.Filter.Eq(c => c.customerId, updatedOutlet.customerId),
                    Builders<Setup_Customer>.Filter.ElemMatch(
                        c => c.Outlets,
                        o => o.outletId == updatedOutlet.outletId
                    )
                );
                var update = Builders<Setup_Customer>.Update
                    .Set("Outlets.$.outletLat", updatedOutlet.outletLat)
                    .Set("Outlets.$.outletLong", updatedOutlet.outletLong)
                    .Set("Outlets.$.outletAddress", updatedOutlet.outletAddress)
                    .Set("Outlets.$.outletImage", updatedOutlet.outletImage)
                    .Set("Outlets.$.outletContact", updatedOutlet.outletContact)
                    .Set("Outlets.$.outletName", updatedOutlet.outletName);
                var updateResult = await _DbSet.UpdateOneAsync(filter, update);

                return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
