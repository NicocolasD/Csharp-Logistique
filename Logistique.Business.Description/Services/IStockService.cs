using Logistique.Business.Description.BusinessModel;

namespace Logistique.Business.Description.Services;

public interface IStockService
{
    Task<Stock> GetStockByPartId(int articleId);
    Task<List<Stock>> GetAll();
    Task AddStock(Stock newStock);
    Task UpdateStock(int id, Stock updatedStock);
    Task RemoveStockById(int id);
    Task RemoveStockByPartId(int articleId);
    Task AddQuantityInStock(int articleId, int quantity);
}