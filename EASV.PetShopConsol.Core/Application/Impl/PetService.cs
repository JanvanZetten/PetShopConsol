using System;
using System.Collections.Generic;
using EASV.PetShopConsol.Core.Domain;
using EASV.PetShopConsol.Core.Entity;
using System.Linq;

namespace EASV.PetShopConsol.Core.Application.Impl
{
    public class PetService: IPetService
    {
        private readonly IPetRepository _PetRepo;
        public PetService(IPetRepository petRepository)
        {
            _PetRepo = petRepository;
        }

        public List<Pet> GetAllPets()
        {
            return _PetRepo.GetPets().ToList();
        }

        public Pet MakeNewPet(string name, AnimalType type, int birthyear, int birthmonth, int birthday, string color, string previousOwner, double price)
        {
            var birthDate = new DateTime(birthyear, birthmonth, birthday);

            return new Pet() { Name = name, Type = type, Birthday = birthDate, Color = color, PreviousOwner = previousOwner, Price = price };
        }

        public Pet SavePet(Pet pet)
        {
            return _PetRepo.SavePet(pet);
        }
    }
}
