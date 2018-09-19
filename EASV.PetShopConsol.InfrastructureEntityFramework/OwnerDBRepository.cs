using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShopConsol.Core.Domain;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.InfrastructureEntityFramework
{
    public class OwnerDBRepository : IOwnerRepository
    {
        readonly PetConsolContext _ctx;

        public OwnerDBRepository(PetConsolContext ctx)
        {
            _ctx = ctx;
        }

        public Owner AddOwner(Owner newOwner)
        {
            var savedOwner = _ctx.Owners.Add(newOwner).Entity;
            _ctx.SaveChanges();
            return savedOwner;
        }

        public void DeleteOwner(int id)
        {
            _ctx.Owners.Remove(_ctx.Owners.FirstOrDefault(owner => owner.Id == id));
            _ctx.SaveChanges();
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _ctx.Owners;
        }

        public void UpdateOwner(int id, Owner newOwner)
        {
            var oldOwner = _ctx.Owners.FirstOrDefault(owner => owner.Id == id);
            oldOwner.FirstName = newOwner.FirstName;
            oldOwner.LastName = newOwner.LastName;
            _ctx.SaveChanges();
        }
    }
}
