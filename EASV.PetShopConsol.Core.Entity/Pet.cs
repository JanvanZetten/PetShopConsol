using System;
using System.Collections.Generic;

namespace EASV.PetShopConsol.Core.Entity
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AnimalType Type { get; set; }
        public DateTime Birthday { get; set; }
        public string Color { get; set; } // THIS COLOR should be deleted when the petColors is fully implemented
        public List<PetColor> PetColors { get; set; }
        public Owner PreviousOwner { get; set; }
        public double Price { get; set; }
    }
}
