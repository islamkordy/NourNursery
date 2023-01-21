
using Domain.Entities.Entity;
using Domain.Services.Base;
using Models.ViewModel.Administration;
using Models.ViewModel.BasicInput;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstracts.BasicInput
{
   public interface IAboutService : IBaseService<TBL_About, AboutVm, AboutVm, int, int>
    {
    }
}
