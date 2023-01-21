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

    public class FaqsService : BaseService<TBL_Faqs, FaqsVm, FaqsVm, int, int>, IFaqsService
    {
        public FaqsService(IRepositoryActionResult repositoryActionResult, IUnitOfWork<TBL_Faqs, int> unitOfWork, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor, IMapper _mapper)
             : base(repositoryActionResult, unitOfWork, httpContextAccessor, _mapper)
        {

        }

     
    }
    //public class PortfolioVmService : BaseService2<TBL_PortfolioVm>//, IPortfolioVmService
    //{
    //    public PortfolioVmService(IRepositoryActionResult repositoryActionResult, IUnitOfWork<TBL_PortfolioVm,int> unitOfWork, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)
    //         : base(repositoryActionResult, unitOfWork, httpContextAccessor)
    //    {

    //    }

    //    //public async Task<TBL_PortfolioVm> PortfolioVmLogin(LoginModelVm model)
    //    //{
    //    //    var PortfolioVm =await _unitOfWork.Repository.FirstOrDefaultAsync(q=>q.PortfolioVmName == model.PortfolioVmname && q.Password == model.Password);
    //    //    return PortfolioVm;
    //    //}


    //    public  async Task<IList<PortfolioVmVm>> GetAllAsync(bool disableTracking = false)
    //    {

    //        var query = await _unitOfWork.Repository.GetAllAsync();
    //        var data = _mapper.Map<IList<TBL_PortfolioVm>, IList<PortfolioVmVm>>(query.ToList());
    //        return data;

    //    }

    //    public virtual async Task<bool> AddAsync(PortfolioVmVm model)
    //    {

    //        var entity = _mapper.Map<PortfolioVmVm, TBL_PortfolioVm>(model);
    //        entity.CreateUserId = UserData.UserId;
    //        //SetEntityCreatedBaseProperties(entity);
    //        _unitOfWork.Repository.Add(entity);
    //        bool affectedRows = await _unitOfWork.SaveChanges()> 0;
    //        return affectedRows;

    //    }


    //   public virtual async Task<bool> UpdateAsync(PortfolioVmVm model)
    //    {

    //        var entity = _mapper.Map<PortfolioVmVm, TBL_PortfolioVm>(model);
    //        entity.CreateUserId = UserData.UserId;
    //        //SetEntityCreatedBaseProperties(entity);
    //        _unitOfWork.Repository.Update(entity);
    //        bool affectedRows = await _unitOfWork.SaveChanges() > 0;
    //        return affectedRows;

    //    }
    //}
}
