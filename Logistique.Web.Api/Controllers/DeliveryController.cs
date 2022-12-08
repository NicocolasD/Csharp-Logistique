namespace Logistique.Web.Api.Controllers;

using Logistique.Business.BusinessModel;
using Logistique.Business.Description.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class DeliveryController : ControllerBase
{
    private readonly ILogger<DeliveryController> _logger;
    public DeliveryController(ILogger<DeliveryController> logger)
    {
        _logger = logger;
    }

    /*[HttpGet("GetReceptions")]
    public Task<List<Delivery>> GetAllDelivery()
    {

    }

    [HttpGet("GetByRecepNo")]
    public Task<Delivery> GetDeliveryById(int id)
    {

    }

    [HttpPost("AddDelivery")]
    public Task<Delivery> AddDelivery(Delivery newDelivery)
    {

    }

    [HttpPatch("UpdateDelivery")]
    public Task<Delivery> UpdateDelivery(Delivery updatedDelivery)
    {

    }*/
}