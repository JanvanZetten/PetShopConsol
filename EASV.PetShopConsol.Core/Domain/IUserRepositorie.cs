using System;
using System.Collections.Generic;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Core.Domain
{
    public interface IUserRepositorie
    {
        IEnumerable<User> GetAll();
    }
}
