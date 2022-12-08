using Logistique.Business.Description.Services;
using Logistique.BusinessServices;
using Logistique.Data.Context;
using Logistique.Data.Description.Repositories;
using Logistique.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//EntityFramework
builder.Services.AddDbContextPool<LogistiqueDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("LogistiqueConnection")));

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

//Services
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IStockRepository, StockRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
