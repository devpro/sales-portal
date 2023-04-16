using MongoDB.Bson;

namespace Devpro.Common.MongoDb
{
    public interface IMongoDbEntity
    {
        ObjectId Id { get; set; }
    }
}
