using Library.Helpers.APIUtilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ViewModel.Administration
{
  public class UserVm : ViewModel, IEntityDto<int>
    {

        public int? UserType { get; set; }
        public int? EmployeeId { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
