namespace Logistique.Web.Api.Controllers;

using Logistique.Business.BusinessModel;
using Logistique.Business.Description.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class DeliveryController : ControllerBase
{
    private readonly ILogger<DeliveryController> _logger;
    private readonly IDeliveryService _service;
    public DeliveryController(ILogger<DeliveryController> logger, IDeliveryService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("GetReceptions")]
    public async Task<ActionResult<List<Delivery>>> GetAllDelivery()
    {
        var deliveries = await _service.GetAll();
        if (deliveries.Any())
            return Ok(deliveries);
        else
            return NotFound("Aucune réception n'a été trouvé.");
    }

    [HttpGet("GetById/{id}")]
    public async Task<ActionResult<Delivery>> GetDeliveryById(int id)
    {
        var delivery = await _service.GetDeliveryById(id);
        if (delivery != null)
            return Ok(delivery);
        else 
            return NotFound($"Aucune réception port l'id {id} n'a été trouvée.");
    }

    [HttpPost("AddDelivery")]
    public async Task<ActionResult<Delivery>> AddDelivery(Delivery newDelivery)
    {
        try
        {
            await _service.AddDelivery(newDelivery);
            return Ok(newDelivery);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, $"Erreur interne : {ex.Message}");
        }
    }

    [HttpPatch("UpdateDelivery/{id}")]
    public async Task<ActionResult<Delivery>> UpdateDelivery(int id, [FromBody] Delivery updatedDelivery)
    {
        try
        {
            await _service.UpdateDelivery(id, updatedDelivery);
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

    [HttpDelete("RemoveDeliveryById/{id}")]
    public async Task<ActionResult<List<Delivery>>> RemoveDeliveryById(int id)
    {
        try
        {
            await _service.RemoveDeliveryById(id);
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