using Microsoft.VisualBasic;
using MiniValuationSystem.Models;
using MiniValuationSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniValuationSystem.Business
{
    public class ValuationService : IValuationService
    {
        private readonly IRepository<Transaction> transactionRepository;
        private readonly IRepository<Prices> pricesRepository;
        public ValuationService(IRepository<Transaction> transactionRepository, IRepository<Prices> pricesRepository)
        {
            this.transactionRepository = transactionRepository;
            this.pricesRepository = pricesRepository;
        }
        public async Task<IEnumerable<Valuation>> CalculateValuetion()
        {
            var transactions = transactionRepository.GetAll();
            List<Valuation> valuations = new();
            await foreach (var itemTransac in transactions)
            {
                var trans = itemTransac;
                await foreach (var itemPrice in pricesRepository.GetAll())
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
}
