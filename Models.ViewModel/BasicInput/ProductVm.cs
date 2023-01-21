using Library.Helpers.APIUtilities;
using Portal.Resource.BasicInput;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModel.BasicInput
{
 public class ProductVm : ViewModel, IEntityDto<int>
    {
        [Display(ResourceType = typeof(BasicInputRes), Name = "TitleAr")]
        public string TitleAr { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "TitleEn")]
        public string TitleEn { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "DescAr")]
        public string DescAr { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "DescEn")]
        public string DescEn { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "DescAr2")]
        public string DescAr2 { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "DescEn2")]
        public string DescEn2 { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "IsMainPage")]
        public bool IsMainPage { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "Image1")]
        public string Image1 { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "Image2")]
        public string Image2 { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "Image3")]
        public string Image3 { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "Image4")]
        public string Image4 { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "Image5")]
        public string Image5 { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "CategoryId")]
        public int? CategoryId { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "CategoryId")]
        public string CategoryName { get; set; }

    }
}
