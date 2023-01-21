using Domain.Abstracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NourNursery.Portal.CustomAttributes
{
    public interface ICommonService
    {

        Task<List<SelectListItem>> FindAllCategory(int selectedValue = 0);
        //Task<List<SelectListItem>> FindAllConditionerTypes(int selectedValue = 0);
        //Task<List<SelectListItem>> FindAllFurnitures(int selectedValue = 0);
        //Task<List<SelectListItem>> FindAllFurnitureStatus(int selectedValue = 0);
        //Task<List<SelectListItem>> FindAllRooms(int selectedValue = 0);
        //Task<List<SelectListItem>> FindAllTaxApply(int selectedValue = 0);
        //Task<List<SelectListItem>> FindAllTaxType(int selectedValue = 0);
    }
}
