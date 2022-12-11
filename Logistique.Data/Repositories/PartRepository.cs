using Logistique.Data.Context;
using Logistique.Data.Description.Models.Entities;
using Logistique.Data.Description.Repositories;
using Microsoft.EntityFrameworkCore; 

namespace Logistique.Data.Repositories;

public class PartRepository : IPartRepository
{
    private LogistiqueDbContext _context;

    public PartRepository(LogistiqueDbContext context)
    {
        this._context = context;
    }

    public async Task<PartEntity> GetById(int id)
    {
        return await _context.Parts.FirstOrDefaultAsync(a=>a.Id == id);
    }

    public async Task<List<PartEntity>> GetAll()
    {
        return await _context.Parts.ToListAsync();
    }

    public async Task<int> AddPart(PartEntity newPart)
    {
        var value = await _context.Parts.AddAsync(newPart);
        _context.SaveChanges();
        return value.Entity.Id;
    }

    public async Task UpdatePart(int id, PartEntity updatedPart)
    {
        var partToUpdate = await _context.Parts.FirstOrDefaultAsync(a=>a.Id == id);
        if (partToUpdate != null)
        {
            partToUpdate.Description = updatedPart.Description;
            partToUpdate.Ean = updatedPart.Ean;
            partToUpdate.PartNo = updatedPart.PartNo;
            partToUpdate.LastModificationDate = DateTime.Now;
            partToUpdate.LastModifiedBy = "ANONYMOUS";
            _context.Parts.Update(partToUpdate);
            _context.SaveChanges();
            return;
        } else {
            throw new KeyNotFoundException($"Aucun article portant l'id {id} n'a été trouvé.");
        }
    }

    public async Task RemovePartById(int id)
    {
        var partToDelete = await _context.Parts.FirstOrDefaultAsync(a=>a.Id == id);
        if (partToDelete != null)
        {
            _context.Parts.Remove(partToDelete);
            await _context.SaveChangesAsync();
            return;
        } else {
            throw new KeyNotFoundException($"Aucun article portant l'id {id} n'a été trouvé.");
        }
    }
}