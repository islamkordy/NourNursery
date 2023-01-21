using System.Collections.Generic;
using System.Threading.Tasks;
using Afaqy.Erp.DataLayer.Base;
using Library.Helpers.APIUtilities;

namespace Domain.Services.Base
{
    public interface IBaseService<T, TDto, TGetDto, TKey , TKeyDto>
        where T : GeneralTable<TKey>
        where TDto : IEntityDto<TKeyDto>
        where TGetDto : IEntityDto<TKeyDto>
    {
        Task<IEnumerable<TGetDto>> GetAllAsync(bool disableTracking = false);
        Task<bool> AddAsync(TDto model);
        Task<bool> AddListAsync(List<TDto> model);
        Task<bool> UpdateAsync(TDto model);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteSoftAsync(int id);
        Task<TGetDto> GetByIdAsync(int id);
    }
}