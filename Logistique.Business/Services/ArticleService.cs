using AutoMapper;
using Logistique.Business.BusinessModel;
using Logistique.Business.Description.Services;
using Logistique.Data.Description.Models.Entities;
using Logistique.Data.Description.Repositories;
using Microsoft.Extensions.Logging;

namespace Logistique.BusinessServices;

public class ArticleService : IArticleService
{
    private readonly ILogger<ArticleService> _logger;
    private readonly IArticleRepository _repo;
    private readonly IMapper _mapper;

    public ArticleService(ILogger<ArticleService> logger, IArticleRepository repo, IMapper mapper)
    {
        _logger = logger;
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Article> GetArticleById(int id)
    {
        var articleEntity = await _repo.GetById(id);
        Article article = _mapper.Map<Article>(articleEntity);
        return article;
    }

    public async Task<List<Article>> GetAll()
    {
        var articleEntities = await _repo.GetAll();
        List<Article> articles = _mapper.Map<List<Article>>(articleEntities);
        return articles;
    }

    public async Task<int> AddArticle(Article newArticle)
    {
        var newArticleEntity = _mapper.Map<ArticleEntity>(newArticle);
        var newArticleId = await _repo.AddArticle(newArticleEntity);
        return newArticleId;
    }

    public async Task UpdateArticle(int id, Article updatedArticle)
    {
        var updatedArticleEntity = _mapper.Map<ArticleEntity>(updatedArticle);
        await _repo.UpdateArticle(id, updatedArticleEntity);
        return;
    }

    public async Task RemoveArticleById(int id)
    {
        await _repo.RemoveArticleById(id);
        return;
    }
}