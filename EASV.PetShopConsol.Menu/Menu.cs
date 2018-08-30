using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using EASV.PetShopConsol.Core.Application;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Menu
{
    public class Menu
    {
        private readonly IPetService _PetService;
        public Menu(IPetService petService)
        {
            _PetService = petService;
            PrintMainMenu();
        }

        private void PrintMainMenu()
        {
            var running = true;
            do
            {

                Console.WriteLine("1 - Add a pet\n" +
                                  "2 - List All pets\n" +
                                  "3 - Exit");
                int chossenMenuNum;


                do
                {
                    Console.WriteLine("Chosse a menu Item:");
                } while (int.TryParse(Console.ReadLine(), out chossenMenuNum) && chossenMenuNum < 1 && chossenMenuNum > Enum.GetNames(typeof(MenuItems)).Length);

                MenuItems chossenMenuItem = (MenuItems)(chossenMenuNum - 1);

                switch (chossenMenuItem)
                {
                    case MenuItems.AddPet:
                        AddPet();
                        break;
                    case MenuItems.Exit:
                        running = false;
                        break;
                    case MenuItems.ListAllPets:
                        ListPets();
                        break;
                }

            } while (running);


        }

        private void ListPets()
        {
            List<Pet> pets = _PetService.GetAllPets();

            foreach (var pet in pets)
            {
                printPet(pet);
            }

            Console.WriteLine("Press enter to go back to menu...");
            Console.ReadLine();
        }

        private void printPet(Pet pet)
        {
            Console.WriteLine($"Id: {pet.Id}, " +
                              $"Name: {pet.Name}, " +
                              $"type {Enum.GetName(typeof(AnimalType), pet.Type)}, " +
                              $"Birthday: {pet.Birthday.ToShortDateString()}, " +
                              $"Color: {pet.Color}, " +
                              $"Previous owner: {pet.PreviousOwner}" +
                              $"Price: {pet.Price}");
        }

        private void AddPet()
        {
            Console.WriteLine("The Name of the Pet?");
            var name = Console.ReadLine();

            Console.WriteLine("What type of pet is it?");
            var type = chossePetType();

            Console.WriteLine("What is the pets birth year?");
            var birthyear = ReadInt();

            Console.WriteLine("What is the pets birth month?");
            var birthmonth = ReadInt(1,12);

            Console.WriteLine("What is the pets birth day?");
            var birthday = ReadInt(1,31);

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
            int num;
            string input;
            input = Console.ReadLine();
            while (!int.TryParse(input, out num) && num < min && num > max)
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
                Console.WriteLine("It has to a number");
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
                Console.WriteLine($"{i+1}- {animalTypes[i]}");
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
