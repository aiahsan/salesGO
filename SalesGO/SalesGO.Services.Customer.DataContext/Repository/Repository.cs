using MongoDB.Bson;
using MongoDB.Driver;
using SalesGO.Services.Customer.DataContext.Interfaces.IContext;
using SalesGO.Services.Customer.DataContext.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Customer.DataContext.Repository
{
    public class Repository<T> : IRepository<T>
     where T : class
    {
        private readonly ICustomerContext _context;

        internal IMongoCollection<T> _DbSet;

        public Repository(ICustomerContext CC)
        {
            _context = CC;
            this._DbSet = _context.Set<T>();
        }


        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> filter = null)
        {

            if (filter != null)
            {
                return await _DbSet.Find(filter).ToListAsync();
            }
            else
            {
                return await _DbSet.Find(_ => true).ToListAsync();
            }
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            return await _DbSet.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<bool> InsertAsync(T data)
        {
            try
            {
                await _DbSet.InsertOneAsync(data);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
 
     

        public async Task<bool> UpdateAsync(T entity, Expression<Func<T, bool>> filter = null)
        {   
            // Replace the document based on the filter and get the acknowledgment
            ReplaceOneResult result =await _DbSet.ReplaceOneAsync(filter, entity);


            // You can now check the result for acknowledgment information
            if (result.IsAcknowledged)
            {
                return true;
            }
            else
            {
                // Update was not acknowledged
                return false;
            }

            
        }

    }
}
