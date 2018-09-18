using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShopConsol.Core.Domain;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Infrastructure
{
    public class OwnerDBRepository : IOwnerRepository
    {
        readonly PetContext _ctx;

        public OwnerDBRepository(PetContext ctx)
        {
            _ctx = ctx;
        }

        public Owner AddOwner(Owner newOwner)
        {
            var savedOwner = _ctx.owners.Add(newOwner).Entity;
            _ctx.SaveChanges();
            return savedOwner;
        }

        public void DeleteOwner(int id)
        {
            _ctx.owners.Remove(_ctx.owners.FirstOrDefault(owner => owner.Id == id));
            _ctx.SaveChanges();
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _ctx.owners;
        }

        public void UpdateOwner(int id, Owner newOwner)
        {
            var oldOwner = _ctx.owners.FirstOrDefault(owner => owner.Id == id);
            oldOwner.FirstName = newOwner.FirstName;
            oldOwner.LastName = newOwner.LastName;
            _ctx.SaveChanges();
        }
    }
}
