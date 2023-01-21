using Library.Helpers.APIUtilities;
using Portal.Resource.BasicInput;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModel.BasicInput
{
 public class CategoryVm : ViewModel, IEntityDto<int>
    {
        [Display(ResourceType = typeof(BasicInputRes), Name = "NameAr")]
        public string NameAr { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "NameEn")]
        public string NameEn { get; set; }
    }
}
