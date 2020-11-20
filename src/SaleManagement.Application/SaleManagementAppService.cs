using System;
using System.Collections.Generic;
using System.Text;
using SaleManagement.Localization;
using Volo.Abp.Application.Services;

namespace SaleManagement
{
    /* Inherit your application services from this class.
     */
    public abstract class SaleManagementAppService : ApplicationService
    {
        protected SaleManagementAppService()
        {
            LocalizationResource = typeof(SaleManagementResource);
        }
    }
}
