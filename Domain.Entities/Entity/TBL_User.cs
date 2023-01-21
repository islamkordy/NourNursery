
using Afaqy.Erp.DataLayer.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Entity
{
    [Table(name: "TBL_User", Schema = "dbo")]
    public class TBL_User : GeneralTable<int>
    {
       
        public int? UserType { get; set; }
        public int? EmployeeId { get; set; }
        public int? HousekeeperId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
