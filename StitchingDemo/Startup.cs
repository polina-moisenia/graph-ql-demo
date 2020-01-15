using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Voyager;
using HotChocolate;
using System;
using HotChocolate.Stitching;

namespace StitchingDemo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient("MoviesService", (sp, client) =>
            {
                client.BaseAddress = new Uri("http://127.0.0.1:5050");
            });
            services.AddHttpClient("UsagesService", (sp, client) =>
            {
                client.BaseAddress = new Uri("http://127.0.0.1:5053");
            });

            services.AddDataLoaderRegistry();
            services.AddGraphQL(sp => SchemaBuilder.New().AddType<Query>().Create());

            services.AddStitchedSchema(builder => builder
              .AddSchemaFromHttp("MoviesService")
              .AddSchemaFromHttp("UsagesService")
              //.AddExtensionsFromFile("./Extensions.graphql")
              .AddSchemaConfiguration(c =>
              {
                  c.RegisterExtendedScalarTypes();
              }));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseGraphQL("/graphql");
            app.UseVoyager("/graphql");
            app.UsePlayground("/graphql");
        }
    }
}
