using MoviesDemo.Models;
using MoviesDemo.Services;
using MoviesDemo.Types;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;

namespace MoviesDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddHttpClient();

            var camelCaseConventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("CamelCase", camelCaseConventionPack, type => true);

            services.Configure<MoviesDatabaseConfiguration>(Configuration.GetSection(nameof(MoviesDatabaseConfiguration)));
            services.AddSingleton<IMoviesService, MoviesService>();

            services.Configure<RateServiceConfiguration>(Configuration.GetSection(nameof(RateServiceConfiguration)));
            services.AddSingleton<IRateService, RateService>();

            services.AddGraphQL(sp => SchemaBuilder.New()
               .AddServices(sp)
               .AddQueryType<QueryType>()
               .AddType<MovieType>()
               .Create(),
                new QueryExecutionOptions
                {
                    TracingPreference = TracingPreference.Always
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseGraphQL("/graphql");
            app.UsePlayground("/graphql");
        }
    }
}