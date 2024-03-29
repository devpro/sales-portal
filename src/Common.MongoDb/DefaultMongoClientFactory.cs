﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MongoDB.Driver.Core.Extensions.DiagnosticSources;

namespace Devpro.Common.MongoDb
{
    public class DefaultMongoClientFactory : IMongoClientFactory
    {
        public DefaultMongoClientFactory()
        {
            RegisterConventions();
        }

        public virtual MongoClient CreateClient(string connectionString)
        {
            var clientSettings = MongoClientSettings.FromConnectionString(connectionString);
            clientSettings.ClusterConfigurator = cb => cb.Subscribe(new DiagnosticsActivityEventSubscriber());
            return new MongoClient(clientSettings);
        }

        /// <summary>
        /// Register usual conventions.
        /// </summary>
        /// <remarks>
        /// See https://github.com/mongodb/mongo-csharp-driver/tree/master/src/MongoDB.Bson/Serialization/Conventions
        /// </remarks>
        protected virtual void RegisterConventions()
        {
            var pack = new ConventionPack
            {
                new CamelCaseElementNameConvention(),
                new EnumRepresentationConvention(BsonType.String),
                new IgnoreExtraElementsConvention(true),
                new IgnoreIfNullConvention(true)
            };
            ConventionRegistry.Register("Conventions", pack, t => true);
        }
    }
}
