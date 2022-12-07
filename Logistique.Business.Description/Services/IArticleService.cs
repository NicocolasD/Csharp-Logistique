using Logistique.Business.BusinessModel;

namespace Logistique.Business.Description.Services;

public interface IArticleService
{
    Task<Article> GetArticleById(int id);
    Task<List<Article>> GetAll();
    Task AddArticle(Article newArticle);
    Task UpdateArticle(int id, Article updatedArticle);
    Task RemoveArticleById(int id);
}