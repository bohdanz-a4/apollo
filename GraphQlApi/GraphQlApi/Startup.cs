using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQlApi.Schemas;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
            services.AddSingleton<DroidSchema>();

            services.AddGraphQL((options, provider) =>
            {
                options.EnableMetrics = true;
                var logger = provider.GetRequiredService<ILogger<Startup>>();
                options.UnhandledExceptionDelegate = ctx => logger.LogError("{Error} occurred", ctx.OriginalException.Message);
            })
                .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { })
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
                .AddWebSockets()
                .AddDataLoader()
                .AddGraphTypes(typeof(DroidSchema));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();
            app.UseGraphQLWebSockets<DroidSchema>();
            app.UseGraphQL<DroidSchema>();

            app.UseGraphQLGraphiQL(new GraphiQLOptions
            {
                //Headers = new Dictionary<string, string>
                //{
                //    ["X-api-token"] = "130fh9823bd023hd892d0j238dh",
                //}
            });
        }
    }
}
