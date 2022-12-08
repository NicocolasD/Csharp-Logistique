using AutoMapper;
using Logistique.Business.BusinessModel;
using Logistique.Business.Description.Services;
using Logistique.Data.Description.Models.Entities;
using Logistique.Data.Description.Repositories;
using Microsoft.Extensions.Logging;

namespace Logistique.BusinessServices;

public class DeliveryService : IDeliveryService
{
    private readonly ILogger<DeliveryService> _logger;
    private readonly IDeliveryRepository _repo;
    private readonly IMapper _mapper;
    public DeliveryService(ILogger<DeliveryService> logger, IDeliveryRepository repo, IMapper mapper)
    {
        _logger = logger;
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Delivery> GetDeliveryById(int articleId)
    {
        var deliveryEntity = await _repo.GetById(articleId);
        Delivery delivery = _mapper.Map<Delivery>(deliveryEntity);
        return delivery;
    }

    public async Task<List<Delivery>> GetAll()
    {
        var deliveryEntities = await _repo.GetAll();
        List<Delivery> delivery = _mapper.Map<List<Delivery>>(deliveryEntities);
        return delivery;
    }

    public async Task AddDelivery(Delivery newDelivery)
    {
        var newDeliveryEntity = _mapper.Map<DeliveryEntity>(newDelivery);
        await _repo.AddDelivery(newDeliveryEntity);
        return;
    }

    public async Task UpdateDelivery(int id, Delivery updatedDelivery)
    {
        var updatedDeliveryEntity = _mapper.Map<DeliveryEntity>(updatedDelivery);
        await _repo.UpdateDelivery(id, updatedDeliveryEntity);
        return;
    }

    public async Task RemoveDeliveryById(int id)
    {
        await _repo.RemoveDeliveryById(id);
        return;
    }
}