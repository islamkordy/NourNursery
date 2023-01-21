using Domain.Entities.Entity;
using Library.Helpers.Utilities;
using System.Collections.Generic;


namespace Domain.Entities.Context
{
    public class SeedData: ISeedData
    {
        public TBL_User[] ReturnUserList()
        {
            EncryptEngin _EncryptEngin = new EncryptEngin();
            var username = "admin";
            var pass  = "admin";
            var password = _EncryptEngin.Encrypt( pass, "icat2056913!", true);
            var userList = new List<TBL_User>();
            userList.AddRange(new[] {
                    new TBL_User{Id =1, UserType =1,UserName =username,Password =password,NameAr="مدير النظام",NameEn="System admin",CreateUserId =1 },
                   
                });
            return userList.ToArray();
        }


    }
}
