using Logistique.Data.Context;
using Logistique.Data.Description.Models.Entities;
using Logistique.Data.Description.Repositories;
using Microsoft.EntityFrameworkCore; 

namespace Logistique.Data.Repositories;

public class USerRepository : IUserRepository
{
    private LogistiqueDbContext _context;

    public USerRepository(LogistiqueDbContext context)
    {
        this._context = context;
    }
    
    public async Task<UserEntity> GetUserByUsername(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u=>u.Username == username);
    }

    public async Task<List<UserEntity>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddUser(UserEntity newUser)
    {
        await _context.Users.AddAsync(newUser);
        _context.SaveChanges();
        return;
    }

    public async Task UpdateUser(UserEntity updatedUser)
    {
        var userToUpdate = await _context.Users.FirstOrDefaultAsync(u=>u.Username == updatedUser.Username);
        if (userToUpdate != null)
        {
            userToUpdate.Email = updatedUser.Email;
            userToUpdate.PasswordHash = updatedUser.PasswordHash;
            userToUpdate.LastModificationDate = DateTime.Now;
            userToUpdate.LastModifiedBy = "ANONYMOUS";
            _context.Users.Update(userToUpdate);
            _context.SaveChanges();
            return;
        } else {
            throw new KeyNotFoundException($"Aucun utilisateur portant l'username {updatedUser.Username} n'a été trouvé.");
        }
    }
}