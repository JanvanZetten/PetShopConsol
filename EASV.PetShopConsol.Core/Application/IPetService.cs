using System;
using System.Collections.Generic;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Core.Application
{
    public interface IPetService
    {
        Pet MakeNewPet(string name, AnimalType type, int birthyear, int birthmonth, int birthday, string color, string previousOwner, double price);
        Pet SavePet(Pet pet);
        List<Pet> GetAllPets();
        List<Pet> GetPetsWithType(AnimalType petType);
        void DeletePetById(int idForDeleting);
        Pet GetPetById(int id);
        void EditPet(Pet petForEditing);
        List<Pet> GetAllPetsSortedByPrice();
        List<Pet> GetCheapestPets(int amount);
    }
}
