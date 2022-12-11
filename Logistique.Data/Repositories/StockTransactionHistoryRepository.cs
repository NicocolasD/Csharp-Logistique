using Logistique.Data.Context;
using Logistique.Data.Description.Models.Entities;
using Logistique.Data.Description.Repositories;
using Microsoft.EntityFrameworkCore; 

namespace Logistique.Data.Repositories;

public class StockTransactionHistoryRepository : IStockTransactionHistoryRepository
{
    private readonly LogistiqueDbContext _context;
    public StockTransactionHistoryRepository(LogistiqueDbContext context)
    {
        _context = context;
    }
    public async Task AddTransaction(StockTransactionHistoryEntity newTransaction)
    {
        await _context.StockTransactionsHistory.AddAsync(newTransaction);
        _context.SaveChanges();
        return;
    }

    public async Task<StockTransactionHistoryEntity> GetById(int id)
    {
        return await _context.StockTransactionsHistory.Include(t=>t.Part).FirstOrDefaultAsync(t=>t.Id == id);
    }

    public async Task<List<StockTransactionHistoryEntity>> GetAll()
    {
        return await _context.StockTransactionsHistory.Include(t=>t.Part).ToListAsync();
    }
}