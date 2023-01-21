using Domain.Entities.Entity;
using Domain.Services.Base;
using Models.ViewModel.BasicInput;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Abstracts.BasicInput
{
   public interface ISlidersService : IBaseService<TBL_Sliders, SlidersVm, SlidersVm, int, int>
    {
        Task<IEnumerable<SlidersVm>> GetAllByTypeAsync(int type);
    }
}
