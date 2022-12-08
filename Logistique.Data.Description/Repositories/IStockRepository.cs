using Logistique.Data.Description.Models.Entities;

namespace Logistique.Data.Description.Repositories;

public interface IStockRepository
{
    Task<StockEntity> GetStockByArticleId(int articleId);
    Task<List<StockEntity>> GetAll();
}