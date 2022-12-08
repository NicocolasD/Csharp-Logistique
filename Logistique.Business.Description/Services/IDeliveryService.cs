using Logistique.Business.Description.BusinessModel;

public interface IDeliveryService
{
    Task<Delivery> GetDeliveryById(int articleId);
    Task<List<Delivery>> GetAll();
    Task AddDelivery(Delivery newDelivery);
    Task UpdateDelivery(int id, Delivery updatedDelivery);
    Task CancelDelivery(int id);
    Task RemoveDeliveryById(int id);
}