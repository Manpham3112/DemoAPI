using Microsoft.EntityFrameworkCore;
using SaleManagement.Models;
using SaleManagement.Users;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;

namespace SaleManagement.EntityFrameworkCore
{
    public static class SaleManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureSaleManagement(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<Product>(t => t.ToTable("Products", SaleManagementConsts.DbSchema));
            builder.Entity<Distributor>(t => t.ToTable("Distributors", SaleManagementConsts.DbSchema));
            builder.Entity<SaleReceipt>(t =>
            {
                t.ToTable("SaleReceipts", SaleManagementConsts.DbSchema);
                t.Ignore(t => t.User);
            });
            builder.Entity<ImportReceipt>(t =>
            {
                t.ToTable("ImportReceipts", SaleManagementConsts.DbSchema);
                t.Ignore(t => t.User);
            });
            builder.Entity<SaleReceiptDetail>(t =>
            {
                t.ToTable("SaleReceiptDetails", SaleManagementConsts.DbSchema);
                t.HasKey(s => new { s.SaleReceiptId, s.ProductId });
            });
            builder.Entity<ImportReceiptDetail>(t =>
            {
                t.ToTable("ImportReceiptDetails", SaleManagementConsts.DbSchema);
                t.HasKey(s => new { s.ImportReceiptId, s.ProductId });
            });
            builder.Entity<Room>(t => t.ToTable("Rooms", SaleManagementConsts.DbSchema));
        }
    }
}