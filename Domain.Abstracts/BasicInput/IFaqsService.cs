
using Domain.Entities.Entity;
using Domain.Services.Base;
using Models.ViewModel.Administration;
using Models.ViewModel.BasicInput;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstracts.BasicInput
{
   public interface IFaqsService : IBaseService<TBL_Faqs, FaqsVm, FaqsVm, int, int>
    {
    }
}
