
using Afaqy.Erp.DataLayer.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Entity
{
    [Table(name: "TBL_ContactUs", Schema = "dbo")]
    public class TBL_ContactUs : GeneralTable<int>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string HoteName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }

}
