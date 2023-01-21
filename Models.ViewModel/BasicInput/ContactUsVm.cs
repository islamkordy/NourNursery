using Library.Helpers.APIUtilities;
using Portal.Resource.BasicInput;
using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModel.BasicInput
{
 public class ContactUsVm : ViewModel, IEntityDto<int>
    {
        [Display(ResourceType = typeof(BasicInputRes), Name = "Name")]
        public string Name { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "Phone")]
        public string ContactPhone { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "Email")]
        public string ContactEmail { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "Description")]
        public string ContactDescription { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string HoteName { get; set; }
        [Display(ResourceType = typeof(BasicInputRes), Name = "CreateDate")]
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
