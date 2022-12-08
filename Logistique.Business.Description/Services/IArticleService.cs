using Logistique.Business.BusinessModel;

namespace Logistique.Business.Description.Services;

public interface IPartService
{
    Task<Part> GetPartById(int id);
    Task<List<Part>> GetAll();
    Task<int> AddPart(Part newArticle);
    Task UpdatePart(int id, Part updatedArticle);
    Task RemovePartById(int id);
}