using System;
using Conditions.Models;

namespace Conditions.Services
{
    public class ConditionService : IConditionService
    {
        public Condition GetConditionByMovieId(string movieId)
        {
            var rand = new Random();

            return new Condition
            {
                MovieId = movieId,
                Price = rand.Next(20,50).ToString(),
                YearOfBuying = rand.Next(2005, 2020).ToString()
            };
        }        
    }
}