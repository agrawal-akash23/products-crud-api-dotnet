using ProductsAPI.Middleware;
using ProductsAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// -- Phase 1: Register services to the DI container. ----

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Tell the DI container: "When anyone asks for IProductService,
// give them a ProductService. One instance per HTTP request."
builder.Services.AddScoped<IProductService, ProductService>();

// -- Phase 2: Build the app and configure the HTTP request pipeline ----

var app = builder.Build();

// 1. Exception handler FIRST
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 2. Logging middleware (custom) - runs on every request
app.UseMiddleware<ExceptionMiddleware>();

// 3. Built-in middleware
app.UseHttpsRedirection();
app.UseAuthorization();

// 4. Endpoint mapping (LAST)
app.MapControllers();

app.Run();

