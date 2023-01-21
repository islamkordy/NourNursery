using Domain.Entities.Entity;
using Domain.Services.Base;
using Models.ViewModel.BasicInput;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Abstracts.BasicInput
{
    public interface ICategoryService : IBaseService<TBL_Category, CategoryVm, CategoryVm, int, int>
    {
    }
}
