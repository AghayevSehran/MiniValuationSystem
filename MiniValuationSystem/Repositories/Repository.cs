using CsvHelper;
using System.Globalization;

namespace MiniValuationSystem.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly string _path;
        public Repository(string path)
        {
            _path = path;
        }
        public IAsyncEnumerable<T> GetAll()
        {
            var reader = new StreamReader(_path);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecordsAsync<T>();
            return records;
        }
    }
}
