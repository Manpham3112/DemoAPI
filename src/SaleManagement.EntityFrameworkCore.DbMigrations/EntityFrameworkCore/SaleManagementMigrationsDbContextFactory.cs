using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SaleManagement.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class SaleManagementMigrationsDbContextFactory : IDesignTimeDbContextFactory<SaleManagementMigrationsDbContext>
    {
        public SaleManagementMigrationsDbContext CreateDbContext(string[] args)
        {
            SaleManagementEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<SaleManagementMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new SaleManagementMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
