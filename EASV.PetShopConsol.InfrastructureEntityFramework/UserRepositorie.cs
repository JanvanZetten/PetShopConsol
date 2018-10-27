using System;
using System.Collections.Generic;
using EASV.PetShopConsol.Core.Domain;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.InfrastructureEntityFramework
{
    public class UserRepositorie: IUserRepositorie
    {
        readonly PetConsolContext _ctx;
        public UserRepositorie(PetConsolContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<User> GetAll()
        {
            return _ctx.Users;
        }
    }
}
