using Domain.Entities.Entity;
using Library.Helpers.Utilities;
using Models.ViewModel.Administration;
using Models.ViewModel.BasicInput;

namespace Models.ViewModel.Mapping
{
    public partial class AutoMapperProfile
    {
        private void UserMappingProfile()
        {

            CreateMap<TBL_User, UserVm>();
            CreateMap<UserVm, TBL_User>();

        }
    }           
}               
                
                