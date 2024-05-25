using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .RegisterInfrastructureServices(builder.Configuration)
    .RegisterApplicationServices()
    .RegisterApiServices();


// Populate DI Container
var app = builder.Build();

app.UseApiServices();


// Configure HTTP request pipeline

app.Run();
