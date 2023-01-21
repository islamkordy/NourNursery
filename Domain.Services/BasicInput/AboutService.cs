using AutoMapper;
using Domain.Abstracts.BasicInput;
using Domain.Entities.Context;
using Domain.Entities.Entity;
using Domain.Services.Base;
using Library.Helpers.APIUtilities;
using Library.Helpers.UnitOfWork;
using Models.ViewModel.BasicInput;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services.BasicInput
{

    public class AboutService : BaseService<TBL_About, AboutVm, AboutVm, int, int>, IAboutService
    {
        public AboutService(IRepositoryActionResult repositoryActionResult, IUnitOfWork<TBL_About, int> unitOfWork, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor, IMapper _mapper)
             : base(repositoryActionResult, unitOfWork, httpContextAccessor, _mapper)
        {

        }

     
    }
    //public class AboutVmService : BaseService2<TBL_AboutVm>//, IAboutVmService
    //{
    //    public AboutVmService(IRepositoryActionResult repositoryActionResult, IUnitOfWork<TBL_AboutVm,int> unitOfWork, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)
    //         : base(repositoryActionResult, unitOfWork, httpContextAccessor)
    //    {

    //    }

    //    //public async Task<TBL_AboutVm> AboutVmLogin(LoginModelVm model)
    //    //{
    //    //    var AboutVm =await _unitOfWork.Repository.FirstOrDefaultAsync(q=>q.AboutVmName == model.AboutVmname && q.Password == model.Password);
    //    //    return AboutVm;
    //    //}


    //    public  async Task<IList<AboutVmVm>> GetAllAsync(bool disableTracking = false)
    //    {

    //        var query = await _unitOfWork.Repository.GetAllAsync();
    //        var data = _mapper.Map<IList<TBL_AboutVm>, IList<AboutVmVm>>(query.ToList());
    //        return data;

    //    }

    //    public virtual async Task<bool> AddAsync(AboutVmVm model)
    //    {

    //        var entity = _mapper.Map<AboutVmVm, TBL_AboutVm>(model);
    //        entity.CreateUserId = UserData.UserId;
    //        //SetEntityCreatedBaseProperties(entity);
    //        _unitOfWork.Repository.Add(entity);
    //        bool affectedRows = await _unitOfWork.SaveChanges()> 0;
    //        return affectedRows;

    //    }


    //   public virtual async Task<bool> UpdateAsync(AboutVmVm model)
    //    {

    //        var entity = _mapper.Map<AboutVmVm, TBL_AboutVm>(model);
    //        entity.CreateUserId = UserData.UserId;
    //        //SetEntityCreatedBaseProperties(entity);
    //        _unitOfWork.Repository.Update(entity);
    //        bool affectedRows = await _unitOfWork.SaveChanges() > 0;
    //        return affectedRows;

    //    }
    //}
}
