using System;
using System.Collections.Generic;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Core.Domain
{
    public interface IOwnerRepository
    {
        Owner AddOwner(Owner newOwner);
        IEnumerable<Owner> GetOwners();
        void DeleteOwner(int id);
        void UpdateOwner(int id, Owner newOwner);
    }
}
