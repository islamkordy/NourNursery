
using Afaqy.Erp.DataLayer.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Entity
{
    [Table(name: "TBL_Category", Schema = "dbo")]
    public class TBL_Category : GeneralTable<int>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
    }

}
