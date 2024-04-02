var builder = WebApplication.CreateBuilder(args);

// Populate DI Container

var app = builder.Build();

// Configure HTTP request pipeline

app.Run();
