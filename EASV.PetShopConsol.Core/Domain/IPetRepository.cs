using System;
using System.Collections.Generic;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Core.Domain
{
    public interface IPetRepository
    {
        Pet SavePet(Pet pet);
        IEnumerable<Pet> GetPets();
        IEnumerable<Pet> GetPetsWithOwner();
        void DeletePet(Pet pet);
        void EditPet(Pet petForEditing);
        int CountPets();
    }
}
