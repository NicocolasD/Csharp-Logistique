using Logistique.Data.Description.Models.Entities;

namespace Logistique.Data.Description.Repositories;

public interface IStockTransactionHistoryRepository
{
    Task AddTransaction(StockTransactionHistoryEntity newTransaction);
    Task<StockTransactionHistoryEntity> GetById(int id);
    Task<List<StockTransactionHistoryEntity>> GetAll();
}