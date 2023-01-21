using Domain.Entities.Entity;
using Library.Helpers.APIUtilities;
using Portal.Resource.BasicInput;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModel.BasicInput
{
 public class FrontVm
    {
        public FrontVm()
        {
         //   MissionList = new List<MissionFrontVm>();  
        }
        public string Title { get; set; }
        public string About { get; set; }
        public string Vision { get; set; }

        public string ProjectTitle { get; set; }
        public string Contact { get; set; }
        public string Mission { get; set; }
        public string Value { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string FaceBook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Linkedin { get; set; }
        public string Youtube { get; set; }
        public string Logo { get; set; }
        public string Logo2 { get; set; }
        public string VisionImage { get; set; }
        public string VisionImage2 { get; set; }
        public string Video { get; set; }[Display(ResourceType = typeof(BasicInputRes), Name = "Name")]
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
        public IEnumerable<TBL_Faqs> Faqs { get; set; }
        public IEnumerable<TBL_Sliders> Sliders1 { get; set; }
        public IEnumerable<TBL_Sliders> Sliders2 { get; set; }
        public IEnumerable<TBL_Product> MainProducts { get; set; }
        public IEnumerable<TBL_Product> Products { get; set; }
        public TBL_Product ProductDetails { get; set; }
        public TBL_About AboutLast { get; set; }
    }

    public class MissionFrontVm 
    {
        public string Title { get; set; }
    
        public string ShortDesc { get; set; }
     
        public string Desc { get; set; }
     
        public string Image { get; set; }
        public string Video { get; set; }
    }
}
