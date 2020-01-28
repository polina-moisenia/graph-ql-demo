using Reviews.Models;
using Reviews.Services;
using Reviews.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;
using HotChocolate;
using HotChocolate.Execution.Configuration;
using HotChocolate.AspNetCore;

namespace Reviews
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

            services.Configure<DatabaseConfiguration>(Configuration.GetSection(nameof(DatabaseConfiguration)));
            services.AddSingleton<IReviewsService, ReviewsService>();

            services.AddGraphQL(sp => SchemaBuilder.New()
               .AddServices(sp)
               .AddQueryType<QueryType>()          
               .AddMutationType<MutationType>()
               .AddType<ReviewType>()
               .AddType<UserType>()
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