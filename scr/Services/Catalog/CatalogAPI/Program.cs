using Microsoft.CodeAnalysis.Options;

using Microsoft.CodeAnalysis.Options;

var builder = WebApplication.CreateBuilder(args);

// Populate DI Container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();

// Configure HTTP request pipeline
app.MapCarter();

app.Run();
