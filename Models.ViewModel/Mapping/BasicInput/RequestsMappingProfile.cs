using Domain.Entities.Entity;
using Library.Helpers.Utilities;
using Models.ViewModel.BasicInput;

namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile
    {
        private void RequestsMappingProfile()
        {

            CreateMap<TBL_ContactUs, ContactUsVm>()
               .ForMember(dest => dest.ContactPhone, opt => opt.MapFrom(src => src.Phone))
               .ForMember(dest => dest.ContactEmail, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.ContactDescription, opt => opt.MapFrom(src => src.Description));
              
            CreateMap<ContactUsVm, TBL_ContactUs>();

        }
    }           
}               
                
                