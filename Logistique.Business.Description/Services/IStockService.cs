using Logistique.Business.BusinessModel;

namespace Logistique.Business.Description.Services;

public interface IStockService
{
    Task<Stock> GetStockByArticleId(int articleId);
    Task<List<Stock>> GetAll();
    Task AddStock(Stock newStock);
    Task UpdateStock(int id, Stock updatedStock);
    Task RemoveStockById(int id);
    Task RemoveStockByArticleId(int articleId);
}