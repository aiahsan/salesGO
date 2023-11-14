using MongoDB.Bson;
using MongoDB.Driver;
using SalesGO.Services.Customer.DataContext.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Const;
using Microsoft.EntityFrameworkCore;
using SalesGO.Services.Customer.DataContext.DataContext;
using SharpCompress.Common;

namespace SalesGO.Services.Customer.DataContext.Repository
{
    public class Repository<T> : IRepository<T> where T : class
      
    {
        private readonly CustomerContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(CustomerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<T>();
        }


        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> filter = null)
        {

            return await _dbSet.Where(filter).ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.FirstOrDefaultAsync(filter);
        }

        public async Task<bool> InsertAsync(T data)
        {
            try
            {
                await _dbSet.AddAsync(data);
                var _data = _context.SaveChanges();
                if (_data > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(T entity, Expression<Func<T, bool>> filter = null)
        {
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                // SaveChangesAsync returns the number of entities written to the database,
                // so if it's greater than 0, the update was successful.
                return await _context.SaveChangesAsync() > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency conflicts if needed
                return false;


            }
        }

        public async Task<IEnumerable<T>> BatchFiltersync(Expression<Func<T, bool>> filter = null, int pageNumber = 1, int pageSize = 10)
        {
 

            var query = filter != null ? _dbSet.Where(filter) : _dbSet.AsQueryable();


            // Calculate the number of documents to skip based on the page number and page size
            int skip = (pageNumber - 1) * pageSize;

            // Apply pagination
            query = query.Skip(skip).Take(pageSize);

            return await query.ToListAsync();
        }
    }
}
