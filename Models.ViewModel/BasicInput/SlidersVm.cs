using Library.Helpers.APIUtilities;
using Portal.Resource.BasicInput;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModel.BasicInput
{
 public class SlidersVm : ViewModel, IEntityDto<int>
    {
        [Display(ResourceType = typeof(BasicInputRes), Name = "DescAr")]
        public string DescAr { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "DescEn")]
        public string DescEn { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "Image")]
        public string Image { get; set; }
        public int Type { get; set; }
    }

}
