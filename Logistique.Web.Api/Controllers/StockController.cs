namespace Logistique.Web.Api.Controllers;

using Logistique.Business.Description.BusinessModel;
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

    [HttpGet("GetStokByPartId/{partId}")]
    public async Task<ActionResult<Stock>> GetStockByPartId(int partId)
    {
        var stock = await _service.GetStockByPartId(partId);
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