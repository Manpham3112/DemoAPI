using Microsoft.EntityFrameworkCore;
using SaleManagement.Models;
using SaleManagement.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;

namespace SaleManagement.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class SaleManagementDbContext : AbpDbContext<SaleManagementDbContext>
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<SaleReceipt> SaleReceipts { get; set; }
        public DbSet<ImportReceipt> ImportReceipts { get; set; }
        public DbSet<SaleReceiptDetail> SaleReceiptDetails { get; set; }
        public DbSet<ImportReceiptDetail> ImportReceiptDetails { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public SaleManagementDbContext(DbContextOptions<SaleManagementDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users");
                b.ConfigureByConvention();
                b.ConfigureAbpUser();
            });

            builder.ConfigureSaleManagement();
        }
    }
}
