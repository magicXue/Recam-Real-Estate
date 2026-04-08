using Microsoft.EntityFrameworkCore;
using RealEstateMediaPlatform.API.Data;
using RealEstateMediaPlatform.API.Configurations;
using MongoDB.Driver;
using RealEstateMediaPlatform.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// MongoDb
builder.Services.AddMongo(builder.Configuration);
// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServer")
    ));
builder.Services.AddScoped<ListingCaseHistoryRepository>();    
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