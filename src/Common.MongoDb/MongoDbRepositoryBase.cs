﻿using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Devpro.Common.MongoDb
{
    public abstract class MongoDbRepositoryBase
    {
        private readonly IMongoClientFactory _mongoClientFactory;

        private readonly ILogger _logger;

        private readonly MongoDbConfiguration _configuration;

        private readonly MongoClient _mongoClient;

        private readonly IMongoDatabase _mongoDatabase;

        protected MongoDbRepositoryBase(IMongoClientFactory mongoClientFactory, ILogger logger, MongoDbConfiguration configuration)
        {
            _mongoClientFactory = mongoClientFactory;
            _logger = logger;
            _configuration = configuration;

            _logger.LogDebug("Opening connection to MongoDB");
            _mongoClient = _mongoClientFactory.CreateClient(_configuration.ConnectionString);
            _logger.LogDebug("Getting database {DatabaseName}", _configuration.DatabaseName);
            _mongoDatabase = _mongoClient.GetDatabase(_configuration.DatabaseName);
        }

        protected abstract string CollectionName { get; }

        protected IMongoCollection<T> GetCollection<T>()
        {
            return _mongoDatabase.GetCollection<T>(CollectionName);
        }
    }
}
