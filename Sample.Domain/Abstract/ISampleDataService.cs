using Sample.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Domain.Abstract
{
    public interface ISampleDataService
    {
        Task<IEnumerable<SampleData>> GetSampleDataAsync();

        void Add(SampleData entity);
    }
}
