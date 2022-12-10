using Logistique.Business.Description.BusinessModel;

namespace Logistique.Business.Description.Services;

public interface IUserService
{
    Task<List<User>> GetAll();
    Task<User> GetByUsername(string username);
    Task AddUser(User newUser);
    Task UpdateUser(User updatedUser);
}