using MiniValuationSystem.Models;
using MiniValuationSystem.Repositories;

namespace MiniValuationSystem.Business;

public class ValuationService : IValuationService
{
    private readonly IRepository<Transaction> _transactionRepository;
    private readonly IRepository<Prices> _pricesRepository;
    public ValuationService(IRepository<Transaction> transactionRepository, IRepository<Prices> pricesRepository)
    {
        this._transactionRepository = transactionRepository;
        this._pricesRepository = pricesRepository;
    }
    public async Task<IEnumerable<Valuation>> CalculateValuetion()
    {
        var transactions = _transactionRepository.GetAll();
        List<Valuation> valuations = new();
        await foreach (var itemTransac in transactions)
        {
            var trans = itemTransac;
            await foreach (var itemPrice in _pricesRepository.GetAll())
            {
                if (itemPrice.Key == trans.Ticker)
                {
                    valuations.Add(new Valuation
                    {
                        Ticker = itemPrice.Key,
                        Counterparty = trans.Counterparty,
                        TradeId = trans.TradeId,
                        TradeType = trans.TradeType,
                        Value = trans.Quantity * itemPrice.Price,
                        CalcEstimate = trans.CalcEstimate,
                        Quantity = trans.Quantity
                    });
                }
            }
        }
        return valuations;
    }
}
