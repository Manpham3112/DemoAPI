using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaleManagement.Data;
using Volo.Abp.DependencyInjection;

namespace SaleManagement.EntityFrameworkCore
{
    public class EntityFrameworkCoreSaleManagementDbSchemaMigrator
        : ISaleManagementDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreSaleManagementDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the SaleManagementMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<SaleManagementMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}