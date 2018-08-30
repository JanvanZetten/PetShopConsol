using System;
using System.Collections.Generic;
using EASV.PetShopConsol.Core.Domain;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Infrastructure
{
    public class PetMockRepository : IPetRepository
    {
        private readonly PetMockDB mockDB = new PetMockDB();

        public IEnumerable<Pet> GetPets()
        {
            return mockDB.SelectAllFromPets();
        }

        public Pet SavePet(Pet pet)
        {
            return mockDB.InsertIntoPets(pet);
        }
    }
}
