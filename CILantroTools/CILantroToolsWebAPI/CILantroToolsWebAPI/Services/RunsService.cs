using CILantroToolsWebAPI.BindingModels.Runs;
using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.ReadModels.Runs;
using CILantroToolsWebAPI.Search;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Services
{
    public class RunsService
    {
        private readonly AppKeyRepository<Run> _runsRepository;

        public RunsService(
            AppKeyRepository<Run> runsRepository
        )
        {
            _runsRepository = runsRepository;
        }

        public async Task<SearchResult<RunReadModel>> SearchRunsAsync(SearchParameter searchParameter)
        {
            var result = await _runsRepository.Search<RunReadModel>(searchParameter);
            result.Data = result.Data.OrderByDescending(r => r.CreatedOn);
            return result;
        }

        public async Task<Guid> AddRunAsync(AddRunBindingModel model)
        {
            var newRun = new Run
            {
                Id = Guid.NewGuid(),
                Type = model.Type,
                CreatedOn = DateTime.Now
            };

            return await _runsRepository.CreateAsync(newRun);
        }
    }
}