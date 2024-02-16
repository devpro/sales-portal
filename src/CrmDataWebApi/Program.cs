// creates the builder
var builder = WebApplication.CreateBuilder(args);
var configuration = new ApplicationConfiguration(builder.Configuration);

// add services to the container
builder.Services.AddInfrastructure(configuration.MongoDbConfiguration);
builder.Services.AddMapping();
builder.Services.AddDefaultServices(configuration, builder.Logging);

// create the application and configures the HTTP request pipeline
var app = builder.Build();
app.AddDefaultMiddlewares(configuration);

// runs the application
app.Run();

// adds explicit class definition for integration test project
public partial class Program { }
