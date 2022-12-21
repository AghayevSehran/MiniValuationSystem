using MiniValuationSystem.Business;
using MiniValuationSystem.Models;
using MiniValuationSystem.Repositories;
using System.Reflection;

class Program
{
    static async Task Main(string[] args)
    {
        //Injections
        var pricePath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\Prices.csv");
        var transactionPath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\Transactions.csv");
        IRepository<Prices> priceRepository = new Repository<Prices>(pricePath);
        IRepository<Transaction> transacRepository = new Repository<Transaction>(transactionPath);
        IValuationService valuationService = new ValuationService(transacRepository, priceRepository);

        var valuationResult = await valuationService.CalculateValuetion();

        foreach (var item in valuationResult)
        {
            Console.WriteLine(item);
        }
    }
}