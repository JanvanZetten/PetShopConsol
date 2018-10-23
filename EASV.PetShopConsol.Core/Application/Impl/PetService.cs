using System;
using System.Collections.Generic;
using EASV.PetShopConsol.Core.Domain;
using EASV.PetShopConsol.Core.Entity;
using System.Linq;
using System.IO;

namespace EASV.PetShopConsol.Core.Application.Impl
{
    public class PetService: IPetService
    {
        private readonly IPetRepository _PetRepo;
        private readonly IOwnerService _OwnerService;
        public PetService(IPetRepository petRepository, IOwnerService ownerService)
        {
            _PetRepo = petRepository;
            _OwnerService = ownerService;
        }

        public void DeletePetById(int id)
        {
            var pet = GetPetById(id);
            if (pet == null){
                throw new ArgumentException("No pet with this id");
            }
            _PetRepo.DeletePet(pet);
        }

        public Pet GetPetById(int id)
        {
            var pet = _PetRepo.GetPetsWithOwner().First(petI => petI.Id == id);
            if (pet == null)
            {
                throw new ArgumentException("No pet with this id");
            }
            return pet;
        }

        public List<Pet> GetAllPets()
        {
            return _PetRepo.GetPets().ToList();
        }

        public List<Pet> GetPetsWithType(AnimalType petType)
        {
            return  _PetRepo.GetPetsWithOwner().Where(pet => pet.Type == petType).ToList();
        }

        public Pet MakeNewPet(string name, AnimalType type, int birthyear, int birthmonth, int birthday, List<PetColorRelation> colorRelation, Owner previousOwner, double price)
        {
            var birthDate = new DateTime(birthyear, birthmonth, birthday);

            return new Pet() { Name = name, Type = type, Birthday = birthDate, PetColors = colorRelation, PreviousOwner = previousOwner, Price = price };
        }

        public Pet SavePet(Pet pet)
        {
            if (pet.PreviousOwner != null)
            {
                if (_OwnerService.GetOwner(pet.PreviousOwner.Id) == null)
                {
                    throw new ArgumentException("There is no Owner with this id");
                }
            }

            return _PetRepo.SavePet(pet);
        }

        public void EditPet(Pet petForEditing)
        {
            _PetRepo.EditPet(petForEditing);
        }

        public List<Pet> GetAllPetsSortedByPrice()
        {
            return _PetRepo.GetPets()
                           .OrderBy(pet => pet.Price)
                           .ToList();
        }

        public List<Pet> GetCheapestPets(int amount)
        {
            return _PetRepo.GetPets()
                           .OrderBy(pet => pet.Price)
                           .Take(amount < _PetRepo.GetPets().Count() ? amount: _PetRepo.GetPets().Count())
                           .ToList();
        }

        public List<Pet> GetAllPetsPaged(int page, int itemsPrPage)
        {
            if (page <= 0 || itemsPrPage <= 0 )
                throw new InvalidDataException("CurrentPage and ItemsPage Must zero or more");
            if (page -1 * itemsPrPage > _PetRepo.CountPets())
                throw new InvalidDataException("Index out bounds, CurrentPage is to high");

            return _PetRepo.GetPets()
                           .Skip((page - 1) * itemsPrPage)
                           .Take(itemsPrPage)
                           .ToList();

        }

    }
}
