using Conditions.Models;

namespace Conditions.Services
{
    public interface IConditionService
    {
        Condition GetConditionByMovieId(string movieId);
    }
}