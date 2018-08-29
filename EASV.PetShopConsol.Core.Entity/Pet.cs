using System;
namespace EASV.PetShopConsol.Core.Entity
{
    public class Pet
    {
        public int Id { get; }
        public string Name { get; set; }
        public AnimalType Type { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public string PreviousOwner { get; set; }
        public double Price { get; set; }

        public Pet(int Id)
        {
            this.Id = Id;
        }

    }
}
