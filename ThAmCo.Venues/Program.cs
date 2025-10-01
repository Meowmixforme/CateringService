using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization; // Needed for ReferenceHandler
using ThAmCo.Venues.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Register Swagger services (missing in your current Venues setup!)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register database context with the framework
builder.Services.AddDbContext<VenuesDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
