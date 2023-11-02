using MongoDB.Driver;
using MongoDB.Bson;
using SalesGO.Services.Vendor.DataContext.Interfaces.IContext;
using SalesGO.Services.Vendor.DataContext.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SalesGO.Services.Vendor.DataContext.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly IVendorContext _context;

        internal IMongoCollection<T> _DbSet;

        public Repository(IVendorContext CC)
        {
            _context = CC;
            this._DbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var filter = Builders<T>.Filter.Eq("IsActive", true);
            var data = await _DbSet.FindAsync(filter);
            return data.ToList();
        }

        public async Task<T> GetDataById(string id)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<T>.Filter.Eq("_id", objectId);
            var data = await _DbSet.FindAsync(filter);

            return await data.FirstOrDefaultAsync();
        }

        public async Task<bool> Create(T data)
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

        public async Task<bool> Delete(FilterDefinition<T> filter)
        {
            var result = await _DbSet.DeleteOneAsync(filter).ConfigureAwait(false);

            return result.DeletedCount > 0;
        }

        public async Task<bool> Update(T data, FilterDefinition<T> filter)
        {
            if (data != null)
            {
                var updateDefinitionBuilder = Builders<T>.Update;
                var updateDefinition = updateDefinitionBuilder.Combine();

                foreach (var property in typeof(T).GetProperties())
                {
                    // Exclude properties with null values
                    var value = property.GetValue(data);
                    if (value != null && !string.IsNullOrEmpty(value.ToString()))
                    {
                        updateDefinition = updateDefinition.Set(property.Name, value);
                    }
                }

                var result = await _DbSet.UpdateOneAsync(filter, updateDefinition).ConfigureAwait(false);
                return result.ModifiedCount > 0;
            }

            return false;
        }

    }
}
