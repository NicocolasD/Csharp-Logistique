using Logistique.Data.Description.Models.Entities;

namespace Logistique.Data.Description.Repositories;

public interface IDeliveryRepository
{
    Task<List<DeliveryEntity>> GetAll();
    Task<DeliveryEntity> GetById(int id);
    Task<int> AddDelivery(DeliveryEntity newDelivery);
    Task UpdateDelivery(int id, DeliveryEntity updatedDelivery);
    Task RemoveDeliveryById(int id);
}