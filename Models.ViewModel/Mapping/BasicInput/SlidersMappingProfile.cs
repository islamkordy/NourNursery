using Domain.Entities.Entity;
using Library.Helpers.Utilities;
using Models.ViewModel.BasicInput;

namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile
    {
        private void SlidersMappingProfile()
        {

            CreateMap<TBL_Sliders, SlidersVm>();
            CreateMap<SlidersVm, TBL_Sliders>();
        }
    }
}

