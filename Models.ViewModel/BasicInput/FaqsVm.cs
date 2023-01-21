using Library.Helpers.APIUtilities;
using Portal.Resource.BasicInput;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModel.BasicInput
{
 public class FaqsVm : ViewModel, IEntityDto<int>
    {
        [Display(ResourceType = typeof(BasicInputRes), Name = "TitleAr")]
        public string TitleAr { get; set; }

        [Display(ResourceType = typeof(BasicInputRes), Name = "TitleEn")]
        public string TitleEn { get; set; }
        public List<FaqsDetailsVm> FaqsDetails { get; set; }
        public string FaqsDetailsStr { get; set; }

        public int DetailId { get; set; }

        [Display(ResourceType = typeof(BasicInputRes), Name = "QuestionAr")]
        public string QuestionAr { get; set; }

        [Display(ResourceType = typeof(BasicInputRes), Name = "QuestionEn")]
        public string QuestionEn { get; set; }

        [Display(ResourceType = typeof(BasicInputRes), Name = "DescAr")]
        public string DescAr { get; set; }

        [Display(ResourceType = typeof(BasicInputRes), Name = "DescEn")]
        public string DescEn { get; set; }
    }

    public class FaqsDetailsVm : ViewModel, IEntityDto<int>
    {
        public int FaqsId { get; set; }

        [Display(ResourceType = typeof(BasicInputRes), Name = "DescAr")]
        public string DescAr { get; set; }

        [Display(ResourceType = typeof(BasicInputRes), Name = "DescEn")]
        public string DescEn { get; set; }

        [Display(ResourceType = typeof(BasicInputRes), Name = "QuestionAr")]
        public string QuestionAr { get; set; }

        [Display(ResourceType = typeof(BasicInputRes), Name = "QuestionEn")]
        public string QuestionEn { get; set; }
        public int CreateUserId { get; set; }

    }
}
