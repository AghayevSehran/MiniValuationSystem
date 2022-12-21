using FluentAssertions;
using MiniValuationSystem.Business;
using MiniValuationSystem.Models;
using MiniValuationSystem.Repositories;
using NSubstitute;

namespace MiniValuationSystem.UnitTests;

public class ValuationServiceUnitTest
{
    private readonly IValuationService _sub;
    private readonly IRepository<Prices> _pricesRepository = Substitute.For<IRepository<Prices>>();
    private readonly IRepository<Transaction> _transactionRepository = Substitute.For<IRepository<Transaction>>();

    public ValuationServiceUnitTest()
    {
        _sub = new ValuationService(_transactionRepository, _pricesRepository);
    }

    async IAsyncEnumerable<Prices> GetPrices()
    {
        yield return new Prices { Key = "ABC", Price = 9 };
        yield return new Prices { Key = "DFG", Price = 2 };
        await Task.CompletedTask;
    }

    async IAsyncEnumerable<Transaction> GetTransactions()
    {
        yield return new Transaction { TradeId = 1, CalcEstimate = 4, Counterparty = "Party", Quantity = 1, Ticker = "ABC", TradeType = "" };
        yield return new Transaction { TradeId = 2, CalcEstimate = 5, Counterparty = "Party", Quantity = 2, Ticker = "DFG", TradeType = "" };
        await Task.CompletedTask;
    }

    [Fact]
    public async Task CalculateValuetion_ShouldCalculateValue_WhenPricesTransactionProvided()
    {
        //Arrange
        _pricesRepository.GetAll().Returns(GetPrices());
        _transactionRepository.GetAll().Returns(GetTransactions());
        //Act
        var result =await _sub.CalculateValuetion();
        //Assert
        result.Should().HaveCount(2);
        result.Should().Contain(c => c.Value == 9);
        result.Should().Contain(c => c.Value == 4);
    }
}