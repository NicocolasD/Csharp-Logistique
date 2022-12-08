namespace Logistique.Web.Api.Controllers;

using Logistique.Business.BusinessModel;
using Logistique.Business.Description.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class PartController : ControllerBase
{
    private readonly IPartService _partService;
    private readonly IStockService _stockService;
    private readonly ILogger<PartController> _logger;

    public PartController(ILogger<PartController> logger, IPartService partService, IStockService stockService)
    {
        _logger = logger;
        _partService = partService;
        _stockService = stockService;
    }

    [HttpGet("GetParts")]
    public async Task<ActionResult<List<Part>>> Get()
    {
        var parts = await _partService.GetAll();
        if (parts.Any())
            return Ok(parts);
        else 
            return NotFound("Aucun article n'a été trouvé.");
    }

    [HttpGet("GetById/{id}")]
    public async Task<ActionResult<Part>> GetById(int id)
    {
        var part = await _partService.GetPartById(id);
        if (part != null)
            return Ok(part);
        else 
            return NotFound($"Aucun article avec l'id {id} n'a été trouvé.");
    }

    [HttpPost("AddPart")]
    public async Task<ActionResult<Part>> AddArticle([FromBody] Part newPart)
    {
        try
        {
            var partAddedId = await _partService.AddPart(newPart);
            await _stockService.AddStock(new Stock(){PartId = partAddedId});
            return Ok(newPart);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, $"Erreur interne : {ex.Message}");
        }
    }

    [HttpPatch("UpdatePart/{id}")]
    public async  Task<ActionResult<Part>> UpdatePart(int id, [FromBody] Part updatedPart)
    {
        try
        {
            await _partService.UpdatePart(id, updatedPart);
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

    [HttpDelete("RemovePartById")]
    public async Task<ActionResult<List<Part>>> RemovePartById(int id)
    {
        try
        {
            await _stockService.RemoveStockByPartId(id);
            await _partService.RemovePartById(id);
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