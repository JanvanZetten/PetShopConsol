﻿using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Infrastructure
{
    public class PetMockDB
    {
        private static IEnumerable<Pet> pets = new List<Pet>();
        private static int nextId = 1;

        public PetMockDB()
        {
            if (!pets.Any())
            {
                InsertIntoPets(new Pet()
                {
                    Name = "Hans",
                    Birthday = new DateTime(2017, 10, 3),
                    Type = AnimalType.Bird,
                    Color = "Neon green",
                    PreviousOwner = new Owner(){Id = 1},
                    Price = 2000000.00
                });
                InsertIntoPets(new Pet()
                {
                    Name = "TrumpDog",
                    Birthday = new DateTime(2016, 2, 29),
                    Type = AnimalType.Dog,
                    Color = "Yellow",
                    PreviousOwner = new Owner() { Id = 2 },
                    Price = 900000.00
                });
                InsertIntoPets(new Pet()
                {
                    Name = "Ole",
                    Birthday = new DateTime(2018, 4, 12),
                    Type = AnimalType.Dog,
                    Color = "Brown",
                    PreviousOwner = new Owner() { Id = 3 },
                    Price = 1000.00
                });
                InsertIntoPets(new Pet()
                {
                    Name = "Snaky",
                    Birthday = new DateTime(1030, 6, 3),
                    Type = AnimalType.Snake,
                    Color = "Green, brown and black",
                    PreviousOwner = new Owner() { Id = 1 },
                    Price = 1.00
                });
            }
        }

        internal void UpdatePet(Pet newPet)
        {
            pets = pets.Select(pet => pet.Id == newPet.Id ? newPet : pet).ToList();
        }

        internal void DeletePet(Pet pet)
        {
            pets = pets.Where(petFromList => !petFromList.Equals(pet));
        }

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
