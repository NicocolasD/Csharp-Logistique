using Logistique.Business.Description.BusinessModel;

namespace Logistique.Business.Description.Services;

public interface IStockTransactionHistoryService
{
    Task<StockTransactionHistory> GetTransactionById(int id);
    Task<List<StockTransactionHistory>> GetAll();
    Task AddTransaction(StockTransactionHistory newTransaction);
}