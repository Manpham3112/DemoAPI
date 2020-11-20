using SaleManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SaleManagement.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class SaleManagementController : AbpController
    {
        protected SaleManagementController()
        {
            LocalizationResource = typeof(SaleManagementResource);
        }
    }
}