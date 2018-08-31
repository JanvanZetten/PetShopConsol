﻿using System;
using System.Collections.Generic;
using EASV.PetShopConsol.Core.Application;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Menu
{
    public class petCRUD
    {
        private IPetService _PetService;
        public petCRUD(IPetService petService)
        {
            _PetService = petService;
        }

        internal void GetCheapest(int amount)
        {
            List<Pet> pets = _PetService.GetCheapestPets(amount);

            printPetList(pets);
        }

        private void printPetList(List<Pet> pets)
        {
            foreach (var pet in pets)
            {
                printPet(pet);
            }
        }

        internal void GetPetsByPrice()
        {
            List<Pet> pets = _PetService.GetAllPetsSortedByPrice();

            printPetList(pets);
        }

        internal void EditPet()
        {
            ListPets();
            Console.WriteLine("--------------------------------/n");
            Console.WriteLine("Which pet do you want to Edit? enter the pets id:");
            var idForEditing = ReadInt();
            var petForEditing = _PetService.GetPetById(idForEditing);

            Console.WriteLine("type y and press enter if you want to edit the name:");
            if (Console.ReadLine().ToLower().Equals("y"))
            {
                Console.WriteLine("Whats the new name:");
                petForEditing.Name = Console.ReadLine();
            }
            Console.WriteLine("type y and press enter if you want to edit the type:");
            if (Console.ReadLine().ToLower().Equals("y"))
            {
                Console.WriteLine("Whats the new name:");
                petForEditing.Type = chossePetType();
            }
            Console.WriteLine("type y and press enter if you want to edit the birthdate:");
            if (Console.ReadLine().ToLower().Equals("y"))
            {
                Console.WriteLine("Whats the new birth year:");
                var year = ReadInt();
                Console.WriteLine("Whats the new birth month:");
                var month = ReadInt(1, 12);
                Console.WriteLine("Whats the new birth day:");
                var day = ReadInt(1, DateTime.DaysInMonth(year, month));

                petForEditing.Birthday = new DateTime(year, month, day);
            }
            Console.WriteLine("type y and press enter if you want to edit the color:");
            if (Console.ReadLine().ToLower().Equals("y"))
            {
                Console.WriteLine("Whats the new color:");
                petForEditing.Color = Console.ReadLine();
            }
            Console.WriteLine("type y and press enter if you want to edit the previous owner:");
            if (Console.ReadLine().ToLower().Equals("y"))
            {
                Console.WriteLine("Whats the new previous owner:");
                petForEditing.PreviousOwner = Console.ReadLine();
            }
            Console.WriteLine("type y and press enter if you want to edit the price:");
            if (Console.ReadLine().ToLower().Equals("y"))
            {
                Console.WriteLine("Whats the new price:");
                petForEditing.Price = ReadDouble();
            }
            _PetService.EditPet(petForEditing);
        }

        internal void DeletePet()
        {
            ListPets();
            Console.WriteLine("--------------------------------/n");
            Console.WriteLine("Which pet do you want to delete? enter the pets id:");
            var idForDeleting = ReadInt();
            _PetService.DeletePetById(idForDeleting);
        }

        internal void PrintPetsByType()
        {
            Console.WriteLine("Which type of pet do you want?");
            var petType = chossePetType();
            var petsWithType = _PetService.GetPetsWithType(petType);

            foreach (var pet in petsWithType)
            {
                printPet(pet);
            }
        }

        internal void ListPets()
        {
            List<Pet> pets = _PetService.GetAllPets();

            printPetList(pets);
        }

        private void printPet(Pet pet)
        {
            Console.WriteLine($"Id: {pet.Id}, " +
                              $"Name: {pet.Name}, " +
                              $"type {Enum.GetName(typeof(AnimalType), pet.Type)}, " +
                              $"Birthday: {pet.Birthday.ToShortDateString()}, " +
                              $"Age: {new DateTime((DateTime.Now - pet.Birthday).Ticks).Year - 1}, " +
                              $"Color: {pet.Color}, " +
                              $"Previous owner: {pet.PreviousOwner}, " +
                              $"Price: {pet.Price}");
        }

        internal void AddPet()
        {
            Console.WriteLine("The Name of the Pet?");
            var name = Console.ReadLine();

            Console.WriteLine("What type of pet is it?");
            var type = chossePetType();

            Console.WriteLine("What is the pets birth year?");
            var birthyear = ReadInt();

            Console.WriteLine("What is the pets birth month?");
            var birthmonth = ReadInt(1, 12);

            Console.WriteLine("What is the pets birth day?");
            int birthday = ReadInt(1, DateTime.DaysInMonth(birthyear, birthmonth));

            Console.WriteLine("What color is the pet?");
            var color = Console.ReadLine();

            Console.WriteLine("Who was the previous owner?");
            var previousOwner = Console.ReadLine();

            Console.WriteLine("What is the price of the pet?");
            var price = ReadDouble();

            var pet = _PetService.MakeNewPet(name, type, birthyear, birthmonth, birthday, color, previousOwner, price);
            _PetService.SavePet(pet);

        }

        private double ReadDouble()
        {
            double num;
            string input;
            input = Console.ReadLine();
            while (!double.TryParse(input, out num))
            {
                Console.WriteLine("It has to be a decimal number");
                input = Console.ReadLine();
            }
            return num;
        }

        private int ReadInt(int min, int max)
        {
            int num = 0;
            string input;
            input = Console.ReadLine();

            while (!(int.TryParse(input, out num)) || num < min || num > max)
            {
                Console.WriteLine($"It has to be a number between {min} and {max}");
                input = Console.ReadLine();
            }

            return num;
        }

        private int ReadInt()
        {
            int num;
            string input;
            input = Console.ReadLine();
            while (!int.TryParse(input, out num))
            {
                Console.WriteLine("It has to be a number");
                input = Console.ReadLine();
            }
            return num;
        }


        private AnimalType chossePetType()
        {
            var animalTypes = Enum.GetNames(typeof(AnimalType));
            int index;

            for (int i = 0; i < animalTypes.Length; i++)
            {
                Console.WriteLine($"{i + 1}- {animalTypes[i]}");
            }
            var input = Console.ReadLine();

            while (!int.TryParse(input, out index) && index < 1 && index > animalTypes.Length)
            {
                Console.WriteLine($"Chosse a number between 1 and {animalTypes.Length}");
                input = Console.ReadLine();
            }

            return (AnimalType)(index - 1);
        }
    }
}