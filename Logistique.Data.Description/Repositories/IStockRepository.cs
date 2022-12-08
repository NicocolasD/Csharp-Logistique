using Logistique.Data.Description.Models.Entities;

namespace Logistique.Data.Description.Repositories;

public interface IStockRepository
{
    Task<StockEntity> GetStockByArticleId(int articleId);
    Task<List<StockEntity>> GetAll();
    Task AddStock(StockEntity newStock);
    Task UpdateStock(int id, StockEntity updatedStock);
    Task RemoveStockById(int id);
    Task RemoveStockByArticleId(int articleId);
}