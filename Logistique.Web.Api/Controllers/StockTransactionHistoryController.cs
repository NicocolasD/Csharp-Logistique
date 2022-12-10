namespace Logistique.Web.Api.Controllers;

using Logistique.Business.Description.BusinessModel;
using Logistique.Business.Description.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
[Authorize]

public class StockTransactionHistoryController : ControllerBase
{
    private readonly ILogger<StockTransactionHistoryController> _logger;
    private readonly IStockTransactionHistoryService _service;
    public StockTransactionHistoryController(ILogger<StockTransactionHistoryController> logger, IStockTransactionHistoryService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("GetById/{id}")]
    public async Task<ActionResult<StockTransactionHistory>> GetById(int id)
    {
        var transaction = await _service.GetTransactionById(id);
        if (transaction != null)
            return Ok(transaction);
        else 
            return NotFound($"Aucuns transaction portant l'id {id} n'a été trouvée.");
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<StockTransactionHistory>>> GetAll()
    {
        var transactions = await _service.GetAll();
        if (transactions.Any())
            return Ok(transactions);
        else 
            return NotFound("Aucuns transaction n'a été trouvée.");
    }
}