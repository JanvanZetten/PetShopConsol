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

        public List<PetColorRelation> PetColors { get; set; }
        public Owner PreviousOwner { get; set; }
        public double Price { get; set; }
    }
}
