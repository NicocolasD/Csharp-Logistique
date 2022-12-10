using System.Text;
using Logistique.Business.Description.Services;
using Logistique.Business.Services;
using Logistique.Data.Context;
using Logistique.Data.Description.Repositories;
using Logistique.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//EntityFramework
builder.Services.AddDbContextPool<LogistiqueDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("LogistiqueConnection")));

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//Services
builder.Services.AddScoped<IPartService, PartService>();
builder.Services.AddScoped<IPartRepository, PartRepository>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
builder.Services.AddScoped<IStockTransactionHistoryService, StockTransactionHistoryService>();
builder.Services.AddScoped<IStockTransactionHistoryRepository, StockTransactionHistoryRepository>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => 
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = "https://localhost.7091",
        ValidAudience = "https://localhost:7091",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MaSuperSecretKey69@680"))
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseCors("EnableCORS");

app.MapControllers();

app.Run();
