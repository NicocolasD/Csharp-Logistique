namespace Logistique.Web.Api.Controllers;

using Logistique.Business.BusinessModel;
using Logistique.Business.Description.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class StockController : ControllerBase
{
    private readonly IStockService _service;
    private readonly ILogger<StockController> _logger;

    public StockController(ILogger<StockController> logger, IStockService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("GetStokByArticleId/{articleId}")]
    public async Task<ActionResult<Stock>> GetStockByArticleId(int articleId)
    {
        var stock = await _service.GetStockByArticleId(articleId);
        if (stock != null)
            return Ok(stock);
        else 
            return NotFound("Aucun stock n'a été trouvé.");
    }

    [HttpGet("GetStocks")]
    public async Task<ActionResult<Stock>> Get()
    {
        var stocks = await _service.GetAll();
        if (stocks.Any())
            return Ok(stocks);
        else
            return NotFound("Aucun stock n'a été trouvé.");
    }
}