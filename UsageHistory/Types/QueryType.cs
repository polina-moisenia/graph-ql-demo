using HotChocolate.Types;
using System;
using System.Linq;
using UsageHistory.Models;
using UsageHistory.Services;

namespace UsageHistory.Types
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(t => t.GetUsages()).Name("usages");
            descriptor.Field(t => t.GetUsage(default)).Name("movieUsages").Argument("movieId", a => a.Type<IdType>());
        }
    }

    public class Query
    {
        private readonly IUsagesService _service;

        public Query(IUsagesService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public IQueryable<Usage> GetUsages() => _service.Get().AsQueryable();
        public IQueryable<Usage> GetUsage(string movieId) => _service.GetByMovieId(movieId).AsQueryable();
    }
}