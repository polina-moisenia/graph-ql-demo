using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Models;
using Demo.Services;
using HotChocolate.Types;

namespace Demo.Types
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(t => t.GetMovie(default)).Argument("id", a => a.Type<IdType>());
        }
    }

    public class Query
    {
        private readonly IMoviesService _service;

        public Query(IMoviesService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public IQueryable<Movie> GetMovie(string id) 
        {
            //todo how can it be done in different functions?
            if(String.IsNullOrEmpty(id)) return _service.Get().AsQueryable();
            return new List<Movie>{_service.Get(id)}.AsQueryable();
        }
        
        //make genre as an enum or category not to make it too difficult
    }
}