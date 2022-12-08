using Logistique.Business.BusinessModel;

namespace Logistique.Business.Description.Services;

public interface IStockService
{
    Task<Stock> GetStockByArticleId(int articleId);
    Task<List<Stock>> GetAll();
}