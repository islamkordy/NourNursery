
using Domain.Entities.Entity;
using Domain.Services.Base;
using Models.ViewModel.Administration;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstracts.Administration
{
   public interface IUserService: IBaseService<TBL_User, UserVm, UserVm, int, int>
    {
        Task<TBL_User> UserLogin(LoginModelVm model);
    }
}
