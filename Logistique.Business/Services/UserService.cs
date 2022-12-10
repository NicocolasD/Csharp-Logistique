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

    public async Task<User> GetByUsername(string username)
    {
        var userEntity = await _repo.GetUserByUsername(username);
        var user = _mapper.Map<User>(userEntity);
        return user;
    }

    public async Task AddUser(User newUser)
    {
        var newUserEntity = _mapper.Map<UserEntity>(newUser);
        await _repo.AddUser(newUserEntity);
        return;
    }

    public async Task UpdateUser(User updatedUser)
    {
        var updatedUserEntity = _mapper.Map<UserEntity>(updatedUser);
        await _repo.UpdateUser(updatedUserEntity);
        return;
    }
}