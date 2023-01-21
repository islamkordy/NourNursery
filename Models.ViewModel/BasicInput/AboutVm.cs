using Library.Helpers.APIUtilities;
using Portal.Resource.BasicInput;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModel.BasicInput
{
 public class AboutVm : ViewModel, IEntityDto<int>
    {
        [Display(ResourceType = typeof(BasicInputRes), Name = "TitleAr")]
        public string TitleAr { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "TitleEn")]
        public string TitleEn { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "AboutAr")]
        public string AboutAr { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "AboutEn")]
        public string AboutEn { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "DescAr")]
        public string DescAr { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "DescEn")]
        public string DescEn { get; set; }

        [Display(ResourceType = typeof(BasicInputRes), Name = "ValueAr")]
        public string ValueAr { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "ValueEn")]
        public string ValueEn { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "VisionAr")]
        public string VisionAr { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "VisionEn")]
        public string VisionEn { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "MissionAr")]
        public string MissionAr { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "MissionEn")]
        public string MissionEn { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "ContactAr")]
        public string ContactAr { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "ContactEn")]
        public string ContactEn { get; set; }

        [Display(ResourceType = typeof(BasicInputRes), Name = "ProjectTitleAr")]
        public string ProjectTitleAr { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "ProjectTitleEn")]
        public string ProjectTitleEn { get; set; }


        [Display(ResourceType = typeof(BasicInputRes), Name = "Email")]
        public string Email { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "Phone")]
        public string Phone { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "Mobile")]
        public string Mobile { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "AddressAr")]
        public string AddressAr { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "AddressEn")]
        public string AddressEn { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "FaceBook")]
        public string FaceBook { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "Twitter")]
        public string Twitter { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "Instagram")]
        public string Instagram { get; set; }

        [Display(ResourceType = typeof(BasicInputRes), Name = "Linkedin")]
        public string Linkedin { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "Youtube")]
        public string Youtube { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "Logo")]
        public string Logo { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "Logo2")]
        public string Logo2 { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "Image")]
        public string VisionImage { get; set; }

    }
}
