using AutoMapper;
using Logistique.Business.Description.BusinessModel;
using Logistique.Business.Description.Services;
using Logistique.Data.Description.Models.Entities;
using Logistique.Data.Description.Repositories;
using Microsoft.Extensions.Logging;

namespace Logistique.Business.Services;

public class StockTransactionHistoryService : IStockTransactionHistoryService
{
    private readonly ILogger<StockTransactionHistoryService> _logger;
    private readonly IStockTransactionHistoryRepository _repo;
    private readonly IMapper _mapper;
    public StockTransactionHistoryService(ILogger<StockTransactionHistoryService> logger, IStockTransactionHistoryRepository repo, IMapper mapper)
    {
        _logger = logger;
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<StockTransactionHistory> GetTransactionById(int id)
    {
        var transactionEntity = await _repo.GetById(id);
        var transaction = _mapper.Map<StockTransactionHistory>(transactionEntity);
        return transaction;
    }

    public async Task<List<StockTransactionHistory>> GetAll()
    {
        var transactionEntities = await _repo.GetAll();
        var transactions = _mapper.Map<List<StockTransactionHistory>>(transactionEntities);
        return transactions;
    }

    public async Task AddTransaction(StockTransactionHistory newTransaction)
    {
        var newTransactionEntity = _mapper.Map<StockTransactionHistoryEntity>(newTransaction);
        await _repo.AddTransaction(newTransactionEntity);
        return;
    }
}