
using Microsoft.EntityFrameworkCore;
using SalesGO.Services.Catelog.DataContext.DataContext;
using SalesGO.Services.Catelog.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SalesGO.Services.Catelog.Repository
{
    public class Repository<T> : IRepository<T> where T : class
       
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<T>();
        }
         
        public async Task<int> InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            var data= _context.SaveChanges();
            return data;
        }

        public async Task<bool> UpdateAsync(T entity)
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
      
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

    }
}
