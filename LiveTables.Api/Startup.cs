using LiveTables.Api.Services;
using LiveTables.Domain.Models;
using LiveTables.Domain.Models.ViewModels;
using LiveTables.Infrastructure;
using LiveTables.Infrastructure.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LiveTables.Api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LiveTables.Api", Version = "v1" });
            });
            
            services
                .AddScoped<IEntityService<ScoresEntity>, ScoresEntityService>()
                .AddScoped<IEntityService<LeagueEntity>, LeagueEntityService>()
                .AddScoped<IEntityService<TeamEntity>, TeamEntityService>()
                .AddSingleton<ILiveTablesContext, LiveTablesContext>()
                .AddDbContext<LiveTablesContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("PostgreConnection")), ServiceLifetime.Singleton);
            
            DataBaseInit(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LiveTables.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
        
        private static void DataBaseInit(IServiceCollection services) =>
            services.BuildServiceProvider()
                .GetRequiredService<LiveTablesContext>()
                .Database
                .Migrate();
    }
}