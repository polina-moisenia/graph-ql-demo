using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Subscriptions;
using HotChocolate.Execution;
using HotChocolate.Stitching;
using HotChocolate.AspNetCore.Voyager;

namespace StitchingDemo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient("MovieService", (sp, client) =>
            {
                HttpContext context = sp.GetRequiredService<IHttpContextAccessor>().HttpContext;
                client.BaseAddress = new Uri("http://localhost:5050/graphql");
            });

            services.AddHttpClient("ReviewService", (sp, client) =>
            {
                HttpContext context = sp.GetRequiredService<IHttpContextAccessor>().HttpContext;
                client.BaseAddress = new Uri("http://localhost:5053/graphql");
            });

            services.AddHttpContextAccessor();

            services.AddSingleton<IQueryResultSerializer, JsonQueryResultSerializer>();

            services.AddGraphQLSubscriptions();

            services.AddStitchedSchema(builder => builder            
                .AddSchemaFromHttp("MovieService")
                .AddSchemaFromHttp("ReviewService")
                .AddExtensionsFromFile("./Extensions.graphql"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseGraphQL("/graphql");
            app.UseVoyager("/graphql");
            app.UsePlayground("/graphql");
        }
    }
}
