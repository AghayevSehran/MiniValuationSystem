using MiniValuationSystem.Models;

namespace MiniValuationSystem.Business
{
    public interface IValuationService
    {
        Task<IEnumerable<Valuation>> CalculateValuetion();
    }
}