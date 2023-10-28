using MongoDB.Driver;
using MongoDB.Bson;
using SalesGO.Services.Vendor.DataContext.Interfaces.IContext;
using SalesGO.Services.Vendor.DataContext.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesGO.Services.Vendor.DataContext.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IVendorContext _context;

        internal IMongoCollection<T> _DbSet;

        public Repository(IVendorContext CC)
        {
            _context = CC;
            this._DbSet = _context.Set<T>();

        }

        public async Task Create(T data)
        {
            await _DbSet.InsertOneAsync(data);
        }

        public async Task<bool> Delete(string id)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<T>.Filter.Eq("_id", objectId);

            var result = await _DbSet.DeleteOneAsync(filter).ConfigureAwait(false);

            return result.DeletedCount > 0;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var data = await _DbSet.FindAsync(x => true);
            return data.ToList();
        }

        public async Task<T> GetDataById(string id)
        {
            var objectId = ObjectId.Parse("id");
            var filter = Builders<T>.Filter.Eq("_id", objectId);
            var data = await _DbSet.FindAsync(filter).ConfigureAwait(false);

            return await data.FirstOrDefaultAsync().ConfigureAwait(false);


        }

        public async Task<bool> Update(T data)
        {
            var objectIdProperty = typeof(T).GetProperty("_id");
            if (objectIdProperty == null)
            {
                // Handle the case where the document doesn't have an "_id" property
                return false;
            }

            var objectIdValue = objectIdProperty.GetValue(data);

            if (objectIdValue == null)
            {
                // Handle the case where the "_id" property is not set
                return false;
            }

            var objectId = (ObjectId)objectIdValue;

            if (objectId == null)
            {
                // Handle the case where the "_id" property is not of type ObjectId
                return false;
            }

            var filter = Builders<T>.Filter.Eq("_id", objectId);
            var result = await _DbSet.ReplaceOneAsync(filter, data).ConfigureAwait(false);

            return result.ModifiedCount > 0;
        }
    }
}
