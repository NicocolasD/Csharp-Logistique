using Logistique.Data.Description.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Logistique.Data.Context;
public class LogistiqueDbContext : DbContext
{
    public LogistiqueDbContext(DbContextOptions options)
    : base(options)
    {
    }

    public DbSet<PartEntity> Parts { get; set; }
    public DbSet<StockEntity> Stocks { get; set; }
    public DbSet<DeliveryEntity> Deliveries {get;set;}
    public DbSet<DeliveryLineEntity> DeliveryLines {get;set;}
    public DbSet<StockTransactionHistoryEntity> StockTransactionsHistory {get;set;}
}