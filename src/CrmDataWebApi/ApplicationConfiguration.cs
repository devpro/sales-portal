﻿namespace Devpro.SalesPortal.CrmDataWebApi
{
    public class ApplicationConfiguration : WebApiConfiguration
    {
        public ApplicationConfiguration(IConfigurationRoot configurationRoot)
            : base(configurationRoot)
        {
        }
        public MongoDbConfiguration MongoDbConfiguration =>
            new()
            {
                ConnectionString = ConfigurationRoot.GetConnectionString(TryGetSection("MongoDb:ConnectionStringName")?.Get<string>() ?? string.Empty) ?? string.Empty,
                DatabaseName = TryGetSection("MongoDb:DatabaseName").Get<string>() ?? string.Empty
            };
    }
}
