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
    
    public async Task<StockEntity> GetStockByPartId(int articleId)
    {
        return await _context.Stocks.Include(s=>s.Part).FirstOrDefaultAsync(s=>s.PartId == articleId);
    }

    public async Task<List<StockEntity>> GetAll()
    {
        return await _context.Stocks.Include(s => s.Part).ToListAsync();
    }

    public async Task AddStock(StockEntity newStock)
    {
        await _context.Stocks.AddAsync(newStock);
        _context.SaveChanges();
        return;
    }

    public async Task UpdateStock(int id, StockEntity updatedStock)
    {
        var stockToUpdate = await _context.Stocks.FirstOrDefaultAsync(s=>s.Id == id);
        if (stockToUpdate != null)
        {
            stockToUpdate.Quantity = updatedStock.Quantity;
            stockToUpdate.LastModificationDate = DateTime.Now;
            stockToUpdate.LastModifiedBy = "ANONYMOUS";
            _context.Stocks.Update(stockToUpdate);
            _context.SaveChanges();
            return;
        } else {
            throw new KeyNotFoundException($"Aucun stock portant l'id {id} n'a été trouvé.");
        }
    }

    public async Task RemoveStockById(int id)
    {
        var stockToDelete = await _context.Stocks.FirstOrDefaultAsync(s=>s.Id == id);
        if (stockToDelete != null)
        {
            _context.Stocks.Remove(stockToDelete);
            await _context.SaveChangesAsync();
            return;
        } else {
            throw new KeyNotFoundException($"Aucun stock portant l'id {id} n'a été trouvé.");
        }
    }

    public async Task RemoveStockByArticleId(int articleId)
    {
        var stockToDelete = await _context.Stocks.FirstOrDefaultAsync(s=>s.PartId == articleId);
        if (stockToDelete != null)
        {
            _context.Stocks.Remove(stockToDelete);
            await _context.SaveChangesAsync();
            return;
        } else {
            throw new KeyNotFoundException($"Aucun stock portant l'articleId {articleId} n'a été trouvé.");
        }
    }
}