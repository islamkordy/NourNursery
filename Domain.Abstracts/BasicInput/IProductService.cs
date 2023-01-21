using Domain.Entities.Entity;
using Domain.Services.Base;
using Models.ViewModel.BasicInput;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Abstracts.BasicInput
{
    public interface IProductService : IBaseService<TBL_Product, ProductVm, ProductVm, int, int>
    {
    }
}
