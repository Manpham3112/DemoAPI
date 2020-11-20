using SaleManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SaleManagement.Permissions
{
    public class SaleManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(SaleManagementPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(SaleManagementPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<SaleManagementResource>(name);
        }
    }
}
