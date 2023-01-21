using Domain.Entities.Entity;
using Library.Helpers.Utilities;
using Models.ViewModel.BasicInput;

namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile
    {
        private void ProductMappingProfile()
        {

            CreateMap<TBL_Product, ProductVm>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => ResourcesReader.IsArabic ? src.Category == null ? "" : src.Category.NameAr : src.Category == null ? "" : src.Category.NameEn));
            //.ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => ResourcesReader.IsArabic ? src.RoomType ==null? "":src.RoomType.NameAr : src.RoomType == null?"": src.RoomType.NameEn));
            CreateMap<ProductVm, TBL_Product>();

        }
    }
}

