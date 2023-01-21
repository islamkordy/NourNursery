
using Afaqy.Erp.DataLayer.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Entity
{
    [Table(name: "TBL_About", Schema = "dbo")]
    public class TBL_About : GeneralTable<int>
    {
     

        public string AboutAr { get; set; }
        public string AboutEn { get; set; }

        public string TitleAr { get; set; }
        public string TitleEn { get; set; }

        public string DescAr { get; set; }
        public string DescEn { get; set; }
        public string ValueAr { get; set; }
        public string ValueEn { get; set; }
        public string VisionAr { get; set; }
        public string VisionEn { get; set; }
        public string MissionAr { get; set; }
        public string MissionEn { get; set; }
        public string ContactAr { get; set; }
        public string ContactEn { get; set; }
        public string ProjectTitleAr { get; set; }
        public string ProjectTitleEn { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string AddressAr { get; set; }
        public string AddressEn { get; set; }

        public string FaceBook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Linkedin { get; set; }
        public string Youtube { get; set; }


        public string Logo { get; set; }
        public string Logo2 { get; set; }
        public string VisionImage { get; set; }
        public string VisionImage2 { get; set; }
        public string Video { get; set; }
    
    }

}
