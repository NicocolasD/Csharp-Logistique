using Logistique.Data.Description.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Logistique.Data.Context;
public class LogistiqueDbContext : DbContext
{
    public LogistiqueDbContext(DbContextOptions options)
    : base(options)
    {
    }

    public DbSet<ArticleEntity> Articles { get; set; }
    public DbSet<StockEntity> Stocks { get; set; }
    public DbSet<ReceptionEntity> Receptions {get;set;}
    public DbSet<LigneReceptionEntity> LigneReceptions {get;set;}
}