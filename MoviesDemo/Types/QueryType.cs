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
}