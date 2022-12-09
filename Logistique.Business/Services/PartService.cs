using AutoMapper;
using Logistique.Business.Description.BusinessModel;
using Logistique.Business.Description.Services;
using Logistique.Data.Description.Models.Entities;
using Logistique.Data.Description.Repositories;
using Microsoft.Extensions.Logging;

namespace Logistique.Business.Services;

public class PartService : IPartService
{
    private readonly ILogger<PartService> _logger;
    private readonly IPartRepository _repo;
    private readonly IMapper _mapper;

    public PartService(ILogger<PartService> logger, IPartRepository repo, IMapper mapper)
    {
        _logger = logger;
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Part> GetPartById(int id)
    {
        var partEntity = await _repo.GetById(id);
        Part part = _mapper.Map<Part>(partEntity);
        return part;
    }

    public async Task<List<Part>> GetAll()
    {
        var partEntities = await _repo.GetAll();
        List<Part> parts = _mapper.Map<List<Part>>(partEntities);
        return parts;
    }

    public async Task<int> AddPart(Part newPart)
    {
        var newPartEntity = _mapper.Map<PartEntity>(newPart);
        var newPartId = await _repo.AddPart(newPartEntity);
        return newPartId;
    }

    public async Task UpdatePart(int id, Part updatedPart)
    {
        var updatedPartEntity = _mapper.Map<PartEntity>(updatedPart);
        await _repo.UpdatePart(id, updatedPartEntity);
        return;
    }

    public async Task RemovePartById(int id)
    {
        await _repo.RemovePartById(id);
        return;
    }
}