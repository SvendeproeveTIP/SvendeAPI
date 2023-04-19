using System;
using AutoMapper;

namespace LeMounAPI.Mappings
{
	public class MappingsProfile : Profile
	{
		public MappingsProfile()
		{
			CreateMap<Order, OrderModel>();
			CreateMap<User, UserModel>();
			CreateMap<UserRole, UserRoleModel>();
			CreateMap<UserStatus, UserStatusModel>();
			CreateMap<Vehicle, VehicleModel>();
			CreateMap<VehicleType, VehicleTypeModel>();
		}
	}
}

