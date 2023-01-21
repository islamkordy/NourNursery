using Domain.Entities.Entity;
using Library.Helpers.Utilities;
using Models.ViewModel.BasicInput;

namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile
    {
        private void AboutMappingProfile()
        {

            CreateMap<TBL_About, AboutVm>();
               //.ForMember(dest => dest.ConditionerTypeName, opt => opt.MapFrom(src => ResourcesReader.IsArabic ? src.ConditionerType == null?"": src.ConditionerType.NameAr : src.ConditionerType== null?"": src.ConditionerType.NameEn))
               //.ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => ResourcesReader.IsArabic ? src.RoomType ==null? "":src.RoomType.NameAr : src.RoomType == null?"": src.RoomType.NameEn));
            CreateMap<AboutVm,TBL_About>();

        }
    }           
}               
                
                