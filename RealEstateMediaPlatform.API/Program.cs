using Microsoft.EntityFrameworkCore;
using RealEstateMediaPlatform.API.Data;
using RealEstateMediaPlatform.API.Configurations;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// MongoDb
var mongoSettings = builder.Configuration
    .GetSection("MongoDb")
    .Get<MongoDbSettings>();

builder.Services.AddSingleton<IMongoClient>(_ =>
    new MongoClient(mongoSettings.ConnectionString));

builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(mongoSettings.Database);
});
// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServer")
    ));
    
var app = builder.Build();

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "API is running");

app.Run();