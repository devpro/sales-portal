var builder = WebApplication.CreateBuilder(args);
var configuration = new ApplicationConfiguration(builder.Configuration);

builder.Services.AddInfrastructure(configuration.MongoDbConfiguration);
builder.Services.AddMapping();
builder.Services.AddDefaultServices(configuration, builder.Logging);

var app = builder.Build();
app.AddDefaultMiddlewares(configuration);

app.Run();

// adds explicit class definition for integration test project
public partial class Program { }
