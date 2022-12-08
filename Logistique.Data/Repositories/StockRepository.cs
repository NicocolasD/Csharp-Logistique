using Logistique.Data.Context;
using Logistique.Data.Description.Models.Entities;
using Logistique.Data.Description.Repositories;
using Microsoft.EntityFrameworkCore; 

namespace Logistique.Data.Repositories;

public class StockRepository : IStockRepository
{
    private LogistiqueDbContext _context;

    public StockRepository(LogistiqueDbContext context)
    {
        this._context = context;
    }
    
    public async Task<StockEntity> GetStockByArticleId(int articleId)
    {
        return await _context.Stocks.Include(s=>s.Article).FirstOrDefaultAsync(s=>s.ArticleId == articleId);
    }

    public async Task<List<StockEntity>> GetAll()
    {
        return await _context.Stocks.Include(s => s.Article).ToListAsync();
    }
}