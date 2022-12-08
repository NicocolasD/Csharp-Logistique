using Logistique.Data.Context;
using Logistique.Data.Description.Models.Entities;
using Logistique.Data.Description.Repositories;
using Microsoft.EntityFrameworkCore; 

namespace Logistique.Data.Repositories;

public class DeliveryRepository : IDeliveryRepository
{
    private readonly LogistiqueDbContext _context;
    public DeliveryRepository(LogistiqueDbContext context)
    {
        _context = context;
    }
    public async Task<List<DeliveryEntity>> GetAll()
    {
        return await _context.Deliveries.Include(d=>d.DeliveryLines).ThenInclude(dl=>dl.Part).ToListAsync();
    }

    public async Task<DeliveryEntity> GetById(int id)
    {
        return await _context.Deliveries.Include(d=>d.DeliveryLines).ThenInclude(dl=>dl.Part).FirstOrDefaultAsync(d=>d.Id == id);
    }

    public async Task<int> AddDelivery(DeliveryEntity newDelivery)
    {
        var value = await _context.Deliveries.AddAsync(newDelivery);
        _context.SaveChanges();
        return value.Entity.Id;
    }

    public async Task UpdateDelivery(int id, DeliveryEntity updatedDelivery)
    {
        var deliveryToUpdate = await _context.Deliveries.FirstOrDefaultAsync(d=>d.Id == id);
        if (deliveryToUpdate != null)
        {
            deliveryToUpdate.State = updatedDelivery.State;
            deliveryToUpdate.LastModificationDate = DateTime.Now;
            deliveryToUpdate.LastModifiedBy = "ANONYMOUS";
            _context.Deliveries.Update(deliveryToUpdate);
            _context.SaveChanges();
            return;
        } else {
            throw new KeyNotFoundException($"Aucune réception portant l'id {id} n'a été trouvé.");
        }
    }

    public async Task RemoveDeliveryById(int id)
    {
        var deliveryToDelete = await _context.Deliveries.FirstOrDefaultAsync(d=>d.Id == id);
        if (deliveryToDelete != null)
        {
            _context.Deliveries.Remove(deliveryToDelete);
            await _context.SaveChangesAsync();
            return;
        } else {
            throw new KeyNotFoundException($"Aucune réception portant l'id {id} n'a été trouvé.");
        }
    }
}