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

            services.AddHttpClient("UsageService", (sp, client) =>
            {
                HttpContext context = sp.GetRequiredService<IHttpContextAccessor>().HttpContext;
                client.BaseAddress = new Uri("http://localhost:5053/graphql");
            });

            services.AddHttpContextAccessor();

            services.AddSingleton<IQueryResultSerializer, JsonQueryResultSerializer>();

            services.AddGraphQLSubscriptions();

            services.AddStitchedSchema(builder => builder            
                .AddSchemaFromHttp("MovieService")
                .AddSchemaFromHttp("UsageService")
                .AddExtensionsFromFile("./Extensions.graphql")
                //.RenameType("LifeInsuranceContract", "LifeInsurance")
                // .AddSchemaConfiguration(c =>
                // {
                //     // custom resolver that depends on data from a remote schema.
                //     c.Map(new FieldReference("Customer", "foo"), next => context =>
                //     {
                //         OrderedDictionary obj = context.Parent<OrderedDictionary>();
                //         context.Result = obj["name"] + "_" + obj["id"];
                //         return Task.CompletedTask;
                //     });
                // })
                );
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseGraphQL("/graphql");
            app.UseVoyager("/graphql");
            app.UsePlayground("/graphql");
        }
    }
}
