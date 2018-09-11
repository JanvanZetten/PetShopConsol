using System;
using System.Collections.Generic;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Core.Application
{
    public interface IOwnerService
    {
        List<Owner> GetAllOwners();
        Owner GetOwner(int id);
        void AddOwner(Owner newOwner);
        void Delete(int id);
        void UpdateOwner(int id, Owner owner);
    }
}
