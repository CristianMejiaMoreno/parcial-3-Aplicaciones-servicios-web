using parcial3.Data;
using Microsoft.EntityFrameworkCore;
using parcial3.Services;

var builder = WebApplication.CreateBuilder(args);

// Agrega el DbContext
builder.Services.AddDbContext<NatilleraDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<LoginService>();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
