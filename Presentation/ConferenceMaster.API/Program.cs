using ConferenceMaster.Application.Interfaces;
using ConferenceMaster.Application.Services;
using ConferenceMaster.Infrastructure.Sentinel;
using ConferenceMaster.Persistence.Context;
using ConferenceMaster.Persistence.Repositories;
using ConfereneceMaster.Application.Interfaces;

using Microsoft.EntityFrameworkCore;
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

// 1. DbContext Kaydý
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Servislerimizin Kaydý (Dependency Injection)
// Bunlarý eklemezsek "Sentinel" ve "SeatService" çalýþmaz
builder.Services.AddScoped<ISentinelService, SentinelService>();
builder.Services.AddScoped<ISeatService, SeatService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Eðer Generic Repository ve UnitOfWork arayüzlerini oluþturduysan onlarý da buraya ekleyeceðiz
// builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
