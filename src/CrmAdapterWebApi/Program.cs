﻿// creates the builder
var builder = WebApplication.CreateBuilder(args);
var configuration = new ApplicationConfiguration(builder.Configuration);

// add services to the container
builder.Services.AddInfrastructure(configuration);
builder.Services.AddCors(configuration.CorsPolicyName, configuration.CorsAllowedOrigin);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

// create the application and configures the HTTP request pipeline
var app = builder.Build();
app.UseDeveloperExceptionPage(app.Environment);
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors(configuration.CorsPolicyName);
app.MapControllers().RequireCors(configuration.CorsPolicyName);
app.MapHealthChecks(configuration.HealthCheckEndpoint);

// runs the application
app.Run();
