using AutoMapper;
using Devpro.Common.MongoDb;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Devpro.SalesPortal.CrmDataWebApi.Repositories
{
    public abstract class CrudRepositoryBase<T, U> : MongoDbRepositoryBase, ICrudRepository<T, U>
        where U : IMongoDbEntity
    {
        protected IMapper Mapper { get; }

        protected CrudRepositoryBase(IMongoClientFactory mongoClientFactory, ILogger logger, MongoDbConfiguration configuration, IMapper mapper)
            : base(mongoClientFactory, logger, configuration)
        {
            Mapper = mapper;
        }

        public async Task<T> FindOneAsync(string id)
        {
            var objectId = ParseObjectId(id);
            var collection = GetCollection<U>();
            var dbEntries = await collection.FindAsync(x => x.Id == objectId);
            return Mapper.Map<T>(dbEntries.FirstOrDefault());
        }

        public async Task<List<T>> FindAllAsync()
        {
            var collection = GetCollection<U>();
            var dbEntries = await collection.FindAsync(new BsonDocument());
            return Mapper.Map<List<T>>(dbEntries.ToList());
        }

        public async Task<T> CreateAsync(T input)
        {
            var collection = GetCollection<U>();
            var entity = Mapper.Map<U>(input);
            await collection.InsertOneAsync(entity);
            return Mapper.Map<T>(entity);
        }

        public async Task<long> UpdateAsync(string id, T input)
        {
            var objectId = ParseObjectId(id);
            var collection = GetCollection<U>();
            var entity = Mapper.Map<U>(input);
            var result = await collection.ReplaceOneAsync(x => x.Id == objectId, entity);
            return result.ModifiedCount;
        }

        public async Task<long> DeleteAsync(string id)
        {
            var objectId = ParseObjectId(id);
            var collection = GetCollection<U>();
            var result = await collection.DeleteOneAsync(x => x.Id == objectId);
            return result.DeletedCount;
        }

        protected static ObjectId ParseObjectId(string id, string message = "")
        {
            if (string.IsNullOrEmpty(id) || !ObjectId.TryParse(id, out var objectId))
            {
                throw new ArgumentException($"{message}{id} is not a valid id.", nameof(id));
            }

            return objectId;
        }
    }
}
