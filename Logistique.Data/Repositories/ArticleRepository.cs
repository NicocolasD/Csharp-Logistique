using Logistique.Data.Context;
using Logistique.Data.Description.Models.Entities;
using Logistique.Data.Description.Repositories;
using Microsoft.EntityFrameworkCore; 

namespace Logistique.Data.Repositories;

public class ArticleRepository : IArticleRepository
{
    private LogistiqueDbContext _context;

    public ArticleRepository(LogistiqueDbContext context)
    {
        this._context = context;
    }

    public async Task<ArticleEntity> GetById(int id)
    {
        return await _context.Articles.FirstOrDefaultAsync(a=>a.Id == id);
    }

    public async Task<List<ArticleEntity>> GetAll()
    {
        return await _context.Articles.ToListAsync();
    }

    public async Task<int> AddArticle(ArticleEntity newArticle)
    {
        newArticle.CreatedBy = "ANONYMOUS";
        newArticle.LastModifiedBy = "ANONYMOUS";
        newArticle.CreationDate = DateTime.Now;
        newArticle.LastModificationDate = DateTime.Now;
        var value = await _context.Articles.AddAsync(newArticle);
        _context.SaveChanges();
        return value.Entity.Id;
    }

    public async Task UpdateArticle(int id, ArticleEntity updatedArticle)
    {
        var articleToUpdate = await _context.Articles.FirstOrDefaultAsync(a=>a.Id == id);
        if (articleToUpdate != null)
        {
            articleToUpdate.Description = updatedArticle.Description;
            articleToUpdate.Ean = updatedArticle.Ean;
            articleToUpdate.PartNo = updatedArticle.PartNo;
            articleToUpdate.LastModificationDate = DateTime.Now;
            articleToUpdate.LastModifiedBy = "ANONYMOUS";
            _context.Articles.Update(articleToUpdate);
            _context.SaveChanges();
            return;
        } else {
            throw new KeyNotFoundException($"Aucun article portant l'id {id} n'a été trouvé.");
        }
    }

    public async Task RemoveArticleById(int id)
    {
        var articleToDelete = await _context.Articles.FirstOrDefaultAsync(a=>a.Id == id);
        if (articleToDelete != null)
        {
            _context.Articles.Remove(articleToDelete);
            await _context.SaveChangesAsync();
            return;
        } else {
            throw new KeyNotFoundException($"Aucun article portant l'id {id} n'a été trouvé.");
        }
    }
}