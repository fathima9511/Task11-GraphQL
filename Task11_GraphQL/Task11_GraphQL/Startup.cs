using HotChocolate.Execution.Processing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task11_GraphQL.Schema;
using Task11_GraphQL.Schema.Mutations;
using Task11_GraphQL.Schema.Queries;
using Task11_GraphQL.Schema.Subscriptions;
using Task11_GraphQL.Services;
using Task11_GraphQL.Services.Courses;

namespace Task11_GraphQL
{
    public class Startup
    {
       private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>();

            services.AddInMemorySubscriptions();

            string connectionString = _configuration.GetConnectionString("default");
            services.AddPooledDbContextFactory<SchoolDbContext>(o => o.UseSqlite(connectionString));

            services.AddScoped<CoursesRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseWebSockets();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
