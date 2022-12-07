namespace Logistique.Web.Api.Controllers;

using Logistique.Business.BusinessModel;
using Logistique.Business.Description.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class ArticleController : ControllerBase
{
    private readonly IArticleService _service;
    private readonly ILogger<ArticleController> _logger;

    public ArticleController(ILogger<ArticleController> logger, IArticleService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("GetArticles")]
    public async Task<ActionResult<List<Article>>> Get()
    {
        var articles = await _service.GetAll();
        if (articles.Any())
            return Ok(articles);
        else 
            return NotFound("Aucun article n'a été trouvé.");
    }

    [HttpGet("GetById/{id}")]
    public async Task<ActionResult<Article>> GetById(int id)
    {
        var article = await _service.GetArticleById(id);
        if (article != null)
            return Ok(article);
        else 
            return NotFound($"Aucun article avec l'id {id} n'a été trouvé.");
    }

    [HttpPost("AddArticle")]
    public async Task<ActionResult<Article>> AddArticle([FromBody] Article newArticle)
    {
        try
        {
            await _service.AddArticle(newArticle);
            return Ok(newArticle);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, $"Erreur interne : {ex.Message}");
        }
    }

    [HttpPatch("UpdateArticle/{id}")]
    public async  Task<ActionResult<Article>> UpdateArticle(int id, [FromBody] Article updatedArticle)
    {
        try
        {
            await _service.UpdateArticle(id, updatedArticle);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, $"Erreur interne : {ex.Message}");
        }
    }

    [HttpDelete("RemoveArticleById")]
    public async Task<ActionResult<List<Article>>> RemoveArticleById(int id)
    {
        try
        {
            await _service.RemoveArticleById(id);
            return Ok();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, $"Erreur interne : {ex.Message}");
        }
    }
}