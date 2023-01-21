
using Afaqy.Erp.DataLayer.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Entity
{
    [Table(name: "TBL_Product", Schema = "dbo")]
    public class TBL_Product : GeneralTable<int>
    {
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string DescAr { get; set; }
        public string DescEn { get; set; }
        public string DescAr2 { get; set; }
        public string DescEn2 { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }
        public int? CategoryId { get; set; }
        public bool IsMainPage { get; set; }
        [ForeignKey("CategoryId")]
        public virtual TBL_Category Category { get; set; }
    }

}
