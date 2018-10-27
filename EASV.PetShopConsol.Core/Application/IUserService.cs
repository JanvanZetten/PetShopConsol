using System;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Core.Application
{
    public interface IUserService
    {
        User GetWhereUsername(string username);
    }
}
