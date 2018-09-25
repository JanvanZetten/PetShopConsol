using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShopConsol.Core.Domain;
using EASV.PetShopConsol.Core.Entity;
using Microsoft.EntityFrameworkCore;

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
            _ctx.Attach(newOwner).State = EntityState.Added;
            _ctx.SaveChanges();
            return newOwner;
        }

        public void DeleteOwner(int id)
        {
            _ctx.Owners.Remove(new Owner { Id = id });
            _ctx.SaveChanges();
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _ctx.Owners;
        }

        public void UpdateOwner(int id, Owner newOwner)
        {
            newOwner.Id = id;
            _ctx.Attach(newOwner).State = EntityState.Modified;
            _ctx.SaveChanges();

        }
    }
}
