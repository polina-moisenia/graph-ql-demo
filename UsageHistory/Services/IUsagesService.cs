using System.Collections.Generic;
using UsageHistory.Models;

namespace UsageHistory.Services
{
    public interface IUsagesService
    {
        List<Usage> Get();
        Usage Get(string id);
        List<Usage> GetByMovieId(string movieId);
        Usage Create(Usage Usage);
        void Update(string id, Usage UsageIn);
        void Remove(string id);
    }
}