using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Identity;

namespace SaleManagement
{
    public class SaleManagementDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<IdentityUser> userRepository;
        private readonly IRepository<IdentityRole> roleRepository;
        private readonly IdentityUserManager userManager;
        private readonly IGuidGenerator guidGenerator;

        public SaleManagementDataSeedContributor(IRepository<IdentityUser> userRepository, IRepository<IdentityRole> roleRepository,
            IGuidGenerator guidGenerator, IdentityUserManager userManager)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.guidGenerator = guidGenerator;
            this.userManager = userManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await roleRepository.GetCountAsync() == 1)
            {
                var existingRole = roleRepository.FirstOrDefault();
                await roleRepository.DeleteAsync(existingRole);

                var roles = new[] { "admin", "employee" };
                foreach (var role in roles)
                {
                    var newRole = new IdentityRole(guidGenerator.Create(), role);
                    await roleRepository.InsertAsync(newRole);
                }
            }
            if (await userRepository.GetCountAsync() == 1)
            {
                var existingAdmin = userRepository.FirstOrDefault();
                if (existingAdmin.Email == "admin@abp.io")
                {
                    await userManager.DeleteAsync(existingAdmin);
                    await userRepository.HardDeleteAsync(existingAdmin);

                    var admin = new IdentityUser(guidGenerator.Create(), "admin", "admin@sm.com");
                    await userManager.CreateAsync(admin, "Admin123!");
                    await userManager.AddToRoleAsync(admin, "admin");

                    var employee = new IdentityUser(guidGenerator.Create(), "employee", "employee@sm.com");
                    await userManager.CreateAsync(employee, "Employee123!");
                    await userManager.AddToRoleAsync(employee, "employee");
                }
            }
        }
    }
}
