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
        private readonly petCRUD _PetCrud;
        public Menu(IPetService petService)
        {
            _PetService = petService;
            _PetCrud = new petCRUD(petService);
            PrintMainMenu();
        }

        private void PrintMainMenu()
        {
            var running = true;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Add a pet\n" +
                                  "2 - List All pets\n" +
                                  "3 - Pets by type\n" +
                                  "4 - Delete Pet\n" +
                                  "5 - Edit Pet\n" +
                                  "6 - Get Pets sorted by price\n" +
                                  "7 - Get five cheapest Pets\n" +
                                  "8 - Exit");

                int chossenMenuNum;

                do
                {
                    Console.WriteLine("Chosse a menu Item:");
                } while (int.TryParse(Console.ReadLine(), out chossenMenuNum) && chossenMenuNum < 1 && chossenMenuNum > Enum.GetNames(typeof(MenuItems)).Length);

                MenuItems chossenMenuItem = (MenuItems)(chossenMenuNum - 1);

                switch (chossenMenuItem)
                {
                    case MenuItems.AddPet:
                        _PetCrud.AddPet();
                        Console.WriteLine("Press enter to go back to menu...");
                        Console.ReadLine();
                        break;
                    case MenuItems.Exit:
                        running = false;
                        break;
                    case MenuItems.ListAllPets:
                        _PetCrud.ListPets();
                        Console.WriteLine("Press enter to go back to menu...");
                        Console.ReadLine();
                        break;
                    case MenuItems.PetsByType:
                        _PetCrud.PrintPetsByType();
                        Console.WriteLine("Press enter to go back to menu...");
                        Console.ReadLine();
                        break;
                    case MenuItems.DeletePet:
                        _PetCrud.DeletePet();
                        Console.WriteLine("Press enter to go back to menu...");
                        Console.ReadLine();
                        break;
                    case MenuItems.EditPet:
                        _PetCrud.EditPet();
                        Console.WriteLine("Press enter to go back to menu...");
                        Console.ReadLine();
                        break;
                    case MenuItems.GetPetsByPrice:
                        _PetCrud.GetPetsByPrice();
                        Console.WriteLine("Press enter to go back to menu...");
                        Console.ReadLine();
                        break;
                    case MenuItems.GetFiveCheapest:
                        _PetCrud.GetCheapest(5);
                        Console.WriteLine("Press enter to go back to menu...");
                        Console.ReadLine();
                        break;
                }

            } while (running);
        }
    }
}
