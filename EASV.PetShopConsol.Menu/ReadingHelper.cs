using System;
using EASV.PetShopConsol.Core.Entity;

namespace EASV.PetShopConsol.Menu
{
    public class ReadingHelper
    {

        internal double ReadDouble()
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

        internal int ReadInt(int min, int max)
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

        internal int ReadInt()
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


        internal AnimalType chossePetType()
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
