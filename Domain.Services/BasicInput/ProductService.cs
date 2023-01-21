using AutoMapper;
using Domain.Abstracts.BasicInput;
using Domain.Entities.Entity;
using Domain.Services.Base;
using Library.Helpers.APIUtilities;
using Library.Helpers.UnitOfWork;
using Models.ViewModel.BasicInput;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services.BasicInput
{

    public class ProductService : BaseService<TBL_Product, ProductVm, ProductVm, int, int>, IProductService
    {
        public ProductService(IRepositoryActionResult repositoryActionResult, IUnitOfWork<TBL_Product, int> unitOfWork, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor, IMapper _mapper)
             : base(repositoryActionResult, unitOfWork, httpContextAccessor, _mapper)
        {

        }

        //public async Task<IEnumerable<MediaVm>> GetAllByTypeAsync(int type)
        //{
        //    var model = await _unitOfWork.Repository.FindAsync(t => t.Type == type);
        //    return _mapper.Map<IEnumerable<MediaVm>>(model);
        //}
    }
}
