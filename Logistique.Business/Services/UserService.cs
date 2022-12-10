using System.Security.Cryptography;
using AutoMapper;
using Logistique.Business.Description.BusinessModel;
using Logistique.Business.Description.Services;
using Logistique.Data.Description.Models.Entities;
using Logistique.Data.Description.Repositories;
using Microsoft.Extensions.Logging;

namespace Logistique.Business.Services;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    private readonly IUserRepository _repo;
    private readonly IMapper _mapper;

    public UserService(ILogger<UserService> logger, IUserRepository repo, IMapper mapper)
    {
        _logger = logger;
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<List<User>> GetAll()
    {
        var userEntities = await _repo.GetAll();
        var users = _mapper.Map<List<User>>(userEntities);
        return users;
    }

    public async Task<UserFromDB> GetByUsername(string username)
    {
        var userEntity = await _repo.GetUserByUsername(username);
        var user = _mapper.Map<UserFromDB>(userEntity);
        return user;
    }

    public async Task AddUser(User newUser)
    {
        var newUserEntity = _mapper.Map<UserEntity>(newUser);

        CreatePasswordHash(newUser.Password, out byte[] passwordHash, out byte[] passwordSalt);
        newUserEntity.PasswordHash = passwordHash;
        newUserEntity.PasswordSalt = passwordSalt;

        await _repo.AddUser(newUserEntity);
        return;
    }

    public async Task UpdateUser(User updatedUser)
    {
        var updatedUserEntity = _mapper.Map<UserEntity>(updatedUser);
        await _repo.UpdateUser(updatedUserEntity);
        return;
    }

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }    
}