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


        public void DeletePet(Pet pet)
        {
            _ctx.Pets.Remove(pet);
        }

        public void EditPet(Pet petForEditing)
        {
            if (petForEditing.PreviousOwner.Id > 0)
            {
                petForEditing.PreviousOwner = new Owner() { Id = petForEditing.Id };
                _ctx.Attach(petForEditing.PreviousOwner);
            }
            _ctx.Update<Pet>(petForEditing);
            
            _ctx.SaveChanges();
        }

        public IEnumerable<Pet> GetPets()
        {
            return _ctx.Pets;
        }

        public IEnumerable<Pet> GetPetsWithOwner()
        {
            return _ctx.Pets.Include(p => p.PreviousOwner);
        }

        public Pet SavePet(Pet pet)
        {
            var made = _ctx.Pets.Add(pet).Entity;
            _ctx.SaveChanges();
            return made;
        }
    }
}
