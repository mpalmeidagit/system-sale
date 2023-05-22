using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SystemSale.DTO;
using SystemSale.Model;


namespace SystemSale.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Roles
            CreateMap<Rol, RolDTO>().ReverseMap();
            #endregion Menu

            #region Menu
            CreateMap<Menu, MenuDTO>().ReverseMap();
            #endregion Menu

            #region User
            CreateMap<User, UserDTO>().ForMember(destiny => destiny.RolDescription, opt => opt.MapFrom(origin => origin.IdRolNavigation.Name)
            ).ForMember(destiny => destiny.IsActivo, opt => opt.MapFrom(origin => origin.IsActivo == true ? 1 : 0)
            );
            CreateMap<User, SessionDTO>().ForMember(destiny => destiny.RolDescription, opt => opt.MapFrom(origin => origin.IdRolNavigation.Name));

            CreateMap<UserDTO, User>().ForMember(destiny => destiny.IdRolNavigation, opt => opt.Ignore()
            ).ForMember(destiny => destiny.IsActivo, opt => opt.MapFrom(origin => origin.IsActivo == 1 ? true : false));

            #endregion User


        }

    }
}
