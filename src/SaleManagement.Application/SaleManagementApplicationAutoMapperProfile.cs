using SaleManagement.Models;
using SaleManagement.Users;
using Volo.Abp.Identity;

namespace SaleManagement
{
    public class SaleManagementApplicationAutoMapperProfile : AutoMapper.Profile
    {
        public SaleManagementApplicationAutoMapperProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateUpdateProductDto, Product>();
            CreateMap<AppUser, AppUserDto>();
            CreateMap<IdentityUser, IdentityUserDto>();
            CreateMap<CreateUserDto, AppUser>();
            CreateMap<Room, RoomDto>();
            CreateMap<RoomDto, Room>();
            CreateMap<CreateUpdateRoomDto, Room>();
        }
    }
}
