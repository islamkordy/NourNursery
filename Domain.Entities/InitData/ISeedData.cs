using Domain.Entities.Entity;
using System;
using System.Collections.Generic;


namespace Domain.Entities.Context
{
    public interface ISeedData
    {
        TBL_User[] ReturnUserList();
    }
}
