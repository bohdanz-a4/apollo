using GraphQL.Server;
using GraphQlApi.Models;
using GraphQlApi.Queries;
using GraphQlApi.Schemas;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQlApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<DroidType>();
            services.AddSingleton<EpisodeEnum>();

            services.AddSingleton<DroidQuery>();
            services.AddSingleton<DroidSchema>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
            })
                .AddWebSockets()
                .AddDataLoader()
                .AddSystemTextJson()
                .AddErrorInfoProvider(options =>
                {
                    options.ExposeExceptionStackTrace = true; // todo: dev only!!!
                })
                .AddGraphTypes(typeof(DroidSchema));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseGraphiQLServer(new GraphQL.Server.Ui.GraphiQL.GraphiQLOptions
            {
                GraphQLEndPoint = "/graphql",
                Path = "/ui/graphiql"
            });
            app.UseWebSockets();
            app.UseGraphQLWebSockets<DroidSchema>();
            app.UseGraphQL<DroidSchema>();
        }
    }
}
