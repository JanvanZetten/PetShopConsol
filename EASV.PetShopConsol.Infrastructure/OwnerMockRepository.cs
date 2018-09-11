using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShopConsol.Core.Domain;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Infrastructure
{
    public class OwnerMockRepository :IOwnerRepository
    {
        public OwnerMockRepository()
        {
            OwnerMockDB.AddMockdataIfEmpty();
        }

        public Owner AddOwner(Owner newOwner)
        {
            newOwner.Id = OwnerMockDB.NextID();
            var aslist = OwnerMockDB.Owners.ToList();
            aslist.Add(newOwner);
            OwnerMockDB.Owners = aslist;
            return newOwner;
        }

        public void DeleteOwner(int id)
        {
            OwnerMockDB.Owners = OwnerMockDB.Owners.Where(owner => owner.Id != id);
        }

        public IEnumerable<Owner> GetOwners()
        {
            return OwnerMockDB.Owners;
        }

        public void UpdateOwner(int id, Owner newOwner)
        {
            newOwner.Id = id;
            OwnerMockDB.Owners = OwnerMockDB.Owners.Select(ownerFromList => ownerFromList.Id == id ? newOwner : ownerFromList).ToList();
        }
    }
}
