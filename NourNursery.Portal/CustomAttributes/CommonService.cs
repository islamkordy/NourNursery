using Domain.Abstracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NourNursery.Portal.CustomAttributes
{
    public class CommonService : ICommonService
    {
        private readonly ILookupService _lookupService;

        #region Constructor
        public CommonService(ILookupService lookupService)
        {

            _lookupService = lookupService;
        }
        private static SelectListItem Clone(KeyValueLookup model, int selectedValue = 0)
        {
            return new SelectListItem
            {
                Text = model.Text,
                Value = model.Value.ToString(),
                Selected = selectedValue == model.Value
            };
        }

        #endregion
        public async Task<List<SelectListItem>> FindAllCategory(int selectedValue = 0)
        {
            var categories = await _lookupService.FindAllCategory();
            var list = new List<SelectListItem>();
            list.AddRange(categories.Select(m => Clone(m, selectedValue = 0)).ToList());
            return list;
        }


    }
}
