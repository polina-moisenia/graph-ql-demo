using System;
using System.Linq;
using MoviesDemo.Models;
using MoviesDemo.Services;
using HotChocolate.Types;

namespace MoviesDemo.Types
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(t => t.GetMovies()).Name("movies");
            descriptor.Field(t => t.GetMovie(default)).Name("movie").Argument("id", a => a.Type<IdType>());
        }
    }

    public class Query
    {
        private readonly IMoviesService _service;

        public Query(IMoviesService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public IQueryable<Movie> GetMovies() => _service.Get().AsQueryable();
        public Movie GetMovie(string id) => _service.Get(id);
    }
}