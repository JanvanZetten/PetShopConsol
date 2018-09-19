using System;
using System.Linq;
using System.Collections.Generic;
using EASV.PetShopConsol.Core.Domain;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Infrastructure
{
    public class PetMockRepository : IPetRepository
    {
        private readonly PetMockDB mockDB = new PetMockDB();

        public void DeletePet(Pet pet)
        {
            mockDB.DeletePet(pet);
        }

        public void EditPet(Pet petForEditing)
        {
            mockDB.UpdatePet(petForEditing);
        }

        public IEnumerable<Pet> GetPets()
        {
            return mockDB.SelectAllFromPets();
        }

        public IEnumerable<Pet> GetPetsWithOwner()
        {
            throw new NotImplementedException();
        }

        public Pet SavePet(Pet pet)
        {
            return mockDB.InsertIntoPets(pet);
        }
    }
}
