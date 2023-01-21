using AutoMapper;
using Domain.Abstracts.Administration;
using Domain.Entities.Entity;
using Domain.Services.Base;
using Library.Helpers.APIUtilities;
using Library.Helpers.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Models.ViewModel.Administration;

using System.Threading.Tasks;

namespace Domain.Services.Administration
{
    public class UserService : BaseService<TBL_User, UserVm, UserVm, int,int>, IUserService
    {
        public UserService(IRepositoryActionResult repositoryActionResult, IUnitOfWork<TBL_User,int> unitOfWork, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor, IMapper _mapper)
             : base(repositoryActionResult, unitOfWork, httpContextAccessor, _mapper)
        {

        }

        public async Task<TBL_User> UserLogin(LoginModelVm model)
        {
            var user = await _unitOfWork.Repository.FirstOrDefaultAsync(q => q.UserName == model.Username && q.Password == model.Password);
            return user;
        }
    }
}
