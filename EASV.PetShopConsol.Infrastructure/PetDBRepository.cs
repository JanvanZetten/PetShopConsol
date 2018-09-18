using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShopConsol.Core.Domain;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Infrastructure
{
    public class PetDBRepository : IPetRepository
    {
        readonly PetContext _ctx;

        public PetDBRepository(PetContext ctx)
        {
            _ctx = ctx;
        }


        public void DeletePet(Pet pet)
        {
            _ctx.pets.Remove(pet);
        }

        public void EditPet(Pet petForEditing)
        {
            var oldPet = _ctx.pets.FirstOrDefault(pet => pet.Id == petForEditing.Id);
            oldPet.Birthday = petForEditing.Birthday;
            oldPet.Color = petForEditing.Color;
            oldPet.Name = petForEditing.Name;
            oldPet.PreviousOwner = petForEditing.PreviousOwner;
            oldPet.Price = petForEditing.Price;
            oldPet.Type = petForEditing.Type;
            _ctx.SaveChanges();
        }

        public IEnumerable<Pet> GetPets()
        {
            return _ctx.pets;
        }

        public Pet SavePet(Pet pet)
        {
            var made = _ctx.pets.Add(pet).Entity;
            _ctx.SaveChanges();
            return made;
        }
    }
}
