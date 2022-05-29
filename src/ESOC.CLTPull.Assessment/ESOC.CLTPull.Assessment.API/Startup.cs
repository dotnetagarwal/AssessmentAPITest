using AutoMapper;
using ESOC.CLTPull.Assessment.Core.Interfaces;
using ESOC.CLTPull.Assessment.Infrastructure.Data.Logging;
using ESOC.CLTPull.Infrastructure.Data;
using ESOC.CLTPull.Infrastructure.Data.Repositories.BaseW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using ESOC.CLTPull.Core.Contracts;
using ESOC.CLTPull.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Server.IISIntegration;

namespace ESOC.CLTPull.WebApi
{

    public class Startup
    {
        private const string CORS_POLICY = "AllowOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration;

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {

            ConfigureProductionServices(services);
        }

        public void ConfigureDockerServices(IServiceCollection services)
        {
            ConfigureDevelopmentServices(services);
        }


        public void ConfigureProductionServices(IServiceCollection services)
        {
            // use real database
            // Requires LocalDB which can be installed with SQL Server Express 2016
            // https://www.microsoft.com/en-us/download/details.aspx?id=54284

            //TODO needs to see how to handle EF CLTPullContext
            services.AddDbContext<CLTPULLContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("CLTPULL")));
            ConfigureServices(services);
        }




        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRequestRepository), typeof(RequestRepository));
            services.AddScoped(typeof(IRequestInteractionRepository), typeof(RequestInteractionRepository));
            services.AddScoped(typeof(IRequestInteractionHistoryRepository), typeof(RequestInteractionHistoryRepository));
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));


            services.AddMemoryCache();

            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            services.AddCors(options =>
            {
                options.AddPolicy(name: CORS_POLICY,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200");
                                      builder.AllowAnyMethod();
                                      builder.AllowAnyHeader();
                                      builder.SetIsOriginAllowed((host) => true);
                                      builder.AllowCredentials();
                                  });
            });

            services.AddControllers();


            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Assessment API", Version = "v1" });
                c.DescribeAllParametersInCamelCase();
                c.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(CORS_POLICY);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Assessment API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}


