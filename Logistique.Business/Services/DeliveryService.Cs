using AutoMapper;
using Logistique.Business.Description.BusinessModel;
using Logistique.Business.Description.Services;
using Logistique.Data.Description.Models.Entities;
using Logistique.Data.Description.Repositories;
using Microsoft.Extensions.Logging;

namespace Logistique.Business.Services;

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

    public async Task ConfirmDelivery(int id)
    {
        var updatedDeliveryEntity = await _repo.GetById(id);
        if (updatedDeliveryEntity.State == Data.Description.Models.Entities.DeliveryState.Validate)
        {
            throw new InvalidDataException("La réception est déjà au statut validé.");
        }
        
        updatedDeliveryEntity.State = Data.Description.Models.Entities.DeliveryState.Validate;
        updatedDeliveryEntity.LastModifiedBy = "ANONYMOUS";
        updatedDeliveryEntity.LastModificationDate = DateTime.Now;
        await _repo.UpdateDelivery(id, updatedDeliveryEntity);
        return;
    }

    public async Task CancelDelivery(int id)
    {
        var updatedDeliveryEntity = await _repo.GetById(id);
        if (updatedDeliveryEntity.State == Data.Description.Models.Entities.DeliveryState.Cancel)
        {
            throw new InvalidDataException("La réception est déjà au statut annulé.");
        }

        updatedDeliveryEntity.State = Data.Description.Models.Entities.DeliveryState.Cancel;
        updatedDeliveryEntity.LastModifiedBy = "ANONYMOUS";
        updatedDeliveryEntity.LastModificationDate = DateTime.Now;
        await _repo.UpdateDelivery(id, updatedDeliveryEntity);
        return;
    }

    public async Task RemoveDeliveryById(int id)
    {
        await _repo.RemoveDeliveryById(id);
        return;
    }
}