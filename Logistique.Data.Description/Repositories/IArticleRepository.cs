using Logistique.Data.Description.Models.Entities;

namespace Logistique.Data.Description.Repositories;

public interface IArticleRepository
{
    Task<ArticleEntity> GetById(int id);
    Task<List<ArticleEntity>> GetAll();
    Task<int> AddArticle(ArticleEntity newArticle);
    Task UpdateArticle(int id, ArticleEntity updatedArticle);
    Task RemoveArticleById(int id);
}