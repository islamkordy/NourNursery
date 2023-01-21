using Domain.Entities.Entity;
using Library.Helpers.Utilities;
using Models.ViewModel.BasicInput;

namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile
    {
        private void FaqsMappingProfile()
        {

            CreateMap<TBL_Faqs, FaqsVm>();
            //.ForMember(dest => dest.ConditionerTypeName, opt => opt.MapFrom(src => ResourcesReader.IsArabic ? src.ConditionerType == null?"": src.ConditionerType.NameAr : src.ConditionerType== null?"": src.ConditionerType.NameEn))
            //.ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => ResourcesReader.IsArabic ? src.RoomType ==null? "":src.RoomType.NameAr : src.RoomType == null?"": src.RoomType.NameEn));
            CreateMap<FaqsVm, TBL_Faqs>();

            CreateMap<TBL_FaqsDetails, FaqsDetailsVm>();
            CreateMap<FaqsDetailsVm, TBL_FaqsDetails>();

        }
    }
}

