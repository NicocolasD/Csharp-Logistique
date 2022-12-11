namespace Logistique.Web.Api.Controllers;

using Logistique.Business.Description.BusinessModel;
using Logistique.Business.Description.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
[Authorize]

public class DeliveryController : ControllerBase
{
    private readonly ILogger<DeliveryController> _logger;
    private readonly IDeliveryService _deliveryService;
    private readonly IStockService _stockService;
    private readonly IStockTransactionHistoryService _stockTransactionHistoryService;
    public DeliveryController(ILogger<DeliveryController> logger, IDeliveryService deliveryService, 
        IStockService stockService, IStockTransactionHistoryService stockTransactionHistoryService)
    {
        _logger = logger;
        _deliveryService = deliveryService;
        _stockService = stockService;
        _stockTransactionHistoryService = stockTransactionHistoryService;
    }

    [HttpGet("GetReceptions")]
    public async Task<ActionResult<List<Delivery>>> GetAllDelivery()
    {
        var deliveries = await _deliveryService.GetAll();
        if (deliveries.Any())
            return Ok(deliveries);
        else
            return NotFound("Aucune réception n'a été trouvé.");
    }

    [HttpGet("GetById/{id}")]
    public async Task<ActionResult<Delivery>> GetDeliveryById(int id)
    {
        var delivery = await _deliveryService.GetDeliveryById(id);
        if (delivery != null)
            return Ok(delivery);
        else 
            return NotFound($"Aucune réception port l'id {id} n'a été trouvée.");
    }

    [HttpPost("AddDelivery")]
    public async Task<ActionResult<Delivery>> AddDelivery([FromBody]Delivery newDelivery)
    {
        try
        {
            // Ajout de la réception
            await _deliveryService.AddDelivery(newDelivery);            
            return Ok(newDelivery);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, $"Erreur interne : {ex.Message}");
        }
    }

    [HttpPost("ConfirmDelivery/{id}")]
    public async Task<ActionResult<Delivery>> ConfirmDelivery(int id)
    {
        try
        {
            // Ajout de la réception
            await _deliveryService.ConfirmDelivery(id);

            var confirmedDelivery = await _deliveryService.GetDeliveryById(id);

            //Ajout de la quantité reçue en stock
            foreach(var deliveryLine in confirmedDelivery.DeliveryLines)
            {
                await _stockService.AddOrRemoveQuantityInStock(deliveryLine.PartId, deliveryLine.Quantity);
                await _stockTransactionHistoryService.AddTransaction(new StockTransactionHistory(){Quantity = deliveryLine.Quantity, PartId = deliveryLine.PartId});
            }
            
            return Ok(confirmedDelivery);
        }
        catch (InvalidDataException ex)
        {
            return BadRequest(ex.Message);
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

    [HttpPatch("CancelDelivery/{id}")]
    public async Task<ActionResult> CancelDelivery(int id)
    {
        try
        {
            // Annulation de la réception
            await _deliveryService.CancelDelivery(id);

            // Suppression du stock pour les articles de la réception
            var cancelledDelivery = await _deliveryService.GetDeliveryById(id);
                foreach(var deliveryLine in cancelledDelivery.DeliveryLines)
                {
                    deliveryLine.Quantity *= -1;
                    await _stockService.AddOrRemoveQuantityInStock(deliveryLine.PartId, deliveryLine.Quantity);
                    await _stockTransactionHistoryService.AddTransaction(new StockTransactionHistory(){Quantity = deliveryLine.Quantity, PartId = deliveryLine.PartId});
                }
            return Ok();
        }
        catch (InvalidDataException ex)
        {
            return BadRequest(ex.Message);
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

    [HttpPatch("UpdateDelivery/{id}")]
    public async Task<ActionResult<Delivery>> UpdateDelivery(int id, [FromBody] Delivery updatedDelivery)
    {
        try
        {
            await _deliveryService.UpdateDelivery(id, updatedDelivery);
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
            await _deliveryService.RemoveDeliveryById(id);
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