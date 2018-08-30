using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Infrastructure
{
    public class PetMockDB
    {
        private IEnumerable<Pet> pets = new List<Pet>();
        private int nextId = 1;

        internal Pet InsertIntoPets(Pet petToSave){
            petToSave.Id = nextId++;

            var asList = pets.ToList();
            asList.Add(petToSave);
            pets = asList;
            return petToSave;
        }

        internal IEnumerable<Pet> SelectAllFromPets()
        {
            return pets;
        }
    }
}
