using Logistique.Data.Description.Models.Entities;

namespace Logistique.Data.Description.Repositories;

public interface IUserRepository
{
    Task<UserEntity> GetUserByUsername(string username);
    Task<List<UserEntity>> GetAll();
    Task AddUser(UserEntity newUser);
    Task UpdateUser(UserEntity updatedUser);
}