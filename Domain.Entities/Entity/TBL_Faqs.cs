
using Afaqy.Erp.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Entity
{
    [Table(name: "TBL_Faqs", Schema = "dbo")]
    public class TBL_Faqs : GeneralTable<int>
    {
        public TBL_Faqs()
        {
            FaqsDetails = new HashSet<TBL_FaqsDetails>();
        }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public virtual ICollection<TBL_FaqsDetails> FaqsDetails { get; set; }
    }

    [Table(name: "TBL_FaqsDetails", Schema = "dbo")]
    public class TBL_FaqsDetails : GeneralTable<int>
    {
        public int FaqsId { get; set; }
        public string QuestionAr { get; set; }
        public string QuestionEn { get; set; }
        public string DescAr { get; set; }
        public string DescEn { get; set; }
        [ForeignKey("FaqsId")]
        public virtual TBL_Faqs Faqs { get; set; }

    }

}
