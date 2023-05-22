using AutoMapper;
using System.Globalization;
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
            CreateMap<User, UserDTO>()
                .ForMember(destiny => destiny.RolDescription,
                opt => opt.MapFrom(origin => origin.IdRolNavigation.Name)
            )
                .ForMember(destiny => destiny.IsActivo,
                opt => opt.MapFrom(origin => origin.IsActivo == true ? 1 : 0)
            );
            CreateMap<User, SessionDTO>()
                .ForMember(destiny => destiny.RolDescription,
                opt => opt.MapFrom(origin => origin.IdRolNavigation.Name));

            CreateMap<UserDTO, User>()
                .ForMember(destiny => destiny.IdRolNavigation,
                opt => opt.Ignore()
            )
                .ForMember(destiny => destiny.IsActivo,
                opt => opt.MapFrom(origin => origin.IsActivo == 1 ? true : false));

            #endregion User

            #region Categoria
            CreateMap<Category, CategoryDTO>().ReverseMap();
            #endregion Categoria

            #region Product
            CreateMap<Product, ProductDTO>()
                .ForMember(destiny => destiny.CategoryDescription,
                opt => opt.MapFrom(origin => origin.IdCategoryNavigation.Name)
                )
                .ForMember(destiny => destiny.Price,
                opt => opt.MapFrom(origin => Convert.ToString(origin.Price.Value, new CultureInfo("pt-BR")))
                )
                .ForMember(destiny => destiny.IsActivo,
                opt => opt.MapFrom(origin => origin.IsActivo == true ? 1 : 0)
                );

            CreateMap<ProductDTO, Product>()
              .ForMember(destiny => destiny.IdCategoryNavigation, opt => opt.Ignore()
              )
              .ForMember(destiny => destiny.Price, opt => opt.MapFrom(origin => Convert.ToDecimal(origin.Price, new CultureInfo("pt-BR")))
              ).ForMember(destiny => destiny.IsActivo, opt => opt.MapFrom(origin => origin.IsActivo == 1 ? true : false)
              );
            #endregion Product

            #region Venda
            CreateMap<Sale, SaleDTO>()
                .ForMember(destiny => destiny.Total,
                opt => opt.MapFrom(origin => Convert.ToString(origin.Total.Value, new CultureInfo("pt-BR")))
            )
                .ForMember(destiny => destiny.DateRegistration,
                opt => opt.MapFrom(origin => origin.DateRegistration.Value.ToString("dd/MM/yyyy"))
                );
            CreateMap<SaleDTO, Sale>()
                .ForMember(destiny => destiny.Total,
                opt => opt.MapFrom(origin => Convert.ToDecimal(origin.Total, new CultureInfo("pt-BR")))
                );
            #endregion Menu

            #region Details sale
            CreateMap<DetailsSale, DetailsSaleDTO>()
                .ForMember(destiny => destiny.ProductDesciption,
                opt => opt.MapFrom(origin => origin.IdProductNavigation.Name)
                )
                .ForMember(destiny => destiny.Price,
                opt => opt.MapFrom(origin => Convert.ToString(origin.Price.Value, new CultureInfo("pt-BR")))
                )
                 .ForMember(destiny => destiny.Total,
                opt => opt.MapFrom(origin => Convert.ToString(origin.Total.Value, new CultureInfo("pt-BR")))
                );

            CreateMap<DetailsSaleDTO, DetailsSale>()
                 .ForMember(destiny => destiny.Price,
                opt => opt.MapFrom(origin => Convert.ToDecimal(origin.Price, new CultureInfo("pt-BR")))
                )
                  .ForMember(destiny => destiny.Total,
                opt => opt.MapFrom(origin => Convert.ToDecimal(origin.Total, new CultureInfo("pt-BR")))
                );

            #endregion Details sale

            #region Report
            CreateMap<DetailsSale, ReportDTO>()
                .ForMember(destiny => destiny.DateRegistration,
                opt => opt.MapFrom(origin => origin.IdSaleNavigation.DateRegistration.Value.ToString("dd/MM/yyyy"))
                )
                 .ForMember(destiny => destiny.NumberDocument,
                opt => opt.MapFrom(origin => origin.IdSaleNavigation.NumberDocument)
                )
                 .ForMember(destiny => destiny.typePayment,
                opt => opt.MapFrom(origin => origin.IdSaleNavigation.TypePayment)
                )
                 .ForMember(destiny => destiny.TotalSale,
                opt => opt.MapFrom(origin => Convert.ToString(origin.IdSaleNavigation.Total.Value, new CultureInfo("pt-BR")))
                )
                  .ForMember(destiny => destiny.Product,
                opt => opt.MapFrom(origin => origin.IdProductNavigation.Name)
                )
                   .ForMember(destiny => destiny.Price,
                opt => opt.MapFrom(origin => Convert.ToString(origin.Price.Value, new CultureInfo("pt-BR")))
                )
                     .ForMember(destiny => destiny.Total,
                opt => opt.MapFrom(origin => Convert.ToString(origin.Total.Value, new CultureInfo("pt-BR")))
                );
            #endregion Report

        }

    }
}
