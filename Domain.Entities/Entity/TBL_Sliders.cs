
using Afaqy.Erp.DataLayer.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Entity
{
    [Table(name: "TBL_Sliders", Schema = "dbo")]
    public class TBL_Sliders : GeneralTable<int>
    {
        public string DescAr { get; set; }
        public string DescEn { get; set; }
        public string Image { get; set; }
        public int Type { get; set; }
    }

}
