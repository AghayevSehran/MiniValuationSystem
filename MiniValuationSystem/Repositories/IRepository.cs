using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniValuationSystem.Repositories
{
    public interface IRepository<T> where T : class
    {
        IAsyncEnumerable<T> GetAll();
    }
}
