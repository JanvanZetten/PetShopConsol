using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShopConsol.Core.Domain;
using EASV.PetShopConsol.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace EASV.PetShopConsol.InfrastructureEntityFramework
{
    public class PetDBRepository : IPetRepository
    {
        readonly PetConsolContext _ctx;
        readonly IOwnerRepository _ownerRepo;

        public PetDBRepository(PetConsolContext ctx, IOwnerRepository ownerRepo)
        {
            _ctx = ctx;
            _ownerRepo = ownerRepo;
        }

        public int CountPets()
        {
            return _ctx.Pets.Count();
        }

        public void DeletePet(Pet pet)
        {
            _ctx.Pets.Remove(pet);
            _ctx.SaveChanges();
        }

        public void EditPet(Pet petForEditing)
        {
            _ctx.Attach(petForEditing).State = EntityState.Modified;
            _ctx.Entry(petForEditing).Reference(p => p.PreviousOwner).IsModified = true;
            _ctx.Entry(petForEditing).Reference(p => p.PetColors).IsModified = true;

            _ctx.SaveChanges();
        }

        public IEnumerable<Pet> GetPets()
        {
            return _ctx.Pets;
        }

        public IEnumerable<Pet> GetPetsWithOwner()
        {
            return _ctx.Pets.Include(p => p.PreviousOwner).Include(p => p.PetColors);
        }

        public Pet SavePet(Pet pet)
        {
            pet.Id = 0;

            _ctx.Attach(pet).State = EntityState.Added;
            _ctx.SaveChanges();
            return pet;
        }
    }
}
