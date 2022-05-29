using ESOC.CLTPull.Assessment.Core.Interfaces;
using ESOC.CLTPull.Assessment.Core.Interfaces.Repositories.Base;
using ESOC.CLTPull.Assessment.Infrastructure.Data.Logging;
using ESOC.CLTPull.Infrastructure.Data;
using ESOC.CLTPull.Infrastructure.Data.Repositories.BaseW;
using ESOC.CLTPull.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace ESOC.CLTPull.Assessment.IntegrationTests
{
    public class WebTestFixture : WebApplicationFactory<Startup>
    {
        private const string CORS_POLICY = "AllowOrigin";

        protected override IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder().ConfigureWebHostDefaults(builder =>
            builder.UseStartup<Startup>());
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {
                services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));

                services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));


                services.AddMemoryCache();


                services.AddCors(options =>
                {
                    options.AddPolicy(name: CORS_POLICY,
                                      builder =>
                                      {
                                          builder.AllowAnyOrigin();
                                          builder.AllowAnyMethod();
                                          builder.AllowAnyHeader();
                                      });
                });

                services.AddEntityFrameworkInMemoryDatabase();

                // Create a new service provider.
                var provider = services
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                // Add a database context (ApplicationDbContext) using an in-memory
                // database for testing.
                services.AddDbContext<CLTPULLContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(provider);
                });

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database
                
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<CLTPULLContext>();
                    var loggerFactory = scopedServices.GetRequiredService<ILoggerFactory>();

                    var logger = scopedServices
                        .GetRequiredService<ILogger<WebTestFixture>>();

                    // Ensure the database is created.
                    db.Database.EnsureCreated();

                    try
                    {
                        //////// Seed the database with test data.
                        //////CatalogContextSeed.SeedAsync(db, loggerFactory).Wait();
                        //////// seed sample user data
                        //////var userManager = scopedServices.GetRequiredService<UserManager<ApplicationUser>>();
                        //////var roleManager = scopedServices.GetRequiredService<RoleManager<IdentityRole>>();
                        //////AppIdentityDbContextSeed.SeedAsync(userManager, roleManager).Wait();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred seeding the " +
                            "database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }
    }
}
