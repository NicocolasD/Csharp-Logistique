using Logistique.Data.Description.Models.Entities;

namespace Logistique.Data.Description.Repositories;

public interface IPartRepository
{
    Task<PartEntity> GetById(int id);
    Task<List<PartEntity>> GetAll();
    Task<int> AddPart(PartEntity newArticle);
    Task UpdatePart(int id, PartEntity updatedArticle);
    Task RemovePartById(int id);
}