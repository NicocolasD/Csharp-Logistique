using AutoMapper;
using Logistique.Business.BusinessModel;
using Logistique.Business.Description.Services;
using Logistique.Data.Description.Models.Entities;
using Logistique.Data.Description.Repositories;
using Microsoft.Extensions.Logging;

namespace Logistique.BusinessServices;

public class StockService : IStockService
{
    private readonly ILogger<StockService> _logger;
    private readonly IStockRepository _repo;
    private readonly IMapper _mapper;

    public StockService(ILogger<StockService> logger, IStockRepository repo, IMapper mapper)
    {
        _logger = logger;
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Stock> GetStockByArticleId(int articleId)
    {
        var stockEntity = await _repo.GetStockByArticleId(articleId);
        Stock stock = _mapper.Map<Stock>(stockEntity);
        return stock;
    }

    public async Task<List<Stock>> GetAll()
    {
        var stockEntities = await _repo.GetAll();
        List<Stock> stock = _mapper.Map<List<Stock>>(stockEntities);
        return stock;
    }

    public async Task AddStock(Stock newStock)
    {
        var newStockEntity = _mapper.Map<StockEntity>(newStock);
        await _repo.AddStock(newStockEntity);
        return;
    }

    public async Task UpdateStock(int id, Stock updatedStock)
    {
        var updatedStockEntity = _mapper.Map<StockEntity>(updatedStock);
        await _repo.UpdateStock(id, updatedStockEntity);
        return;
    }

    public async Task RemoveStockById(int id)
    {
        await _repo.RemoveStockById(id);
        return;
    }

    public async Task RemoveStockByArticleId(int articleId)
    {
        await _repo.RemoveStockByArticleId(articleId);
        return;
    }
}