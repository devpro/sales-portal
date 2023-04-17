using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Devpro.SalesPortal.CrmDataWebApi.Entities
{
    public class Opportunity : IMongoDbEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
