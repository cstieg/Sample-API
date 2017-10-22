using Sample.Domain.Abstract;
using Sample.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Sample.Infrastructure
{
    public class SampleDataService : ISampleDataService
    {
        private IEntityRepository<SampleData> _sampleDataRepository;

        public SampleDataService(IEntityRepository<SampleData> sampleDataRepository)
        {
            _sampleDataRepository = sampleDataRepository;
        }

        public async Task<IEnumerable<SampleData>> GetSampleDataAsync()
        {
            return await _sampleDataRepository.GetAll().ToListAsync();
        }

        public void Add(SampleData entity)
        {
            _sampleDataRepository.Add(entity);
        }
    }
}