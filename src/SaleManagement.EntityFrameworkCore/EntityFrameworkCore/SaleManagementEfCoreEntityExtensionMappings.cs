using IdentityModel;
using System;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace SaleManagement.EntityFrameworkCore
{
    public static class SaleManagementEfCoreEntityExtensionMappings
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                ObjectExtensionManager.Instance.MapEfCoreProperty<IdentityUser, DateTime?>("DateOfBirth");
                ObjectExtensionManager.Instance.MapEfCoreProperty<IdentityUser, string>("Address", b => b.HasMaxLength(200));
                ObjectExtensionManager.Instance.MapEfCoreProperty<IdentityUser, bool>("Locked");
                ObjectExtensionManager.Instance.MapEfCoreProperty<IdentityUser, int>("FailedLoginsNumber");
                ObjectExtensionManager.Instance.MapEfCoreProperty<IdentityUser, DateTime?>("LastLockedDate");
            });
        }
    }
}
