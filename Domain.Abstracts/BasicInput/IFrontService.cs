
using Domain.Entities.Entity;
using Domain.Services.Base;
using Models.ViewModel.Administration;
using Models.ViewModel.BasicInput;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstracts.BasicInput
{
   public interface IFrontService 
    {
        Task<FrontVm> GetAllFrontData();
        Task<FrontVm> GetAllFrontProductDetails(int Id);
        Task<FrontVm> GetAllFrontProductData();
        Task<FrontVm> GetAllFrontDataFaqs();
        Task<bool> AddAsync(ContactUsVm model);
    }
}
